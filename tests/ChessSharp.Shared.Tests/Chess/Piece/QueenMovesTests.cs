namespace ChessSharp.Shared.Tests.Chess.Piece;
using ChessSharp.Shared.Chess;

public class QueenMovesTests
{
    [Fact]
    public void QueenMovesUntilEdge()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | |q| |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(7, 7);
        int[,] endPositions =
        {
            {8, 7},
            {8, 8},
            {7, 8},
            {6, 8},
            {6, 7}, {5, 7}, {4, 7}, {3, 7}, {2, 7}, {1, 7},
            {6, 6}, {5, 5}, {4, 4}, {3, 3}, {2, 2}, {1, 1},
            {7, 6}, {7, 5}, {7, 4}, {7, 3}, {7, 2}, {7, 1},
            {8, 6},
        };
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void QueenCaptureEnemy()
    {
        // Given
        string board = """
        |b| | | | | | | |
        | | | | | | | | |
        | | |R| | | | | |
        | | | | | | | | |
        |Q| | |p| | | | |
        | | | | | | | | |
        |P| |n| | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(4, 1);
        int[,] endPositions =
        {
            {5, 1}, {6, 1}, {7, 1}, {8, 1},
            {5, 2},
            {4, 2}, {4, 3}, {4, 4},
            {3, 1}, {3, 2},
            {2, 3}, 
        };
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void QueenBlocked()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        |P|R| | | | | | |
        |Q|K| | | | | | |
        """;
        ChessPosition position = new ChessPosition(1, 1);
        int[,] endPositions = {};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }
}