namespace ChessSharp.Shared.WebSocket.Commands;
using ChessSharp.Shared.Enums;

public record UserGameCommand(CommandType CommandType, string AuthToken, int GameID)
{
    
}