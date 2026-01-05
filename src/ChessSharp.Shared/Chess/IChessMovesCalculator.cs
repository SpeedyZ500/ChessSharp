namespace ChessSharp.Shared.Chess;

public interface IChessMovesCalculator
{
    public List<ChessMove> PieceMoves(ChessBoard board, ChessPosition position);
}