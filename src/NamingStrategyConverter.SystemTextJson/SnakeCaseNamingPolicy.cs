using System.Text.Json;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToSnakeCase();
}