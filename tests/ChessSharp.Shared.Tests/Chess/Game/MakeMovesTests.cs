using ChessSharp.Shared.Enums;

namespace ChessSharp.Shared.Tests.Chess.Game;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;
using ChessSharp.Shared.Exceptions;

public class MakeMovesTests
{
    private ChessGame game;

    public MakeMovesTests()
    {
        game = new ChessGame();
        game.Turn = TeamColor.WHITE;
        game.Board = TestUtilities.DefaultBoard();

    }

    [Fact(DisplayName ="Make Valid King Move")]
    public void MakeValidKingMoveTest() {
        game.Board = TestUtilities.LoadBoard("""
                | | | | | | | | |
                |p| | | | | | |k|
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | |K| | | | | | |
                """);
        game.Turn = TeamColor.WHITE;

        var kingStartPosition = new ChessPosition(1, 2);
        var kingEndPosition = new ChessPosition(1, 1);
        game.MakeMove(new ChessMove(kingStartPosition, kingEndPosition, null));

        Assert.Equal(TestUtilities.LoadBoard("""
                | | | | | | | | |
                |p| | | | | | |k|
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |K| | | | | | | |
                """), game.Board);
    }

    [Fact(DisplayName ="Make Valid Queen Move")]
    public void MakeValidQueenMoveTest() {
        game.Board = TestUtilities.LoadBoard("""
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | |q| |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |K| |k| | | | | |
                """);
        game.Turn = TeamColor.BLACK;

        var queenStartPosition = new ChessPosition(6, 7);
        var queenEndPosition = new ChessPosition(1, 2);
        game.MakeMove(new ChessMove(queenStartPosition, queenEndPosition, null));

        Assert.Equal(TestUtilities.LoadBoard("""
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |K|q|k| | | | | |
                """), game.Board);
    }

    [Fact(DisplayName ="Make Valid Rook Move")]
    public void MakeValidRookMoveTest() {
        game.Board = TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | |R|
                | | | | | | | | |
                |K| | | | | | | |
                """);
        game.Turn = TeamColor.WHITE;

        var rookStartPosition = new ChessPosition(3, 8);
        var rookEndPosition = new ChessPosition(7, 8);
        game.MakeMove(new ChessMove(rookStartPosition, rookEndPosition, null));

        Assert.Equal(TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | | | | | | |R|
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |K| | | | | | | |
                """), game.Board);
    }

    
    [Fact(DisplayName ="Make Valid Knight Move")]
    public void MakeValidKnightMoveTest()  {
        game.Board = TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | | | | | | | |
                | | |n| | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | |P|
                | | | | |K| | | |
                """);
        game.Turn = TeamColor.BLACK;

        var knightStartPosition = new ChessPosition(6, 3);
        var knightEndPosition = new ChessPosition(4, 4);
        game.MakeMove(new ChessMove(knightStartPosition, knightEndPosition, null));

        Assert.Equal(TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | |n| | | | |
                | | | | | | | | |
                | | | | | | | |P|
                | | | | |K| | | |
                """), game.Board);
    }

    
    [Fact(DisplayName ="Make Valid Bishop Move")]
    public void MakeValidBishopMoveTest()  {
        game.Board = TestUtilities.LoadBoard("""
                | | | | |k| | | |
                |p| | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | |B| |K| | | |
                """);
        game.Turn = TeamColor.WHITE;

        var bishopStartPosition = new ChessPosition(1, 3);
        var bishopEndPosition = new ChessPosition(6, 8);
        game.MakeMove(new ChessMove(bishopStartPosition, bishopEndPosition, null));

        Assert.Equal(TestUtilities.LoadBoard("""
                | | | | |k| | | |
                |p| | | | | | | |
                | | | | | | | |B|
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
                """), game.Board);
    }

    
    [Fact(DisplayName ="Make Valid Pawn Move")]
    public void MakeValidPawnMoveTest()  {
        game.Board = TestUtilities.LoadBoard("""
                | |k| | | | | | |
                | |p| | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | |P| |
                | | | | | | |K| |
                """);
        game.Turn = TeamColor.BLACK;

        var pawnStartPosition = new ChessPosition(7, 2);
        var pawnEndPosition = new ChessPosition(6, 2);
        game.MakeMove(new ChessMove(pawnStartPosition, pawnEndPosition, null));

        Assert.Equal(TestUtilities.LoadBoard("""
                | |k| | | | | | |
                | | | | | | | | |
                | |p| | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | |P| |
                | | | | | | |K| |
                """), game.Board);
    }

    
    [Fact(DisplayName ="Make Move Changes Team Turn")]
    public void MakeMoveChangesTurnTest()  {
        game.MakeMove(new ChessMove(new ChessPosition(2, 5), new ChessPosition(4, 5), null));
        Assert.Equal(TeamColor.BLACK, game.Turn);

        game.MakeMove(new ChessMove(new ChessPosition(7, 5), new ChessPosition(5, 5), null));
        Assert.Equal(TeamColor.WHITE, game.Turn);
    }

    
    [Fact(DisplayName ="Invalid Make Move Too Far")]
    public void InvalidMakeMoveTooFarTest() {
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(2, 1), new ChessPosition(5, 1), null)));
    }

    
    [Fact(DisplayName ="Invalid Make Move Pawn Diagonal No Capture")]
    public void InvalidMakeMovePawnDiagonalNoCaptureTest() {
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(2, 1), new ChessPosition(3, 2), null)));
    }

    
    [Fact(DisplayName ="Invalid Make Move Out Of Turn")]
    public void InvalidMakeMoveOutOfTurnTest() {
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(7, 5), new ChessPosition(6, 5), null)));
    }

    
    [Fact(DisplayName ="Invalid Make Move Through Piece")]
    public void InvalidMakeMoveThroughPieceTest() {
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(1, 1), new ChessPosition(4, 1), null)));
    }

    
    [Fact(DisplayName ="Invalid Make Move No Piece")]
    public void InvalidMakeMoveNoPieceTest() {
        //starting position does not have a piece
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(4, 4), new ChessPosition(4, 5), null)));
    }

    
    [Fact(DisplayName ="Invalid Make Move Invalid Move")]
    public void InvalidMakeMoveInvalidMoveTest() {
        //not a move the piece can ever take
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(8, 7), new ChessPosition(5, 5), null)));
    }

    
    [Fact(DisplayName ="Invalid Make Move Take Own Piece")]
    public void InvalidMakeMoveTakeOwnPieceTest() {
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(1, 3), new ChessPosition(2, 4), null)));
    }

    
    [Fact(DisplayName ="Invalid Make Move Captured Piece")]
    public void InvalidMakeMoveCapturedPieceTest()  {
        game.Board = TestUtilities.LoadBoard("""
                |r|n|b|q|k|b|n|r|
                |p|p|p|p| |p|p|p|
                | | | | | | | | |
                | | | | |p| | | |
                | | | | | | | | |
                | | | | | |N| | |
                |P|P|P|P|P|P|P|P|
                |R|N|B|Q|K|B| |R|
                """);

        game.MakeMove(new ChessMove(new ChessPosition(3, 6), new ChessPosition(5, 5), null));
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(5, 5), new ChessPosition(4, 5), null)));
    }

    
    [Fact(DisplayName ="Invalid Make Move Jump Enemy")]
    public void InvalidMakeMoveJumpEnemyTest() {
        game.Board = TestUtilities.LoadBoard("""
                | | | | |k| | | |
                | | | | | | | | |
                | | | | | | | | |
                |R| |r| | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | | | | |K| | | |
                """);
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(5, 1), new ChessPosition(5, 5), null)));
    }

    
    [Fact(DisplayName ="Invalid Make Move In Check")]
    public void InvalidMakeMoveInCheckTest() {
        game.Board = TestUtilities.LoadBoard("""
                |r|n| |q|k|b| |r|
                |p| |p|p|p|p|p|p|
                |b|p| | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                |P| | |B| |n| | |
                |R|P|P| | |P|P|P|
                | |N|B|Q|K| |R| |
                """);
        //try to make an otherwise valid move that doesn't remove check
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(1, 7), new ChessPosition(1, 8), null)));
    }

    
    [Fact(DisplayName ="Invalid Make Move Double Move Moved Pawn")]
    public void InvalidMakeMoveDoubleMoveMovedPawnTest() {
        game.Board = TestUtilities.LoadBoard("""
                |r|n|b|q|k|b|n|r|
                |p| |p|p|p|p|p|p|
                | | | | | | | | |
                | |p| | | | | | |
                | | | | | | | | |
                | | | | | | |P| |
                |P|P|P|P|P|P| |P|
                |R|N|B|Q|K|B|N|R|
                """);
        Assert.Throws<InvalidMoveException>(() => game.MakeMove(new ChessMove(new ChessPosition(3, 7), new ChessPosition(5, 7), null)));
    }



    [Theory]
    [InlineData(PieceType.QUEEN)]
    [InlineData(PieceType.ROOK)]
    [InlineData(PieceType.KNIGHT)]
    [InlineData(PieceType.BISHOP)]

    public void PromotionMoves(PieceType promotionType)  {
        

        game.Board = TestUtilities.LoadBoard("""
                | | | | | | | | |
                | | |P| | | | | |
                | | | | | | |k| |
                | | | | | | | | |
                | | | | | | | | |
                | | | | | | | | |
                | |K| | |p| | | |
                | | | | | |Q| | |
                """);

        //White promotion
        ChessMove whitePromotion = new ChessMove(new ChessPosition(7, 3), new ChessPosition(8, 3), promotionType);
        game.MakeMove(whitePromotion);

        Assert.Null(game.Board.GetPiece(whitePromotion.StartPosition));
        ChessPiece? whiteEndPiece = game.Board.GetPiece(whitePromotion.EndPosition);
        Assert.NotNull(whiteEndPiece);
        Assert.Equal(promotionType, whiteEndPiece.Type);
        Assert.Equal(TeamColor.WHITE, whiteEndPiece.PieceColor);


        //Black take + promotion
        game.Turn = TeamColor.BLACK;
        ChessMove blackPromotion = new ChessMove(new ChessPosition(2, 5), new ChessPosition(1, 6), promotionType);
        game.MakeMove(blackPromotion);

        Assert.Null(game.Board.GetPiece(blackPromotion.StartPosition));
        ChessPiece? blackEndPiece = game.Board.GetPiece(blackPromotion.EndPosition);
        Assert.NotNull(blackEndPiece);
        Assert.Equal(promotionType, blackEndPiece.Type);
        Assert.Equal(TeamColor.BLACK, blackEndPiece.PieceColor);
    }
}