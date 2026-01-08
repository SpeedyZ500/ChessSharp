namespace ChessSharp.Shared.Tests.Chess.Game;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class MakeMovesTests
{
    private ChessGame game;

    public MakeMovesTests()
    {
        game = new ChessGame();
        game.Turn = TeamColor.WHITE;
        game.Board = TestUtilities.DefaultBoard();

    }
}