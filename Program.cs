using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Bustroker.ParallelExceptions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Runner> runners = BuildRunners();

            Task wholeTask = null;
            try
            {
                var runnersTasks = new List<Task>();
                runners.ForEach(r => runnersTasks.Add(r.RunAsync()));
                wholeTask = Task.WhenAll(runnersTasks);
                await wholeTask;
            }
            catch (Exception ex)
            {
                // note that the exception catched IS NOT the AggregateException, but the first exception thrown
                Console.WriteLine($"First exception catched: '{ex.Message}'");
                wholeTask?
                    .Exception?
                    .InnerExceptions // here are all the exceptions
                    .ToList()
                    .ForEach(ex => Console.WriteLine($"Catched ex => '{ex.Message}'"));
            }
        }

        private static List<Runner> BuildRunners()
        {
            var runners = new List<Runner>();

            for (int i = 0; i < 3; i++)
            {
                runners.Add(new Runner($"Runner-0{i}", i * 100));
            }

            return runners;
        }
    }
}
