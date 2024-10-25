using DanWalsh.NamingStrategyConverter.Constants;
using System.Text;

namespace DanWalsh.NamingStrategyConverter;

public static class DotCaseConverter
{
    public static string ToDotCase(this string input, NamingStrategy namingStrategy = NamingStrategy.Unknown) =>
        namingStrategy switch
        {
            NamingStrategy.PascalCase => input.ToDotCaseFromPascalOrCamel(),
            NamingStrategy.CamelCase => input.ToDotCaseFromPascalOrCamel(),
            NamingStrategy.KebabCase => input.ToDotCaseFromLowerCaseDelimited(Delimiters.Dash),
            NamingStrategy.SnakeCase => input.ToDotCaseFromLowerCaseDelimited(Delimiters.Underscore),
            NamingStrategy.UpperKebabCase => input.ToDotCaseFromUpperCaseDelimited(Delimiters.Dash),
            NamingStrategy.UpperSnakeCase => input.ToDotCaseFromUpperCaseDelimited(Delimiters.Underscore),
            NamingStrategy.DotCase => input,
            _ => input.ToDotCaseFromUnknown()
        };

    private static string ToDotCaseFromUnknown(this string input)
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

        if (isSnakeCase) return input.Replace(Delimiters.Underscore, Delimiters.Dot);

        if (isKebabCase) return input.Replace(Delimiters.Dash, Delimiters.Dot);

        if (isUpperCase) return input.ToLowerInvariant().Replace(Delimiters.Underscore, Delimiters.Dot).Replace(Delimiters.Dash, Delimiters.Dot);

        var dotCaseStrBuilder = new StringBuilder(input.Length + 1);
        dotCaseStrBuilder.Append(char.ToLowerInvariant(input[0]));

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (currentChar == Delimiters.Underscore || currentChar == Delimiters.Dash)
            {
                dotCaseStrBuilder.Append(Delimiters.Dot);

                continue;
            }

            if (char.IsUpper(currentChar)) dotCaseStrBuilder.Append(Delimiters.Dot);

            dotCaseStrBuilder.Append(char.ToLowerInvariant(currentChar));
        }

        return dotCaseStrBuilder.ToString();
    }

    private static string ToDotCaseFromPascalOrCamel(this string input)
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

                if (char.IsUpper(currentChar)) span[spanIndex++] = Delimiters.Dot;

                span[spanIndex++] = char.ToLowerInvariant(currentChar);
            }
        });
    }

    private static string ToDotCaseFromLowerCaseDelimited(this string input, char delimiter)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return string.Create(input.Length, input.ToCharArray(), (strContent, charArray) =>
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                strContent[i] = charArray[i] == delimiter ? Delimiters.Dot : charArray[i];
            }
        });
    }

    private static string ToDotCaseFromUpperCaseDelimited(this string input, char delimiter)
    {
        if (string.IsNullOrEmpty(input)) return input;

        return string.Create(input.Length, input.ToCharArray(), (strContent, charArray) =>
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                strContent[i] = charArray[i] == delimiter ? Delimiters.Dot : char.ToLowerInvariant(charArray[i]);
            }
        });
    }
    
    public static bool IsDotCase(this string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLower(c) && c != Delimiters.Dot) return false;
        }

        return true;
    }
}
