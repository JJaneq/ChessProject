using System.CodeDom;
using Chess.ChessLogic;

namespace Chess;

public class BoardGraphic
{
    public List<List<Button>> DrawBoard(Control controler, Board board, EventHandler? clickHandler)
    {        
        int tileSize = 100;
        int offset = 25;
        DrawLabels(controler, board.Size, tileSize, offset);
        List<List<Button>> btnTileList = new List<List<Button>>();
        
        for (int i = 0, x = 0; i < board.Size; i++, x++)
        {
            List<Button> btnRowList = new List<Button>();
            for (int j = 0; j < board.Size; j++, x++)
            {
                Button btnTile = new Button();
                btnTile.Location = new Point(j * tileSize + offset, i * tileSize + offset);
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

    public void DrawLabels(Control controler, int boardSize, int tileSize, int offset)
    {
        Font labelFont = new Font("Arial", 14, FontStyle.Bold);
        // Dodaj litery (A-H) na górze i na dole planszy
        for (int i = 0; i < boardSize; i++)
        {
            Label topLabel = new Label();
            topLabel.Text = ((char)('A' + i)).ToString();
            topLabel.Size = new Size(tileSize, offset);
            topLabel.Font = labelFont;
            topLabel.TextAlign = ContentAlignment.MiddleCenter;
            topLabel.Location = new Point(i * tileSize + offset, 0); // Góra planszy
            controler.Controls.Add(topLabel);

            Label bottomLabel = new Label();
            bottomLabel.Text = ((char)('A' + i)).ToString();
            bottomLabel.Size = new Size(tileSize, offset);
            bottomLabel.Font = labelFont;
            bottomLabel.TextAlign = ContentAlignment.MiddleCenter;
            bottomLabel.Location = new Point(i * tileSize + offset, boardSize * tileSize + offset); // Dół planszy
            controler.Controls.Add(bottomLabel);
        }

        // Dodaj liczby (1-8) po lewej i prawej stronie planszy
        for (int i = 0; i < boardSize; i++)
        {
            Label leftLabel = new Label();
            leftLabel.Text = (boardSize - i).ToString(); // Liczby malejąco od 8 do 1
            leftLabel.Size = new Size(25, tileSize);
            leftLabel.Font = labelFont;
            leftLabel.TextAlign = ContentAlignment.MiddleCenter;
            leftLabel.Location = new Point(0, i * tileSize + (tileSize / 2) - (leftLabel.Height / 2) + 25); // Lewa strona
            controler.Controls.Add(leftLabel);

            Label rightLabel = new Label();
            rightLabel.Text = (boardSize - i).ToString(); // Liczby malejąco od 8 do 1
            rightLabel.Size = new Size(25, tileSize);
            rightLabel.Font = labelFont;
            rightLabel.TextAlign = ContentAlignment.MiddleCenter;
            rightLabel.Location = new Point(boardSize * tileSize + 25, i * tileSize + (tileSize / 2) - (rightLabel.Height / 2) + 25); // Prawa strona
            controler.Controls.Add(rightLabel);
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

    public void ShowEndWindow(string text, GameWindow gameWindow)
    {
        var endWindow = new EndWindow(text ,gameWindow);
        endWindow.Show();
    }
}