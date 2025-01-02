namespace Chess.ChessLogic;

public class Rook : Piece
{
    public Rook(char color, int row, int col) : base(color, row, col)
    {
        PieceType = 'r';
    }

    public override List<Tile> GetPossibleMoves(Board board)
    {
        return null;
    }
}