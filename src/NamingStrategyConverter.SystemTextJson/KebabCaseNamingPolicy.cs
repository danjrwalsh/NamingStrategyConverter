using System.Text.Json;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public class KebabCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToKebabCase();
}