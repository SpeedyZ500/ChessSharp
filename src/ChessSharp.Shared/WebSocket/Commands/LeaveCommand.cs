namespace ChessSharp.Shared.WebSocket.Commands;
using ChessSharp.Shared.Enums;

public record LeaveCommand(string AuthToken, int GameID): UserGameCommand(CommandType.LEAVE, AuthToken, GameID)
{
    
}