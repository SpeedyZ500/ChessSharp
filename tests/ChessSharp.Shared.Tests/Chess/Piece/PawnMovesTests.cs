namespace ChessSharp.Shared.Tests.Chess.Piece;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class PawnMovesTest
{
    [Fact]
    public void PawnMiddleOfBoardWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | |P| | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(4, 4);
        int[,] endPositions = {{5, 4}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnMiddleOfBoardBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | |p| | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(4, 4);
        int[,] endPositions = {{3, 4}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnInitialMoveBoardWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | |P| | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(2, 5);
        int[,] endPositions ={{3, 5}, {4, 5}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnInitialMoveBoardBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | |p| | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(7, 3);
        int[,] endPositions ={{6, 3}, {5, 3}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnPromotionWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | |P| | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(7, 3);
        int[,] endPositions ={{8, 3}};
        // Then
        ValidatePromotion(board, position, endPositions);
    }

    [Fact]
    public void PawnPromotionBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | |p| | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(2, 3);
        int[,] endPositions ={{1, 3}};
        // Then
        ValidatePromotion(board, position, endPositions);
    }

    [Fact]
    public void PawnPromotionCapture()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | |p| | | | | | |
        |N| | | | | | | |
        """;
        ChessPosition position = new ChessPosition(2, 2);
        int[,] endPositions ={{1, 1}, {1, 2}};
        // Then
        ValidatePromotion(board, position, endPositions);
    }

    [Fact]
    public void PawnAdvanceBlockedWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | |n| | | | |
        | | | |P| | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(4, 4);
        int[,] endPositions ={};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnAdvanceBlockedBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | |p| | | | |
        | | | |r| | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(5, 4);
        int[,] endPositions ={};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnAdvanceBlockedDoubleMoveWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | |p| |
        | | | | | | | | |
        | | | | | | |P| |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(2, 7);
        int[,] endPositions ={{3,7}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnAdvanceBlockedDoubleMoveBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | |p| | | | | |
        | | |p| | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(7, 3);
        int[,] endPositions ={};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnCaptureWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | |r| |N| | | |
        | | | |P| | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(4, 4);
        int[,] endPositions ={{5, 3}, {5, 4}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnCaptureBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | |p| | | | |
        | | | |n|R| | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(4, 4);
        int[,] endPositions ={{3, 5}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnMoveFromEdgeWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | |P|
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(4, 8);
        int[,] endPositions = {{5, 8}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnMoveFromEdgeBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | |p|
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(5, 8);
        int[,] endPositions = {{4, 8}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }


    [Fact]
    public void PawnCaptureFromEdgeWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | |r| |
        | | | | | | | |P|
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(4, 8);
        int[,] endPositions = {{5, 8}, {5,7}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnCaptureFromStartWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | |r| | | | | |
        | | |r| | | | | |
        | | | |P| | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(2, 4);
        int[,] endPositions = {{3, 3}, {3, 4}, {4, 4}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnCaptureFromEdgeBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | |p| | | | |
        | | |R| | | | | |
        | | |R| | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(7, 4);
        int[,] endPositions = {{6, 4}, {5, 4}, {6, 3}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnCaptureFromStartBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | |p|
        | | | | | | |R| |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(5, 8);
        int[,] endPositions = {{4, 8}, {4,7}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnAndPromoteWhite()
    {
        // Given
        string board = """
        | | |r| | | | | |
        | | | |P| | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(7,4);
        int[,] endPositions = {{8, 3}, {8, 4}};
        // Then
        ValidatePromotion(board, position, endPositions);
    }

    [Fact]
    public void PawnAndPromoteBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | |p| | | | |
        | | |R| | | | | |
        """;
        ChessPosition position = new ChessPosition(2, 4);
        int[,] endPositions = {{1, 3}, {1, 4}};
        // Then
        ValidatePromotion(board, position, endPositions);
    }

    [Fact]
    public void PawnCannotCaptureBackwardWhite()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | |P| | | | | |
        | | |r|r| | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(3, 3);
        int[,] endPositions = {{4, 3}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    [Fact]
    public void PawnCannotCaptureBackwardBlack()
    {
        // Given
        string board = """
        | | | | | | | | |
        | | |R|R| | | | |
        | | |p| | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        | | | | | | | | |
        """;
        ChessPosition position = new ChessPosition(6,3);
        int[,] endPositions = {{5, 3}};
        // Then
        TestUtilities.ValidateMoves(board, position, endPositions);
    }

    private static void ValidatePromotion(String boardText, ChessPosition startingPosition, int[,] endPositions)
    {
        var board = TestUtilities.LoadBoard(boardText);
        var testPiece = board.GetPiece(startingPosition);
        var validMoves = new List<ChessMove>();
        for(int i =0; i < endPositions.GetLength(0); i++)
        {
            var end = new ChessPosition(endPositions[i,0], endPositions[i,1]);
            validMoves.Add(new ChessMove(startingPosition, end, PieceType.QUEEN));
            validMoves.Add(new ChessMove(startingPosition, end, PieceType.KNIGHT));
            validMoves.Add(new ChessMove(startingPosition, end, PieceType.ROOK));
            validMoves.Add(new ChessMove(startingPosition, end, PieceType.BISHOP));
        }
        TestUtilities.ValidateMoves(board, testPiece, startingPosition, validMoves);
    }

}