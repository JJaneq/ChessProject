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

    public Board(int size)
    {
        Size = size;
        Tiles = new Tile[Size, Size];
        for (int i = 0; i < Size; i++)
        for (int j = 0; j < Size; j++)
            Tiles[i, j] = new Tile(i, j);

        // SelectedTile = null;
        SetStartPieces();
    }

    public void SetStartPieces()
    {
        for (int i = 0; i < Size; i++)
        for (int j = 0; j < Size; j++)
        {
            if (i == 1) 
                Tiles[i, j].Piece = new Pawn('b', i, j);
            else if (i == 6)
                Tiles[i, j].Piece = new Pawn('w', i, j);
            //TODO: dodać inne pionki startowe
        }
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