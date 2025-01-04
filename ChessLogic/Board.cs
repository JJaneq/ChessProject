using System.Reflection.Metadata.Ecma335;

namespace Chess.ChessLogic;

public class Board
{
    public readonly int Size;
    
    public Tile[,] Tiles {get; set;}
    // {
    //     get { return _tiles; }
    //     set { _tiles = value; }
    // }
    public Tile? SelectedTile {get; set;}

    public Boolean Check { get; private set; }
    
    public Board(int size)
    {
        Size = size;
        Tiles = new Tile[Size, Size];
        for (int i = 0; i < Size; i++)
        for (int j = 0; j < Size; j++)
            Tiles[i, j] = new Tile(i, j);

        // SelectedTile = null;
        Check = false;
        
        SetStartPieces();
    }

    public void SetStartPieces()
    {
        for (int i = 0; i < Size; i++)
        for (int j = 0; j < Size; j++)
        {
            if (i == 0 && j == 4)
                Tiles[i, j].Piece = new King('b', i, j);
            if (i == 7 && j == 4)
                Tiles[i, j].Piece = new King('w', i, j);
            if (i == 0 && j == 3)
                Tiles[i, j].Piece = new Queen('b', i, j);
            if (i == 7 && j == 3)
                Tiles[i, j].Piece = new Queen('w', i, j);
            if (i == 0 && (j == 2 || j == 5))
                Tiles[i, j].Piece = new Bishop('b', i, j);
            if (i == 7 && (j == 2 || j == 5))
                Tiles[i, j].Piece = new Bishop('w', i, j); 
            if (i == 0 && (j == 1 || j == 6))
                Tiles[i, j].Piece = new Knight('b', i, j);
            if (i == 7 && (j == 1 || j == 6))
                Tiles[i, j].Piece = new Knight('w', i, j); 
            if (i == 0 && (j == 0 || j == 7))
                Tiles[i, j].Piece = new Rook('b', i, j);
            if (i == 7 && (j == 0 || j == 7))
                Tiles[i, j].Piece = new Rook('w', i, j);
            if (i == 1) 
                Tiles[i, j].Piece = new Pawn('b', i, j);
            if (i == 6)
                Tiles[i, j].Piece = new Pawn('w', i, j);
        }
    }

    public List<Tile> GetOpponentGuardedTiles(char playerColor)
    {
        List<Tile> guardedTiles = new List<Tile>();

        // Przejdź przez wszystkie pola planszy
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Tile tile = GetTile(i, j);
                Piece? piece = tile.Piece;

                // Jeśli na polu jest figura przeciwnika, pobierz jej strzeżone pola
                if (piece != null && piece.Color != playerColor)
                {
                    guardedTiles.AddRange(piece.GetGuardedTiles(this));
                }
            }
        }

        return guardedTiles;
    }
    
    public Boolean isKingChecked(char color)
    {
        List<Tile> guardedTiles = GetOpponentGuardedTiles(color);
        foreach (var tile in guardedTiles)
        {
            if (tile.Piece is King)
            {
                Check = true;
                return true;
            }
        }

        Check = false;
        return false;
    }
    
    public Piece? GetPiece(int x, int y)
    {
        return Tiles[x, y].Piece;
    }

    public Tile GetTile(int x, int y)
    {
        return Tiles[x, y];
    }
}