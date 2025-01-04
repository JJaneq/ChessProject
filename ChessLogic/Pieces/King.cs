﻿namespace Chess.ChessLogic;

public class King : Piece
{
    public King(char color, int row, int col) : base(color, row, col)
    {
        PieceType = 'k';
    }

    public override List<Tile> GetPossibleMoves(Board board)
    {
        List<Tile> possibleMoves = new List<Tile>();
        List<Tile> opponentGuardedTiles = board.GetOpponentGuardedTiles(Color);
        int[][] directions = new int[][]
        {
            new int[] { -1, -1 }, // Góra-lewo
            new int[] { -1, 0 },  // Góra
            new int[] { -1, 1 },  // Góra-prawo
            new int[] { 0, -1 },  // Lewo
            new int[] { 0, 1 },   // Prawo
            new int[] { 1, -1 },  // Dół-lewo
            new int[] { 1, 0 },   // Dół
            new int[] { 1, 1 }    // Dół-prawo
        };

        foreach (var direction in directions)
        {
            if(Row + direction[0] >= 0 && Row + direction[0] <= 7 && Col + direction[1] >= 0 && Col + direction[1] <= 7)
            {
                Tile forwardTile = board.GetTile(Row + direction[0], Col + direction[1]);
                if (!opponentGuardedTiles.Contains(forwardTile) 
                    && (forwardTile.Piece == null || forwardTile.Piece.Color != Color))
                    possibleMoves.Add(forwardTile);
            }
        }
        return possibleMoves;
    }

    public override List<Tile> GetGuardedTiles(Board board)
    {
        // Król atakuje wszystkie pola wokół siebie
        List<Tile> guardedTiles = new List<Tile>();
        int[][] directions = new int[][]
        {
            new int[] { -1, -1 }, // Góra-lewo
            new int[] { -1, 0 },  // Góra
            new int[] { -1, 1 },  // Góra-prawo
            new int[] { 0, -1 },  // Lewo
            new int[] { 0, 1 },   // Prawo
            new int[] { 1, -1 },  // Dół-lewo
            new int[] { 1, 0 },   // Dół
            new int[] { 1, 1 }    // Dół-prawo
        };

        foreach (var direction in directions)
        {
            int newRow = Row + direction[0];
            int newCol = Col + direction[1];

            if (newRow >= 0 && newRow <= 7 && newCol >= 0 && newCol <= 7)
            {
                Tile forwardTile = board.GetTile(newRow, newCol);
                guardedTiles.Add(forwardTile);
            }
        }

        return guardedTiles;
    }
}