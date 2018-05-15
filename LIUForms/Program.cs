using System;
using System.Collections.Generic;
using LIU.Models;
using System.Linq;

namespace LIU
{
    class Program
    {
        public List<Activity> Activities;
        public Activity[] FixedActivities;
        public int[] MinEndTime;

        public Program()
        {
            SetActivities();
            foreach (var i in MinimumEndTime(Activities.Count))
                Console.Write(i + " ");
            Console.WriteLine("Optimized Time =  " + MinimizeMaxWorkTime());
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
            var i = 0;

            foreach (var act in Activities)
                res[i++] = SearchMinEndTime(i, size);

            MinEndTime = res;
            return res;
        }

        private int MaximumEndTime(int size)
        {
            var max = 0;
            foreach (var act in Activities)
            {
                if (act.EndTime > max)
                    max = act.EndTime;
            }
            return max;
        }

        private int SearchMinEndTime(int id, int size)
        {
            var queue = new List<int>() { id };
            var res = Int32.MaxValue;

            for (int i = id; i <= size; i++)
            {
                if (queue.Contains(i))
                {
                    foreach (var suc in Activities[i - 1].Successor)
                        queue.Add(suc);
                }
            }

            foreach(var value in queue)
            {
                var temp = Activities[value - 1].EndTime;
                if (temp < res)
                    res = temp;
            }
            return res;
        }

        private int MinimizeMaxWorkTime()
        {
            int[] positions = new int[64];
            var activeTasks = new List<Activity>();
            int time = 0;
            while(Activities.Where(a => a.IsFinished == false).FirstOrDefault() != null)
            {
                activeTasks = new List<Activity>();
                SetActiveTasks(activeTasks, time);
                var actWithSmallestFixedEndTime = GetActWithSmallestFixedEndTime(activeTasks);
                if (actWithSmallestFixedEndTime != null)
                {
                    positions[time] = actWithSmallestFixedEndTime.Id;
                    if (positions.Where(p => p == actWithSmallestFixedEndTime.Id).ToList().Count
                        == actWithSmallestFixedEndTime.Duration)
                    {
                        actWithSmallestFixedEndTime.IsFinished = true;
                    }
                }
                time++;
            }
            FixedActivities = new Activity[time];
            for (int i = 0; i < time; i++)
            {
                if (positions[i] != 0)
                    FixedActivities[i] = Activities[positions[i] - 1];
                else
                    FixedActivities[i] = null;
            }
            return time;
        }

        private Activity GetActWithSmallestFixedEndTime(List<Activity> activeTasks)
        {
            Activity res = null;
            foreach (var act in activeTasks)
            {
                if (res == null)
                    res = act;
                else
                    if (MinEndTime[res.Id - 1] > MinEndTime[act.Id - 1])
                        res = act;
            }
            return res;
        }

        private void SetActiveTasks(List<Activity> activeTask, int time)
        {
            foreach (var act in Activities)
                if (act.StartTime <= time)
                    if (!act.IsFinished)
                        if (IsActPredecessorsFinished(act.Predecessor))
                            activeTask.Add(act);
        }

        private bool IsActPredecessorsFinished(int[] pred)
        {
            foreach (var id in pred)
            {
                if (Activities[id - 1].IsFinished == false)
                    return false;
            }
            return true;
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
