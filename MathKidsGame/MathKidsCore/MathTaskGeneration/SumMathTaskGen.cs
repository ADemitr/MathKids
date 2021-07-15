using MathKidsCore.Model;
using System;

namespace MathKidsCore.MathTaskGeneration
{
    public class SumMathTaskGen : BasicMathTaskGen
    {
        public SumMathTaskGen(Random r, int maxResult) : base(r, "+", maxResult) { }

        protected override void GenerateNumbers(out int a, out int b)
        {
            a = _random.Next(0, _maxResult);
            b = _random.Next(0, _maxResult - a);
            RandomlyExchange(ref a, ref b);
        }

        protected override int GetResult(int a, int b) => a + b;
    }
}
