namespace ChessSharp.Shared.Chess;

using ChessSharp.Shared.Exceptions;
using ChessSharp.Shared.Enums;
using System;

public class ChessBoard
{
    private readonly HashSet<ChessPosition> history;
    public HashSet<ChessPosition> History => history;
    private ChessMove? lastMove = null;
    public ChessMove? LastMove => lastMove;


    private readonly Dictionary<ChessPosition, ChessPiece> board;


    public ChessBoard() 
    {
        this.history = new HashSet<ChessPosition>();
        this.board = new Dictionary<ChessPosition, ChessPiece>();
    }

    public ChessBoard(Dictionary<ChessPosition, ChessPiece> board)
    {
        this.board = board;
        this.history = new HashSet<ChessPosition>();
    }
    public bool Equals(ChessBoard? other)
    {
        if (other is null) return false;
        if (other is not ChessBoard) return false;
        if (ReferenceEquals(this, other)) return true;
        if (board.Count != other.board.Count)
            return false;
        return board.All(kvp => other.board.TryGetValue(kvp.Key, out var value) && kvp.Value.Equals(value));

    }

    private static int BoardHash(Dictionary<ChessPosition, ChessPiece> board)
    {
        unchecked // allow overflow
        {
            int hash = 19;
            foreach (var kvp in board.OrderBy(kvp => kvp.Key)) // deterministic order
            {
                hash = hash * 31 + kvp.Key.GetHashCode();
                hash = hash * 31 + kvp.Value.GetHashCode();
            }
            return hash;
        }
    }
    public override bool Equals(object? obj) => Equals(obj as ChessBoard);
    public override int GetHashCode()
    {
        int boardHash = BoardHash(board);
        return HashCode.Combine(boardHash, lastMove);
    }

    public void AddPiece(ChessPosition position, ChessPiece piece)
    {
        if (OutOfBounds(position))
        {
            throw new InvalidPositionException("Chess Piece out of bounds");
        }
        board.Add(position, piece);
    }

    public void AddPiece(Placement place)
    {
        AddPiece(place.Position, place.Piece);
    }

    public ChessPiece? GetPiece(ChessPosition position)
    {
        if (OutOfBounds(position))
        {
            throw new InvalidPositionException("Chess Piece out of bounds");
        }
        try
        {
            return board[position];
        }
        catch
        {
            return null;
        }
    }

    public static bool OutOfBounds(ChessPosition position){
        return position.Row < 1 || position.Row > 8 || position.Col < 1 || position.Col > 8;
    }

    public void ResetBoard()
    {
        board.Clear();
        history.Clear();
        lastMove = null;
        ResetBack(TeamColor.WHITE, 1);
        ResetPawns(TeamColor.WHITE,2);
        ResetPawns(TeamColor.BLACK,7);
        ResetBack(TeamColor.BLACK, 8);
    }

    private void ResetPawns(TeamColor color, int row)
    {
        for(int i = 1; i <= 8; i++)
        {
            AddPiece(new ChessPosition(row, i), new ChessPiece(color, PieceType.PAWN));
        }
    }

    private void ResetBack(TeamColor color, int row)
    {
        for(int i = 1; i <= 8; i++)
        {
            PieceType type = i switch
            {
                1 or 8 => PieceType.ROOK,
                2 or 7 => PieceType.KNIGHT,
                3 or 6 => PieceType.BISHOP,
                4 => PieceType.QUEEN,
                5 => PieceType.KING,
                _ => PieceType.PAWN
            };
            AddPiece(new ChessPosition(row, i), new ChessPiece(color, type));
        }
    }


    public override string ToString(){
        return $"ChessBoard{{history={history}, lastMove={lastMove}, board={board}}}";
    }

    public void MovePiece(ChessPosition startPosition, ChessPosition endPosition, PieceType? promotion = null)
    {
        ChessPiece? thisPieces = GetPiece(startPosition);
        if (thisPieces == null)
        {
            return;
        }
        ChessPiece thisPiece = (ChessPiece) thisPieces;

        if(thisPiece.Type == PieceType.ROOK || thisPiece.Type == PieceType.KING)
        {
            history.Add(startPosition);
            history.Add(endPosition);
        }
        int endCol = endPosition.Col;
        int startCol = startPosition.Col;
        int file = endCol - startCol;
        int startRow = startPosition.Row;
        if (thisPiece.Type == PieceType.PAWN && startCol != endCol)
        {
            board.Remove(new ChessPosition(startRow, endCol));
        }
        else if(thisPiece.Type == PieceType.KING && Math.Abs(file) == 2)
        {
            int dir = file/Math.Abs(file);
            int rookCol = endCol - dir;
            ChessPosition rookPosition = new ChessPosition(startRow, dir > 0 ? 8 : 1);
            ChessPiece? rook = GetPiece(rookPosition);
            if(rook != null)
            {
                board.Remove(rookPosition);
                board.Add(new ChessPosition(startRow, rookCol), rook);
            }
        }
        if(promotion != null)
        {
            board[endPosition] = new ChessPiece(thisPiece.PieceColor, (PieceType)promotion);
        }
        else
        {
            board[endPosition] = thisPiece;
        }
        board.Remove(startPosition);
        lastMove = new ChessMove(startPosition, endPosition, promotion);
    }

    public void MovePiece(ChessMove move)
    {
        MovePiece(move.StartPosition, move.EndPosition, move.Promotion);
    }

    public List<Placement> ToList()
    {
        List<Placement> placements = new List<Placement>();
        foreach (KeyValuePair<ChessPosition, ChessPiece> entry in board)
        {
            placements.Add(new Placement(entry.Key, entry.Value));
        }
        return placements;
    }

}