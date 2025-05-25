using System;
using System.Diagnostics;

namespace ClockApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            Clock MyClock = new Clock();
            for (int i = 0; i < 10000; i++)
            {
                MyClock.Tick();
            }

            stopwatch.Stop();
            Console.WriteLine("Time after 10000 ticks: " + MyClock.GetTime());
            MyClock.Restart();
            Console.WriteLine("Time after reset: " + MyClock.GetTime());

            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");

            Process process = Process.GetCurrentProcess();
            Console.WriteLine("Physical memory usage: {0} bytes", process.WorkingSet64);
        }
    }
}
