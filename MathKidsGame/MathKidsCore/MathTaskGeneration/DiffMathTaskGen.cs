using MathKidsCore.Model;
using System;

namespace MathKidsCore.MathTaskGeneration
{
    public class DiffMathTaskGen : BasicMathTaskGen
    {
        public DiffMathTaskGen(Random r, int maxResult) : base(r, "-", maxResult) { }

        protected override void GenerateNumbers(out int a, out int b)
        {
            a = _random.Next(0, _maxResult);
            b = _random.Next(0, a);
        }

        protected override int GetResult(int a, int b) => a - b;
    }
}
