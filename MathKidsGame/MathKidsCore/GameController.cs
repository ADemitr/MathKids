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
            Restart();
        }

        public string GenerateMathTaskAndGetDescription()
        {
            _correntMathTask = _mathTaskGenerator.Next();

            _ctsForTime = new CancellationTokenSource();
            Task.Run(() => CountDown(_timeForMathTask, _ctsForTime.Token));

            return _correntMathTask.Description;
        }

        public bool CheckAnswerAndCancelCountDown(bool userAnswer)
        {
            _ctsForTime?.Cancel();

            bool isRightAnswer = _correntMathTask.IsCorrectAnswer == userAnswer;

            CurrentInARow = isRightAnswer ? CurrentInARow + 1 : 0;
            MaxInARow = Math.Max(CurrentInARow, MaxInARow);
            _gameSettingsModel.MaxResult = MaxInARow;
            GameSettingsModel.Save(_gameSettingsModel);

            return isRightAnswer;
        }

        public void Stop() => _ctsForTime?.Cancel();

        private async Task CountDown(TimeSpan span, CancellationToken ct)
        {
            int progress = 0;
            int parts = 10;
            int dt_msec = (int)span.TotalMilliseconds / parts;

            for (int i = 0; i < parts; i++)
            {
                progress += 100 / parts;
                await Task.Delay(dt_msec);
                ct.ThrowIfCancellationRequested();
                OnCountDown?.Invoke(this, progress);
            }

            ct.ThrowIfCancellationRequested();

            OnTimeForMathTaskUp?.Invoke(this, null);
            CurrentInARow = 0;
        }

        public void Restart()
        {
            var mathTaskGeneratorFabric = new MathTaskGeneratorFabric();
            _mathTaskGenerator = mathTaskGeneratorFabric.CreateGenerator(_gameSettingsModel);
            MaxInARow = _gameSettingsModel.MaxResult;
            CurrentInARow = 0;
        }
    }
}
