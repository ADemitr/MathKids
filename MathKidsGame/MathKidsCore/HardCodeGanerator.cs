using MathKidsCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathKidsCore
{
    public class HardCodeGanerator : IMathTaskGenerator
    {
        public MathTask Next()
        {
            var mathTask = _tasks[_currentTask];

            _currentTask = _currentTask >= _tasks.Count - 1 ? 0 : _currentTask + 1;

            return mathTask;
        }

        private int _currentTask = 0;
        private List<MathTask> _tasks = new List<MathTask>
        {
            new MathTask ( "1 + 2 + 3 + 4 + 5 = 16", false ),
            new MathTask ( "5 * 5  + 1 * 1 - 1 = 26", false ),
            new MathTask ( "1 * 2 * 3 * 4 = 24", true ),
            new MathTask ( "2 + 2 * 2 = 8", false ),
            new MathTask ( "7 * 7 = 47", false ),
            new MathTask ( "11 * 11 = 121", true )

        };
    }
}
