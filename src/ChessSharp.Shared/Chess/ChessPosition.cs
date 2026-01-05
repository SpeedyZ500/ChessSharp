namespace ChessSharp.Shared.Chess;

public record ChessPosition(int Row, int Col)
{
    public string PrettyOut() => $"{(char)('a' + Col)}{Row + 1}";
}