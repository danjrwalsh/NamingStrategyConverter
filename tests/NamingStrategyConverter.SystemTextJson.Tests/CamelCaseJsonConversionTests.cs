using System.Text.Json;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public sealed class CamelCaseJsonConversionTests
{
    private readonly JsonSerializerOptions _options;

    public CamelCaseJsonConversionTests()
    {
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new CamelCaseJsonNamingPolicy() };
    }

    [Fact]
    public void Serialize_ToCamelCasePropertyNames()
    {
        var testData = new TestData();

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("testProperty", json);
        Assert.DoesNotContain("TestProperty", json);
    }

    [Fact]
    public void Deserialize_FromCamelCasePropertyNames()
    {
        const string json = """{ "testProperty": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.Equal("someValue", result!.TestProperty);
    }

    [Fact]
    public void DeserializeFails_FromSnakeCasePropertyNames_ExpectedCamel()
    {
        const string json = """{ "test_property": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.NotEqual("someValue", result!.TestProperty);
    }
}