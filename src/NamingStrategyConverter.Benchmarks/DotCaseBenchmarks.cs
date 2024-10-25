using BenchmarkDotNet.Attributes;
using DanWalsh.NamingStrategyConverter.Constants;

namespace DanWalsh.NamingStrategyConverter.Benchmarks;

[MemoryDiagnoser]
public class DotCaseBenchmarks
{
    [Benchmark]
    public void PascalToDot()
    {
        NamingStrategyExample.PascalCase.ToDotCase();
    }

    [Benchmark]
    public void PascalToDot_SpecifiedPascal()
    {
        NamingStrategyExample.PascalCase.ToDotCase(NamingStrategy.PascalCase);
    }

    [Benchmark]
    public void CamelToDot()
    {
        NamingStrategyExample.CamelCase.ToDotCase();
    }

    [Benchmark]
    public void CamelToDot_SpecifiedCamel()
    {
        NamingStrategyExample.CamelCase.ToDotCase(NamingStrategy.CamelCase);
    }

    [Benchmark]
    public void KebabToDot()
    {
        NamingStrategyExample.KebabCase.ToDotCase();
    }

    [Benchmark]
    public void KebabToDot_SpecifiedKebab()
    {
        NamingStrategyExample.KebabCase.ToDotCase(NamingStrategy.KebabCase);
    }

    [Benchmark]
    public void SnakeToDot()
    {
        NamingStrategyExample.SnakeCase.ToDotCase();
    }

    [Benchmark]
    public void SnakeToDot_SpecifiedSnake()
    {
        NamingStrategyExample.SnakeCase.ToDotCase(NamingStrategy.SnakeCase);
    }

    [Benchmark]
    public void UpperSnakeToDot()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToDotCase();
    }

    [Benchmark]
    public void UpperSnakeToDot_SpecifiedUpperSnake()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToDotCase(NamingStrategy.UpperSnakeCase);
    }

    [Benchmark]
    public void UpperKebabToDot()
    {
        NamingStrategyExample.ScreamingKebabCase.ToDotCase();
    }

    [Benchmark]
    public void UpperKebabToDot_SpecifiedUpperKebab()
    {
        NamingStrategyExample.ScreamingKebabCase.ToDotCase(NamingStrategy.UpperKebabCase);
    }
}
