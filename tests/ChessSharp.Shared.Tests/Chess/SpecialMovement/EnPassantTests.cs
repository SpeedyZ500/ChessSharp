namespace ChessSharp.Shared.Tests.Chess.SpecialMovement;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class EnPassantTests
{
    
    [Fact(DisplayName ="White En Passant Right")]
    public void EnPassantWhiteRightTest()
    {
        ChessBoard board = TestUtilities.LoadBoard("""
                | | | | | | | | |
                | | |p| | | | | |
                | | | | | | | | |
                | |P| | | | | | |
                | | | | | | | |k|
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
                """);
        ChessMove setupMove = new ChessMove(new ChessPosition(7, 3), new ChessPosition(5, 3), null);
        /*
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | |P|p| | | | | |
                | | | | | | | |k|
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
         */

        ChessMove enPassantMove = new ChessMove(new ChessPosition(5, 2), new ChessPosition(6, 3), null);
        ChessBoard endBoard = TestUtilities.LoadBoard("""
                | | | | | | | | |
                | | | | | | | | |
                | | |P| | | | | |
                | | | | | | | | |
                | | | | | | | |k|
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
                """);

        AssertValidEnPassant(board, TeamColor.BLACK, setupMove, enPassantMove, endBoard);
    }


    
    [Fact(DisplayName ="White En Passant Left")]
    public void EnPassantWhiteLeftTest()
    {
        ChessBoard board = TestUtilities.LoadBoard("""
                | | | | | | | | |
                | | |p| | | | | |
                | | | | | | | | |
                | | | |P| | | | |
                | | | | | | | |k|
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
                """);

        ChessMove setupMove = new ChessMove(new ChessPosition(7, 3), new ChessPosition(5, 3), null);
        /*
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | |p|P| | | | |
                | | | | | | | |k|
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
         */
        ChessMove enPassantMove = new ChessMove(new ChessPosition(5, 4), new ChessPosition(6, 3), null);
        ChessBoard endBoard = TestUtilities.LoadBoard("""
                | | | | | | | | |
                | | | | | | | | |
                | | |P| | | | | |
                | | | | | | | | |
                | | | | | | | |k|
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
                """);

        AssertValidEnPassant(board, TeamColor.BLACK, setupMove, enPassantMove, endBoard);
    }


    
    [Fact(DisplayName ="Black En Passant Right")]
    public void EnPassantBlackRightTest()
    {
        ChessBoard board = TestUtilities.LoadBoard("""
                | | | |k| | | | |
                | | | | | | | | |
                | | | | | | | | |
                |K| | | | | | | |
                | | | | | |p| | |
                | | | | | | | | |
                | | | | | | |P| |
                | | | | | | | | |
                """);
        ChessMove setupMove = new ChessMove(new ChessPosition(2, 7), new ChessPosition(4, 7), null);
        /*
                | | | |k| | | | |
                | | | | | | | | |
                | | | | | | | | |
                |K| | | | | | | |
                | | | | | |p|P| |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
         */
        ChessMove enPassantMove = new ChessMove(new ChessPosition(4, 6), new ChessPosition(3, 7), null);
        ChessBoard endBoard = TestUtilities.LoadBoard("""
                | | | |k| | | | |
                | | | | | | | | |
                | | | | | | | | |
                |K| | | | | | | |
                | | | | | | | | |
                | | | | | | |p| |
                | | | | | | | | |
                | | | | | | | | |
                """);

        AssertValidEnPassant(board, TeamColor.WHITE, setupMove, enPassantMove, endBoard);
    }


    
    [Fact(DisplayName ="Black En Passant Left")]
    public void EnPassantBlackLeftTest()
    {
        ChessBoard board = TestUtilities.LoadBoard("""
                | | | |k| | | | |
                | | | | | | | | |
                | | | | | | | | |
                |K| | | | | | | |
                | | | | | | | |p|
                | | | | | | | | |
                | | | | | | |P| |
                | | | | | | | | |
                """);
        ChessMove setupMove = new ChessMove(new ChessPosition(2, 7), new ChessPosition(4, 7), null);
        /*
                | | | |k| | | | |
                | | | | | | | | |
                | | | | | | | | |
                |K| | | | | | | |
                | | | | | | |P|p|
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
         */
        ChessMove enPassantMove = new ChessMove(new ChessPosition(4, 8), new ChessPosition(3, 7), null);
        ChessBoard endBoard = TestUtilities.LoadBoard("""
                | | | |k| | | | |
                | | | | | | | | |
                | | | | | | | | |
                |K| | | | | | | |
                | | | | | | | | |
                | | | | | | |p| |
                | | | | | | | | |
                | | | | | | | | |
                """);
        AssertValidEnPassant(board, TeamColor.WHITE, setupMove, enPassantMove, endBoard);
    }


    
    [Fact(DisplayName ="Can Only En Passant on Next Turn")]
    public void MissedEnPassantTest()
    {
        ChessBoard board = TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | |p| | | | | |
                | | | | | | | |P|
                | |P| | | | | | |
                | | | | | | | | |
                | | | | | | | |p|
                | | | | | | | | |
                | | | |K| | | | |
                """);
        ChessGame game = new ChessGame();
        game.Board = board;
        game.Turn = TeamColor.BLACK;

        //move black piece 2 spaces
        game.MakeMove(new ChessMove(new ChessPosition(7, 3), new ChessPosition(5, 3), null));
        /*
                | | | | |k| | | |
                | | | | | | | | |
                | | | | | | | |P|
                | |P|p| | | | | |
                | | | | | | | | |
                | | | | | | | |p|
                | | | | | | | | |
                | | | |K| | | | |
         */

        //filler moves
        game.MakeMove(new ChessMove(new ChessPosition(6, 8), new ChessPosition(7, 8), null));
        game.MakeMove(new ChessMove(new ChessPosition(3, 8), new ChessPosition(2, 8), null));
        /*
                | | | | |k| | | |
                | | | | | | | |P|
                | | | | | | | | |
                | |P|p| | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | |p|
                | | | |K| | | | |
         */

        //make sure pawn cannot do En Passant move
        ChessPosition enPassantPosition = new ChessPosition(5, 2);
        ChessMove enPassantMove = new ChessMove(enPassantPosition, new ChessPosition(6, 3), null);
        Assert.DoesNotContain(enPassantMove, game.ValidMoves(enPassantPosition));
    }

    private void AssertValidEnPassant(ChessBoard board, TeamColor turn, ChessMove setupMove,
                                      ChessMove enPassantMove, ChessBoard endBoard)
    {
        ChessGame game = new ChessGame();
        game.Board = board;
        game.Turn = turn;

        //setup prior move for en passant
        game.MakeMove(setupMove);

        //make sure pawn has En Passant move
        Assert.Contains(enPassantMove, game.ValidMoves(enPassantMove.StartPosition));

        //en passant move works correctly
        var exception = Record.Exception(() => game.MakeMove(enPassantMove));
        Assert.Null(exception);
        Assert.Equal(endBoard, game.Board);
    }
}