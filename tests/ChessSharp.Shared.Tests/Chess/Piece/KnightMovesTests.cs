namespace ChessSharp.Shared.Tests.Chess.Piece;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class KnightMovesTest
{
    [Fact]
    public void KnightMiddleOfBoardWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | |N| | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(5, 5);
        int[,] endPositions =
        {
            {7, 6}, {6, 7}, {4, 7}, {3, 6}, {3, 4}, {4, 3}, {6, 3}, {7, 4},

        };
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KnightMiddleOfBoardBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | |n| | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(5, 5);
        int[,] endPositions =
        {
            {7,6}, {6,7}, {7,4}, {6,3},
            {3,4}, {4,3}, {3,6}, {4,7}
        };
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KnightEdgeOfBoardLeft()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        |n| | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(4, 1);
        int[,] endPositions ={{6,2}, {5,3}, {3,3}, {2,2}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KnightEdgeOfBoardRight()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | |n|
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(3, 8);
        int[,] endPositions ={{1,7}, {2,6}, {4,6}, {5,7}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KnightCaptureEnemy()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | |n| | | |
        | | |N| | | | | |
        | | | |P| |R| | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(5, 5);
        int[,] endPositions = {{7, 6}, {6, 7}, {4, 7}, {3, 6}, {3, 4}, {4, 3}, {6, 3}, {7, 4}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }
}