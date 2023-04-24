using System.Text;

namespace DanWalsh.NamingStrategyConverter.Converters;

public static class PascalCaseConverter
{
    public static string ToPascalCase(this string input, NamingStrategy namingStrategy = NamingStrategy.Unknown) =>
        namingStrategy switch
        {
            NamingStrategy.PascalCase => input,
            NamingStrategy.CamelCase => input.ToPascalCaseFromCamel(),
            NamingStrategy.KebabCase => input.ToPascalCaseFromKebab(),
            NamingStrategy.SnakeCase => input.ToPascalCaseFromSnake(),
            NamingStrategy.UpperKebabCase => input.ToPascalCaseFromUpperKebabCase(),
            NamingStrategy.UpperSnakeCase => input.ToPascalCaseFromUpperSnakeCase(),
            _ => input.ToPascalCaseFromUnknown()
        };

    private static string ToPascalCaseFromUnknown(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        bool hasDelimiter = false;
        
        foreach(char c in input)
        {
            if (c is '-' or '_')
            {
                hasDelimiter = true;

                break;
            }
        }
        
        if (!hasDelimiter && char.IsUpper(input[0]) && !char.IsUpper(input[1])) return input;

        var snakeCaseStrBuilder = new StringBuilder(input.Length);
        snakeCaseStrBuilder.Append(char.ToUpperInvariant(input[0]));

        bool wasUpperCase = true;

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar is '_' or '-')
            {
                snakeCaseStrBuilder.Append(char.ToUpperInvariant(input[++i]));

                continue;
            }

            bool isUpperCase = char.IsUpper(currentChar);

            if (isUpperCase && !wasUpperCase)
                snakeCaseStrBuilder.Append(currentChar);
            else
                snakeCaseStrBuilder.Append(char.ToLowerInvariant(currentChar));

            wasUpperCase = isUpperCase;
        }

        return snakeCaseStrBuilder.ToString();
    }

    private static string ToPascalCaseFromCamel(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return string.Create(input.Length, input.ToCharArray(), (span, chars) =>
        {
            span[0] = char.ToUpperInvariant(chars[0]);

            for (int i = 1; i < chars.Length; i++)
            {
                span[i] = chars[i];
            }
        });
    }

    private static string ToPascalCaseFromKebab(this string input)
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
            span[0] = char.ToUpperInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == '-' ? char.ToUpperInvariant(chars[++i]) : currentChar;
            }
        });
    }

    private static string ToPascalCaseFromSnake(this string input)
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
            span[0] = char.ToUpperInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == '_' ? char.ToUpperInvariant(chars[++i]) : currentChar;
            }
        });
    }

    private static string ToPascalCaseFromUpperKebabCase(this string input)
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
            span[0] = chars[0];
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == '-' ? chars[++i] : char.ToLowerInvariant(currentChar);
            }
        });
    }

    private static string ToPascalCaseFromUpperSnakeCase(this string input)
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
            span[0] = chars[0];
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == '_' ? chars[++i] : char.ToLowerInvariant(currentChar);
            }
        });
    }

    public static bool IsPascalCase(this string input)
    {
        if (!char.IsUpper(input[0])) return false;

        for (int index = 1; index < input.Length; index++)
        {
            if (input[index] is '-' or '_') return false;
        }

        return true;
    }
}