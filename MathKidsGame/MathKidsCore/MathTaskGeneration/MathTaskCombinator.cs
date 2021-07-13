using MathKidsCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathKidsCore.MathTaskGeneration
{
    public class MathTaskCombinator : IMathTaskGenerator
    {
        private List<IMathTaskGenerator> _generators;
        private Random _random;

        public MathTaskCombinator(Random random, params IMathTaskGenerator[] gens)
        {
            if(gens == null || gens.Length == 0)
            {
                throw new ArgumentException("MathTaskCombinator must be initialized with at least one IMathTaskGenerator");
            }

            _random = random;
            _generators = gens.ToList();
        }

        public MathTask Next()
        {
            int r = _random.Next(0, _generators.Count);
            return _generators[r].Next();
        }
    }
}
