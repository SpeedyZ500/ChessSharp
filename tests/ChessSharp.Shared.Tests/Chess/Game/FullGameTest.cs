namespace ChessSharp.Shared.Tests.Chess.Game;

using System.ComponentModel;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class FullGameTest
{
    [Fact(DisplayName="Full Game Checkmate")]
    public void ScholarsMateTest() {
        var game = new ChessGame();
        game.MakeMove(new ChessMove(new ChessPosition(2, 5), new ChessPosition(4, 5), null));
        /*
                |r|n|b|q|k|b|n|r|
                |p|p|p|p|p|p|p|p|
                | | | | | | | | |
                | | | | | | | | |
                | | | | |P| | | |
                | | | | | | | | |
                |P|P|P|P| |P|P|P|
                |R|N|B|Q|K|B|N|R|
         */
        game.MakeMove(new ChessMove(new ChessPosition(7, 5), new ChessPosition(5, 5), null));
        /*
                |r|n|b|q|k|b|n|r|
                |p|p|p|p| |p|p|p|
                | | | | | | | | |
                | | | | |p| | | |
                | | | | |P| | | |
                | | | | | | | | |
                |P|P|P|P| |P|P|P|
                |R|N|B|Q|K|B|N|R|
         */
        game.MakeMove(new ChessMove(new ChessPosition(1, 6), new ChessPosition(4, 3), null));
        /*
                |r|n|b|q|k|b|n|r|
                |p|p|p|p| |p|p|p|
                | | | | | | | | |
                | | | | |p| | | |
                | | |B| |P| | | |
                | | | | | | | | |
                |P|P|P|P| |P|P|P|
                |R|N|B|Q|K| |N|R|
         */
        game.MakeMove(new ChessMove(new ChessPosition(8, 7), new ChessPosition(6, 6), null));
        /*
                |r|n|b|q|k|b| |r|
                |p|p|p|p| |p|p|p|
                | | | | | |n| | |
                | | | | |p| | | |
                | | |B| |P| | | |
                | | | | | | | | |
                |P|P|P|P| |P|P|P|
                |R|N|B|Q|K| |N|R|
         */
        game.MakeMove(new ChessMove(new ChessPosition(1, 4), new ChessPosition(5, 8), null));
        /*
                |r|n|b|q|k|b| |r|
                |p|p|p|p| |p|p|p|
                | | | | | |n| | |
                | | | | |p| | |Q|
                | | |B| |P| | | |
                | | | | | | | | |
                |P|P|P|P| |P|P|P|
                |R|N|B| |K| |N|R|
         */
        game.MakeMove(new ChessMove(new ChessPosition(8, 2), new ChessPosition(6, 3), null));
        /*
                |r| |b|q|k|b| |r|
                |p|p|p|p| |p|p|p|
                | | |n| | |n| | |
                | | | | |p| | |Q|
                | | |B| |P| | | |
                | | | | | | | | |
                |P|P|P|P| |P|P|P|
                |R|N|B| |K| |N|R|
         */
        game.MakeMove(new ChessMove(new ChessPosition(5, 8), new ChessPosition(7, 6), null));
        /*
                |r| |b|q|k|b| |r|
                |p|p|p|p| |Q|p|p|
                | | |n| | |n| | |
                | | | | |p| | | |
                | | |B| |P| | | |
                | | | | | | | | |
                |P|P|P|P| |P|P|P|
                |R|N|B| |K| |N|R|
         */
        Assert.True(game.IsInCheck(TeamColor.BLACK));
        Assert.False(game.IsInCheck(TeamColor.WHITE));
        Assert.True(game.IsInCheckmate(TeamColor.BLACK));
        Assert.False(game.IsInCheckmate(TeamColor.WHITE));
        Assert.False(game.IsInStalemate(TeamColor.BLACK));
        Assert.False(game.IsInStalemate(TeamColor.WHITE));
    }
}