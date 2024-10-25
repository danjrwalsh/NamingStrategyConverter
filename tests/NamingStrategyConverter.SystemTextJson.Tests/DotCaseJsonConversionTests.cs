using System.Text.Json;
using Xunit;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public sealed class DotCaseJsonConversionTests
{
    private readonly JsonSerializerOptions _options;

    public DotCaseJsonConversionTests()
    {
        _options = new JsonSerializerOptions { PropertyNamingPolicy = new DotCaseJsonNamingPolicy() };
    }

    [Fact]
    public void Serialize_ToDotCasePropertyNames()
    {
        var testData = new TestData();

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("test.property", json);
        Assert.DoesNotContain("testProperty", json);
    }

    [Fact]
    public void Deserialize_FromDotCasePropertyNames()
    {
        const string json = """{ "test.property": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.Equal("someValue", result!.TestProperty);
    }

    [Fact]
    public void DeserializeFails_FromSnakeCasePropertyNames_ExpectedDot()
    {
        const string json = """{ "test_property": "someValue" }""";

        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        Assert.NotEqual("someValue", result!.TestProperty);
    }
}
