using System;
using System.Collections.Generic;

namespace MathKidsCore.Model
{
    public class GameSettingsModel
    {
        public TimeSpan TimeForMathTask { get; set; }
        public int MaxResult { get; set; }
        public GameDificulty Dificulty { get; set; }
        public IEnumerable<MathOperations> Operations { get; set; } = new List<MathOperations>() { MathOperations.Add};
    }
}
