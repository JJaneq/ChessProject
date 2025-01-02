namespace Chess.ChessLogic;

public class King : Piece
{
    public King(char color, int row, int col) : base(color, row, col)
    {
        PieceType = 'k';
    }

    public override List<Tile> GetPossibleMoves(Board board)
    {
        return null;
    }
}