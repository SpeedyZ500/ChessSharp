namespace ChessSharp.Shared.WebSocket.Commands;
using ChessSharp.Shared.Enums;

public record ConnectCommand(string AuthToken, int GameID): UserGameCommand(CommandType.CONNECT, AuthToken, GameID)
{
    
}