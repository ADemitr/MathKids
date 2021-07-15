using MathKidsCore.Model;
using System;

namespace MathKidsCore.MathTaskGeneration
{
    public class MultiplyMathTaskGenerator : BasicMathTaskGen
    {
        private int _maxNum;

        public MultiplyMathTaskGenerator(Random r, int maxResult) : base(r, "*", maxResult)
        {
            _maxNum = (int)Math.Sqrt(Math.Abs(maxResult));
        }

        protected override void GenerateNumbers(out int a, out int b)
        {
            a = _random.Next(0, _maxNum);
            b = _random.Next(0, _maxNum);
        }

        protected override int GetResult(int a, int b) => a * b;
    }
}

