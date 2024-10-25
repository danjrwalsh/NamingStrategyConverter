using System.Text.Json;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public sealed class UpperKebabCaseJsonConversionTests
{
    private readonly JsonSerializerOptions _options;

    public UpperKebabCaseJsonConversionTests()
    {
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new UpperKebabCaseJsonNamingPolicy() };
    }

    [Fact]
    public void Serialize_ToUpperKebabCasePropertyNames()
    {
        var testData = new TestData();

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("TEST-PROPERTY", json);
        Assert.DoesNotContain("testProperty", json);
    }

    [Fact]
    public void Deserialize_FromUpperKebabCasePropertyNames()
    {
        const string json = """{ "TEST-PROPERTY": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.Equal("someValue", result!.TestProperty);
    }

    [Fact]
    public void DeserializeFails_FromSnakeCasePropertyNames_ExpectedUpperKebab()
    {
        const string json = """{ "test_property": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.NotEqual("someValue", result!.TestProperty);
    }
}