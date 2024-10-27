using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class CamelCaseConversionTests
{
    [Theory]
    [InlineData("ThisWasPascalCase", "thisWasPascalCase", NamingStrategy.PascalCase)]
    [InlineData("thisWasCamelCase", "thisWasCamelCase", NamingStrategy.CamelCase)]
    [InlineData("this-was-kebab-case", "thisWasKebabCase", NamingStrategy.KebabCase)]
    [InlineData("THIS-WAS-UPPER-KEBAB-CASE", "thisWasUpperKebabCase", NamingStrategy.UpperKebabCase)]
    [InlineData("THIS_WAS_UPPER_SNAKE_CASE", "thisWasUpperSnakeCase", NamingStrategy.UpperSnakeCase)]
    [InlineData("this_was_snake_case", "thisWasSnakeCase", NamingStrategy.SnakeCase)]
    [InlineData("THISWASUPPERCASE", "tHISWASUPPERCASE", NamingStrategy.Unknown)]
    [InlineData("thiswaslowercase", "thiswaslowercase", NamingStrategy.Unknown)]
    [InlineData("", "", NamingStrategy.Unknown)]
    [InlineData("SomeMixedCASEString", "someMixedCASEString", NamingStrategy.Unknown)]
    [InlineData("Special@#%&*()Characters", "special@#%&*()Characters", NamingStrategy.Unknown)]
    [InlineData("StringWith123Numbers", "stringWith123Numbers", NamingStrategy.Unknown)]
    [InlineData("This is a sentence", "thisIsASentence", NamingStrategy.Unknown)]
    public void ToCamelCase_ValidConversion(string input, string expected, NamingStrategy strategy)
    {
        string result = input.ToCamelCase(strategy);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("thisIsCamelCase", true)]
    [InlineData("ThisIsNotCamelCase", false)]
    [InlineData("this is not camel case", false)]
    [InlineData("this_is_not_camel_case", false)]
    [InlineData("this.is.not.camel.case", false)]
    [InlineData("THISISNOTCAMELCASE", false)]
    public void IsCamelCase_ValidCheck(string input, bool expected)
    {
        bool result = input.IsCamelCase();

        Assert.Equal(expected, result);
    }
}
