using System;
using System.Collections.Generic;
using LIU.Models;

namespace LIU
{
    class Program
    {
        public List<Activity> Activities;

        public Program()
        {
            SetActivities();
            MinimumEndTime(Activities.Count);
        }

        private void SetActivities()
        {
            Activities = new List<Activity>
            {
                new Activity(1, 3, 0, 4, new int[]{ 3 }, new int[]{ }),
                new Activity(2, 2, 4, 6, new int[]{ 4 }, new int[]{ }),
                new Activity(3, 2, 2, 8, new int[]{ 5 }, new int[]{ 1 }),
                new Activity(4, 1, 5, 15, new int[]{ 5 , 6 }, new int[]{ 2 }),
                new Activity(5, 4, 6, 10, new int[]{ 7 }, new int[]{ 3, 4 }),
                new Activity(6, 1, 15, 20, new int[]{ 7 }, new int[]{ 4 }),
                new Activity(7, 2, 13, 25, new int[]{}, new int[]{ 5, 6 })
            };
        }

        private int[] MinimumEndTime(int size)
        {
            var res = new int[size];
            foreach (var act in Activities)
            {
                int delay = act.EndTime;
                foreach (var id in act.Successor)
                {
                    var nextDelay = SearchMinEndTime(id);
                    if (delay > nextDelay)
                        delay = nextDelay;
                }
            }
            return res;
        }

        private int SearchMinEndTime(int id)
        {
            int delay = Activities[id - 1].EndTime;
            foreach (var Id in Activities[id - 1].Successor)
            {
                var nextDelay = Activities[Id - 1].EndTime;
                if (nextDelay < delay)
                    delay = nextDelay;
            }
        }

        private void CheckValues()
        {
            foreach (var act in Activities)
            {
                foreach (var id in act.Predecessor)
                {
                    if (id >= act.Id)
                        throw new Exception("GRAF ZAWIERA ZALEZNOSCI CYKLICZNE!");
                }
            }
        }
    }
}
