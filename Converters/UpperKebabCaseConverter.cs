using System.Text;

namespace DanWalsh.NamingStrategyConverter.Converters;

public static class UpperKebabCaseConverter
{
    public static string ToUpperKebabCase(this string input, NamingStrategy namingStrategy = NamingStrategy.Unknown) =>
        namingStrategy switch
        {
            NamingStrategy.PascalCase => input.ToUpperKebabCaseFromPascalOrCamel(),
            NamingStrategy.CamelCase => input.ToUpperKebabCaseFromPascalOrCamel(),
            NamingStrategy.KebabCase => input.ToUpperKebabCaseFromKebab(),
            NamingStrategy.SnakeCase => input.ToUpperKebabCaseFromSnakeCase(),
            NamingStrategy.UpperKebabCase => input,
            NamingStrategy.UpperSnakeCase => input.ToUpperKebabCaseFromUpperSnakeCase(),
            _ => input.ToUpperKebabCaseFromUnknown()
        };

    private static string ToUpperKebabCaseFromUnknown(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        bool isSnakeCase = true;
        bool isKebabCase = true;
        bool isUpperCase = true;

        foreach (char c in input)
        {
            bool isLowerChar = char.IsLower(c);

            if (isSnakeCase && !isLowerChar && c != '_') isSnakeCase = false;
            if (isKebabCase && !isLowerChar && c != '-') isKebabCase = false;
            if (isUpperCase && isLowerChar && c is not ('_' or '-')) isUpperCase = false;

            if (!isSnakeCase && !isUpperCase && !isKebabCase) break;
        }

        if (isSnakeCase) return input.ToUpperKebabCaseFromSnakeCase();

        if (isKebabCase) return input.ToUpperKebabCaseFromKebab();

        if (isUpperCase) return input.ToUpperKebabCaseFromUpperSnakeCase();

        var snakeCaseStrBuilder = new StringBuilder(input.Length + 1);
        snakeCaseStrBuilder.Append(char.ToUpperInvariant(input[0]));

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == '_')
            {
                snakeCaseStrBuilder.Append('-');

                continue;
            }

            if (char.IsUpper(currentChar)) snakeCaseStrBuilder.Append('-');

            snakeCaseStrBuilder.Append(char.ToUpperInvariant(currentChar));
        }

        return snakeCaseStrBuilder.ToString();
    }

    private static string ToUpperKebabCaseFromPascalOrCamel(this string input)
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

                if (char.IsUpper(currentChar))
                {
                    span[spanIndex++] = '-';
                }

                span[spanIndex++] = char.ToUpperInvariant(currentChar);
            }
        });
    }

    private static string ToUpperKebabCaseFromKebab(this string input) => input.ToUpperInvariant();

    private static string ToUpperKebabCaseFromUpperSnakeCase(this string input) => input.Replace('_', '-');

    private static string ToUpperKebabCaseFromSnakeCase(this string input) => input.ToUpperInvariant().Replace('_', '-');

    public static bool IsUpperKebabCase(this string input)
    {
        foreach (char c in input)
        {
            if (!char.IsUpper(c) && c != '-') return false;
        }

        return true;
    }
}