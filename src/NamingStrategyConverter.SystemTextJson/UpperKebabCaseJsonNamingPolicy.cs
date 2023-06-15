using System.Text.Json;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public class UpperKebabCaseJsonNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToUpperKebabCase();
}