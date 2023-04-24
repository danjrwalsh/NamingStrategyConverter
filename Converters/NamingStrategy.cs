namespace DanWalsh.NamingStrategyConverter.Converters;

public static class NamingStrategyExample
{
    public const string PascalCase = "PascalCase";
    public const string CamelCase = "camelCase";
    public const string KebabCase = "kebab-case";
    public const string SnakeCase = "snake_case";
    public const string ScreamingSnakeCase = "SCREAMING_SNAKE_CASE";
    public const string ScreamingKebabCase = "SCREAMING-KEBAB-CASE";
}

public enum NamingStrategy
{
    Unknown,
    PascalCase,
    CamelCase,
    KebabCase,
    SnakeCase,
    UpperSnakeCase,
    UpperKebabCase
}