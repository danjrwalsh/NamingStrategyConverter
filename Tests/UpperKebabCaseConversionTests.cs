using DanWalsh.NamingStrategyConverter.Converters;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class UpperKebabCaseConversionTests
{
    [Fact]
    public void PascalCase_To_UpperKebabCase_General_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToUpperKebabCase();
        
        Assert.Equal("THIS-WAS-PASCAL-CASE", result);
    }

    [Fact]
    public void PascalCase_To_UpperKebabCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToUpperKebabCase(NamingStrategy.PascalCase);

        Assert.Equal("THIS-WAS-PASCAL-CASE", result);
    }
    
    [Fact]
    public void CamelCase_To_UpperKebabCase_General_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToUpperKebabCase();

        Assert.Equal("THIS-WAS-CAMEL-CASE", result);
    }

    [Fact]
    public void CamelCase_To_UpperKebabCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToUpperKebabCase(NamingStrategy.CamelCase);

        Assert.Equal("THIS-WAS-CAMEL-CASE", result);
    }

    [Fact]
    public void KebabCase_To_UpperKebabCase_General_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToUpperKebabCase();

        Assert.Equal("THIS-WAS-KEBAB-CASE", result);
    }

    [Fact]
    public void KebabCase_To_UpperKebabCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        // Realistically this would never happen but test it anyways
        string result = str.ToUpperKebabCase(NamingStrategy.KebabCase);

        Assert.Equal("THIS-WAS-KEBAB-CASE", result);
    }

    [Fact]
    public void UpperKebabCase_To_UpperKebabCase_General_RemainsUnchanged()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToUpperKebabCase();

        Assert.Equal("THIS-WAS-UPPER-KEBAB-CASE", result);
    }

    [Fact]
    public void UpperKebabCase_To_UpperKebabCase_KnownNamingStrategy_RemainsUnchanged()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        // Realistically this would never happen but test it anyways
        string result = str.ToUpperKebabCase(NamingStrategy.UpperKebabCase);

        Assert.Equal("THIS-WAS-UPPER-KEBAB-CASE", result);
    }

    [Fact]
    public void UpperSnakeCase_To_UpperKebabCase_General_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToUpperKebabCase();

        Assert.Equal("THIS-WAS-UPPER-SNAKE-CASE", result);
    }

    [Fact]
    public void UpperSnakeCase_To_UpperKebabCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToUpperKebabCase(NamingStrategy.UpperSnakeCase);

        Assert.Equal("THIS-WAS-UPPER-SNAKE-CASE", result);
    }

    [Fact]
    public void SnakeCase_To_UpperKebabCase_General_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToUpperKebabCase();

        Assert.Equal("THIS-WAS-SNAKE-CASE", result);
    }

    [Fact]
    public void SnakeCase_To_UpperKebabCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToUpperKebabCase(NamingStrategy.SnakeCase);

        Assert.Equal("THIS-WAS-SNAKE-CASE", result);
    }

    [Fact]
    public void AllUpperCase_To_UpperKebabCase_RemainsUnchanged()
    {
        const string str = "THISWASUPPERCASE";

        string result = str.ToUpperKebabCase();

        Assert.Equal("THISWASUPPERCASE", result);
    }

    [Fact]
    public void AllLowerCase_To_UpperKebabCase_ValidConversion()
    {
        const string str = "thiswaslowercase";

        string result = str.ToUpperKebabCase();

        Assert.Equal("THISWASLOWERCASE", result);
    }

    [Fact]
    public void IsUpperKebabCase_WithValidUpperKebabCase_ReturnsTrue()
    {
        const string str = "THIS-IS-UPPER-KEBAB-CASE";

        bool result = str.IsUpperKebabCase();

        Assert.True(result);
    }

    [Fact]
    public void IsUpperKebabCase_WithInvalidUpperKebabCase_ReturnsFalse()
    {
        const string str = "this_is_not_upper_kebab_case";

        bool result = str.IsUpperKebabCase();

        Assert.False(result);
    }
}