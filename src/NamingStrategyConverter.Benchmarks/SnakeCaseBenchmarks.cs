using BenchmarkDotNet.Attributes;
using DanWalsh.NamingStrategyConverter.Constants;

namespace DanWalsh.NamingStrategyConverter.Benchmarks;

[MemoryDiagnoser]
public class SnakeCaseBenchmarks
{
    [Benchmark]
    public void PascalToSnake()
    {
        NamingStrategyExample.PascalCase.ToSnakeCase();
    }

    [Benchmark]
    public void PascalToSnake_SpecifiedPascal()
    {
        NamingStrategyExample.PascalCase.ToSnakeCase(NamingStrategy.PascalCase);
    }

    [Benchmark]
    public void CamelToSnake()
    {
        NamingStrategyExample.CamelCase.ToSnakeCase();
    }

    [Benchmark]
    public void CamelToSnake_SpecifiedCamel()
    {
        NamingStrategyExample.CamelCase.ToSnakeCase(NamingStrategy.CamelCase);
    }

    [Benchmark]
    public void KebabToSnake()
    {
        NamingStrategyExample.KebabCase.ToSnakeCase();
    }

    [Benchmark]
    public void KebabToSnake_SpecifiedKebab()
    {
        NamingStrategyExample.KebabCase.ToSnakeCase(NamingStrategy.KebabCase);
    }

    [Benchmark]
    public void SnakeToSnake()
    {
        NamingStrategyExample.SnakeCase.ToSnakeCase();
    }

    [Benchmark]
    public void SnakeToSnake_SpecifiedSnake()
    {
        NamingStrategyExample.SnakeCase.ToSnakeCase(NamingStrategy.SnakeCase);
    }

    [Benchmark]
    public void UpperSnakeToSnake()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToSnakeCase();
    }

    [Benchmark]
    public void UpperSnakeToSnake_SpecifiedUpperSnake()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToSnakeCase(NamingStrategy.UpperSnakeCase);
    }

    [Benchmark]
    public void UpperKebabToSnake()
    {
        NamingStrategyExample.ScreamingKebabCase.ToSnakeCase();
    }

    [Benchmark]
    public void UpperKebabToSnake_SpecifiedUpperKebab()
    {
        NamingStrategyExample.ScreamingKebabCase.ToSnakeCase(NamingStrategy.UpperKebabCase);
    }
}