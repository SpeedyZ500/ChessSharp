namespace ChessSharp.Shared.Chess;

using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ChessSharp.Shared.Chess.Pieces;
using ChessSharp.Shared.Enums;
public record ChessPiece(TeamColor PieceColor, PieceType Type)
{
    public List<ChessMove> PieceMoves(ChessBoard board, ChessPosition myPosition)
    {
        ChessPiece? piece = board.GetPiece(myPosition);
        List<ChessMove> moves = [];
        IChessMovesCalculator calculator;

        if (piece != null)
        {
            switch (piece.Type)
            {
                case PieceType.KING:
                    calculator = new KingMovesCalculator();
                    moves.AddRange(calculator.PieceMoves(board, myPosition));
                    break;
                case PieceType.PAWN:
                    moves.AddRange();
                    break;
                case PieceType.ROOK:
                    calculator = new RookMovesCalculator();
                    moves.AddRange(calculator.PieceMoves(board, myPosition));
                    break;
                case PieceType.BISHOP:
                    calculator = new BishopMovesCalculator();
                    moves.AddRange(calculator.PieceMoves(board, myPosition));
                    break;
                case PieceType.KNIGHT:
                    calculator = new KnightMovesCalculator();
                    moves.AddRange(calculator.PieceMoves(board, myPosition));
                    break;
                case PieceType.QUEEN:
                    calculator = new BishopMovesCalculator();
                    moves.AddRange(calculator.PieceMoves(board, myPosition));
                    calculator = new RookMovesCalculator();
                    moves.AddRange(calculator.PieceMoves(board, myPosition));
                    break;
                default:
                    break;
            }
        }

        return moves;
    }
}