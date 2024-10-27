using DanWalsh.NamingStrategyConverter.Constants;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.Tests;

public class SnakeCaseConversionTests
{
    [Theory]
    [InlineData("ThisWasPascalCase", "this_was_pascal_case", NamingStrategy.PascalCase)]
    [InlineData("thisWasCamelCase", "this_was_camel_case", NamingStrategy.CamelCase)]
    [InlineData("this-was-kebab-case", "this_was_kebab_case", NamingStrategy.KebabCase)]
    [InlineData("THIS-WAS-UPPER-KEBAB-CASE", "this_was_upper_kebab_case", NamingStrategy.UpperKebabCase)]
    [InlineData("THIS_WAS_UPPER_SNAKE_CASE", "this_was_upper_snake_case", NamingStrategy.UpperSnakeCase)]
    [InlineData("this_was_snake_case", "this_was_snake_case", NamingStrategy.SnakeCase)]
    [InlineData("THISWASUPPERCASE", "thiswasuppercase", NamingStrategy.Unknown)]
    [InlineData("thiswaslowercase", "thiswaslowercase", NamingStrategy.Unknown)]
    [InlineData("", "", NamingStrategy.Unknown)]
    [InlineData("SomeMixedCASEString", "some_mixed_c_a_s_e_string", NamingStrategy.Unknown)]
    [InlineData("Special@#%&*()Characters", "special@#%&*()_characters", NamingStrategy.Unknown)]
    [InlineData("StringWith123Numbers", "string_with123_numbers", NamingStrategy.Unknown)]
    public void ToSnakeCase_ValidConversion(string input, string expected, NamingStrategy strategy)
    {
        string result = input.ToSnakeCase(strategy);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("thisIsNotSnakeCase", false)]
    [InlineData("ThisIsNotSnakeCase", false)]
    [InlineData("this is not snake case", false)]
    [InlineData("this_is_snake_case", true)]
    [InlineData("this-is-not-snake-case", false)]
    [InlineData("this.is.not.snake.case", false)]
    [InlineData("THISISNOTSNAKECASE", false)]
    public void IsSnakeCase_ValidCheck(string input, bool expected)
    {
        bool result = input.IsSnakeCase();

        Assert.Equal(expected, result);
    }
}
