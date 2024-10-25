using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class DotCaseConversionTests
{
    [Fact]
    public void PascalCase_To_DotCase_General_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToDotCase();

        Assert.Equal("this.was.pascal.case", result);
    }

    [Fact]
    public void PascalCase_To_DotCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "ThisWasPascalCase";

        string result = str.ToDotCase(NamingStrategy.PascalCase);

        Assert.Equal("this.was.pascal.case", result);
    }

    [Fact]
    public void CamelCase_To_DotCase_General_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToDotCase();

        Assert.Equal("this.was.camel.case", result);
    }

    [Fact]
    public void CamelCase_To_DotCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "thisWasCamelCase";

        string result = str.ToDotCase(NamingStrategy.CamelCase);

        Assert.Equal("this.was.camel.case", result);
    }

    [Fact]
    public void KebabCase_To_DotCase_General_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToDotCase();

        Assert.Equal("this.was.kebab.case", result);
    }

    [Fact]
    public void KebabCase_To_DotCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this-was-kebab-case";

        string result = str.ToDotCase(NamingStrategy.KebabCase);

        Assert.Equal("this.was.kebab.case", result);
    }

    [Fact]
    public void UpperKebabCase_To_DotCase_General_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToDotCase();

        Assert.Equal("this.was.upper.kebab.case", result);
    }

    [Fact]
    public void UpperKebabCase_To_DotCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS-WAS-UPPER-KEBAB-CASE";

        string result = str.ToDotCase(NamingStrategy.UpperKebabCase);

        Assert.Equal("this.was.upper.kebab.case", result);
    }

    [Fact]
    public void UpperSnakeCase_To_DotCase_General_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToDotCase();

        Assert.Equal("this.was.upper.snake.case", result);
    }

    [Fact]
    public void UpperSnakeCase_To_DotCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "THIS_WAS_UPPER_SNAKE_CASE";

        string result = str.ToDotCase(NamingStrategy.UpperSnakeCase);

        Assert.Equal("this.was.upper.snake.case", result);
    }

    [Fact]
    public void SnakeCase_To_DotCase_General_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToDotCase();

        Assert.Equal("this.was.snake.case", result);
    }

    [Fact]
    public void SnakeCase_To_DotCase_KnownNamingStrategy_ValidConversion()
    {
        const string str = "this_was_snake_case";

        string result = str.ToDotCase(NamingStrategy.SnakeCase);

        Assert.Equal("this.was.snake.case", result);
    }

    [Fact]
    public void DotCase_To_DotCase_General_RemainsUnchanged()
    {
        const string str = "this.is.dot.case";

        string result = str.ToDotCase();

        Assert.Equal("this.is.dot.case", result);
    }

    [Fact]
    public void DotCase_To_DotCase_KnownNamingStrategy_RemainsUnchanged()
    {
        const string str = "this.is.dot.case";

        // Realistically this would never happen but test it anyways
        string result = str.ToDotCase(NamingStrategy.DotCase);

        Assert.Equal("this.is.dot.case", result);
    }

    [Fact]
    public void AllUpperCase_To_DotCase_ValidConversion()
    {
        const string str = "THISWASUPPERCASE";

        string result = str.ToDotCase();

        Assert.Equal("thiswasuppercase", result);
    }

    [Fact]
    public void AllLowerCase_To_DotCase_RemainsUnchanged()
    {
        const string str = "thiswaslowercase";

        string result = str.ToDotCase();

        Assert.Equal("thiswaslowercase", result);
    }

    [Fact]
    public void IsDotCase_WithValidDotCase_ReturnsTrue()
    {
        const string str = "this.is.dot.case";

        bool result = str.IsDotCase();

        Assert.True(result);
    }

    [Fact]
    public void IsDotCase_WithInvalidDotCase_ReturnsFalse()
    {
        const string str = "this_is_not_dot_case";

        bool result = str.IsDotCase();

        Assert.False(result);
    }
}
