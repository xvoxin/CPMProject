using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMForms
{
    public class Activity
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public int[] Predecessor { get; set; }
        public int EarliestStartTime { get; set; }
        public string Name { get; set; }

        public Activity(int id, int duration, int[] predecessor)
        {
            Id = id;
            Duration = duration;
            Predecessor = predecessor;
        }
    }
}
