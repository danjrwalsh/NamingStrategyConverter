using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class UpperKebabCaseConversionTests
{
    [Theory]
    [InlineData("ThisWasPascalCase", "THIS-WAS-PASCAL-CASE", NamingStrategy.PascalCase)]
    [InlineData("thisWasCamelCase", "THIS-WAS-CAMEL-CASE", NamingStrategy.CamelCase)]
    [InlineData("this-was-kebab-case", "THIS-WAS-KEBAB-CASE", NamingStrategy.KebabCase)]
    [InlineData("THIS-WAS-UPPER-KEBAB-CASE", "THIS-WAS-UPPER-KEBAB-CASE", NamingStrategy.UpperKebabCase)]
    [InlineData("THIS_WAS_UPPER_SNAKE_CASE", "THIS-WAS-UPPER-SNAKE-CASE", NamingStrategy.UpperSnakeCase)]
    [InlineData("this_was_snake_case", "THIS-WAS-SNAKE-CASE", NamingStrategy.SnakeCase)]
    [InlineData("THISWASUPPERCASE", "THISWASUPPERCASE", NamingStrategy.Unknown)]
    [InlineData("thiswaslowercase", "THISWASLOWERCASE", NamingStrategy.Unknown)]
    [InlineData("", "", NamingStrategy.Unknown)]
    [InlineData("SomeMixedCASEString", "SOME-MIXED-C-A-S-E-STRING", NamingStrategy.Unknown)]
    [InlineData("Special@#%&*()Characters", "SPECIAL@#%&*()-CHARACTERS", NamingStrategy.Unknown)]
    [InlineData("StringWith123Numbers", "STRING-WITH123-NUMBERS", NamingStrategy.Unknown)]
    public void ToUpperKebabCase_ValidConversion(string input, string expected, NamingStrategy strategy)
    {
        string result = input.ToUpperKebabCase(strategy);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("THIS-IS-UPPER-KEBAB-CASE", true)]
    [InlineData("thisIsNotUpperKebabCase", false)]
    [InlineData("ThisIsNotUpperKebabCase", false)]
    [InlineData("this is not upper kebab case", false)]
    [InlineData("this_is_not_upper_kebab_case", false)]
    [InlineData("this-is-not-upper-kebab-case", false)]
    [InlineData("this.is.not.upper.kebab.case", false)]
    [InlineData("THISISNOTUPPERKEBABCASE", true)]
    public void IsUpperKebabCase_ValidCheck(string input, bool expected)
    {
        bool result = input.IsUpperKebabCase();

        Assert.Equal(expected, result);
    }
}
