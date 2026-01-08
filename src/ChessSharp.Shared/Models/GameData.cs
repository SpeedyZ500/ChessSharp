namespace ChessSharp.Shared.Models;
using ChessSharp.Shared.Chess;
public record GameData(int GameID, String WhiteUsername, String BlackUsername, String GameName, ChessGame Game) {
    public GameData SetId(int id){
        return new GameData(id, WhiteUsername, BlackUsername, GameName, Game);
    }
}