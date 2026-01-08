namespace ChessSharp.Shared.Tests.Chess.Game;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class GameStatusTests
{
    
    [Fact(DisplayName ="New Game Default Values")]
    public void NewGameTest() {
        var game = new ChessGame();
        var expectedBoard = TestUtilities.DefaultBoard();
        Assert.Equal(expectedBoard, game.Board);
        Assert.Equal(TeamColor.WHITE, game.Turn);
    }

    
    [Fact(DisplayName ="Default Board No Statuses")]
    public void NoGameStatusesTest() {
        var game = new ChessGame();
        game.Board = TestUtilities.DefaultBoard();
        game.Turn = TeamColor.WHITE;

        Assert.False(game.IsInCheck(TeamColor.BLACK));
        Assert.False(game.IsInCheck(TeamColor.WHITE));
        Assert.False(game.IsInCheckmate(TeamColor.BLACK));
        Assert.False(game.IsInCheckmate(TeamColor.WHITE));
        Assert.False(game.IsInStalemate(TeamColor.BLACK));
        Assert.False(game.IsInStalemate(TeamColor.WHITE));
    }


    
    [Fact(DisplayName ="White in Check")]
    public void WhiteCheckTest() {
        var game = new ChessGame();
        game.Board =TestUtilities.LoadBoard("""
                | | | | | | | |k|
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | |K| | | |r| | |
                | | | | | | | | |
                | | | | | | | | |
                """);

        Assert.True(game.IsInCheck(TeamColor.WHITE));
        Assert.False(game.IsInCheck(TeamColor.BLACK));
    }


    
    [Fact(DisplayName ="Black in Check")]
    public void BlackCheckTest() {
        var game = new ChessGame();
        game.Board =TestUtilities.LoadBoard("""
                | | | |K| | | | |
                | | | | | | | | |
                | | | |k| | | | |
                | | | | | | | | |
                | | | | | | | | |
                |B| | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                """);

        Assert.True(game.IsInCheck(TeamColor.BLACK),
                "Black is in check but IsInCheck returned false");
        Assert.False(game.IsInCheck(TeamColor.WHITE));
    }


    
    [Fact(DisplayName ="White in Checkmate")]
    public void WhiteTeamCheckmateTest() {

        var game = new ChessGame();
        game.Board =TestUtilities.LoadBoard("""
                | | | | | | | | |
                | | |b|q| | | | |
                | | | | | | | | |
                | | | |p| | | |k|
                | | | | | |K| | |
                | | |r| | | | | |
                | | | | |n| | | |
                | | | | | | | | |
                """);
        game.Turn = TeamColor.WHITE;

        Assert.True(game.IsInCheckmate(TeamColor.WHITE));
        Assert.False(game.IsInCheckmate(TeamColor.BLACK));
    }


    
    [Fact(DisplayName ="Black in Checkmate by Pawns")]
    public void BlackTeamPawnCheckmateTest() {
        var game = new ChessGame();
        game.Board =TestUtilities.LoadBoard("""
                | | | |k| | | | |
                | | | |P|P| | | |
                | |P| | |P|P| | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | |K| | | | |
                """);
        game.Turn = TeamColor.BLACK;

        Assert.True(game.IsInCheckmate(TeamColor.BLACK));
        Assert.False(game.IsInCheckmate(TeamColor.WHITE));

    }

    
    [Fact(DisplayName ="Black can escape Check by capturing")]
    public void EscapeCheckByCapturingThreateningPieceTest() {

        var game = new ChessGame();
        game.Board =TestUtilities.LoadBoard("""
                | | | | | |r|k| |
                | | | | | |P| |p|
                | | | |N| | | | |
                | | | | |B| | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | |n| | | |
                |K| | | | | | | |
                """);
        game.Turn = TeamColor.BLACK;

        Assert.False(game.IsInCheckmate(TeamColor.BLACK));
        Assert.False(game.IsInCheckmate(TeamColor.WHITE));
    }


    
    [Fact(DisplayName ="Black CANNOT escape Check by capturing")]
    public void CannotEscapeCheckByCapturingThreateningPieceTest() {

        var game = new ChessGame();
        game.Board =TestUtilities.LoadBoard("""
                | | | | | |r|k| |
                | | | | | |P| |p|
                | | | |N| | | | |
                | | | | |B| | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | |n| | | |
                |K| | | | | |R| |
                """);
        game.Turn = TeamColor.BLACK;

        Assert.True(game.IsInCheckmate(TeamColor.BLACK));
        Assert.False(game.IsInCheckmate(TeamColor.WHITE));
    }


    
    [Fact(DisplayName ="Checkmate, where blocking a threat reveals a new threat")]
    public void CheckmateWhereBlockingThreateningPieceOpensNewThreatTest() {

        var game = new ChessGame();
        game.Board =TestUtilities.LoadBoard("""
                | | | | | | |r|k|
                | | |R| | | | | |
                | | | | | | | | |
                | | | | |r| | | |
                | | | | | | | | |
                | | |B| | | | | |
                | | | | | | | | |
                |K| | | | | | |R|
                """);
        game.Turn = TeamColor.BLACK;

        Assert.True(game.IsInCheckmate(TeamColor.BLACK));
        Assert.False(game.IsInCheckmate(TeamColor.WHITE));
    }


    
    [Fact(DisplayName ="Pinned King Causes Stalemate")]
    public void StalemateTest() {
        var game = new ChessGame();
        game.Board =TestUtilities.LoadBoard("""
                |k| | | | | | | |
                | | | | | | | |r|
                | | | | | | | | |
                | | | | |q| | | |
                | | | |n| | |K| |
                | | | | | | | | |
                | | | | | | | | |
                | | | | |b| | | |
                """);
        game.Turn = TeamColor.WHITE;

        Assert.True(game.IsInStalemate(TeamColor.WHITE));
        Assert.False(game.IsInStalemate(TeamColor.BLACK));
    }

    
    [Fact(DisplayName ="Stalemate Requires not in Check")]
    public void CheckmateNotStalemateTest() {
        var game = new ChessGame();
        game.Board =TestUtilities.LoadBoard("""
                |k| | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | |P| | | |
                | | | | | | | |r|
                |K| | | | | |r| |
                """);
        game.Turn = TeamColor.WHITE;

        Assert.False(game.IsInStalemate(TeamColor.WHITE));
        Assert.False(game.IsInStalemate(TeamColor.BLACK));
    }
}