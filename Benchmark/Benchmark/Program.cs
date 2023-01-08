using BenchmarkDotNet.Running;
using System;

namespace Benchmark
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");
            BenchmarkRunner.Run<Algorithms>();
        }
    }
}
