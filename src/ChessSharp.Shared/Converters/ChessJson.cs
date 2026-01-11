namespace ChessSharp.Shared.Converters;

using System.Text.Json;
using System.Text.Json.Serialization;

public static class ChessJson
{
    public static JsonSerializerOptions Create()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        options.Converters.Add(new ChessBoardDictionaryConverter());
        return options;
    }
}
