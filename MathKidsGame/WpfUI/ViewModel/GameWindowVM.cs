using MathKidsCore;
using Prism.Commands;
using Prism.Mvvm;
using System.Media;
using System.Threading.Tasks;

namespace WpfUI.ViewModel
{
    public class GameWindowVM : BindableBase
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
        public string Answer { get; private set; }
        public string AnswerColor { get; private set; }
        public bool Stop { get; set; }

        public GameWindowVM()
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
            _gameController.OnTimeForMathTaskUp += (o, e) => CheckResult(solvedCorrect: false, timeIsUp: true);
        }

        private void NextRound()
        {
            Answer = string.Empty;
            Description = _gameController.GenerateMathTaskAndGetDescription();
            ButtonsEnabled = true;

            RaisePropertyChanged(nameof(Description));
            RaisePropertyChanged(nameof(BestScore));
            RaisePropertyChanged(nameof(CurrentScore));
            RaisePropertyChanged(nameof(ButtonsEnabled));
            RaisePropertyChanged(nameof(Answer));
        }

        private void CheckResult(bool solvedCorrect, bool timeIsUp = false)
        {
            if(timeIsUp == false)
            {
                Answer = solvedCorrect ? "Правильно!" : "Ошибка!";
                AnswerColor = solvedCorrect ? "Green" : "Red";
            }
            else
            {
                Answer = "Время истекло!";
                AnswerColor = "Red";
            }

            ButtonsEnabled = false;

            RaisePropertyChanged(nameof(ButtonsEnabled));
            RaisePropertyChanged(nameof(Answer));
            RaisePropertyChanged(nameof(AnswerColor));

            if (!Stop)
            {
                _myPlayer.Stream = solvedCorrect ? Properties.Resources.Correct : Properties.Resources.Wrong3;
                _myPlayer.Play();

                Task.Delay(500)
                    .ContinueWith(t => NextRound());
            }
        }
    }
}
