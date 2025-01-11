using System.Windows.Forms.VisualStyles;

namespace Chess;

public partial class Menu : Form
{
    public Menu()
    {
        InitializeComponent();
    }

    private void StartButton_Click(object sender, EventArgs e)
    {
        Hide();
        GameWindow game = new GameWindow(this);
        game.Show();
    }

    private void Exit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void HistoryButton_Click(object sender, EventArgs e)
    {
        Hide();
        HistoryWindow history = new HistoryWindow(this);
        history.Show();
    }
}