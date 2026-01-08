namespace ChessSharp.Shared.Tests.Chess;
using ChessSharp.Shared.Chess;
using ChessSharp.Shared.Enums;

public class ChessPositionTests
{
    private readonly ChessPosition original;
    private readonly ChessPosition equal;
    private readonly ChessPosition different;
    public ChessPositionTests()
    {
        original = new ChessPosition(3,7);
        equal =  new ChessPosition(3,7);
        different = new ChessPosition(7,3);
    }

    [Fact(DisplayName ="Equals Testing")]
    public void EqualsTest() {
        Assert.Equal(original, equal);
        Assert.NotEqual(original, different);

    }

    [Fact(DisplayName ="HashCode Testing")]
    public void HashCodeTest() {
        Assert.Equal(original.GetHashCode(), equal.GetHashCode());
        Assert.NotEqual(original.GetHashCode(), different.GetHashCode());

    }

    [Fact(DisplayName ="Combined Testing")]
    public void HashSetTest() {
        HashSet<ChessPosition> set = new HashSet<ChessPosition>();
        set.Add(original);

        Assert.Contains(original, set);
        Assert.Contains(equal, set);
        Assert.Single(set);
        set.Add(equal);
        Assert.Single(set);

        Assert.DoesNotContain(different, set);
        set.Add(different);
        Assert.Equal(2, set.Count);
    }


}