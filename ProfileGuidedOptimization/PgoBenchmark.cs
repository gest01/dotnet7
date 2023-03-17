using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace ProfileGuidedOptimization;

[MemoryDiagnoser]
public class PgoBenchmark
{
    static readonly int[] s_values = Enumerable.Range(0, 1_000).ToArray();
    static readonly IEnumerator<int> _source = Enumerable.Range(0, 1_000).GetEnumerator();

    [Benchmark]
    public int Where()
    {
        return s_values.Where(f => f % 2 == 0).Sum();
    }

    [Benchmark]
    public int WhereOrderByDescending()
    {
        return s_values.Where(f => f % 2 == 0).OrderByDescending(f => f).Sum();
    }

    // [Benchmark]
    // public int InterfaceDispatch()
    // {
    //     ISumOperation ops = new MySumOperation();
    //     return s_values.Sum(f => Bla.Calculate(ops, s_values));
    // }

    [Benchmark]
    public void MoveNext() => _source.MoveNext();

    [Benchmark]
    public int Delegate() => Sum(s_values, i => i * 42);

    static int Sum(int[] values, Func<int, int>? func)
    {
        int sum = 0;
        foreach (int value in values)
        {
            sum += func(value);
        }
        return sum;
    }

    public int Calculate(ISumOperation operation, int[] values)
    {
        return operation.Sum(values);
    }

    public interface ISumOperation
    {
        int Sum(int[] value);
    }

    public class MySumOperation : ISumOperation
    {
        public int Sum(int[] value)
        {
            return value.Sum();
        }
    }

    public static class Bla
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int Calculate(ISumOperation operation, int[] values)
        {
            return operation.Sum(values);
        }
    }
}