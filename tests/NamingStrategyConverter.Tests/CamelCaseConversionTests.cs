using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class CamelCaseConversionTests
{
    [Fact]
    public void PascalCase_To_CamelCase_General_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToCamelCase();

        Assert.Equal("thisWasPascalCase", result);
    }

    [Fact]
    public void PascalCase_To_CamelCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToCamelCase(NamingStrategy.PascalCase);

        Assert.Equal("thisWasPascalCase", result);
    }

    [Fact]
    public void CamelCase_To_CamelCase_General_RemainsUnchanged()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToCamelCase();

        Assert.Equal("thisWasCamelCase", result);
    }

    [Fact]
    public void CamelCase_To_CamelCase_KnownNamingStrategy_RemainsUnchanged()
    {
        const string str = "thisWasCamelCase";

        // Realistically this would never happen but test it anyways
        string result = str.ToCamelCase(NamingStrategy.CamelCase);

        Assert.Equal("thisWasCamelCase", result);
    }

    [Fact]
    public void KebabCase_To_CamelCase_General_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToCamelCase();

        Assert.Equal("thisWasKebabCase", result);
    }

    [Fact]
    public void KebabCase_To_CamelCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToCamelCase(NamingStrategy.KebabCase);

        Assert.Equal("thisWasKebabCase", result);
    }

    [Fact]
    public void UpperKebabCase_To_CamelCase_General_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToCamelCase();

        Assert.Equal("thisWasUpperKebabCase", result);
    }

    [Fact]
    public void UpperKebabCase_To_CamelCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToCamelCase(NamingStrategy.UpperKebabCase);

        Assert.Equal("thisWasUpperKebabCase", result);
    }

    [Fact]
    public void UpperSnakeCase_To_CamelCase_General_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToCamelCase();

        Assert.Equal("thisWasUpperSnakeCase", result);
    }

    [Fact]
    public void UpperSnakeCase_To_CamelCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToCamelCase(NamingStrategy.UpperSnakeCase);

        Assert.Equal("thisWasUpperSnakeCase", result);
    }

    [Fact]
    public void SnakeCase_To_CamelCase_General_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToCamelCase();

        Assert.Equal("thisWasSnakeCase", result);
    }

    [Fact]
    public void SnakeCase_To_CamelCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToCamelCase(NamingStrategy.SnakeCase);

        Assert.Equal("thisWasSnakeCase", result);
    }

    [Fact]
    public void AllUpperCase_To_CamelCase_ValidConversion()
    {
        const string str = "THISWASUPPERCASE";

        string result = str.ToCamelCase();

        Assert.Equal("thiswasuppercase", result);
    }

    [Fact]
    public void AllLowerCase_To_CamelCase_ValidConversion()
    {
        const string str = "thiswaslowercase";

        string result = str.ToCamelCase();

        Assert.Equal("thiswaslowercase", result);
    }

    [Fact]
    public void IsCamelCase_WithValidCamelCase_ReturnsTrue()
    {
        const string str = "thisIsCamelCase";

        bool result = str.IsCamelCase();

        Assert.True(result);
    }

    [Fact]
    public void IsCamelCase_WithInvalidCamelCase_ReturnsFalse()
    {
        const string str = "ThisIsNotCamelCase";

        bool result = str.IsCamelCase();

        Assert.False(result);
    }
}