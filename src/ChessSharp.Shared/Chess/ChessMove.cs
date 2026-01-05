namespace ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;
public record ChessMove(ChessPosition StartPosition, ChessPosition EndPosition, PieceType? Promotion = null);