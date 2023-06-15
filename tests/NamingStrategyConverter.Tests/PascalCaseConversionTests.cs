using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class PascalCaseConversionTests
{
    [Fact]
    public void PascalCase_To_PascalCase_General_RemainsUnchanged()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToPascalCase();

        Assert.Equal("ThisWasPascalCase", result);
    }

    [Fact]
    public void PascalCase_To_PascalCase_KnownNamingStrategy_RemainsUnchanged()
    {
        const string str = "ThisWasPascalCase";

        // Realistically this would never happen but test it anyways
        string result = str.ToPascalCase(NamingStrategy.PascalCase);

        Assert.Equal("ThisWasPascalCase", result);
    }

    [Fact]
    public void CamelCase_To_PascalCase_General_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToPascalCase();

        Assert.Equal("ThisWasCamelCase", result);
    }

    [Fact]
    public void CamelCase_To_PascalCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToPascalCase(NamingStrategy.CamelCase);

        Assert.Equal("ThisWasCamelCase", result);
    }

    [Fact]
    public void KebabCase_To_PascalCase_General_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToPascalCase();

        Assert.Equal("ThisWasKebabCase", result);
    }

    [Fact]
    public void KebabCase_To_PascalCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToPascalCase(NamingStrategy.KebabCase);

        Assert.Equal("ThisWasKebabCase", result);
    }

    [Fact]
    public void UpperKebabCase_To_PascalCase_General_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToPascalCase();

        Assert.Equal("ThisWasUpperKebabCase", result);
    }

    [Fact]
    public void UpperKebabCase_To_PascalCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToPascalCase(NamingStrategy.UpperKebabCase);

        Assert.Equal("ThisWasUpperKebabCase", result);
    }

    [Fact]
    public void UpperSnakeCase_To_PascalCase_General_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToPascalCase();

        Assert.Equal("ThisWasUpperSnakeCase", result);
    }

    [Fact]
    public void UpperSnakeCase_To_PascalCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToPascalCase(NamingStrategy.UpperSnakeCase);

        Assert.Equal("ThisWasUpperSnakeCase", result);
    }

    [Fact]
    public void SnakeCase_To_PascalCase_General_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToPascalCase();

        Assert.Equal("ThisWasSnakeCase", result);
    }

    [Fact]
    public void SnakeCase_To_PascalCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToPascalCase(NamingStrategy.SnakeCase);

        Assert.Equal("ThisWasSnakeCase", result);
    }

    [Fact]
    public void AllUpperCase_To_PascalCase_ValidConversion()
    {
        const string str = "THISWASUPPERCASE";

        string result = str.ToPascalCase();

        Assert.Equal("Thiswasuppercase", result);
    }

    [Fact]
    public void AllLowerCase_To_PascalCase_ValidConversion()
    {
        const string str = "thiswaslowercase";

        string result = str.ToPascalCase();

        Assert.Equal("Thiswaslowercase", result);
    }

    [Fact]
    public void IsPascalCase_WithValidPascalCase_ReturnsTrue()
    {
        const string str = "ThisIsPascalCase";

        bool result = str.IsPascalCase();

        Assert.True(result);
    }

    [Fact]
    public void IsPascalCase_WithInvalidPascalCase_ReturnsFalse()
    {
        const string str = "thisIsNotPascalCase";

        bool result = str.IsPascalCase();

        Assert.False(result);
    }
}