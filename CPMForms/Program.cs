using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPMForms
{
    class Program
    {
        public List<Activity> Activites;
        public Program()
        {
            SetActivites();
            SetTime();
            WriteAll();
        }

        private void SetActivites()
        {
            Activites = new List<Activity>
            {
                new Activity(1, 3, new int[]{ }),
                new Activity(2, 8, new int[]{ }),
                new Activity(3, 2, new int[]{ }),
                new Activity(4, 2, new int[]{ 1 }),
                new Activity(5, 4, new int[]{ 1 }),
                new Activity(6, 6, new int[]{ 3 }),
                new Activity(7, 9, new int[]{ 3 }),
                new Activity(8, 2, new int[]{ 4 }),
                new Activity(9, 1, new int[]{ 2, 5, 6 }),
                new Activity(10, 2, new int[]{ 2, 5, 6 }),
                new Activity(11, 1, new int[]{ 7 }),
                new Activity(12, 2, new int[]{ 7 }),
                new Activity(13, 6, new int[]{ 8, 9 }),
                new Activity(14, 5, new int[]{ 10, 11 }),
                new Activity(15, 9, new int[]{ 10, 11 }),
                new Activity(16, 6, new int[]{ 10, 11 }),
                new Activity(17, 2, new int[]{ 12 }),
                new Activity(18, 5, new int[]{ 13, 14 }),
                new Activity(19, 3, new int[]{ 16, 17 }),
                //new Activity(20, 3, new int[]{ 5, 21 }),
            };
            CheckValues();
        }

        private void SetTime()
        {
            foreach (var act in Activites)
            {
                if (act.Predecessor.Length == 0)
                {
                    act.EarliestStartTime = 0;
                    continue;
                }
                var predecessor = act.Predecessor;
                var earliestStartTime = 0;
                for (int i = 0; i < predecessor.Length; i++)
                {
                    var activity = Activites.Where(actv => actv.Id == predecessor[i]).FirstOrDefault();
                    var previousEarliestStartTime = activity.EarliestStartTime + activity.Duration;
                    if (earliestStartTime < previousEarliestStartTime)
                        earliestStartTime = previousEarliestStartTime;
                }
                act.EarliestStartTime = earliestStartTime;
            }
        }

        private void WriteAll()
        {
            var biggestEstId = 0;
            var biggestEst = 0;
            foreach (var act in Activites)
            {
                act.Name = "Z" + act.Id;
                Console.WriteLine(act.Name + " - " + act.EarliestStartTime);
                if (biggestEst < act.EarliestStartTime + act.Duration)
                {
                    biggestEst = act.EarliestStartTime + act.Duration;
                    biggestEstId = act.Id;
                }
            }
            Console.WriteLine("CMP max value - Z{0}: {1}", biggestEstId, biggestEst);
        }

        public List<ActivityRect> DrawHarmonogram()
        {
            var activities = new List<ActivityRect>();
            foreach (var act in Activites)
            {
                activities.Add(new ActivityRect(act.Duration, act.Name, act.EarliestStartTime));
            }

            for (int i = 0; i < activities.Count; i++)
            {
                var line = 1;
                bool search = true;
                while (search)
                {
                    var activity = activities.Where(actv => actv.Line == line).ToList();
                    if (activity.Count == 0)
                        search = false;

                    var counter = 0;
                    foreach (var act in activity)
                    {
                        if (activities[i].StartTime < (act.StartTime + act.Duration))
                        {
                            line++;
                            break;
                        }
                        counter++;
                    }
                    if (counter == activity.Count)
                        search = false;
                }
                activities[i].Line = line; 
            }
            return activities;
        }
        private void CheckValues()
        {
            foreach (var act in Activites)
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
