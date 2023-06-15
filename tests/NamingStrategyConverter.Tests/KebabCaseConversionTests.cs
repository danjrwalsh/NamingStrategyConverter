using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class KebabCaseConversionTests
{
    [Fact]
    public void PascalCase_To_KebabCase_General_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToKebabCase();

        Assert.Equal("this-was-pascal-case", result);
    }

    [Fact]
    public void PascalCase_To_KebabCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToKebabCase(NamingStrategy.PascalCase);

        Assert.Equal("this-was-pascal-case", result);
    }

    [Fact]
    public void CamelCase_To_KebabCase_General_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToKebabCase();

        Assert.Equal("this-was-camel-case", result);
    }

    [Fact]
    public void CamelCase_To_KebabCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToKebabCase(NamingStrategy.CamelCase);

        Assert.Equal("this-was-camel-case", result);
    }

    [Fact]
    public void KebabCase_To_KebabCase_General_RemainsUnchanged()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToKebabCase();

        Assert.Equal("this-was-kebab-case", result);
    }

    [Fact]
    public void KebabCase_To_KebabCase_KnownNamingStrategy_RemainsUnchanged()
    {
        const string str = "this-was-kebab-case";

        // Realistically this would never happen but test it anyways
        string result = str.ToKebabCase(NamingStrategy.KebabCase);

        Assert.Equal("this-was-kebab-case", result);
    }

    [Fact]
    public void UpperKebabCase_To_KebabCase_General_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToKebabCase();

        Assert.Equal("this-was-upper-kebab-case", result);
    }

    [Fact]
    public void UpperKebabCase_To_KebabCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToKebabCase(NamingStrategy.UpperKebabCase);

        Assert.Equal("this-was-upper-kebab-case", result);
    }

    [Fact]
    public void UpperSnakeCase_To_KebabCase_General_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToKebabCase();

        Assert.Equal("this-was-upper-snake-case", result);
    }

    [Fact]
    public void UpperSnakeCase_To_KebabCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToKebabCase(NamingStrategy.UpperSnakeCase);

        Assert.Equal("this-was-upper-snake-case", result);
    }

    [Fact]
    public void SnakeCase_To_KebabCase_General_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToKebabCase();

        Assert.Equal("this-was-snake-case", result);
    }

    [Fact]
    public void SnakeCase_To_KebabCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToKebabCase(NamingStrategy.SnakeCase);

        Assert.Equal("this-was-snake-case", result);
    }

    [Fact]
    public void AllUpperCase_To_KebabCase_ValidConversion()
    {
        const string str = "THISWASUPPERCASE";

        string result = str.ToKebabCase();

        Assert.Equal("thiswasuppercase", result);
    }

    [Fact]
    public void AllLowerCase_To_KebabCase_RemainsUnchanged()
    {
        const string str = "thiswaslowercase";

        string result = str.ToKebabCase();

        Assert.Equal("thiswaslowercase", result);
    }

    [Fact]
    public void IsKebabCase_WithValidKebabCase_ReturnsTrue()
    {
        const string str = "this-is-kebab-case";

        bool result = str.IsKebabCase();

        Assert.True(result);
    }

    [Fact]
    public void IsKebabCase_WithInvalidKebabCase_ReturnsFalse()
    {
        const string str = "this_is_not_kebab_case";

        bool result = str.IsKebabCase();

        Assert.False(result);
    }
}