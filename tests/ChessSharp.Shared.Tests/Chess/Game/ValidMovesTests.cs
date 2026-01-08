namespace ChessSharp.Shared.Tests.Chess.Game;

using System.ComponentModel;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class ValidMovesTests
{

    [Fact(DisplayName ="Check ForcesMovement")]
    public void ForcedMovementTest()
    {
        var game = new ChessGame();
        game.Turn = TeamColor.BLACK;
        game.Board = TestUtilities.LoadBoard("""
                    | | | | | | | | |
                    | | | | | | | | |
                    | |B| | | | | | |
                    | | | | | |K| | |
                    | | |n| | | | | |
                    | | | | | | | | |
                    | | | |q| |k| | |
                    | | | | | | | | |
                    """);

        // Knight moves
        ChessPosition knightPosition = new ChessPosition(4, 3);
        int[,] knightMoves = {{3, 5}, {6, 2}};
        var validMoves = TestUtilities.LoadMoves(knightPosition, knightMoves);
        AssertMoves(game, validMoves, knightPosition);

        // Queen Moves
        ChessPosition queenPosition = new ChessPosition(2, 4);
        int[,] queenMoves = {{3, 5}, {4, 4}};
        validMoves = TestUtilities.LoadMoves(queenPosition, queenMoves);
        AssertMoves(game, validMoves, queenPosition);
    }

    [Fact(DisplayName="Piece Partially Trapped")]
    public void MoveIntoCheckTest() {

        var game = new ChessGame();
        game.Board =TestUtilities.LoadBoard("""
                    | | | | | | | | |
                    | | | | | | | | |
                    | | | | | | | | |
                    |k|r| | | |R| |K|
                    | | | | | | | | |
                    | | | | | | | | |
                    | | | | | | | | |
                    | | | | | | | | |
                    """);

        ChessPosition rookPosition = new ChessPosition(5, 6);
        int[,] rookMoves = {{5, 7}, {5, 5}, {5, 4}, {5, 3}, {5, 2}};
        var validMoves = TestUtilities.LoadMoves(rookPosition, rookMoves);
        AssertMoves(game, validMoves, rookPosition);
    }

    [Fact(DisplayName="Piece Completely Trapped")]
    public void RookPinnedToKing() {

        var game = new ChessGame();
        game.Board = TestUtilities.LoadBoard("""
                    |K| | | | | | |Q|
                    | | | | | | | | |
                    | | | | | | | | |
                    | | | | | | | | |
                    | | | |r| | | | |
                    | | | | | | | | |
                    | |k| | | | | | |
                    | | | | | | | | |
                    """);

        ChessPosition position = new ChessPosition(4, 4);
        Assert.Empty(game.ValidMoves(position));
    }


    [Fact(DisplayName= "Pieces Cannot Eliminate Check")]
    public void KingInDangerTest() {
        var game = new ChessGame();
        game.Turn = TeamColor.BLACK;
        game.Board = TestUtilities.LoadBoard("""
                    |R| | | | | | | |
                    | | | |k| | | |b|
                    | | | | |P| | | |
                    |K| |Q|n| | | | |
                    | | | | | | | | |
                    | | | | | | | |r|
                    | | | | | |p| | |
                    | |q| | | | | | |
                    """);

        //get positions
        ChessPosition kingPosition = new ChessPosition(7, 4);
        ChessPosition pawnPosition = new ChessPosition(2, 6);
        ChessPosition bishopPosition = new ChessPosition(7, 8);
        ChessPosition queenPosition = new ChessPosition(1, 2);
        ChessPosition knightPosition = new ChessPosition(5, 4);
        ChessPosition rookPosition = new ChessPosition(3, 8);

        int[,] kingEnds = {{6, 5}};
        var validMoves = TestUtilities.LoadMoves(kingPosition, kingEnds);

        AssertMoves(game, validMoves, kingPosition);

        //make sure teams other pieces are not allowed to move
        Assert.Empty(game.ValidMoves(pawnPosition));
        Assert.Empty(game.ValidMoves(bishopPosition));
        Assert.Empty(game.ValidMoves(queenPosition));
        Assert.Empty(game.ValidMoves(knightPosition));
        Assert.Empty(game.ValidMoves(rookPosition));
    }


    [Fact(DisplayName = "King Cannot Move Into Check")]
    public void NoPutSelfInDangerTest() {

        var game = new ChessGame();
        game.Board = TestUtilities.LoadBoard("""
                    | | | | | | | | |
                    | | | | | | | | |
                    | | | | | | | | |
                    | | | | | | | | |
                    | | | | | |k| | |
                    | | | | | | | | |
                    | | | | | |K| | |
                    | | | | | | | | |
                    """);

        ChessPosition position = new ChessPosition(2, 6);
        int[,] end = {{1, 5}, {1, 6}, {1, 7}, {2, 5}, {2, 7}};
        var validMoves = TestUtilities.LoadMoves(position, end);
        AssertMoves(game, validMoves, position);
    }

    [Fact(DisplayName = "Valid Moves Independent of Team Turn")]
    public void ValidMovesOtherTeamTest() {
        var game = new ChessGame();
        game.Board = TestUtilities.DefaultBoard();
        game.Turn = TeamColor.BLACK;

        ChessPosition position = new ChessPosition(2, 5);
        int[,] end ={{3, 5}, {4, 5}};
        var validMoves = TestUtilities.LoadMoves(position, end);
        AssertMoves(game, validMoves, position);
    }

    private static void AssertMoves(ChessGame game, List<ChessMove> validMoves, ChessPosition position) {
        var actualMoves = game.ValidMoves(position);
        TestUtilities.ValidateMoves(validMoves, actualMoves);
    }
}