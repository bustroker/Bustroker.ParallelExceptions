using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bustroker.ParallelExceptions
{
    public class Runner
    {
        private readonly string Name;
        private readonly int DelayBetweenStepsInMiliseconds;

        public Runner(string name, int delayBetweenStepsInMiliseconds)
        {
            Name = name;
            DelayBetweenStepsInMiliseconds = delayBetweenStepsInMiliseconds;
        }
        
        public async Task RunAsync()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Task {Name} running step '{i}'");
                await Task.Delay(DelayBetweenStepsInMiliseconds);
            }
            var message = $"Runner '{Name}' throwing exception";
            Console.WriteLine(message);
            throw new Exception(message);
        }
    }
}