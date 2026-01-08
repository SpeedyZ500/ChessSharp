namespace ChessSharp.Shared.Tests.Chess.SpecialMovement;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class CastlingTests
{
    
    [Fact(DisplayName ="White Team Castle")]
    public void CastleWhiteTest()
    {
        ChessBoard board = TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |R| | | |K| | |R|
                """);
        ChessGame game = new ChessGame();
        game.Board = board;
        game.Turn = TeamColor.WHITE;

        //check that with nothing in way, king can castle
        ChessPosition kingPosition = new ChessPosition(1, 5);
        ChessMove queenSide = new ChessMove(kingPosition, new ChessPosition(1, 3), null);
        ChessMove kingSide = new ChessMove(kingPosition, new ChessPosition(1, 7), null);

        Assert.Contains(queenSide, game.ValidMoves(kingPosition));
        Assert.Contains(kingSide, game.ValidMoves(kingPosition));

        //queen side castle works correctly
        var exception = Record.Exception(() => game.MakeMove(queenSide));
        Assert.Null(exception);
        Assert.Equal(TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | |K|R| | | |R|
                """), game.Board);

        //reset board
        board = TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |R| | | |K| | |R|
                """);
        game.Board = board;
        game.Turn = TeamColor.WHITE;

        //king side castle works correctly
        exception = Record.Exception(() => game.MakeMove(kingSide));
        Assert.Null(exception);
        Assert.Equal(TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |R| | | | |R|K| |
                """), game.Board);
    }


    
    [Fact(DisplayName ="Black Team Castle")]
    public void CastleBlackTest()
    {
        ChessBoard board = TestUtilities.LoadBoard("""
                |r| | | |k| | |r|
                | |p| | | | | |q|
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
                |R| | | | | | | |
                """);
        ChessGame game = new ChessGame();
        game.Board = board;
        game.Turn = TeamColor.BLACK;

        //check that with nothing in way, king can castle
        ChessPosition kingPosition = new ChessPosition(8, 5);
        ChessMove queenSide = new ChessMove(kingPosition, new ChessPosition(8, 3), null);
        ChessMove kingSide = new ChessMove(kingPosition, new ChessPosition(8, 7), null);

        Assert.Contains(queenSide, game.ValidMoves(kingPosition));
        Assert.Contains(kingSide, game.ValidMoves(kingPosition));

        //queen side castle works correctly
        var exception = Record.Exception(() => game.MakeMove(queenSide));
        Assert.Null(exception);
        Assert.Equal(TestUtilities.LoadBoard("""
                | | |k|r| | | |r|
                | |p| | | | | |q|
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
                |R| | | | | | | |
                """), game.Board);


        //reset board
        board = TestUtilities.LoadBoard("""
                |r| | | |k| | |r|
                | |p| | | | | |q|
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
                |R| | | | | | | |
                """);
        game.Board = board;
        game.Turn = TeamColor.BLACK;

        //king side castle works correctly
        exception = Record.Exception(() => game.MakeMove(kingSide));
        Assert.Null(exception);

        Assert.Equal(TestUtilities.LoadBoard("""
                |r| | | | |r|k| |
                | |p| | | | | |q|
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
                |R| | | | | | | |
                """), game.Board);
    }


    
    [Fact(DisplayName ="Cannot Castle Through Pieces")]
    public void CastlingBlockedByTeamTest()
    {
        ChessBoard board = TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |R| |B| |K| |Q|R|
                """);
        ChessGame game = new ChessGame();
        game.Board = board;
        game.Turn = TeamColor.WHITE;

        //check that with nothing in way, king can castle
        ChessPosition kingPosition = new ChessPosition(1, 5);
        ChessMove queenSide = new ChessMove(kingPosition, new ChessPosition(1, 3), null);
        ChessMove kingSide = new ChessMove(kingPosition, new ChessPosition(1, 7), null);

        //make sure king cannot castle
        Assert.DoesNotContain(queenSide, game.ValidMoves(kingPosition));
        Assert.DoesNotContain(kingSide, game.ValidMoves(kingPosition));
    }


    
    [Fact(DisplayName ="Cannot Castle in Check")]
    public void CastlingBlockedByEnemyTest()
    {
        ChessBoard board = TestUtilities.LoadBoard("""
                |r| | |B|k| | |r|
                | | | | | | | | |
                | | | | | |R| | |
                | | | | | | | | |
                | | | | | | | | |
                | |K| | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                """);
        ChessGame game = new ChessGame();
        game.Board = board;

        //make sure king cannot castle on either side
        ChessPosition kingPosition = new ChessPosition(8, 5);
        ChessMove queenSide = new ChessMove(kingPosition, new ChessPosition(8, 3), null);
        ChessMove kingSide = new ChessMove(kingPosition, new ChessPosition(8, 7), null);
        Assert.DoesNotContain(queenSide, game.ValidMoves(kingPosition));
        Assert.DoesNotContain(kingSide, game.ValidMoves(kingPosition));
    }


    
    [Fact(DisplayName ="Cannot Castle After Moving")]
    public void NoCastleAfterMoveTest()
    {
        ChessBoard board = TestUtilities.LoadBoard("""
                | | |k| | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |R| | | |K| | |R|
                """);
        ChessGame game = new ChessGame();
        game.Board = board;
        game.Turn = TeamColor.WHITE;

        //move left rook
        game.MakeMove(new ChessMove(new ChessPosition(1, 1), new ChessPosition(1, 4), null));
        game.MakeMove(new ChessMove(new ChessPosition(8, 3), new ChessPosition(8, 2), null));

        //move rook back to starting spot
        game.MakeMove(new ChessMove(new ChessPosition(1, 4), new ChessPosition(1, 1), null));
        /*
                | |k| | | | | | |
		        | | | | | | | | |
		        | | | | | | | | |
		        | | | | | | | | |
		        | | | | | | | | |
		        | | | | | | | | |
		        | | | | | | | | |
		        |R| | | |K| | |R|
         */

        ChessPosition kingPosition = new ChessPosition(1, 5);
        ChessMove queenSide = new ChessMove(kingPosition, new ChessPosition(1, 3), null);
        ChessMove kingSide = new ChessMove(kingPosition, new ChessPosition(1, 7), null);

        //make sure king can't castle towards moved rook, but still can to unmoved rook
        Assert.DoesNotContain(queenSide, game.ValidMoves(kingPosition));
        Assert.Contains(kingSide, game.ValidMoves(kingPosition));

        //move king
        game.MakeMove(new ChessMove(new ChessPosition(8, 2), new ChessPosition(8, 3), null));
        game.MakeMove(new ChessMove(kingPosition, new ChessPosition(1, 6), null));
        /*
                | | |k| | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |R| | | | |K| |R|
         */

        //move king back to starting position
        game.MakeMove(new ChessMove(new ChessPosition(8, 3), new ChessPosition(8, 4), null));
        game.MakeMove(new ChessMove(new ChessPosition(1, 6), kingPosition, null));
        /*
                | | | |k| | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |R| | | |K| | |R|
         */

        //make sure king can't castle anymore
        Assert.DoesNotContain(queenSide, game.ValidMoves(kingPosition));
        Assert.DoesNotContain(kingSide, game.ValidMoves(kingPosition));
    }
}