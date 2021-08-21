using MathKidsCore.MathTaskGeneration;
using MathKidsCore.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MathKidsCore
{
    public class GameController
    {
        public int MaxInARow { get; private set; } = 0;
        public int CurrentInARow { get; private set; } = 0;

        public EventHandler<int> OnCountDown;
        public EventHandler OnTimeForMathTaskUp;

        private IMathTaskGenerator _mathTaskGenerator;
        private MathTask _correntMathTask;
        private TimeSpan _timeForMathTask = TimeSpan.FromSeconds(4);
        private CancellationTokenSource _ctsForTime;
        private GameSettingsModel _gameSettingsModel;

        public GameController(GameSettingsModel gameSettingsModel)
        {
            _gameSettingsModel = gameSettingsModel;

            MaxInARow = _gameSettingsModel.MaxResult;

            var mathTaskGeneratorFabric = new MathTaskGeneratorFabric();
            _mathTaskGenerator = mathTaskGeneratorFabric.CreateGenerator(_gameSettingsModel);
        }

        public string GenerateMathTaskAndGetDescription()
        {
            _correntMathTask = _mathTaskGenerator.Next();

            _ctsForTime = new CancellationTokenSource();
            Task.Run(() => CountDown(_timeForMathTask, _ctsForTime));

            return _correntMathTask.Description;
        }

        public bool CheckAnswerAndCancelCountDown(bool userAnswer)
        {
            _ctsForTime?.Cancel();

            bool isRightAnswer = _correntMathTask.IsCorrectAnswer == userAnswer;

            CurrentInARow = isRightAnswer ? CurrentInARow + 1 : 0;
            MaxInARow = Math.Max(CurrentInARow, MaxInARow);
            _gameSettingsModel.MaxResult = MaxInARow;

            return isRightAnswer;
        }

        private async void CountDown(TimeSpan span, CancellationTokenSource cts)
        {
            int progress = 0;
            int parts = 10;
            int dt_msec = (int)span.TotalMilliseconds / parts;

            for (int i = 0; i < parts; i++)
            {
                progress += 100 / parts;
                await Task.Delay(dt_msec);
                if (cts.IsCancellationRequested == false)
                {
                    OnCountDown?.Invoke(this, progress);
                }
            }

            if(cts.IsCancellationRequested == false)
            {
                OnTimeForMathTaskUp?.Invoke(this, null);
                CurrentInARow = 0;
            }
        }
    }
}
