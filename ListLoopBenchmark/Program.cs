using BenchmarkDotNet.Running;
using LoopBenchMark;



internal class Program
{
    private static void Main(string[] args)
    {
        BenchmarkRunner.Run<LoopBenchmarks>();
    }
}
public static class StringExtensions
{
    // 👇 Extension block specifies receiver type but doesn't specify a parameter name
    extension(string)
    {
        //    👇 static extension method
        public static bool HasValue(string value)
            => !string.IsNullOrEmpty(value);
    }
}