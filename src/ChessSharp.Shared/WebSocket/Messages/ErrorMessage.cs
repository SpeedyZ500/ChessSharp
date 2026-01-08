namespace ChessSharp.Shared.WebSocket.Messages;
using ChessSharp.Shared.Enums;

public record ErrorMessage(string Error):ServerMessage(ServerMessageType.ERROR)
{
    public string Message()
    {
        if(Error.Contains("Error"))
        {
            return Error;
        }
        else
        {
            return "Error: " + Error;
        }
    }
}