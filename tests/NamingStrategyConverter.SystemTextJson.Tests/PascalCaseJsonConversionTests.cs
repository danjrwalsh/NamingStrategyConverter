using System.Text.Json;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public sealed class PascalCaseJsonConversionTests
{
    private readonly JsonSerializerOptions _options;

    public PascalCaseJsonConversionTests()
    {
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new PascalCaseJsonNamingPolicy() };
    }

    [Fact]
    public void Serialize_ToPascalCasePropertyNames()
    {
        var testData = new TestData();

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("TestProperty", json);
        Assert.DoesNotContain("testProperty", json);
    }

    [Fact]
    public void Deserialize_FromPascalCasePropertyNames()
    {
        const string json = """{ "TestProperty": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.Equal("someValue", result!.TestProperty);
    }

    [Fact]
    public void DeserializeFails_FromSnakeCasePropertyNames_ExpectedPascal()
    {
        const string json = """{ "test_property": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.NotEqual("someValue", result!.TestProperty);
    }
}