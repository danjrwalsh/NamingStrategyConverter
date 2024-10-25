using DanWalsh.NamingStrategyConverter.Constants;
using System.Text;

namespace DanWalsh.NamingStrategyConverter;

public static class KebabCaseConverter
{
    public static string ToKebabCase(this string input, NamingStrategy namingStrategy = NamingStrategy.Unknown) =>
        namingStrategy switch
        {
            NamingStrategy.PascalCase => input.ToKebabCaseFromPascalOrCamel(),
            NamingStrategy.CamelCase => input.ToKebabCaseFromPascalOrCamel(),
            NamingStrategy.KebabCase => input,
            NamingStrategy.SnakeCase => input.ToKebabCaseFromLowerCaseDelimited(Delimiters.Underscore),
            NamingStrategy.UpperKebabCase => input.ToKebabCaseFromUpperKebab(),
            NamingStrategy.UpperSnakeCase => input.ToKebabCaseFromUpperSnakeCase(),
            NamingStrategy.DotCase => input.ToKebabCaseFromLowerCaseDelimited(Delimiters.Dot),
            _ => input.ToKebabCaseFromUnknown()
        };

    private static string ToKebabCaseFromUnknown(this string input)
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

        if (isKebabCase) return input;

        if (isSnakeCase) return input.Replace(Delimiters.Underscore, Delimiters.Dash);

        if (isUpperCase) return input.ToLowerInvariant().Replace(Delimiters.Underscore, Delimiters.Dash);

        var snakeCaseStrBuilder = new StringBuilder(input.Length + 1);
        snakeCaseStrBuilder.Append(char.ToLowerInvariant(input[0]));

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == Delimiters.Underscore)
            {
                snakeCaseStrBuilder.Append(Delimiters.Dash);

                continue;
            }

            if (char.IsUpper(currentChar)) snakeCaseStrBuilder.Append(Delimiters.Dash);

            snakeCaseStrBuilder.Append(char.ToLowerInvariant(currentChar));
        }

        return snakeCaseStrBuilder.ToString();
    }

    private static string ToKebabCaseFromPascalOrCamel(this string input)
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

                if (char.IsUpper(currentChar)) span[spanIndex++] = Delimiters.Dash;

                span[spanIndex++] = char.ToLowerInvariant(currentChar);
            }
        });
    }

    private static string ToKebabCaseFromLowerCaseDelimited(this string input, char delimiter)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return string.Create(input.Length, input.ToCharArray(), (strContent, charArray) =>
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                strContent[i] = charArray[i] == delimiter ? Delimiters.Dash : charArray[i];
            }
        });
    }

    private static string ToKebabCaseFromUpperKebab(this string input) => input.ToLowerInvariant();

    private static string ToKebabCaseFromUpperSnakeCase(this string input) => input.ToLowerInvariant().Replace(Delimiters.Underscore, Delimiters.Dash);

    public static bool IsKebabCase(this string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLower(c) && c != Delimiters.Dash) return false;
        }

        return true;
    }
}
