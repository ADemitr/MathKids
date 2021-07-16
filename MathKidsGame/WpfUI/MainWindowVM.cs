using MathKidsCore;
using Prism.Commands;
using Prism.Mvvm;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfUI
{
    public class MainWindowVM : BindableBase
    {
        private GameController _gameController;
        private SoundPlayer _myPlayer = new SoundPlayer();

        public string BestScore => $"Рекорд : { _gameController.MaxInARow }";
        public string CurrentScore => $"Счет : { _gameController.CurrentInARow }";
        public string Description { get; private set; }
        public int TimeProgress { get; private set; }
        public DelegateCommand SayYes { get; }
        public DelegateCommand SayNo { get; }
        public bool ButtonsEnabled { get; private set; }

        public MainWindowVM()
        {
            _gameController = new GameController();
            NextRound();
            SayYes = new DelegateCommand(() => CheckResult(_gameController.CheckAnswerAndCancelCountDown(true)));
            SayNo = new DelegateCommand(() => CheckResult(_gameController.CheckAnswerAndCancelCountDown(false)));
            _gameController.OnCountDown += (o, progress) =>
            {
                TimeProgress = progress;
                RaisePropertyChanged(nameof(TimeProgress));
            };
            _gameController.OnTimeForMathTaskUp += (o, e) => TimeIsUp();
        }

        private void NextRound()
        {
            Description = _gameController.GenerateMathTaskAndGetDescription();
            ButtonsEnabled = true;

            RaisePropertyChanged(nameof(Description));
            RaisePropertyChanged(nameof(BestScore));
            RaisePropertyChanged(nameof(CurrentScore));
            RaisePropertyChanged(nameof(ButtonsEnabled));
        }

        private void TimeIsUp()
        {
            CheckResult(false);
        }

        private void CheckResult(bool solvedCorrect)
        {
            ButtonsEnabled = false;
            RaisePropertyChanged(nameof(ButtonsEnabled));

            Task.Delay(250)
                .ContinueWith(t => NextRound());
        }
    }
}
