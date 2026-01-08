using System.Runtime.CompilerServices;

namespace ChessSharp.Shared.Chess;

using System.ComponentModel.DataAnnotations;
using ChessSharp.Shared.Chess.Pieces;
using ChessSharp.Shared.Enums;

public class ChessCheckCalculator
{
    private readonly ChessBoard board;
    
    public ChessCheckCalculator(ChessBoard board)
    {
        this.board = board;
    }
    /**
     * Determines if the given team is in check
     *
     * @param color which team to check for check
     * @return True if the specified team is in check
     */
    public bool IsInCheck(TeamColor color)
    {
        ChessPiece king = new ChessPiece(color, PieceType.KING);
        ChessPosition? kingPosition = null;
        List<ChessMove> oppositeMoves = new List<ChessMove>();
        List<Placement> boardList = board.ToList();
        foreach(Placement place in boardList)
        {
            if(place.Piece.PieceColor != color)
            {
                oppositeMoves.AddRange(place.Piece.PieceMoves(board, place.Position));
            }
            else if (place.Piece == king)
            {
                kingPosition = place.Position;
            }
        }
        foreach (ChessMove move in oppositeMoves)
        {
            if(move.EndPosition == kingPosition)
            {
                return true;
            }
        }
        return false;
    }

    /**
     * Determines if the given team is in checkmate
     *
     * @param color which team to check for checkmate
     * @return True if the specified team is in checkmate
     */

    public bool IsInCheckmate(TeamColor color)
    {
        return IsInCheck(color) && CantMove(color);
    }

    /**
     * Determines if the given team is in stalemate, which here is defined as having
     * no valid moves
     *
     * @param color which team to check for stalemate
     * @return True if the specified team is in stalemate, otherwise false
     */
    public bool IsInStalemate(TeamColor color)
    {
        return !IsInCheck(color) && CantMove(color);
    }

    private bool CantMove(TeamColor color)
    {
        List<Placement> boardList = board.ToList();
        List<ChessMove> valid = new List<ChessMove>();
        foreach(Placement place in boardList)
        {
            if(place.Piece.PieceColor == color)
            {
                valid.AddRange(new ChessMovesValidator(board).ValidMoves(place.Position));
            }
        }
        return valid.Count == 0;
    }
}