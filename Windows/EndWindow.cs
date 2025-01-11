namespace Chess;

public partial class EndWindow : Form
{
    private GameWindow _gameWindow;
    public EndWindow(string endReason, GameWindow gameWindow)
    {
        InitializeComponent();
        reasonLabel.Text = endReason;
        _gameWindow = gameWindow;
    }

    private void exitButton_Click(object sender, EventArgs e)
    {
        Close();
        _gameWindow.Menu.Close();
    }

    private void menuButton_Click(object sender, EventArgs e)
    {
        _gameWindow.Menu.Show();
        Close();
    }
    
    
    private void OnClosing(object sender, FormClosingEventArgs e)
    {
        _gameWindow.Close();
    }

    private void newGameButton_Click(object sender, EventArgs e)
    {
        var game = new GameWindow(_gameWindow.Menu);
        game.Show();
        Close();
    }
}