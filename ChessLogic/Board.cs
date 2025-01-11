using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.JavaScript;

namespace Chess.ChessLogic;

public class Board
{
    public readonly int Size;

    public Tile[,] Tiles { get; set; }
    // {
    //     get { return _tiles; }
    //     set { _tiles = value; }
    // }
    public Tile? SelectedTile { get; set; }

    public Boolean Check { get; private set; }
    public Boolean CheckMate { get; private set; }
    public Boolean Pat { get; private set; }

    public Boolean InsufficientMaterial { get; private set; }
    public Boolean GameON { get; private set; }
    public Board(int size)
    {
        Size = size;
        Tiles = new Tile[Size, Size];
        for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
                Tiles[i, j] = new Tile(i, j);

        // SelectedTile = null;
        Check = false;
        CheckMate = false;
        Pat = false;
        InsufficientMaterial = false;
        GameON = true;
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

    public void GameOver()
    {
        GameON = false;
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
            if (tile.Piece is King king && king.Color == color)
            {
                Check = true;
                return true;
            }
        }

        Check = false;
        return false;
    }

    public Boolean isCheckMate(char color)
    {
        List<Tile> possibleMoves = new List<Tile>();
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Tile tile = GetTile(i, j);
                Piece? piece = tile.Piece;

                if (piece != null && piece.Color == color)
                {
                    possibleMoves.AddRange(piece.RemoveBlockedMoves(this, piece.GetPossibleMoves(this)));
                }
            }
        }

        isKingChecked(color);
        if (possibleMoves.Count <= 0 && Check)
        {
            CheckMate = true;
            GameOver();
            return true;
        }
        if (possibleMoves.Count <= 0 && !Check)
        {
            Pat = true;
            GameOver();
            return true;
        }
        return false;
    }

    public Boolean Insufficient(char color)
    {
        int insufficientPieces = 0; // Gońce i skoczki
        int restPieces = 0; // Wieże, hetmany i piony

        int enemyInsufficientPieces = 0; // Gońce i skoczki wroga
        int enemyRestPieces = 0; // Wieże, hetmany i piony wroga
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                Tile tile = GetTile(i, j);
                Piece? piece = tile.Piece;

                if (tile.Piece != null)
                {
                    if ((piece is Queen || piece is Rook || piece is Pawn) && piece.Color == color) restPieces++;
                    if ((piece is Bishop || piece is Knight) && piece.Color == color) insufficientPieces++;

                    if ((piece is Queen || piece is Rook || piece is Pawn) && piece.Color != color) enemyRestPieces++;
                    if ((piece is Bishop || piece is Knight) && piece.Color != color) enemyInsufficientPieces++;
                }
            }
        }
        // Sprawdź przypadki braku materiału
        if (restPieces == 0 && insufficientPieces == 0 && enemyRestPieces == 0 && enemyInsufficientPieces <= 1)
        {
            InsufficientMaterial = true;
            GameOver();
            return true;
        }
        return false;
    }
    public Piece? GetPiece(int x, int y)
    {
        return Tiles[x, y].Piece;
    }

    public Tile GetTile(int row, int col)
    {
        return Tiles[row, col];
    }
}