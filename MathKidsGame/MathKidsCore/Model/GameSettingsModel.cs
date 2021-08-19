using System;
using System.Collections.Generic;
using System.Text;

namespace MathKidsCore.Model
{
    public class GameSettingsModel
    {
        public TimeSpan TimeForMathTask { get; set; }
        public int MaxResult { get; set; }
        public GameDificulty Dificulty { get; set; }
    }
}
