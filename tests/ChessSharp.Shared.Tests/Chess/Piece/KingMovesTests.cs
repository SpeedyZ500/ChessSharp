namespace ChessSharp.Shared.Tests.Chess.Piece;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class KingMovesTest
{
    [Fact]
    public void KingMiddleOfBoard()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | |K| | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(3, 6);
        int[,] endPositions =
        {
            {4,5}, {4,6}, {4,7},
            {3,5}, {3,7},
            {2,5}, {2,6}, {2,7}
        };
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KingCaptureEnemy()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | |N|n| | | |
        | | | |k| | | | |
        | | |P|b|p| | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(3, 4);
        int[,] endPositions =
        {
            {4, 3}, {4, 4},
            {3, 5}, {3, 3},
            {2, 3}
        };
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KingBlocked()
    {
        // Given
        string board = """
        | | | | | | |r|k|
        | | | | | | |p|p|
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