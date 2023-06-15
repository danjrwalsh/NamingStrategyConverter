using DanWalsh.NamingStrategyConverter.Constants;
using System.Text;

namespace DanWalsh.NamingStrategyConverter;

public static class UpperSnakeCaseConverter
{
    public static string ToUpperSnakeCase(this string input, NamingStrategy namingStrategy = NamingStrategy.Unknown) =>
        namingStrategy switch
        {
            NamingStrategy.PascalCase => input.ToUpperSnakeCaseFromPascalOrCamel(),
            NamingStrategy.CamelCase => input.ToUpperSnakeCaseFromPascalOrCamel(),
            NamingStrategy.KebabCase => input.ToUpperSnakeCaseFromKebab(),
            NamingStrategy.SnakeCase => input.ToUpperSnakeCaseFromSnakeCase(),
            NamingStrategy.UpperKebabCase => input.ToUpperSnakeCaseFromUpperKebabCase(),
            NamingStrategy.UpperSnakeCase => input,
            _ => input.ToUpperSnakeCaseFromUnknown()
        };

    private static string ToUpperSnakeCaseFromUnknown(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        bool isSnakeCase = true;
        bool isKebabCase = true;
        bool isUpperCase = true;

        foreach (char c in input)
        {
            bool isLowerChar = char.IsLower(c);

            if (isSnakeCase && !isLowerChar && c != Delimiters.Underscore) isSnakeCase = false;
            if (isKebabCase && !isLowerChar && c != Delimiters.Dash) isKebabCase = false;
            if (isUpperCase && isLowerChar && c is not (Delimiters.Underscore or Delimiters.Dash)) isUpperCase = false;

            if (!isSnakeCase && !isUpperCase && !isKebabCase) break;
        }

        if (isSnakeCase) return input.ToUpperSnakeCaseFromSnakeCase();

        if (isKebabCase) return input.ToUpperSnakeCaseFromKebab();

        if (isUpperCase) return input.ToUpperSnakeCaseFromUpperKebabCase();

        var snakeCaseStrBuilder = new StringBuilder(input.Length + 1);
        snakeCaseStrBuilder.Append(char.ToUpperInvariant(input[0]));

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == Delimiters.Dash)
            {
                snakeCaseStrBuilder.Append(Delimiters.Underscore);

                continue;
            }

            if (char.IsUpper(currentChar)) snakeCaseStrBuilder.Append(Delimiters.Underscore);

            snakeCaseStrBuilder.Append(char.ToUpperInvariant(currentChar));
        }

        return snakeCaseStrBuilder.ToString();
    }

    private static string ToUpperSnakeCaseFromPascalOrCamel(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        int tokens = 0;

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (char.IsUpper(currentChar)) tokens++;
        }

        return string.Create(input.Length + tokens, input.ToCharArray(), (span, chars) =>
        {
            span[0] = char.ToUpperInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];

                if (char.IsUpper(currentChar)) span[spanIndex++] = Delimiters.Underscore;

                span[spanIndex++] = char.ToUpperInvariant(currentChar);
            }
        });
    }

    private static string ToUpperSnakeCaseFromKebab(this string input) => input.ToUpperInvariant().Replace(Delimiters.Dash, Delimiters.Underscore);

    private static string ToUpperSnakeCaseFromUpperKebabCase(this string input) => input.Replace(Delimiters.Dash, Delimiters.Underscore);

    private static string ToUpperSnakeCaseFromSnakeCase(this string input) => input.ToUpperInvariant();

    public static bool IsUpperSnakeCase(this string input)
    {
        foreach (char c in input)
        {
            if (!char.IsUpper(c) && c != Delimiters.Underscore) return false;
        }

        return true;
    }
}