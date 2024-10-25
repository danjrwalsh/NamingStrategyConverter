using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class DotCaseConversionTests
{
    [Theory]
    [InlineData("ThisWasPascalCase", "this.was.pascal.case", NamingStrategy.PascalCase)]
    [InlineData("thisWasCamelCase", "this.was.camel.case", NamingStrategy.CamelCase)]
    [InlineData("this-was-kebab-case", "this.was.kebab.case", NamingStrategy.KebabCase)]
    [InlineData("THIS-WAS-UPPER-KEBAB-CASE", "this.was.upper.kebab.case", NamingStrategy.UpperKebabCase)]
    [InlineData("THIS_WAS_UPPER_SNAKE_CASE", "this.was.upper.snake.case", NamingStrategy.UpperSnakeCase)]
    [InlineData("this_was_snake_case", "this.was.snake.case", NamingStrategy.SnakeCase)]
    [InlineData("this.is.dot.case", "this.is.dot.case", NamingStrategy.DotCase)]
    [InlineData("THISWASUPPERCASE", "thiswasuppercase", NamingStrategy.Unknown)]
    [InlineData("thiswaslowercase", "thiswaslowercase", NamingStrategy.Unknown)]
    [InlineData("", "", NamingStrategy.Unknown)]
    [InlineData("SomeMixedCASEString", "some.mixed.case.string", NamingStrategy.Unknown)]
    [InlineData("Special@#%&*()Characters", "special@#%&*()characters", NamingStrategy.Unknown)]
    [InlineData("StringWith123Numbers", "string.with123numbers", NamingStrategy.Unknown)]
    public void ToDotCase_ValidConversion(string input, string expected, NamingStrategy strategy)
    {
        string result = input.ToDotCase(strategy);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("this.is.dot.case", true)]
    [InlineData("this_is_not_dot_case", false)]
    public void IsDotCase_ValidCheck(string input, bool expected)
    {
        bool result = input.IsDotCase();

        Assert.Equal(expected, result);
    }
}
