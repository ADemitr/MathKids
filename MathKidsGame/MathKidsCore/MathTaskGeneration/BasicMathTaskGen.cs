using MathKidsCore.Model;
using System;

namespace MathKidsCore.MathTaskGeneration
{
    public abstract class BasicMathTaskGen : IMathTaskGenerator
    {
        protected readonly int _maxResult;
        protected readonly Random _random;
        private string _operation;

        public BasicMathTaskGen(Random random, string operation, int maxResult)
        {
            _random = random;
            _operation = operation;
            _maxResult = maxResult;
        }

        public MathTask Next()
        {
            GenerateNumbers(out int a, out int b);
            RandomlyExchange(ref a, ref b);
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

        protected abstract void GenerateNumbers(out int a, out int b);
        protected abstract int GetResult(int a, int b);

        private string GetMathTaskDescription(int a, int b, int result)
            => $"{ a } { _operation } { b } = { result }";

        private bool GenerateRandomCorrectness() => _random.NextDouble() < 0.5;

        private void RandomlyExchange(ref int a, ref int b)
        {
            if (_random.NextDouble() < 0.5)
            {
                int temp = a;
                a = b;
                b = temp;
            }
        }
    }
}
