using System.Text;

namespace DanWalsh.NamingStrategyConverter.Converters;

public static class CamelCaseConverter
{
    public static string ToCamelCase(this string input, NamingStrategy namingStrategy = NamingStrategy.Unknown) =>
        namingStrategy switch
        {
            NamingStrategy.PascalCase => input.ToCamelCaseFromPascal(),
            NamingStrategy.CamelCase => input,
            NamingStrategy.KebabCase => input.ToCamelCaseFromKebab(),
            NamingStrategy.SnakeCase => input.ToCamelCaseFromSnake(),
            NamingStrategy.UpperKebabCase => input.ToCamelCaseFromUpperKebabCase(),
            NamingStrategy.UpperSnakeCase => input.ToCamelCaseFromUpperSnakeCase(),
            _ => input.ToCamelCaseFromUnknown()
        };

    private static string ToCamelCaseFromUnknown(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var snakeCaseStrBuilder = new StringBuilder(input.Length);
        snakeCaseStrBuilder.Append(char.ToLowerInvariant(input[0]));

        bool wasUpperCase = true;

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar is '_' or '-')
            {
                snakeCaseStrBuilder.Append(char.ToUpperInvariant(input[++i]));

                continue;
            }

            if (char.IsUpper(currentChar) && !wasUpperCase)
                snakeCaseStrBuilder.Append(currentChar);
            else
                snakeCaseStrBuilder.Append(char.ToLowerInvariant(currentChar));

            wasUpperCase = char.IsUpper(currentChar);
        }

        return snakeCaseStrBuilder.ToString();
    }

    private static string ToCamelCaseFromPascal(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return string.Create(input.Length, input.ToCharArray(), (span, chars) =>
        {
            span[0] = char.ToLowerInvariant(chars[0]);

            for (int i = 1; i < chars.Length; i++)
            {
                span[i] = chars[i];
            }
        });
    }

    private static string ToCamelCaseFromKebab(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        int delimiters = 0;

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == '-') delimiters++;
        }

        return string.Create(input.Length - delimiters, input.ToCharArray(), (span, chars) =>
        {
            span[0] = char.ToLowerInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == '-' ? char.ToUpperInvariant(chars[++i]) : currentChar;
            }
        });
    }

    private static string ToCamelCaseFromSnake(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        int delimiters = 0;

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == '_') delimiters++;
        }

        return string.Create(input.Length - delimiters, input.ToCharArray(), (span, chars) =>
        {
            span[0] = char.ToLowerInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == '_' ? char.ToUpperInvariant(chars[++i]) : currentChar;
            }
        });
    }

    private static string ToCamelCaseFromUpperKebabCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        int delimiters = 0;

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == '-') delimiters++;
        }

        return string.Create(input.Length - delimiters, input.ToCharArray(), (span, chars) =>
        {
            span[0] = char.ToLowerInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == '-' ? chars[++i] : char.ToLowerInvariant(currentChar);
            }
        });
    }

    private static string ToCamelCaseFromUpperSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        int delimiters = 0;

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == '_') delimiters++;
        }

        return string.Create(input.Length - delimiters, input.ToCharArray(), (span, chars) =>
        {
            span[0] = char.ToLowerInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == '_' ? chars[++i] : char.ToLowerInvariant(currentChar);
            }
        });
    }

    public static bool IsCamelCase(this string input)
    {
        if (!char.IsLower(input[0])) return false;

        for (int index = 1; index < input.Length; index++)
        {
            if (input[index] is '-' or '_') return false;
        }

        return true;
    }
}