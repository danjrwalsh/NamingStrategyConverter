using System.Text.Json;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public class CamelCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToCamelCase();
}