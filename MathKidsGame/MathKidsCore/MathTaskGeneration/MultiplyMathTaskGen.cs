using MathKidsCore.Model;
using System;

namespace MathKidsCore.MathTaskGeneration
{
    public class MultiplyMathTaskGenerator : IMathTaskGenerator
    {
        private int _minNumber = 0;
        private int _maxNumber = 100;
        private Random _random = new Random();

        public MultiplyMathTaskGenerator(Random random) => _random = random;

        public MultiplyMathTaskGenerator(Random random, int minNumber = 0, int maxNumber = 100) : this(random)
        {
            _minNumber = minNumber;
            _maxNumber = maxNumber;
        }

        public MathTask Next()
        {
            int topLimit = (int)Math.Sqrt(_maxNumber);

            int a = _random.Next(_minNumber, topLimit);
            int b = _random.Next(_minNumber, topLimit);
            int product = a * b;

            bool shouldEquationBeCorrect = _random.NextDouble() < 0.5;

            if (shouldEquationBeCorrect == false)
            {
                int correction = 0;
                while (correction == 0)
                {
                    correction = _random.Next(-1, 1) * a + _random.Next(-1, 1) * b + _random.Next(-1, 1) * 10;
                }
                product += correction;
            }

            return new MathTask()
            {
                Description = $"{ a } * { b } = { product }",
                CorrectAnswer = shouldEquationBeCorrect
            };
        }
    }
}

