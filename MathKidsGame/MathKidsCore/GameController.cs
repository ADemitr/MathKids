using MathKidsCore.MathTaskGeneration;
using MathKidsCore.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MathKidsCore
{
    public class GameController
    {
        public EventHandler<int> OnCountDown;
        public EventHandler OnTimeForMathTaskUp;

        private IMathTaskGenerator _mathTaskGenerator = new TwoNumbersSumMathTaskGen(new Random(), 0, 50);
        private MathTask _correntMathTask;
        private TimeSpan _timeForMathTask = TimeSpan.FromSeconds(2.5);
        private CancellationTokenSource _ctsForTime;

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
            return _correntMathTask.IsCorrectAnswer == userAnswer;
        }

        private async void CountDown(TimeSpan span, CancellationTokenSource cts)
        {
            int progress = 0;
            int parts = 10;
            TimeSpan dt = span / parts;

            for (int i = 0; i < parts; i++)
            {
                progress += 100 / parts;
                await Task.Delay(dt);
                if (cts.IsCancellationRequested == false)
                {
                    OnCountDown?.Invoke(this, progress);
                }
            }

            if(cts.IsCancellationRequested == false)
            {
                OnTimeForMathTaskUp?.Invoke(this, null);
            }
        }
    }
}
