namespace ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class ChessMovesValidator
{
    private readonly ChessBoard board;
    
    public ChessMovesValidator(ChessBoard board)
    {
        this.board = board;
    }

    public List<ChessMove> ValidMoves(ChessPosition startPosition)
    {
        ChessPiece? piece = board.GetPiece(startPosition);
        List<ChessMove> valid = new List<ChessMove>();
        if (piece != null)
        {
            TeamColor color = piece.PieceColor;
            valid.AddRange(piece.PieceMoves(board, startPosition));
            List<ChessMove> copy = valid.ToList();
            int row = startPosition.Row;
            int col = startPosition.Col;
            HashSet<ChessPosition> invalidDir = new HashSet<ChessPosition>();
            bool check = new ChessCheckCalculator(board).IsInCheck(color);
            foreach(ChessMove move in copy)
            {
                ChessBoard copyBoard = new ChessBoard();
                ChessPosition end = move.EndPosition;
                List<Placement> boardList = board.ToList();
                foreach(Placement place in boardList)
                {
                    if(!place.Position.Equals(startPosition) && !place.Position.Equals(end))
                    {
                        copyBoard.AddPiece(place);
                    }
                }
                copyBoard.AddPiece(end, move.Promotion != null ? new ChessPiece(color, (PieceType)move.Promotion) : piece);
                int endRow = end.Row;
                int endCol = end.Col;
                int rankDiff = endRow - row;
                int fileDiff = endCol - col;
                ChessPosition dir = new ChessPosition(rankDiff != 0 ? rankDiff/Math.Abs(rankDiff) :
                        rankDiff, fileDiff != 0 ? fileDiff/Math.Abs(fileDiff) : fileDiff);
                                if(new ChessCheckCalculator(copyBoard).IsInCheck(color) || (!check && invalidDir.Contains(dir)) ||
                        (invalidDir.Contains(dir) && piece.Type == PieceType.KING)){
                    if(!check) {
                        invalidDir.Add(dir);
                    }
                    valid.Remove(move);
                }
                if(check && piece.Type == PieceType.KING){
                    invalidDir.Add(dir);
                }
            }

        }
        return valid;
    }
}