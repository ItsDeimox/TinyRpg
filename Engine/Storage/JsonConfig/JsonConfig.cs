using System.Text.Json;

internal static class JsonConfig
{
    public static JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
        };
    }
}
