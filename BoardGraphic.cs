using System.CodeDom;
using Chess.ChessLogic;

namespace Chess;

public class BoardGraphic
{
    public List<List<Button>> DrawBoard(Control controler, Board board, EventHandler? clickHandler)
    {
        int tileSize = 100;
        List<List<Button>> btnTileList = new List<List<Button>>();
        for (int i = 0, x = 0; i < board.Size; i++, x++)
        {
            List<Button> btnRowList = new List<Button>();
            for (int j = 0; j < board.Size; j++, x++)
            {
                Button btnTile = new Button();
                btnTile.Location = new Point(j * tileSize, i * tileSize);
                btnTile.Size = new Size(tileSize, tileSize);
                btnTile.BackColor = x % 2 == 0 ? Color.SaddleBrown : Color.Bisque;
                btnTile.FlatStyle = FlatStyle.Flat;
                btnTile.FlatAppearance.BorderSize = 0;
                
                btnTile.BackgroundImageLayout = ImageLayout.Stretch;
                btnTile.Tag = new Point(i, j);
                btnTile.Click += clickHandler;
                
                btnRowList.Add(btnTile);
                controler.Controls.Add(btnTile);
            }
            btnTileList.Add(btnRowList);
        }
        return btnTileList;
    }

    public void DrawPieces(Control controler, Board board, List<List<Button>> buttonList)
    {
        for (int row = 0; row < board.Size; row++)
        {
            for (int column = 0; column < board.Size; column++)
            {
                if (board.Tiles[row, column].Piece == null)
                {
                    buttonList[row][column].BackgroundImage = null;
                    continue;
                }
                
                switch (board.Tiles[row, column].Piece.PieceType)
                {
                    case 'p':
                        buttonList[row][column].BackgroundImage = board.Tiles[row, column].Piece.Color == 'b'
                            ? Image.FromFile("Assets/black_pawn.png")
                            : Image.FromFile("Assets/white_pawn.png");
                        break;
                    case 'k':
                        buttonList[row][column].BackgroundImage = board.Tiles[row, column].Piece.Color == 'b'
                            ? Image.FromFile("Assets/black_king.png")
                            : Image.FromFile("Assets/white_king.png");
                        break;
                    case 'q':
                        buttonList[row][column].BackgroundImage = board.Tiles[row, column].Piece.Color == 'b'
                            ? Image.FromFile("Assets/black_queen.png")
                            : Image.FromFile("Assets/white_queen.png");
                        break;
                    case 'r':
                        buttonList[row][column].BackgroundImage = board.Tiles[row, column].Piece.Color == 'b'
                            ? Image.FromFile("Assets/black_rook.png")
                            : Image.FromFile("Assets/white_rook.png");
                        break;
                    case 'n':
                        buttonList[row][column].BackgroundImage = board.Tiles[row, column].Piece.Color == 'b'
                            ? Image.FromFile("Assets/black_knight.png")
                            : Image.FromFile("Assets/white_knight.png");
                        break;
                    case 'b':
                        buttonList[row][column].BackgroundImage = board.Tiles[row, column].Piece.Color == 'b'
                            ? Image.FromFile("Assets/black_bishop.png")
                            : Image.FromFile("Assets/white_bishop.png");
                        break;
                }
            }
        }
    }

    public void ShowMoves(Board board, List<List<Button>> buttonList, Tile tile)
    {
        if (tile.Piece == null)
            return;

        var moves = tile.Piece.RemoveBlockedMoves(board, tile.Piece.GetPossibleMoves(board));

        Console.WriteLine("Dozwolone ruchy:");
        foreach (var move in moves)
        {
            if (move != null)
            {
                Console.WriteLine(move.Row + "," + move.Column);
                try
                {
                    buttonList[move.Row][move.Column].FlatAppearance.BorderSize = 5;
                    buttonList[move.Row][move.Column].FlatAppearance.BorderColor = Color.Green;
                }
                catch
                {
                    continue;
                }
            }
        }
    }

    public void HideMoves(List<List<Button>> buttonList)
    {
        foreach (var buttonRow in buttonList)
        {
            foreach (var button in buttonRow)
            {
                button.FlatAppearance.BorderSize = 0;
            }
        }
    }
}