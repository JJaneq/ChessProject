namespace Chess.ChessLogic;

public class Knight : Piece
{
    public Knight(char color, int row, int col) : base(color, row, col)
    {
        PieceType = 'n';
    }

    public override List<Tile> GetPossibleMoves(Board board)
    {
        return null;
    }
}