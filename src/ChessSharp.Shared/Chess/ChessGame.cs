namespace ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;
using ChessSharp.Shared.Exceptions;
public class ChessGame
{
    private TeamColor turn;
    private ChessBoard board = new ChessBoard();
    private bool gameOver;
    public bool GameOver
    {
        get{return gameOver;}
        set{ gameOver = value;}
    }
    public TeamColor Turn
    {
        get{return turn;}
        set{turn = value;}
    }

    public ChessBoard Board
    {
        get{return board;}
        set{board = value;}
    }
    public ChessGame() {
        turn = TeamColor.WHITE;
        board.ResetBoard();
        gameOver = false;
    }

    public List<ChessMove> ValidMoves(ChessPosition startPosition)
    {
        ChessPiece? piece = board.GetPiece(startPosition);
        List<ChessMove> valid = new List<ChessMove>();
        if(piece != null)
        {
            ChessMovesValidator movesValidator = new ChessMovesValidator(board);
            valid.AddRange(movesValidator.ValidMoves(startPosition));
        }
        return valid;
    }

    /**
     * Makes a move in a chess game
     *
     * @param move chess move to preform
     * @throws InvalidMoveException if move is invalid
     */
    public void MakeMove(ChessMove move) 
    {
        ChessPosition start = move.StartPosition;
        ChessPiece? piece = board.GetPiece(start);
        List<ChessMove> valid = ValidMoves(start);
        if(!valid.Contains(move) || piece == null){
            throw new InvalidMoveException($"Error: From {move.StartPosition} to {move.EndPosition} is not a valid move");
        }
        else if(piece.PieceColor != turn){
            throw new InvalidMoveException($"Error: it is {turn} team's turn");
        }
        board.MovePiece(move);
        if(turn == TeamColor.WHITE){
            turn = TeamColor.BLACK;
        }
        else if (turn == TeamColor.BLACK){
            turn = TeamColor.WHITE;
        }
    }

    /**
     * Determines if the given team is in check
     *
     * @param teamColor which team to check for check
     * @return True if the specified team is in check
     */
    public bool IsInCheck(TeamColor teamColor) 
    {
        return new ChessCheckCalculator(board).IsInCheck(teamColor);
    }

    /**
     * Determines if the given team is in checkmate
     *
     * @param teamColor which team to check for checkmate
     * @return True if the specified team is in checkmate
     */

    public bool IsInCheckmate(TeamColor teamColor) 
    {
        bool checkmate = new ChessCheckCalculator(board).IsInCheckmate(teamColor);
        if(checkmate){
            gameOver = true;
        }
        return checkmate;
    }

    /**
     * Determines if the given team is in stalemate, which here is defined as having
     * no valid moves
     *
     * @param teamColor which team to check for stalemate
     * @return True if the specified team is in stalemate, otherwise false
     */
    public bool IsInStalemate(TeamColor teamColor) 
    {
        bool stalemate = new ChessCheckCalculator(board).IsInStalemate(teamColor);
        if(stalemate){
            gameOver = true;
        }
        return stalemate;
    }

    public bool Equals(ChessGame? other)
    {
        if (other is null) return false;
        if (other is not ChessGame) return false;
        if (ReferenceEquals(this, other)) return true;
        return turn == other.turn && board.Equals(other.board);
    }

    
    public override bool Equals(object? obj) => Equals(obj as ChessGame);
    public override int GetHashCode()
    {
        return HashCode.Combine(turn, board);
    }

    public override string ToString()
    {
        return $"ChessGame{{turn={turn}, board={board}, gameOver={gameOver}}}";
    }

    
}