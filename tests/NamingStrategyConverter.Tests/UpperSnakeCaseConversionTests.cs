using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class UpperSnakeCaseConversionTests
{
    [Theory]
    [InlineData("ThisWasPascalCase", "THIS_WAS_PASCAL_CASE", NamingStrategy.PascalCase)]
    [InlineData("thisWasCamelCase", "THIS_WAS_CAMEL_CASE", NamingStrategy.CamelCase)]
    [InlineData("this-was-kebab-case", "THIS_WAS_KEBAB_CASE", NamingStrategy.KebabCase)]
    [InlineData("THIS-WAS-UPPER-KEBAB-CASE", "THIS_WAS_UPPER_KEBAB_CASE", NamingStrategy.UpperKebabCase)]
    [InlineData("THIS_WAS_UPPER_SNAKE_CASE", "THIS_WAS_UPPER_SNAKE_CASE", NamingStrategy.UpperSnakeCase)]
    [InlineData("this_was_snake_case", "THIS_WAS_SNAKE_CASE", NamingStrategy.SnakeCase)]
    [InlineData("THISWASUPPERCASE", "THISWASUPPERCASE", NamingStrategy.Unknown)]
    [InlineData("thiswaslowercase", "THISWASLOWERCASE", NamingStrategy.Unknown)]
    [InlineData("", "", NamingStrategy.Unknown)]
    [InlineData("SomeMixedCASEString", "SOMEMIXEDCASESTRING", NamingStrategy.Unknown)]
    [InlineData("Special@#%&*()Characters", "SPECIAL@#%&*()CHARACTERS", NamingStrategy.Unknown)]
    [InlineData("StringWith123Numbers", "STRINGWITH123NUMBERS", NamingStrategy.Unknown)]
    public void ToUpperSnakeCase_ValidConversion(string input, string expected, NamingStrategy strategy)
    {
        string result = input.ToUpperSnakeCase(strategy);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("THIS_IS_SNAKE_CASE", true)]
    [InlineData("this-is-not-upper-snake-case", false)]
    public void IsUpperSnakeCase_ValidCheck(string input, bool expected)
    {
        bool result = input.IsUpperSnakeCase();

        Assert.Equal(expected, result);
    }
}
