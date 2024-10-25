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
    public void Serialize_ToCamelCasePropertyNames_SomeValue()
    {
        var testData = new TestData("someValue");

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("testProperty", json);
        Assert.Contains("someValue", json);
    }

    [Fact]
    public void Serialize_ToCamelCasePropertyNames_Null()
    {
        var testData = new TestData(null);

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("test_property", json);
        Assert.Contains("null", json);
    }

    [Fact]
    public void Serialize_ToCamelCasePropertyNames_EmptyString()
    {
        var testData = new TestData("");

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("testProperty", json);
        Assert.Contains("\"\"", json);
    }

    [Fact]
    public void Serialize_ToCamelCasePropertyNames_MixedCaseString()
    {
        var testData = new TestData("SomeMixedCASEString");

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("testProperty", json);
        Assert.Contains("SomeMixedCASEString", json);
    }

    [Fact]
    public void Serialize_ToCamelCasePropertyNames_SpecialCharacters()
    {
        var testData = new TestData("Special@#%&*()Characters");

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("testProperty", json);
        Assert.Contains("Special@#%&*()Characters", json);
    }

    [Fact]
    public void Serialize_ToCamelCasePropertyNames_Numbers()
    {
        var testData = new TestData("StringWith123Numbers");

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("testProperty", json);
        Assert.Contains("StringWith123Numbers", json);
    }

    [Theory]
    [InlineData("""{ "testProperty": "someValue" }""", "someValue")]
    [InlineData("""{ "test_property": "someValue" }""", null)]
    public void Deserialize_FromCamelCasePropertyNames(string json, string expectedValue)
    {
        var result = JsonSerializer.Deserialize<TestData>(json, _options);

        if (expectedValue != null)
        {
            Assert.Equal(expectedValue, result!.TestProperty);
        }
        else
        {
            Assert.NotEqual("someValue", result!.TestProperty);
        }
    }
}
