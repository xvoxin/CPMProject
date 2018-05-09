using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMForms
{
    public class ActivityRect
    {
        public int Height => 20;
        public int Width => 40 * Duration;
        public int Duration { get; set; }
        public string Name { get; set; }
        public int StartTime { get; set; }
        public int Line { get; set; }

        public ActivityRect(int duration, string name, int startTime)
        {
            Duration = duration;
            Name = name;
            StartTime = startTime;
            Line = 0;
        }
    }
}
