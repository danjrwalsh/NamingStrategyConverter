using BenchmarkDotNet.Attributes;
using DanWalsh.NamingStrategyConverter.Converters;

namespace DanWalsh.NamingStrategyConverter.Benchmarks;

[MemoryDiagnoser]
public class TempBenchmarks
{
    [Benchmark]
    public void IsKebabCaseForLoop_IsKebab()
    {
        var str = "this-is-kebab".IsKebabCase();
    }

    [Benchmark]
    public void IsKebabCaseForLoop_IsNotKebab()
    {
        var str = "this_is_not_kebab".IsKebabCase();
    }
}