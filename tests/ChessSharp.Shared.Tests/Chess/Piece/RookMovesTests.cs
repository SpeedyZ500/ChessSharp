namespace ChessSharp.Shared.Tests.Chess.Piece;
using ChessSharp.Shared.Chess;

public class RookMovesTests
{
    [Fact]
    public void RookMovesUntilEdge()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | |R| | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(2, 3);
        int[,] endPositions =
        {
            {2, 4}, {2, 5}, {2, 6}, {2, 7}, {2, 8},
            {2, 2}, {2, 1},
            {1, 3},
            {3, 3}, {4, 3}, {5, 3}, {6, 3}, {7, 3}, {8, 3},
        };
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void RookCaptureEnemy()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        |N| | | | | | | |
        |r| | | | |B| | |
        | | | | | | | | |
        |q| | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(4, 1);
        int[,] endPositions =
        {
            {5, 1},
            {3, 1},
            {4, 2}, {4, 3}, {4, 4}, {4, 5}, {4, 6},
        };
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void RookBlocked()
    {
        // Given
        string board = """
        | | | | | | |n|r|
        | | | | | | | |p|
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(8, 8);
        int[,] endPositions = {};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }
}