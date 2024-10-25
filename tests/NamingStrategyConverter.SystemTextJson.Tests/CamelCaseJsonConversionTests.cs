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

    [Theory]
    [InlineData("testProperty", "someValue")]
    [InlineData("test_property", null)]
    [InlineData("testProperty", "")]
    [InlineData("testProperty", "SomeMixedCASEString")]
    [InlineData("testProperty", "Special@#%&*()Characters")]
    [InlineData("testProperty", "StringWith123Numbers")]
    public void Serialize_ToCamelCasePropertyNames(string propertyName, string propertyValue)
    {
        var testData = new TestData(propertyValue);

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains(propertyName, json);
        if (propertyValue != null)
        {
            Assert.Contains(propertyValue, json);
        }
        else
        {
            Assert.Contains("null", json);
        }
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
