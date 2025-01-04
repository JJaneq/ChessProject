namespace Chess.ChessLogic;

public abstract class Piece
{
    public char Color {get; set;}
    public char PieceType {get; set;}
    public Boolean Moved {get; set;}
    public int Row {get; set;}
    public int Col {get; set;}

    public Piece(char color, int row, int col)
    {
        Color = color;
        Moved = false;
        Row = row;
        Col = col;
    }

    public abstract List<Tile> GetPossibleMoves(Board board);

    public abstract List<Tile> GetGuardedTiles(Board board);

    //FIXME: Za dużo razy sprawdza ruchy na całej planszy - wywoływanie tego w returnie każdej figury to prosty sposób na szybkie zabicie programu :)
    public List<Tile> RemoveBlockedMoves(Board board, List<Tile> possibleMoves)
    {
        int ogCol = Col;
        int ogRow = Row;
        List<Tile> blockedMoves = new List<Tile>();
        
        foreach (Tile tile in possibleMoves)
        {
            board.GetTile(ogRow, ogCol).Piece = null;
            var ogPiece = tile.Piece;
            tile.Piece = this;

            if (board.isKingChecked(Color))
            {
                blockedMoves.Add(tile);
            }
            
            tile.Piece = ogPiece;
            board.GetTile(ogRow, ogCol).Piece = this;
        }
        return possibleMoves.Except(blockedMoves).ToList();
    }
}