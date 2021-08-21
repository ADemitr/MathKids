using MathKidsCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathKidsCore.MathTaskGeneration
{
    public class MathTaskGeneratorFabric
    {
        public IMathTaskGenerator CreateGenerator(GameSettingsModel settings)
        {
            Random r = new Random();

            List<IMathTaskGenerator> operations = new List<IMathTaskGenerator>();

            if(settings.Operations.Contains(MathOperations.Add))
            {
                operations.Add(new SumMathTaskGen(r, 100));
            }
            if (settings.Operations.Contains(MathOperations.Diff))
            {
                operations.Add(new DiffMathTaskGen(r, 100));
            }
            if (settings.Operations.Contains(MathOperations.Multiply))
            {
                operations.Add(new MultiplyMathTaskGenerator(r, 170)); 
            }

            IMathTaskGenerator mathTaskCombinator = new MathTaskCombinator(r, operations.ToArray());

            return mathTaskCombinator;
        }
    }
}
