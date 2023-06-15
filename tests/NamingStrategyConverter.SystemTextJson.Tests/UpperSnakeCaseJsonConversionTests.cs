using System.Text.Json;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public sealed class UpperSnakeCaseJsonConversionTests
{
    private readonly JsonSerializerOptions _options;

    public UpperSnakeCaseJsonConversionTests()
    {
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new UpperSnakeCaseJsonNamingPolicy() };
    }

    [Fact]
    public void Serialize_ToUpperSnakeCasePropertyNames()
    {
        var testData = new TestData();

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("TEST_PROPERTY", json);
        Assert.DoesNotContain("testProperty", json);
    }

    [Fact]
    public void Deserialize_FromUpperSnakeCasePropertyNames()
    {
        const string json = """{ "TEST_PROPERTY": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.Equal("someValue", result!.TestProperty);
    }

    [Fact]
    public void DeserializeFails_FromCamelCasePropertyNames_ExpectedUpperSnake()
    {
        const string json = """{ "testProperty": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.NotEqual("someValue", result!.TestProperty);
    }
}