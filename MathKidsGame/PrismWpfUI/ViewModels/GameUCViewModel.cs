using MathKidsCore;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismWpfUI.Core;
using PrismWpfUI.Views;
using System.Media;
using System.Threading.Tasks;

namespace PrismWpfUI.ViewModels
{
    public class GameUCViewModel : BindableBase, INavigationAware
    {
        private IApplicationCommands _applicationCommands;
        private GameController _gameController;
        private SoundPlayer _myPlayer = new SoundPlayer();

        public GameUCViewModel(IApplicationCommands applicationCommands, GameController gameController)
        {
            _applicationCommands = applicationCommands;
            _gameController = gameController;

            _gameController.OnCountDown += (o, progress) => TimeProgress = progress;
            _gameController.OnTimeForMathTaskUp += (o, e) => CheckResult(solvedCorrect: false, timeIsUp: true);
        }

        #region SayNo
        private DelegateCommand _sayNo;
        public DelegateCommand SayNo =>
            _sayNo ?? (_sayNo = new DelegateCommand(ExecuteSayNo));

        void ExecuteSayNo() => CheckResult(_gameController.CheckAnswerAndCancelCountDown(false));
        #endregion

        #region SayYes
        private DelegateCommand _sayYes;
        public DelegateCommand SayYes =>
            _sayYes ?? (_sayYes = new DelegateCommand(ExecuteSayYes));

        void ExecuteSayYes() => CheckResult(_gameController.CheckAnswerAndCancelCountDown(true));
        #endregion

        #region BackCommand
        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand =>
            _backCommand ?? (_backCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {
            _gameController.Stop();
            _applicationCommands.Naviagte.Execute(typeof(MainMenu).Name);
        }
        #endregion

        #region ButtonsEnabled
        private bool _buttonsEnables;
        public bool ButtonsEnabled
        {
            get { return _buttonsEnables; }
            set { SetProperty(ref _buttonsEnables, value); }
        }
        #endregion

        #region Description
        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        #endregion

        #region IsAnswerCorrect
        private MathTaskResult _isAnswerCorrect;
        public MathTaskResult IsAnswerCorrect
        {
            get { return _isAnswerCorrect; }
            set { SetProperty(ref _isAnswerCorrect, value); }
        }
        #endregion

        #region BestScore
        private int _bestScore;
        public int BestScore
        {
            get { return _bestScore; }
            set { SetProperty(ref _bestScore, value); }
        }
        #endregion CurrentScore

        #region CurrentScore
        private int _currentScore;
        public int CurrentScore
        {
            get { return _currentScore; }
            set { SetProperty(ref _currentScore, value); }
        }

        #endregion

        #region TimeProgress
        private int _timeProgress;
        public int TimeProgress
        {
            get { return _timeProgress; }
            set { SetProperty(ref _timeProgress, value); }
        }
        #endregion

        private void NextRound()
        {
            IsAnswerCorrect = MathTaskResult.Undefined;
            Description = _gameController.GenerateMathTaskAndGetDescription();
            ButtonsEnabled = true;

            BestScore = _gameController.MaxInARow;
            CurrentScore = _gameController.CurrentInARow;
        }

        private void CheckResult(bool solvedCorrect, bool timeIsUp = false)
        {
            if (timeIsUp)
            {
                IsAnswerCorrect = MathTaskResult.TimeIsUp;
            }
            else
            {
                IsAnswerCorrect = solvedCorrect ? MathTaskResult.Correct : MathTaskResult.Incorrect;
            }

            ButtonsEnabled = false;

            if (_gameController.IsRunning)
            {
                _myPlayer.Stream = solvedCorrect ? Properties.Resources.Correct : Properties.Resources.Wrong3;
                _myPlayer.Play();

                Task.Delay(500)
                    .ContinueWith(t => NextRound());
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _gameController.Restart();
            NextRound();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext) { }
    }
}
