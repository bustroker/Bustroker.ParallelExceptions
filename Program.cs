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
            var runnersTasks = new List<Task>();
            Task compositeTask = null;
            try
            {
                // run all the tasks and keep them in the list
                Runners.ForEach(r => runnersTasks.Add(r.RunAsync()));

                // just wait for them all to finish, and keep a reference to this compose task
                compositeTask = Task.WhenAll(runnersTasks);
                await compositeTask;
            }
            catch (Exception ex)
            {
                // note that the exception catched IS NOT the AggregateException, but the first exception thrown
                Console.WriteLine($"First exception catched: '{ex.Message}'");
                //usually just throw back the full AggregateException, rather than just the first exception catched here
                throw compositeTask.Exception;
            }
        }

        private static List<Runner> Runners
        {
            get
            {
                var runners = new List<Runner>();

                for (int i = 0; i < 5; i++)
                {
                    runners.Add(new Runner($"Runner-0{i}", i * 100));
                }

                return runners;
            }
        }

    }
}
