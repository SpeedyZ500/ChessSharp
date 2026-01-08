namespace ChessSharp.Shared.WebSocket.Commands;

using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public record MakeMoveCommand(string AuthToken, int GameID, ChessMove Move): UserGameCommand(CommandType.MAKE_MOVE, AuthToken, GameID)
{
    
}