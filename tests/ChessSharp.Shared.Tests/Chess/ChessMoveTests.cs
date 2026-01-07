namespace ChessSharp.Shared.Tests.Chess;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class ChessMoveTests
{
    private readonly ChessMove original;
    private readonly ChessMove equal;
    private readonly ChessMove startDifferent;
    private readonly ChessMove endDifferent;
    private readonly ChessMove promoteDifferent;
    public ChessMoveTests()
    {
        original = new ChessMove(new ChessPosition(2, 6), new ChessPosition(1, 5), null);
        equal = new ChessMove(new ChessPosition(2, 6), new ChessPosition(1, 5), null);
        startDifferent = new ChessMove(new ChessPosition(2, 4), new ChessPosition(1, 5), null);
        endDifferent = new ChessMove(new ChessPosition(2, 6), new ChessPosition(5, 3), null);
        promoteDifferent = new ChessMove(new ChessPosition(2, 6), new ChessPosition(1, 5), PieceType.QUEEN);
    }

    [Fact(DisplayName ="Equals Testing")]
    public void EqualsTest() {
        Assert.Equal(original, equal);
        Assert.NotEqual(original, startDifferent);
        Assert.NotEqual(original, endDifferent);
        Assert.NotEqual(original, promoteDifferent);
    }

    [Fact(DisplayName ="HashCode Testing")]
    public void HashCodeTest() {
        Assert.Equal(original.GetHashCode(), equal.GetHashCode());
        Assert.NotEqual(original.GetHashCode(), startDifferent.GetHashCode());
        Assert.NotEqual(original.GetHashCode(), endDifferent.GetHashCode());
        Assert.NotEqual(original.GetHashCode(), promoteDifferent.GetHashCode());
    }

    [Fact(DisplayName ="Combined Testing")]
    public void HashSetTest() {
        HashSet<ChessMove> set = new HashSet<ChessMove>();
        set.Add(original);

        Assert.Contains(original, set);
        Assert.Contains(equal, set);
        Assert.Single(set);
        set.Add(equal);
        Assert.Single(set);

        Assert.DoesNotContain(startDifferent, set);
        set.Add(startDifferent);
        Assert.Equal(2, set.Count);

        Assert.DoesNotContain(endDifferent, set);
        set.Add(endDifferent);
        Assert.Equal(3, set.Count);

        Assert.DoesNotContain(promoteDifferent, set);
        set.Add(promoteDifferent);
        Assert.Equal(4, set.Count);
    }


}