using BenchmarkDotNet.Attributes;
using DanWalsh.NamingStrategyConverter.Constants;

namespace DanWalsh.NamingStrategyConverter.Benchmarks;

[MemoryDiagnoser]
public class KebabCaseBenchmarks
{
    [Benchmark]
    public void PascalToKebab()
    {
        NamingStrategyExample.PascalCase.ToKebabCase();
    }

    [Benchmark]
    public void PascalToKebab_SpecifiedPascal()
    {
        NamingStrategyExample.PascalCase.ToKebabCase(NamingStrategy.PascalCase);
    }

    [Benchmark]
    public void CamelToKebab()
    {
        NamingStrategyExample.CamelCase.ToKebabCase();
    }

    [Benchmark]
    public void CamelToKebab_SpecifiedCamel()
    {
        NamingStrategyExample.CamelCase.ToKebabCase(NamingStrategy.CamelCase);
    }

    [Benchmark]
    public void KebabToKebab()
    {
        NamingStrategyExample.KebabCase.ToKebabCase();
    }

    [Benchmark]
    public void KebabToKebab_SpecifiedKebab()
    {
        NamingStrategyExample.KebabCase.ToKebabCase(NamingStrategy.KebabCase);
    }

    [Benchmark]
    public void SnakeToKebab()
    {
        NamingStrategyExample.SnakeCase.ToKebabCase();
    }

    [Benchmark]
    public void SnakeToKebab_SpecifiedSnake()
    {
        NamingStrategyExample.SnakeCase.ToKebabCase(NamingStrategy.SnakeCase);
    }

    [Benchmark]
    public void UpperSnakeToKebab()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToKebabCase();
    }

    [Benchmark]
    public void UpperSnakeToKebab_SpecifiedUpperSnake()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToKebabCase(NamingStrategy.UpperSnakeCase);
    }

    [Benchmark]
    public void UpperKebabToKebab()
    {
        NamingStrategyExample.ScreamingKebabCase.ToKebabCase();
    }

    [Benchmark]
    public void UpperKebabToKebab_SpecifiedUpperKebab()
    {
        NamingStrategyExample.ScreamingKebabCase.ToKebabCase(NamingStrategy.UpperKebabCase);
    }
}