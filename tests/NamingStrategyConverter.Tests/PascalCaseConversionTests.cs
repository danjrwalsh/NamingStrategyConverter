using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class PascalCaseConversionTests
{
    [Theory]
    [InlineData("ThisWasPascalCase", "ThisWasPascalCase", NamingStrategy.PascalCase)]
    [InlineData("thisWasCamelCase", "ThisWasCamelCase", NamingStrategy.CamelCase)]
    [InlineData("this-was-kebab-case", "ThisWasKebabCase", NamingStrategy.KebabCase)]
    [InlineData("THIS-WAS-UPPER-KEBAB-CASE", "ThisWasUpperKebabCase", NamingStrategy.UpperKebabCase)]
    [InlineData("THIS_WAS_UPPER_SNAKE_CASE", "ThisWasUpperSnakeCase", NamingStrategy.UpperSnakeCase)]
    [InlineData("this_was_snake_case", "ThisWasSnakeCase", NamingStrategy.SnakeCase)]
    [InlineData("THISWASUPPERCASE", "Thiswasuppercase", NamingStrategy.Unknown)]
    [InlineData("thiswaslowercase", "Thiswaslowercase", NamingStrategy.Unknown)]
    [InlineData("", "", NamingStrategy.Unknown)]
    [InlineData("SomeMixedCASEString", "SomeMixedCASEString", NamingStrategy.Unknown)]
    [InlineData("Special@#%&*()Characters", "Special@#%&*()Characters", NamingStrategy.Unknown)]
    [InlineData("StringWith123Numbers", "StringWith123Numbers", NamingStrategy.Unknown)]
    public void ToPascalCase_ValidConversion(string input, string expected, NamingStrategy strategy)
    {
        string result = input.ToPascalCase(strategy);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("thisIsNotPascalCase", false)]
    [InlineData("ThisIsPascalCase", true)]
    [InlineData("this is not pascal case", false)]
    [InlineData("this_is_not_pascal_case", false)]
    [InlineData("this-is-not-pascal-case", false)]
    [InlineData("this.is.not.pascal.case", false)]
    [InlineData("THISISNOTPASCALCASE", true)]
    public void IsPascalCase_ValidCheck(string input, bool expected)
    {
        bool result = input.IsPascalCase();

        Assert.Equal(expected, result);
    }
}
