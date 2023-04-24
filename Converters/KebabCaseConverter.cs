using System.Text;

namespace DanWalsh.NamingStrategyConverter.Converters;

public static class KebabCaseConverter
{
    public static string ToKebabCase(this string input, NamingStrategy namingStrategy = NamingStrategy.Unknown) =>
        namingStrategy switch
        {
            NamingStrategy.PascalCase => input.ToKebabCaseFromPascalOrCamel(),
            NamingStrategy.CamelCase => input.ToKebabCaseFromPascalOrCamel(),
            NamingStrategy.KebabCase => input,
            NamingStrategy.SnakeCase => input.ToKebabCaseFromSnake(),
            NamingStrategy.UpperKebabCase => input.ToKebabCaseFromUpperKebabCase(),
            NamingStrategy.UpperSnakeCase => input.ToKebabCaseFromUpperSnakeCase(),
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

            if (isSnakeCase && !isLowerChar && c != '_') isSnakeCase = false;
            if (isKebabCase && !isLowerChar && c != '-') isKebabCase = false;
            if (isUpperCase && isLowerChar && c is not ('_' or '-')) isUpperCase = false;

            if (!isSnakeCase && !isUpperCase && !isKebabCase) break;
        }

        if (isKebabCase) return input;

        if (isSnakeCase) return input.Replace('_', '-');

        if (isUpperCase) return input.ToLowerInvariant().Replace('_', '-');

        var snakeCaseStrBuilder = new StringBuilder(input.Length + 1);
        snakeCaseStrBuilder.Append(char.ToLowerInvariant(input[0]));

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == '_')
            {
                snakeCaseStrBuilder.Append('-');

                continue;
            }

            if (char.IsUpper(currentChar)) snakeCaseStrBuilder.Append('-');

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

                if (char.IsUpper(currentChar)) span[spanIndex++] = '-';

                span[spanIndex++] = char.ToLowerInvariant(currentChar);
            }
        });
    }

    private static string ToKebabCaseFromSnake(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return string.Create(input.Length, input.ToCharArray(), (strContent, charArray) =>
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                strContent[i] = charArray[i] == '_' ? '-' : charArray[i];
            }
        });
    }

    private static string ToKebabCaseFromUpperKebabCase(this string input) => input.ToLowerInvariant();

    private static string ToKebabCaseFromUpperSnakeCase(this string input) => input.ToLowerInvariant().Replace('_', '-');

    public static bool IsKebabCase(this string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLower(c) && c != '-') return false;
        }

        return true;
    }
}