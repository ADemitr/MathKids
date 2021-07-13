using MathKidsCore.Model;
using System;

namespace MathKidsCore.MathTaskGeneration
{
    public class TwoNumbersMinusMathTaskGen : IMathTaskGenerator
    {
        private int _minNumber = 0;
        private int _maxNumber = 100;
        private Random _random = new Random();

        public TwoNumbersMinusMathTaskGen(Random random) => _random = random;

        public TwoNumbersMinusMathTaskGen(Random random, int minNumber = 0, int maxNumber = 100) : this(random)
        {
            _minNumber = minNumber;
            _maxNumber = maxNumber;
        }

        public MathTask Next()
        {
            int num1 = _random.Next(_minNumber, _maxNumber);
            int num2 = _random.Next(_minNumber, _maxNumber);
            int a = Math.Max(num1, num2);
            int b = Math.Min(num1, num2);
            int result = a - b;

            bool shouldEquationBeCorrect = _random.NextDouble() < 0.5;

            if (shouldEquationBeCorrect == false)
            {
                int correction = 0;
                while (correction == 0)
                {
                    correction = _random.Next(-1, 1) + _random.Next(-1, 1) * 10;
                }
                result += correction;
            }

            return new MathTask()
            {
                Description = $"{ a } - { b } = { result }",
                CorrectAnswer = shouldEquationBeCorrect
            };
        }
    }
}
