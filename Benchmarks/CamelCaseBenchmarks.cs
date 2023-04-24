using BenchmarkDotNet.Attributes;
using DanWalsh.NamingStrategyConverter.Converters;

namespace DanWalsh.NamingStrategyConverter.Benchmarks;

[MemoryDiagnoser]
public class CamelCaseBenchmarks
{
    [Benchmark]
    public void PascalToCamel()
    {
        NamingStrategyExample.PascalCase.ToCamelCase();
    }

    [Benchmark]
    public void PascalToCamel_SpecifiedPascal()
    {
        NamingStrategyExample.PascalCase.ToCamelCase(NamingStrategy.PascalCase);
    }

    [Benchmark]
    public void CamelToCamel()
    {
        NamingStrategyExample.CamelCase.ToCamelCase();
    }

    [Benchmark]
    public void CamelToCamel_SpecifiedCamel()
    {
        NamingStrategyExample.CamelCase.ToCamelCase(NamingStrategy.CamelCase);
    }
    
    [Benchmark]
    public void KebabToCamel()
    {
        NamingStrategyExample.KebabCase.ToCamelCase();
    }

    [Benchmark]
    public void KebabToCamel_SpecifiedKebab()
    {
        NamingStrategyExample.KebabCase.ToCamelCase(NamingStrategy.KebabCase);
    }

    [Benchmark]
    public void SnakeToCamel()
    {
        NamingStrategyExample.SnakeCase.ToCamelCase();
    }

    [Benchmark]
    public void SnakeToCamel_SpecifiedSnake()
    {
        NamingStrategyExample.SnakeCase.ToCamelCase(NamingStrategy.SnakeCase);
    }
    
    [Benchmark]
    public void UpperSnakeToCamel()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToCamelCase();
    }

    [Benchmark]
    public void UpperSnakeToCamel_SpecifiedUpperSnake()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToCamelCase(NamingStrategy.UpperSnakeCase);
    }

    [Benchmark]
    public void UpperKebabToCamel()
    {
        NamingStrategyExample.ScreamingKebabCase.ToCamelCase();
    }

    [Benchmark]
    public void UpperKebabToCamel_SpecifiedUpperKebab()
    {
        NamingStrategyExample.ScreamingKebabCase.ToCamelCase(NamingStrategy.UpperKebabCase);
    }
}