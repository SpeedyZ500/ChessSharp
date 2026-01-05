namespace ChessSharp.Shared.Chess.Pieces;

public class RookMovesCalculator : IChessMovesCalculator
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
        for(int i = -1; i <= 1; i += 2)
        {
            int row = position.Row + i;
            int col = position.Col;
            ChessPosition nextPosition = new ChessPosition(row, col);
            while (!ChessBoard.OutOfBounds(nextPosition))
            {
                ChessPiece? checkPosition = board.GetPiece(nextPosition);
                if(checkPosition == null){moves.Add(new ChessMove(position, nextPosition, null));}
                else if(checkPosition.PieceColor != piece.PieceColor){
                    moves.Add(new ChessMove(position, nextPosition, null));
                    break;
                }
                else
                {
                    break;
                }
                row += i;
                nextPosition = new ChessPosition(row, col);
            }
        }
        for(int j = -1; j <= 1; j += 2)
        {
            int row = position.Row;
            int col = position.Col + j;
            ChessPosition nextPosition = new ChessPosition(row, col);
            while (!ChessBoard.OutOfBounds(nextPosition))
            {
                ChessPiece? checkPosition = board.GetPiece(nextPosition);
                if(checkPosition == null){moves.Add(new ChessMove(position, nextPosition, null));}
                else if(checkPosition.PieceColor != piece.PieceColor){
                    moves.Add(new ChessMove(position, nextPosition, null));
                    break;
                }
                else
                {
                    break;
                }
                col += j;
                nextPosition = new ChessPosition(row, col);
            }
        }
        return moves;
    }
}