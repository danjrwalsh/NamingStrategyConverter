using BenchmarkDotNet.Attributes;
using DanWalsh.NamingStrategyConverter.Converters;

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
    public void PascalToSnake_ChatGPT()
    {
        NamingStrategyExample.PascalCase.ToSnakeCaseChatGPTOptimized();
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
    public void CamelToSnake_ChatGPT()
    {
        NamingStrategyExample.CamelCase.ToSnakeCaseChatGPTOptimized();
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
    public void KebabToSnake_ChatGPT()
    {
        NamingStrategyExample.KebabCase.ToSnakeCaseChatGPTOptimized();
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
    public void SnakeToSnake_ChatGPT()
    {
        NamingStrategyExample.SnakeCase.ToSnakeCaseChatGPTOptimized();
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
    public void UpperSnakeToSnake_ChatGPT()
    {
        NamingStrategyExample.ScreamingSnakeCase.ToSnakeCaseChatGPTOptimized();
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
    
    [Benchmark]
    public void UpperKebabToSnake_ChatGPT()
    {
        NamingStrategyExample.ScreamingKebabCase.ToSnakeCaseChatGPTOptimized();
    }
}