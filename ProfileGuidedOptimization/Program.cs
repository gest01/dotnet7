using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace ProfileGuidedOptimization
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<PgoBenchmark>();
        }
    }
}