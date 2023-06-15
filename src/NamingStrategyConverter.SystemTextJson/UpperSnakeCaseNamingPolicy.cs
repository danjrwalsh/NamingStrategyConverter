using System.Text.Json;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public class UpperSnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToUpperSnakeCase();
}