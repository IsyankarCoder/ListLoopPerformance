using BenchmarkDotNet.Running;
using LoopBenchMark;



internal class Program
{
    private static void Main(string[] args)
    {
        BenchmarkRunner.Run<LoopBenchmarks>();
    }
}
