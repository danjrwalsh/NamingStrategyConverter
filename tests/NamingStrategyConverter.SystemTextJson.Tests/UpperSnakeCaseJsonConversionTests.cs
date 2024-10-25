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
    public void Serialize_ToUpperSnakeCasePropertyNames_SomeValue()
    {
        var testData = new TestData("someValue");

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("TEST_PROPERTY", json);
        Assert.Contains("someValue", json);
    }

    [Fact]
    public void Serialize_ToUpperSnakeCasePropertyNames_Null()
    {
        var testData = new TestData(null);

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("TEST_PROPERTY", json);
        Assert.Contains("null", json);
    }

    [Fact]
    public void Serialize_ToUpperSnakeCasePropertyNames_EmptyString()
    {
        var testData = new TestData("");

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("TEST_PROPERTY", json);
        Assert.Contains("\"\"", json);
    }

    [Fact]
    public void Serialize_ToUpperSnakeCasePropertyNames_MixedCaseString()
    {
        var testData = new TestData("SomeMixedCASEString");

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("TEST_PROPERTY", json);
        Assert.Contains("SomeMixedCASEString", json);
    }

    [Fact]
    public void Serialize_ToUpperSnakeCasePropertyNames_SpecialCharacters()
    {
        var testData = new TestData("Special@#%&*()Characters");

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("TEST_PROPERTY", json);
        Assert.Contains("Special@#%&*()Characters", json);
    }

    [Fact]
    public void Serialize_ToUpperSnakeCasePropertyNames_Numbers()
    {
        var testData = new TestData("StringWith123Numbers");

        string json = JsonSerializer.Serialize(testData, _options);

        Assert.Contains("TEST_PROPERTY", json);
        Assert.Contains("StringWith123Numbers", json);
    }

    [Theory]
    [InlineData("""{ "TEST_PROPERTY": "someValue" }""", "someValue")]
    [InlineData("""{ "test_property": "someValue" }""", null)]
    public void Deserialize_FromUpperSnakeCasePropertyNames(string json, string expectedValue)
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
