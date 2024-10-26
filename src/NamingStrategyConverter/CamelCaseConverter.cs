using DanWalsh.NamingStrategyConverter.Constants;
using System.Text;

namespace DanWalsh.NamingStrategyConverter;

public static class CamelCaseConverter
{
    public static string ToCamelCase(this string input, NamingStrategy namingStrategy = NamingStrategy.Unknown) =>
        namingStrategy switch
        {
            NamingStrategy.PascalCase => input.ToCamelCaseFromPascal(),
            NamingStrategy.CamelCase => input,
            NamingStrategy.KebabCase => input.ToCamelCaseFromLowerCaseDelimited(Delimiters.Dash),
            NamingStrategy.SnakeCase => input.ToCamelCaseFromLowerCaseDelimited(Delimiters.Underscore),
            NamingStrategy.UpperKebabCase => input.ToCamelCaseFromUpperCaseDelimited(Delimiters.Dash),
            NamingStrategy.UpperSnakeCase => input.ToCamelCaseFromUpperCaseDelimited(Delimiters.Underscore),
            NamingStrategy.DotCase => input.ToCamelCaseFromLowerCaseDelimited(Delimiters.Dot),
            _ => input.ToCamelCaseFromUnknown()
        };

    private static string ToCamelCaseFromUnknown(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var snakeCaseStrBuilder = new StringBuilder(input.Length);
        snakeCaseStrBuilder.Append(char.ToLowerInvariant(input[0]));

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar is Delimiters.Underscore or Delimiters.Dash or Delimiters.Dot or Delimiters.Space)
            {
                snakeCaseStrBuilder.Append(char.ToUpperInvariant(input[++i]));

                continue;
            }

            snakeCaseStrBuilder.Append(char.IsUpper(currentChar) ? currentChar : char.ToLowerInvariant(currentChar));
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

    private static string ToCamelCaseFromLowerCaseDelimited(this string input, char delimiter)
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
            span[0] = char.ToLowerInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == delimiter ? char.ToUpperInvariant(chars[++i]) : currentChar;
            }
        });
    }

    private static string ToCamelCaseFromUpperCaseDelimited(this string input, char delimiter)
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
            span[0] = char.ToLowerInvariant(chars[0]);
            short spanIndex = 1;

            for (int i = 1; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                span[spanIndex++] = currentChar == delimiter ? char.ToUpperInvariant(chars[++i]) : char.ToLowerInvariant(currentChar);
            }
        });
    }
    
    public static bool IsCamelCase(this string input)
    {
        if (!char.IsLower(input[0])) return false;

        for (int index = 1; index < input.Length; index++)
        {
            if (input[index] is Delimiters.Dash or Delimiters.Underscore or Delimiters.Dot or Delimiters.Space) return false;
        }

        return true;
    }
}
