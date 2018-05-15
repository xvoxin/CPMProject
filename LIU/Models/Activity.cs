using System;
namespace LIU.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public int[] Successor { get; set; }
        public int[] Predecessor { get; set; }
        public int EarliestStartTime { get; set; }

        public string Name { get; set; }
    
        public Activity(int id, int duration, int startTime, int endTime, 
                        int[] successor, int[] predecessor)
        {
            Id = id;
            Duration = duration;
            StartTime = startTime;
            EndTime = endTime;
            Successor = successor;
            Predecessor = predecessor;
        }
    }
}
