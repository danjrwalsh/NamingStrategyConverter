using BenchmarkDotNet.Attributes;

namespace DanWalsh.NamingStrategyConverter.Benchmarks;

[MemoryDiagnoser]
public class UpperKebabCaseBenchmarks
{
    [Benchmark]
    public void PascalToUpperKebab()
    {
        NamingStrategyExample.PascalCase.ToUpperKebabCase();
    }

    [Benchmark]
    public void PascalToUpperKebab_SpecifiedPascal()
    {
        NamingStrategyExample.PascalCase.ToUpperKebabCase(NamingStrategy.PascalCase);
    }

    [Benchmark]
    public void CamelToUpperKebab()
    {
        NamingStrategyExample.CamelCase.ToUpperKebabCase();
    }

    [Benchmark]
    public void CamelToUpperKebab_SpecifiedCamel()
    {
        NamingStrategyExample.CamelCase.ToUpperKebabCase(NamingStrategy.CamelCase);
    }
    
    [Benchmark]
    public void KebabToUpperKebab()
    {
        NamingStrategyExample.KebabCase.ToUpperKebabCase();
    }

    [Benchmark]
    public void KebabToUpperKebab_SpecifiedKebab()
    {
        NamingStrategyExample.KebabCase.ToUpperKebabCase(NamingStrategy.KebabCase);
    }

    [Benchmark]
    public void SnakeToUpperKebab()
    {
        NamingStrategyExample.SnakeCase.ToUpperKebabCase();
    }

    [Benchmark]
    public void SnakeToUpperKebab_SpecifiedSnake()
    {
        NamingStrategyExample.SnakeCase.ToUpperKebabCase(NamingStrategy.SnakeCase);
    }
    
    [Benchmark]
    public void UpperSnakeToUpperKebab()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToUpperKebabCase();
    }

    [Benchmark]
    public void UpperSnakeToUpperKebab_SpecifiedUpperSnake()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToUpperKebabCase(NamingStrategy.UpperSnakeCase);
    }

    [Benchmark]
    public void UpperKebabToUpperKebab()
    {
        NamingStrategyExample.ScreamingKebabCase.ToUpperKebabCase();
    }

    [Benchmark]
    public void UpperKebabToUpperKebab_SpecifiedUpperKebab()
    {
        NamingStrategyExample.ScreamingKebabCase.ToUpperKebabCase(NamingStrategy.UpperKebabCase);
    }
}