namespace Chess.ChessLogic;

public class Bishop : Piece
{
    public Bishop(char color, int row, int col) : base(color, row, col)
    {
        PieceType = 'b';
    }

    public override List<Tile> GetPossibleMoves(Board board)
    {
        return null;
    }
}