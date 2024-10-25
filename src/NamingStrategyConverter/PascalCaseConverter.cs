using DanWalsh.NamingStrategyConverter.Constants;
using System.Text;

namespace DanWalsh.NamingStrategyConverter;

public static class PascalCaseConverter
{
    public static string ToPascalCase(this string input, NamingStrategy namingStrategy = NamingStrategy.Unknown) =>
        namingStrategy switch
        {
            NamingStrategy.PascalCase => input,
            NamingStrategy.CamelCase => input.ToPascalCaseFromCamel(),
            NamingStrategy.KebabCase => input.ToPascalCaseFromLowerCaseDelimited(Delimiters.Dash),
            NamingStrategy.SnakeCase => input.ToPascalCaseFromLowerCaseDelimited(Delimiters.Underscore),
            NamingStrategy.UpperKebabCase => input.ToPascalCaseFromUpperCaseDelimited(Delimiters.Dash),
            NamingStrategy.UpperSnakeCase => input.ToPascalCaseFromUpperCaseDelimited(Delimiters.Underscore),
            NamingStrategy.DotCase => input.ToPascalCaseFromLowerCaseDelimited(Delimiters.Dot),
            _ => input.ToPascalCaseFromUnknown()
        };

    private static string ToPascalCaseFromUnknown(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        bool hasDelimiter = false;

        foreach (char c in input)
        {
            if (c is Delimiters.Dash or Delimiters.Underscore)
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

            if (currentChar is Delimiters.Underscore or Delimiters.Dash or Delimiters.Dot)
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

    private static string ToPascalCaseFromLowerCaseDelimited(this string input, char delimiter)
    {
        if (string.IsNullOrEmpty(input)) return input;

        int delimiters = 0;

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == delimiter) delimiters++;
        }

        return string.Create(input.Length - delimiters, input.ToCharArray(), (span, chars) =>
        {
            span[0] = char.ToUpperInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == delimiter ? char.ToUpperInvariant(chars[++i]) : currentChar;
            }
        });
    }
    
    private static string ToPascalCaseFromUpperCaseDelimited(this string input, char delimiter)
    {
        if (string.IsNullOrEmpty(input)) return input;

        int delimiters = 0;

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == delimiter) delimiters++;
        }

        return string.Create(input.Length - delimiters, input.ToCharArray(), (span, chars) =>
        {
            span[0] = chars[0];
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == delimiter ? chars[++i] : char.ToLowerInvariant(currentChar);
            }
        });
    }

    public static bool IsPascalCase(this string input)
    {
        if (!char.IsUpper(input[0])) return false;

        for (int index = 1; index < input.Length; index++)
        {
            if (input[index] is Delimiters.Dash or Delimiters.Underscore or Delimiters.Dot) return false;
        }

        return true;
    }
}
