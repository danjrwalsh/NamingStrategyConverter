using System.Text.Json;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public sealed class SnakeCaseJsonConversionTests
{
    private readonly JsonSerializerOptions _options;

    public SnakeCaseJsonConversionTests()
    {
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy() };
    }

    [Fact]
    public void Serialize_ToSnakeCasePropertyNames()
    {
        var testData = new TestData();

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("test_property", json);
        Assert.DoesNotContain("testProperty", json);
    }

    [Fact]
    public void Deserialize_FromSnakeCasePropertyNames()
    {
        const string json = """{ "test_property": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.Equal("someValue", result!.TestProperty);
    }

    [Fact]
    public void DeserializeFails_FromCamelCasePropertyNames_ExpectedSnake()
    {
        const string json = """{ "testProperty": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.NotEqual("someValue", result!.TestProperty);
    }
}