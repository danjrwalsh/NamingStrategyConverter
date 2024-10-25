using System.Text.Json;

namespace DanWalsh.NamingStrategyConverter.SystemTextJson;

public class DotCaseJsonNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) => name.ToDotCase();
}
