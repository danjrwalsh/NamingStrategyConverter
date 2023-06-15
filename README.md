# NamingStrategyConverter.NET
An open source naming strategy converter library for .NET Standard.

The following naming strategies are currently supported:
- PascalCase
- camelCase
- snake_case
- kebab-case
- UPPER_SNAKE_CASE
- UPPER-KEBAB-CASE

## Usage
NamingStrategyConverter.NET exposes string extension methods for each naming strategy following a `ToXCase()` syntax. For example, to convert to _camelCase_, you can use the `ToCamelCase()` method. Going from any naming strategy to another is supported.
```cs
string str = "thisWasCamelCase";

Console.WriteLine(str.ToSnakeCase());
// output: this_was_camel_case
Console.WriteLine(str.ToPascalCase());
// output: ThisWasCamelCase
Console.WriteLine(str.ToUpperKebabCase());
// output: THIS-WAS-CAMEL-CASE
```
You can optionally pass in the input naming strategy for a more optimal conversion for improved performance when applicable. In certain scenarios, the conversions can be done with zero memory allocation.
```cs
str.ToSnakeCase(NamingStrategy.CamelCase);
```
Each naming strategy also has an `IsXCase()` method that returns a boolean about whether the input follows that naming strategy.
```cs
Console.WriteLine(str.IsCamelCase());
// output: true
Console.WriteLine(str.IsSnakeCase());
// output: false
```

## Contribute
We greatly appreciate contributions from the community. We welcome any performance enhancements, bug corrections, or the introduction of new naming strategies. If you have such contributions, kindly submit a PR for our evaluation. It's worth noting that every naming strategy in this project comes with its own set of unit tests. Thus, when introducing a new strategy, we ask that you include comprehensive tests for each conversion from one strategy to another. Additionally, if you're proposing performance improvements, kindly confirm that you've conducted benchmark tests to verify the efficacy of your suggested changes.

## License
NamingStrategyConverter.NET is open source and freely available under the [MIT license](LICENSE).
