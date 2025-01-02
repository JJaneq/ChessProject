namespace Chess.ChessLogic;

public class Knight : Piece
{
    public Knight(char color, int row, int col) : base(color, row, col)
    {
        PieceType = 'n';
    }

    public override List<Tile> GetPossibleMoves(Board board)
    {
        List<Tile> possibleMoves = new List<Tile>();

        int[][] moves = new int[][]
        {
            new int[] { -2, -1 },
            new int[] { -2, 1 },
            new int[] { -1, -2 },
            new int[] { -1, 2 },
            new int[] { 1, -2 },
            new int[] { 1, 2 },
            new int[] { 2, -1 },
            new int[] { 2, 1 }
        };

        foreach (var move in moves)
        {
            int newRow = Row + move[0];
            int newCol = Col + move[1];

            if (newRow >= 0 && newRow <= 7 && newCol >= 0 && newCol <= 7)
            {
                Tile tile = board.GetTile(newRow, newCol);
                if (tile.Piece == null || tile.Piece.Color != this.Color)
                {
                    possibleMoves.Add(tile);
                }
            }
        }

        return possibleMoves;
    }
}
