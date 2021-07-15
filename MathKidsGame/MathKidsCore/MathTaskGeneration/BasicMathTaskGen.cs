using MathKidsCore.Model;
using System;

namespace MathKidsCore.MathTaskGeneration
{
    public abstract class BasicMathTaskGen : IMathTaskGenerator
    {
        protected readonly Random _random;
        private string _operation;

        public BasicMathTaskGen(Random random, string operation)
        {
            _random = random;
            _operation = operation;
        }

        public MathTask Next()
        {
            int a = GenerateNumber();
            int b = GenerateNumber();
            int result = GetResult(a, b);

            bool isCorrectEquation = GenerateRandomCorrectness();
            if (isCorrectEquation == false)
            {
                result += GenerateNonZeroCorrection();
            }

            string mathTaskDescription = GetMathTaskDescription(a, b, result);
            return new MathTask(mathTaskDescription, isCorrectEquation);
        }

        private int GenerateNonZeroCorrection()
        {
            int correction = 0;

            int countTriesToGenerateNonZeroCorrection = 10;
            for (int i = 0; i < countTriesToGenerateNonZeroCorrection; i++)
            {
                correction = GenerateCorrection();
                if (correction != 0)
                {
                    break;
                }
            }

            if (correction == 0)
            {
                correction = -1;
            }

            return correction;
        }

        protected virtual int GenerateCorrection()
            => _random.Next(-1, 1) + _random.Next(-1, 1) * 10;

        protected abstract int GenerateNumber();
        protected abstract int GetResult(int a, int b);

        private string GetMathTaskDescription(int a, int b, int result)
            => $"a { _operation } b = { result }";

        private bool GenerateRandomCorrectness() => _random.NextDouble() < 0.5;

    }
}
