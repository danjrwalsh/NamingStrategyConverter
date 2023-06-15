using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class UpperSnakeCaseConversionTests
{
    [Fact]
    public void PascalCase_To_UpperSnakeCase_General_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToUpperSnakeCase();

        Assert.Equal("THIS_WAS_PASCAL_CASE", result);
    }

    [Fact]
    public void PascalCase_To_UpperSnakeCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToUpperSnakeCase(NamingStrategy.PascalCase);

        Assert.Equal("THIS_WAS_PASCAL_CASE", result);
    }

    [Fact]
    public void CamelCase_To_UpperSnakeCase_General_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToUpperSnakeCase();

        Assert.Equal("THIS_WAS_CAMEL_CASE", result);
    }

    [Fact]
    public void CamelCase_To_UpperSnakeCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToUpperSnakeCase(NamingStrategy.CamelCase);

        Assert.Equal("THIS_WAS_CAMEL_CASE", result);
    }

    [Fact]
    public void KebabCase_To_UpperSnakeCase_General_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToUpperSnakeCase();

        Assert.Equal("THIS_WAS_KEBAB_CASE", result);
    }

    [Fact]
    public void KebabCase_To_UpperSnakeCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToUpperSnakeCase(NamingStrategy.KebabCase);

        Assert.Equal("THIS_WAS_KEBAB_CASE", result);
    }

    [Fact]
    public void UpperKebabCase_To_UpperSnakeCase_General_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToUpperSnakeCase();

        Assert.Equal("THIS_WAS_UPPER_KEBAB_CASE", result);
    }

    [Fact]
    public void UpperKebabCase_To_UpperSnakeCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToUpperSnakeCase(NamingStrategy.UpperKebabCase);

        Assert.Equal("THIS_WAS_UPPER_KEBAB_CASE", result);
    }

    [Fact]
    public void UpperSnakeCase_To_UpperSnakeCase_General_RemainsUnchanged()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToUpperSnakeCase();

        Assert.Equal("THIS_WAS_UPPER_SNAKE_CASE", result);
    }

    [Fact]
    public void UpperSnakeCase_To_UpperSnakeCase_KnownNamingStrategy_RemainsUnchanged()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        // Realistically this would never happen but test it anyways
        string result = str.ToUpperSnakeCase(NamingStrategy.UpperSnakeCase);

        Assert.Equal("THIS_WAS_UPPER_SNAKE_CASE", result);
    }

    [Fact]
    public void SnakeCase_To_UpperSnakeCase_General_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToUpperSnakeCase();

        Assert.Equal("THIS_WAS_SNAKE_CASE", result);
    }

    [Fact]
    public void SnakeCase_To_UpperSnakeCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToUpperSnakeCase(NamingStrategy.SnakeCase);

        Assert.Equal("THIS_WAS_SNAKE_CASE", result);
    }

    [Fact]
    public void AllUpperCase_To_UpperSnakeCase_RemainsUnchanged()
    {
        const string str = "THISWASUPPERCASE";

        string result = str.ToUpperSnakeCase();

        Assert.Equal("THISWASUPPERCASE", result);
    }

    [Fact]
    public void AllLowerCase_To_UpperSnakeCase_ValidConversion()
    {
        const string str = "thiswaslowercase";

        string result = str.ToUpperSnakeCase();

        Assert.Equal("THISWASLOWERCASE", result);
    }

    [Fact]
    public void IsUpperSnakeCase_WithValidUpperSnakeCase_ReturnsTrue()
    {
        const string str = "THIS_IS_SNAKE_CASE";

        bool result = str.IsUpperSnakeCase();

        Assert.True(result);
    }

    [Fact]
    public void IsUpperSnakeCase_WithInvalidUpperSnakeCase_ReturnsFalse()
    {
        const string str = "this-is-not-upper-snake-case";

        bool result = str.IsUpperSnakeCase();

        Assert.False(result);
    }
}