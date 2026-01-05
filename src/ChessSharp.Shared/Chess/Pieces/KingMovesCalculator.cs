namespace ChessSharp.Shared.Chess.Pieces;
using ChessSharp.Shared.Enums;
public class KingMovesCalculator : IChessMovesCalculator
{
    public List<ChessMove> PieceMoves(ChessBoard board, ChessPosition position)
    {
        List<ChessMove> moves = new List<ChessMove>();
        ChessPiece? pieces = board.GetPiece(position);
        if (pieces == null)
        {
            return moves;
        }
        ChessPiece piece = (ChessPiece)pieces;
        for(int i = -1; i <= 1; i++)
        {
            for(int j = -1; j <= 1; j++)
            {
                int row = position.Row + i;
                int col = position.Col + j;
                ChessPosition nextPosition = new ChessPosition(row, col);
                if (!ChessBoard.OutOfBounds(nextPosition))
                {
                    ChessPiece? checkPosition = board.GetPiece(nextPosition);
                    if(checkPosition == null){moves.Add(new ChessMove(position, nextPosition, null));}
                    else if(checkPosition.PieceColor != piece.PieceColor){
                        moves.Add(new ChessMove(position, nextPosition, null));
                    }
                }
            }
        }
        moves.AddRange(CastleMove(board, position));
        return moves;
    }

    private List<ChessMove> CastleMove(ChessBoard board, ChessPosition position)
    {
        List<ChessMove> moves = new List<ChessMove>();
        ChessPiece? pieces = board.GetPiece(position);
        if (pieces == null)
        {
            return moves;
        }
        ChessPiece king = (ChessPiece)pieces;
        int[] rookStartCols = {1, 8};
        ChessPosition kingStart = new ChessPosition(king.PieceColor == TeamColor.WHITE ? 1: 8, 5);
        foreach(int rookCol in rookStartCols)
        {
            ChessPosition rookPosition = new ChessPosition(position.Row, rookCol);
            
            ChessPiece? rook = board.GetPiece(rookPosition);
            if(position.Equals(kingStart) &&  rook != null && rook.Type == PieceType.ROOK &&
                    rook.PieceColor == king.PieceColor)
            {
                int row = kingStart.Row;
                int col = kingStart.Col;
                int dir = rookCol > col ? 1 : -1;
                ChessPosition endPosition = new ChessPosition(row, col + (2 * dir));
                bool pathOpen = true;
                for(int i = col + dir; i != rookCol; i += dir)
                {
                    if(board.GetPiece(new ChessPosition(row, i)) != null)
                    {
                        pathOpen = false;
                        break;
                    }
                }
                if (!pathOpen)
                {
                    continue;
                }
                HashSet<ChessPosition> history = board.History;
                if (history.Contains(kingStart))
                {
                    break;
                }
                if (history.Contains(rookPosition))
                {
                    continue;
                }
                moves.Add(new ChessMove(position, endPosition, null));
            }
        }
        return moves;
    }
}