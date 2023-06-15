using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class SnakeCaseConversionTests
{
    [Fact]
    public void PascalCase_To_SnakeCase_General_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToSnakeCase();

        Assert.Equal("this_was_pascal_case", result);
    }

    [Fact]
    public void PascalCase_To_SnakeCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToSnakeCase(NamingStrategy.PascalCase);

        Assert.Equal("this_was_pascal_case", result);
    }

    [Fact]
    public void CamelCase_To_SnakeCase_General_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToSnakeCase();

        Assert.Equal("this_was_camel_case", result);
    }

    [Fact]
    public void CamelCase_To_SnakeCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToSnakeCase(NamingStrategy.CamelCase);

        Assert.Equal("this_was_camel_case", result);
    }

    [Fact]
    public void KebabCase_To_SnakeCase_General_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToSnakeCase();

        Assert.Equal("this_was_kebab_case", result);
    }

    [Fact]
    public void KebabCase_To_SnakeCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToSnakeCase(NamingStrategy.KebabCase);

        Assert.Equal("this_was_kebab_case", result);
    }

    [Fact]
    public void UpperKebabCase_To_SnakeCase_General_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToSnakeCase();

        Assert.Equal("this_was_upper_kebab_case", result);
    }

    [Fact]
    public void UpperKebabCase_To_SnakeCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToSnakeCase(NamingStrategy.UpperKebabCase);

        Assert.Equal("this_was_upper_kebab_case", result);
    }

    [Fact]
    public void UpperSnakeCase_To_SnakeCase_General_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToSnakeCase();

        Assert.Equal("this_was_upper_snake_case", result);
    }

    [Fact]
    public void UpperSnakeCase_To_SnakeCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToSnakeCase(NamingStrategy.UpperSnakeCase);

        Assert.Equal("this_was_upper_snake_case", result);
    }

    [Fact]
    public void SnakeCase_To_SnakeCase_General_RemainsUnchanged()
    {
        const string str = "this_is_snake_case";

        string result = str.ToSnakeCase();

        Assert.Equal("this_is_snake_case", result);
    }

    [Fact]
    public void SnakeCase_To_SnakeCase_KnownNamingStrategy_RemainsUnchanged()
    {
        const string str = "this_is_snake_case";

        // Realistically this would never happen but test it anyways
        string result = str.ToSnakeCase(NamingStrategy.SnakeCase);

        Assert.Equal("this_is_snake_case", result);
    }

    [Fact]
    public void AllUpperCase_To_SnakeCase_ValidConversion()
    {
        const string str = "THISWASUPPERCASE";

        string result = str.ToSnakeCase();

        Assert.Equal("thiswasuppercase", result);
    }

    [Fact]
    public void AllLowerCase_To_SnakeCase_RemainsUnchanged()
    {
        const string str = "thiswaslowercase";

        string result = str.ToSnakeCase();

        Assert.Equal("thiswaslowercase", result);
    }

    [Fact]
    public void IsSnakeCase_WithValidSnakeCase_ReturnsTrue()
    {
        const string str = "this_is_snake_case";

        bool result = str.IsSnakeCase();

        Assert.True(result);
    }

    [Fact]
    public void IsSnakeCase_WithInvalidSnakeCase_ReturnsFalse()
    {
        const string str = "this-is-not-snake-case";

        bool result = str.IsSnakeCase();

        Assert.False(result);
    }
}