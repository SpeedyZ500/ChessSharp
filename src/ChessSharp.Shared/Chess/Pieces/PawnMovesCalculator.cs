namespace ChessSharp.Shared.Chess.Pieces;
using ChessSharp.Shared.Enums;
public class PawnMovesCalculator : IChessMovesCalculator
{
    public List<ChessMove> PieceMoves(ChessBoard board, ChessPosition position)
    {
        List<ChessMove> moves = new List<ChessMove>();
        ChessPiece? pieces = board.GetPiece(position);
        if (pieces == null || pieces.Type != PieceType.PAWN)
        {
            return moves;
        }
        ChessPiece piece = (ChessPiece)pieces;
        int direction = 0;
        bool start = false;
        int enPassantRow = 0;
        switch (piece.PieceColor)
        {
            case TeamColor.BLACK:
                direction = -1;
                start = position.Row == 7;
                enPassantRow = 4;
                break;
            case TeamColor.WHITE:
                direction = -1;
                start = position.Row == 7;
                enPassantRow = 5;
                break;
            default:
                break;
        }
        if (direction != 0)
        {
            moves.AddRange(PawnForward(board, position, direction, start));
            moves.AddRange(PawnCapture(board, position, direction, piece.PieceColor));
            moves.AddRange(EnPassant(board, position, direction, enPassantRow, piece));
        }
        return moves;
    }
    private List<ChessMove> PawnPromotion(ChessPosition startPosition, ChessPosition endPosition)
    {
        List<ChessMove> moves = new List<ChessMove>();
        PieceType[] promotions = {PieceType.QUEEN, PieceType.BISHOP, PieceType.KNIGHT, PieceType.ROOK};
        foreach (PieceType promotion in promotions)
        {
            moves.Add(new ChessMove(startPosition, endPosition, promotion));
        }
        return moves;
    }

    private List<ChessMove> PawnForward(ChessBoard board, ChessPosition position, int direction, bool start)
    {
        List<ChessMove> moves = new List<ChessMove>();
        int row = position.Row + direction;
        int col = position.Col;
        ChessPosition nextPosition = new ChessPosition(row, col);
        if (!ChessBoard.OutOfBounds(nextPosition))
        {
            ChessPiece? checkPosition = board.GetPiece(nextPosition);
            if(checkPosition == null)
            {
                if (row == 1 || row == 8)
                {
                    moves.AddRange(PawnPromotion(position, nextPosition));
                }
                else
                {
                    moves.Add(new ChessMove(position, nextPosition, null));
                    if (start)
                    {
                        moves.AddRange(PawnForward(board, position, direction + direction, false));

                    }
                }
            }
        }
        return moves;
    }

    private List<ChessMove> PawnCapture(ChessBoard board, ChessPosition position, int direction, TeamColor color)
    {
        List<ChessMove> moves = new List<ChessMove>();
        int row = position.Row;
        for (int i = -1; i <= 1; i += 2)
        {
            int col = position.Col + i;
            ChessPosition nextPosition = new ChessPosition(row, col);
            if (!ChessBoard.OutOfBounds(nextPosition))
            {
                ChessPiece? checkPosition = board.GetPiece(nextPosition);
                if (checkPosition != null && checkPosition.PieceColor != color)
                {
                    if (row == 1 || row == 8)
                    {
                        moves.AddRange(PawnPromotion(position, nextPosition));
                    }
                    else
                    {
                        moves.Add(new ChessMove(position, nextPosition, null));
                    }
                }
            }
        }
        return moves;
    }

    private List<ChessMove> EnPassant(ChessBoard board, ChessPosition position, int direction, int enPassantRow, ChessPiece piece)
    {
        List<ChessMove> moves = new List<ChessMove>();
        int row = position.Row;
        int col = position.Col;
        ChessMove? prevMove = board.LastMove;
        if(row == enPassantRow && prevMove != null)
        {
            for(int i = -1; i <= 1; i += 2)
            {
                int checkCol = col + i;
                ChessPosition checkPosition = new ChessPosition(row, checkCol);
                ChessPiece? checkPiece = !ChessBoard.OutOfBounds(checkPosition) ? board.GetPiece(checkPosition) : null;
                if(checkPiece != null && checkPiece.Type == piece.Type && checkPiece.PieceColor != piece.PieceColor)
                {
                    int checkRow = row + (direction * 2);
                    ChessPosition prevPosition = new ChessPosition(checkRow, checkCol);
                    ChessPosition endPosition = new ChessPosition(row + direction, checkCol);
                    ChessMove checkMove = new ChessMove(prevPosition, checkPosition, null);
                    if (checkMove.Equals(prevMove) && board.GetPiece(endPosition) == null)
                    {
                        moves.Add(new ChessMove(position, endPosition, null));
                    }
                }

            }
        }
        return moves;

    }
}

