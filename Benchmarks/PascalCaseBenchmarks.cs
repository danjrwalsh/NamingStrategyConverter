using BenchmarkDotNet.Attributes;

namespace DanWalsh.NamingStrategyConverter.Benchmarks;

[MemoryDiagnoser]
public class PascalCaseBenchmarks
{
    [Benchmark]
    public void PascalToPascal()
    {
        NamingStrategyExample.PascalCase.ToPascalCase();
    }

    [Benchmark]
    public void PascalToPascal_SpecifiedPascal()
    {
        NamingStrategyExample.PascalCase.ToPascalCase(NamingStrategy.PascalCase);
    }

    [Benchmark]
    public void CamelToPascal()
    {
        NamingStrategyExample.CamelCase.ToPascalCase();
    }

    [Benchmark]
    public void CamelToPascal_SpecifiedCamel()
    {
        NamingStrategyExample.CamelCase.ToPascalCase(NamingStrategy.CamelCase);
    }
    
    [Benchmark]
    public void KebabToPascal()
    {
        NamingStrategyExample.KebabCase.ToPascalCase();
    }

    [Benchmark]
    public void KebabToPascal_SpecifiedKebab()
    {
        NamingStrategyExample.KebabCase.ToPascalCase(NamingStrategy.KebabCase);
    }

    [Benchmark]
    public void SnakeToPascal()
    {
        NamingStrategyExample.SnakeCase.ToPascalCase();
    }

    [Benchmark]
    public void SnakeToPascal_SpecifiedSnake()
    {
        NamingStrategyExample.SnakeCase.ToPascalCase(NamingStrategy.SnakeCase);
    }
    
    [Benchmark]
    public void UpperSnakeToPascal()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToPascalCase();
    }

    [Benchmark]
    public void UpperSnakeToPascal_SpecifiedUpperSnake()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToPascalCase(NamingStrategy.UpperSnakeCase);
    }

    [Benchmark]
    public void UpperKebabToPascal()
    {
        NamingStrategyExample.ScreamingKebabCase.ToPascalCase();
    }

    [Benchmark]
    public void UpperKebabToPascal_SpecifiedUpperKebab()
    {
        NamingStrategyExample.ScreamingKebabCase.ToPascalCase(NamingStrategy.UpperKebabCase);
    }
}