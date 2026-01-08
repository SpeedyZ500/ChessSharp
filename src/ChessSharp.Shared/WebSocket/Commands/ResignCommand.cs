namespace ChessSharp.Shared.WebSocket.Commands;
using ChessSharp.Shared.Enums;

public record ResignCommand(string AuthToken, int GameID): UserGameCommand(CommandType.RESIGN, AuthToken, GameID)
{
    
}