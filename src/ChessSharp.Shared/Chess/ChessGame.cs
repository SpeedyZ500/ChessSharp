namespace ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class ChessGame
{
    private TeamColor turn;
    private ChessBoard board = new ChessBoard();
    private bool gameOver;
    public bool GameOver
    {
        get{return gameOver;}
        set{ gameOver = value;}
    }
    public ChessGame() {
        turn = TeamColor.WHITE;
        board.ResetBoard();
        gameOver = false;
    }

    public List<ChessMove> ValidMoves(ChessPosition startPosition)
    {
        ChessPiece? piece = board.GetPiece(startPosition);
        List<ChessMove> valid = new List<ChessMove>();
        if(piece != null)
        {
            valid.AddRange(new ChessMovesValidator(board).ValidMoves(startPosition));
        }
        return valid;
    }

    
}