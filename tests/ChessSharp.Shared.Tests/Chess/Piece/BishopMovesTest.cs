namespace ChessSharp.Shared.Tests.Chess.Piece;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class BishopMovesTest
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
}