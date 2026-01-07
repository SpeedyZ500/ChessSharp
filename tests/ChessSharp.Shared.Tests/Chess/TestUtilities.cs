namespace ChessSharp.Shared.Tests.Chess;

using System.Collections;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;
public class TestUtilities
{
    public static void ValidateMoves(string boardText, ChessPosition startPosition, int[,] endPositions)
    {
        var board = LoadBoard(boardText);
        var testPiece = board.GetPiece(startPosition);
        var validMoves = LoadMoves(startPosition, endPositions);
        ValidateMoves(board, testPiece, startPosition, validMoves);
    }

    public static void ValidateMoves(ChessBoard board, ChessPiece testPiece, ChessPosition startPosition, 
                                        List<ChessMove> validMoves)
    {
        var pieceMoves = new List<ChessMove>(testPiece.PieceMoves(board, startPosition));
        ValidateMoves(validMoves,pieceMoves);
    }
    public static void ValidateMoves(List<ChessMove> expected, List<ChessMove> actual)
    {
        Comparer<ChessMove> comparer = Comparer<ChessMove>.Create((a, b) => MoveToInt(a).CompareTo(MoveToInt(b)));

        expected.Sort(comparer);
        actual.Sort(comparer);
        Assert.Equal(expected, actual);
    }
    private static readonly Dictionary<char, PieceType> CHAR_TO_TYPE_MAP = new Dictionary<char, PieceType>
    {
        {'p', PieceType.PAWN},
        {'n', PieceType.KNIGHT},
        {'r', PieceType.ROOK},
        {'q', PieceType.QUEEN},
        {'k', PieceType.KING},
        {'b', PieceType.BISHOP}
    };

    public static ChessBoard LoadBoard(string boardText)
    {
        var board = new ChessBoard();
        int row = 8;
        int column = 1;
        foreach (var c in boardText.ToCharArray())
        {
            switch (c)
            {
                case '\n':
                    column = 1;
                    row--;
                    break;
                case ' ':
                    column++;
                    break;
                case '|':
                    break;
                default:
                    TeamColor color = Char.IsLower(c) ? TeamColor.BLACK : TeamColor.WHITE;
                    var type = CHAR_TO_TYPE_MAP[Char.ToLower(c)];
                    var position = new ChessPosition(row, column);
                    var piece = new ChessPiece(color, type);
                    board.AddPiece(position, piece);
                    column++;
                    break;

            }
        }
        return board;
    }

    public static List<ChessMove> LoadMoves(ChessPosition startPosition, int[,] endPositions)
    {
        var validMoves = new List<ChessMove>();
        for(int i =0; i < endPositions.GetLength(0); i++)
        {
            validMoves.Add(new ChessMove(startPosition, new ChessPosition(endPositions[i,0], endPositions[i,1]), null));
        }
        return validMoves;
    }

    public static ChessBoard DefaultBoard()
    {
        return LoadBoard("""
            |r|n|b|q|k|b|n|r|
            |p|p|p|p|p|p|p|p|
            | | | | | | | | |
            | | | | | | | | |
            | | | | | | | | |
            | | | | | | | | |
            |P|P|P|P|P|P|P|P|
            |R|N|B|Q|K|B|N|R|
            """);
    }

    private static int PositionToInt(ChessPosition position)
    {
        return 10 * position.Row + position.Col;
    }

    private static int MoveToInt(ChessMove move)
    {
        return 1000 * PositionToInt(move.StartPosition) + 10 * PositionToInt(move.EndPosition) + 
        ((move.Promotion != null) ? ((int) move.Promotion) + 1 : 0);
    }
}