namespace ChessSharp.Shared.Chess.Pieces;

public class KnightMovesCalculator : IChessMovesCalculator
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
        int[] path = {-2, -1, 1, 2};
        foreach(int vert in path)
        {
            int row = vert + position.Row;
            foreach(int horiz in path)
            {
                int col = horiz + position.Col;
                ChessPosition pos = new ChessPosition(row, col);
                if(Math.Abs(vert) != Math.Abs(horiz) && !ChessBoard.OutOfBounds(pos))
                {
                    ChessPiece? checkPosition = board.GetPiece(position);
                    if (checkPosition == null || checkPosition.PieceColor != piece.PieceColor)
                    {
                        moves.Add(new ChessMove(position, pos, null));
                    }
                }
            }
        }
        return moves;
    }
}