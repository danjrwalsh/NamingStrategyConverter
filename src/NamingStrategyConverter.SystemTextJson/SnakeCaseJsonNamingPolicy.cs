using System.Text.Json;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public class SnakeCaseJsonNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToSnakeCase();
}