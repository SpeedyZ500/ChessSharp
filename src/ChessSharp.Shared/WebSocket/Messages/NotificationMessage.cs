namespace ChessSharp.Shared.WebSocket.Messages;
using ChessSharp.Shared.Enums;

public record NotificationMessage(string Message):ServerMessage(ServerMessageType.NOTIFICATION)
{
    
}