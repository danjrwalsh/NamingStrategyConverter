using System.Text.Json;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public class PascalCaseJsonNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToPascalCase();
}