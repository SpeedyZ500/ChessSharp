namespace ChessSharp.Shared.WebSocket.Messages;
using ChessSharp.Shared.Enums;
using ChessSharp.Shared.Chess;


public record LoadGameMessage(ChessGame Game):ServerMessage(ServerMessageType.LOAD_GAME)
{
    
}