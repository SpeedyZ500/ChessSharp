namespace ChessSharp.Shared.Converters;

using System.Text.Json;
using System.Text.Json.Serialization;

using ChessSharp.Shared.Chess;

public class ChessBoardDictionaryConverter : JsonConverter<Dictionary<ChessPosition, ChessPiece>>
{
    public override Dictionary<ChessPosition, ChessPiece>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var board = new Dictionary<ChessPosition, ChessPiece>();
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                return board;
            var key = reader.GetString();
            if(key == null)
                throw new JsonException();
            
            var parts = key.Split(',');
            int row = int.Parse(parts[0]);
            int col = int.Parse(parts[1]);

            var Position = new ChessPosition(row, col);

            //advance
            reader.Read();
            var piece = JsonSerializer.Deserialize<ChessPiece>(ref reader, options)!;
            board[Position] = piece;
        }
        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<ChessPosition, ChessPiece> value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        foreach (var (position, piece) in value)
        {
            var key = $"{position.Row},{position.Col}";
            writer.WritePropertyName(key);
            JsonSerializer.Serialize(writer, piece, options);
        }

        writer.WriteEndObject();
    }
}
