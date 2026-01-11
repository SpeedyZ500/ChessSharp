namespace ChessSharp.Shared.Tests.Converters;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;
using ChessSharp.Shared.Converters;

using System.Text.Json;

public class BoardConversionTests
{
    [Fact]
    public void ChessBoardConversionTest()
    {
        ChessBoard board = new ChessBoard();
        board.ResetBoard();
        var json = JsonSerializer.Serialize(board, ChessJson.Create());
        
        ChessBoard restoredBoard = JsonSerializer.Deserialize<ChessBoard>(json, ChessJson.Create())!;

        Assert.Equal(board, restoredBoard);
    }

    [Fact]
    public void ChessGameConversionTest()
    {
        ChessGame game = new ChessGame();
        
        var json = JsonSerializer.Serialize(game, ChessJson.Create());
        
        ChessGame restoredGame = JsonSerializer.Deserialize<ChessGame>(json, ChessJson.Create())!;

        Assert.Equal(game, restoredGame);
    }

    [Fact]
    public void ChessGameMovedConversionTest()
    {
        ChessGame game = new ChessGame();
        game.MakeMove(new ChessMove(new ChessPosition(2, 5), new ChessPosition(4, 5), null));

        var json = JsonSerializer.Serialize(game, ChessJson.Create());
        
        ChessGame restoredGame = JsonSerializer.Deserialize<ChessGame>(json, ChessJson.Create())!;

        Assert.Equal(game, restoredGame);
    }

    [Fact]
    public void FullGameConversionTest()
    {
        ChessGame game = new ChessGame();
        game.MakeMove(new ChessMove(new ChessPosition(2, 5), new ChessPosition(4, 5), null));
        game.MakeMove(new ChessMove(new ChessPosition(7, 5), new ChessPosition(5, 5), null));
        game.MakeMove(new ChessMove(new ChessPosition(1, 6), new ChessPosition(4, 3), null));
        game.MakeMove(new ChessMove(new ChessPosition(8, 7), new ChessPosition(6, 6), null));
        game.MakeMove(new ChessMove(new ChessPosition(1, 4), new ChessPosition(5, 8), null));
        game.MakeMove(new ChessMove(new ChessPosition(8, 2), new ChessPosition(6, 3), null));
        game.MakeMove(new ChessMove(new ChessPosition(5, 8), new ChessPosition(7, 6), null));
        
        var json = JsonSerializer.Serialize(game, ChessJson.Create());
        
        ChessGame restoredGame = JsonSerializer.Deserialize<ChessGame>(json, ChessJson.Create())!;

        Assert.Equal(game, restoredGame);
    }

}
