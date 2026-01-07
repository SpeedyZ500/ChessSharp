namespace ChessSharp.Shared.Tests.Chess;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class ChessBoardTests
{
    [Fact(DisplayName ="Add and Get Piece")]
    public void GetAndAddPiece()
    {
        ChessPosition position = new ChessPosition(4, 4);
        ChessPiece piece = new ChessPiece(TeamColor.BLACK, PieceType.BISHOP);

        var board = new ChessBoard();
        board.AddPiece(position, piece);

        ChessPiece? foundPiece = board.GetPiece(position);

        Assert.Equal(piece.Type, foundPiece.Type);
        Assert.Equal(piece.PieceColor, foundPiece.PieceColor);

    }

    [Fact(DisplayName ="Reset Board")]
    public void DefaultGameBoard()
    {
        var expectedBoard = TestUtilities.DefaultBoard();

        var actualBoard = new ChessBoard();
        actualBoard.ResetBoard();
        Assert.Equal(expectedBoard, actualBoard);
    }

    [Fact(DisplayName ="Piece Move on All Pieces")]
    public void PieceMoveAllPieces()
    {
        var board = new ChessBoard();
        board.ResetBoard();
        for(int i = 1; i <= 8; i++) {
            for(int j = 1; j <= 8; j++) {
                ChessPosition position = new ChessPosition(i, j);
                ChessPiece? piece = board.GetPiece(position);
                if(piece != null) {
                    var exception = Record.Exception(() => piece.PieceMoves(board, position));
                    Assert.Null(exception);
                }
            }
        }
    }
}