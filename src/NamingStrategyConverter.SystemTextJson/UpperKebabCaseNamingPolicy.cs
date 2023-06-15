using System.Text.Json;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public class UpperKebabCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToUpperKebabCase();
}