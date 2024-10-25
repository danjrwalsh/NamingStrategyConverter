using DanWalsh.NamingStrategyConverter.Constants;
using System.Text;

namespace DanWalsh.NamingStrategyConverter;

public static class SnakeCaseConverter
{
    public static string ToSnakeCase(this string input, NamingStrategy namingStrategy = NamingStrategy.Unknown) =>
        namingStrategy switch
        {
            NamingStrategy.PascalCase => input.ToSnakeCaseFromPascalOrCamel(),
            NamingStrategy.CamelCase => input.ToSnakeCaseFromPascalOrCamel(),
            NamingStrategy.KebabCase => input.ToSnakeCaseFromLowerCaseDelimited(Delimiters.Dash),
            NamingStrategy.SnakeCase => input,
            NamingStrategy.UpperKebabCase => input.ToSnakeCaseFromUpperKebabCase(),
            NamingStrategy.UpperSnakeCase => input.ToSnakeCaseFromUpperSnakeCase(),
            NamingStrategy.DotCase => input.ToSnakeCaseFromLowerCaseDelimited(Delimiters.Dot),
            _ => input.ToSnakeCaseFromUnknown()
        };

    private static string ToSnakeCaseFromUnknown(this string input)
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

        if (isSnakeCase) return input;

        if (isKebabCase) return input.Replace(Delimiters.Dash, Delimiters.Underscore);

        if (isUpperCase) return input.ToLowerInvariant().Replace(Delimiters.Dash, Delimiters.Underscore);

        var snakeCaseStrBuilder = new StringBuilder(input.Length + 1);
        snakeCaseStrBuilder.Append(char.ToLowerInvariant(input[0]));

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == Delimiters.Dash)
            {
                snakeCaseStrBuilder.Append(Delimiters.Underscore);

                continue;
            }

            if (char.IsUpper(currentChar)) snakeCaseStrBuilder.Append(Delimiters.Underscore);

            snakeCaseStrBuilder.Append(char.ToLowerInvariant(currentChar));
        }

        return snakeCaseStrBuilder.ToString();
    }

    private static string ToSnakeCaseFromPascalOrCamel(this string input)
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
            span[0] = char.ToLowerInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];

                if (char.IsUpper(currentChar)) span[spanIndex++] = Delimiters.Underscore;

                span[spanIndex++] = char.ToLowerInvariant(currentChar);
            }
        });
    }

    private static string ToSnakeCaseFromLowerCaseDelimited(this string input, char delimiter)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return string.Create(input.Length, input.ToCharArray(), (strContent, charArray) =>
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                strContent[i] = charArray[i] == Delimiters.Dash ? delimiter : charArray[i];
            }
        });
    }

    private static string ToSnakeCaseFromUpperKebabCase(this string input) => input.ToLowerInvariant().Replace(Delimiters.Dash, Delimiters.Underscore);

    private static string ToSnakeCaseFromUpperSnakeCase(this string input) => input.ToLowerInvariant();

    public static bool IsSnakeCase(this string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLower(c) && c != Delimiters.Underscore) return false;
        }

        return true;
    }
}
