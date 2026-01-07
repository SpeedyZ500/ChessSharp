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
    public void KnightEdgeOfBoardBottom()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | |N| | |
        """;
        ChessPosition position = new ChessPosition(1, 6);
        int[,] endPositions ={{2, 4}, {3, 5}, {3, 7}, {2, 8}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KnightEdgeOfBoardTop()
    {
        // Given
        string board = """
        | | |N| | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(8, 3);
        int[,] endPositions ={{7, 5}, {6, 4}, {6, 2}, {7, 1}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KnightEdgeOfBoardBottomRight()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | |N|
        """;
        ChessPosition position = new ChessPosition(1, 8);
        int[,] endPositions ={{2, 6}, {3, 7}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KnightEdgeOfBoardTopRight()
    {
        // Given
        string board = """
        | | | | | | | |N|
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(8, 8);
        int[,] endPositions ={{6, 7}, {7, 6}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KnightEdgeOfBoardTopLeft()
    {
        // Given
        string board = """
        |N| | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(8, 1);
        int[,] endPositions ={{7, 3}, {6, 2}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KnightEdgeOfBoardBottomLeft()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        |N| | | | | | | |
        """;
        ChessPosition position = new ChessPosition(1, 1);
        int[,] endPositions ={{2, 3}, {3, 2}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void KnightSurroundedButNotBlocked()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | |R|R|R| | |
        | | | |R|N|R| | |
        | | | |R|R|R| | |
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
    public void KnightBlocked()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | |R| | | | |
        | | | | | | |P| |
        | | | | |N| | | |
        | | |N| | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(5, 5);
        int[,] endPositions =
        {
            {3, 4}, {3, 6}, {4, 7}, {7, 6}, {6, 3}

        };
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