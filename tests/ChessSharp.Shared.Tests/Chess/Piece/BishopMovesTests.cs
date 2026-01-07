namespace ChessSharp.Shared.Tests.Chess.Piece;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class BishopMovesTests
{
    [Fact]
    public void BishopMovesUntilEdge()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | |B| | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(5, 4);
        int[,] endPositions =
        {
            {6, 5}, {7, 6}, {8, 7},
            {4, 5}, {3, 6}, {2, 7}, {1, 8},
            {4, 3}, {3, 2}, {2, 1},
            {6, 3}, {7, 2}, {8, 1},
        };
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void BishopCaptureEnemy()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | |Q| | | | |
        | | | | | | | | |
        | |b| | | | | | |
        |r| | | | | | | |
        | | | | | | | | |
        | | | | |P| | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(5, 2);
        int[,] endPositions =
        {
            {6, 3}, {7, 4},
            {4, 3}, {3, 4}, {2, 5},
            // none
            {6, 1},
        };
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void BishopBlocked()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | |R| |P| |
        | | | | | |B| | |
        """;
        ChessPosition position = new ChessPosition(1, 6);
        int[,] endPositions = {};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }
}