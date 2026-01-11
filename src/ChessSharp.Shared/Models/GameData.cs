namespace ChessSharp.Shared.Models;
using ChessSharp.Shared.Chess;
public record GameData(int GameID, string? WhiteUsername, string? BlackUsername, string GameName, ChessGame Game) {
    public GameData SetId(int id){
        return new GameData(id, WhiteUsername, BlackUsername, GameName, Game);
    }
}