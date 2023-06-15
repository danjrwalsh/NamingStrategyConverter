using BenchmarkDotNet.Attributes;

namespace DanWalsh.NamingStrategyConverter.Benchmarks;

[MemoryDiagnoser]
public class UpperSnakeCaseBenchmarks
{
    [Benchmark]
    public void PascalToUpperSnake()
    {
        NamingStrategyExample.PascalCase.ToUpperSnakeCase();
    }

    [Benchmark]
    public void PascalToUpperSnake_SpecifiedPascal()
    {
        NamingStrategyExample.PascalCase.ToUpperSnakeCase(NamingStrategy.PascalCase);
    }

    [Benchmark]
    public void CamelToUpperSnake()
    {
        NamingStrategyExample.CamelCase.ToUpperSnakeCase();
    }

    [Benchmark]
    public void CamelToUpperSnake_SpecifiedCamel()
    {
        NamingStrategyExample.CamelCase.ToUpperSnakeCase(NamingStrategy.CamelCase);
    }

    [Benchmark]
    public void KebabToUpperSnake()
    {
        NamingStrategyExample.KebabCase.ToUpperSnakeCase();
    }

    [Benchmark]
    public void KebabToUpperSnake_SpecifiedKebab()
    {
        NamingStrategyExample.KebabCase.ToUpperSnakeCase(NamingStrategy.KebabCase);
    }

    [Benchmark]
    public void SnakeToUpperSnake()
    {
        NamingStrategyExample.SnakeCase.ToUpperSnakeCase();
    }

    [Benchmark]
    public void SnakeToUpperSnake_SpecifiedSnake()
    {
        NamingStrategyExample.SnakeCase.ToUpperSnakeCase(NamingStrategy.SnakeCase);
    }

    [Benchmark]
    public void UpperSnakeToUpperSnake()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToUpperSnakeCase();
    }

    [Benchmark]
    public void UpperSnakeToUpperSnake_SpecifiedUpperSnake()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToUpperSnakeCase(NamingStrategy.UpperSnakeCase);
    }

    [Benchmark]
    public void UpperKebabToUpperSnake()
    {
        NamingStrategyExample.ScreamingKebabCase.ToUpperSnakeCase();
    }

    [Benchmark]
    public void UpperKebabToUpperSnake_SpecifiedUpperKebab()
    {
        NamingStrategyExample.ScreamingKebabCase.ToUpperSnakeCase(NamingStrategy.UpperKebabCase);
    }
}