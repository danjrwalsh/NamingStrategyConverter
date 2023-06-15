using System.Text.Json;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public class UpperSnakeCaseJsonNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToUpperSnakeCase();
}