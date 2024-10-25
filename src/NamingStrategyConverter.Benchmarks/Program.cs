using BenchmarkDotNet.Running;
using DanWalsh.NamingStrategyConverter.Benchmarks;

BenchmarkRunner.Run<PascalCaseBenchmarks>();
BenchmarkRunner.Run<CamelCaseBenchmarks>();
BenchmarkRunner.Run<KebabCaseBenchmarks>();
BenchmarkRunner.Run<SnakeCaseBenchmarks>();
BenchmarkRunner.Run<UpperKebabCaseBenchmarks>();
BenchmarkRunner.Run<UpperSnakeCaseBenchmarks>();
BenchmarkRunner.Run<DotCaseBenchmarks>();
