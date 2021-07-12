using MathKidsCore.Model;
using System;

namespace MathKidsCore.MathTaskGeneration
{
    public class TwoNumbersSumMathTaskGen : IMathTaskGenerator
    {
        private int _minNumber = 0;
        private int _maxNumber = 100;
        private Random _random = new Random();

        public TwoNumbersSumMathTaskGen(Random random) => _random = random;

        public TwoNumbersSumMathTaskGen(Random random, int minNumber = 0, int maxNumber = 100) : this(random)
        {
            _minNumber = minNumber;
            _maxNumber = maxNumber;
        }

        public MathTask Next()
        {
            int a = _random.Next(_minNumber, _maxNumber);
            int b = _random.Next(_minNumber, _maxNumber);
            int sum = a + b;

            bool shouldEquationBeCorrect = _random.NextDouble() < 0.5;

            if (shouldEquationBeCorrect == false)
            {
                int correction = 0;
                while (correction == 0)
                {
                    correction = _random.Next(-1, 1) + _random.Next(-1, 1) * 10;
                }
                sum += correction;
            }

            return new MathTask()
            {
                Description = $"{ a } + { b } = { sum }",
                IsCorrectAnswer = shouldEquationBeCorrect
            };
        }
    }
}
