namespace Chess.ChessLogic;

public class Rook : Piece
{
    public Rook(char color, int row, int col) : base(color, row, col)
    {
        PieceType = 'r';
    }

    public override List<Tile> GetPossibleMoves(Board board)
    {
        List<Tile> possibleMoves = new List<Tile>();

        int[][] directions = new int[][]
        {
            new int[] { -1, 0 }, // Góra
            new int[] { 1, 0 },  // Dół
            new int[] { 0, -1 }, // Lewo
            new int[] { 0, 1 }   // Prawo
        };

        foreach (var direction in directions)
        {
            int newRow = Row;
            int newCol = Col;

            while (true)
            {
                newRow += direction[0];
                newCol += direction[1];

                if (newRow < 0 || newRow > 7 || newCol < 0 || newCol > 7)
                {
                    break;
                }

                Tile tile = board.GetTile(newRow, newCol);
                possibleMoves.Add(tile);
                if (tile.Piece != null)
                {
                   // if (tile.Piece.Color != this.Color)
                   // {
                       // possibleMoves.Add(tile);
                   // }
                    break;
                }
                //possibleMoves.Add(tile);
            }
        }

        return possibleMoves;
    }

    public override List<Tile> GetGuardedTiles(Board board)
    {
        return GetPossibleMoves(board);
    }
}