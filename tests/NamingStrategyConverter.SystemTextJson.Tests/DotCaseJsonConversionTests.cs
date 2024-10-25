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

    [Theory]
    [InlineData("test.property", "someValue")]
    [InlineData("test_property", null)]
    [InlineData("test.property", "")]
    [InlineData("test.property", "SomeMixedCASEString")]
    [InlineData("test.property", "Special@#%&*()Characters")]
    [InlineData("test.property", "StringWith123Numbers")]
    public void Serialize_ToDotCasePropertyNames(string propertyName, string propertyValue)
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
    [InlineData("""{ "test.property": "someValue" }""", "someValue")]
    [InlineData("""{ "test_property": "someValue" }""", null)]
    public void Deserialize_FromDotCasePropertyNames(string json, string expectedValue)
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
