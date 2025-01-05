namespace Chess;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        labelMove = new Label();
        labelCheck = new Label();
        textPanel = new Panel();
        boardPanel = new Panel();
        textPanel.SuspendLayout();
        SuspendLayout();
        // 
        // labelMove
        // 
        labelMove.Location = new Point(3, 7);
        labelMove.Name = "labelMove";
        labelMove.Size = new Size(132, 22);
        labelMove.TabIndex = 1;
        labelMove.Text = "Ruch: białe";
        // 
        // labelCheck
        // 
        labelCheck.Location = new Point(3, 28);
        labelCheck.Name = "labelCheck";
        labelCheck.Size = new Size(132, 39);
        labelCheck.TabIndex = 2;
        labelCheck.Text = "Check Info";
        // 
        // textPanel
        // 
        textPanel.Controls.Add(labelCheck);
        textPanel.Controls.Add(labelMove);
        textPanel.Dock = DockStyle.Right;
        textPanel.Location = new Point(939, 0);
        textPanel.Margin = new Padding(3, 2, 3, 2);
        textPanel.Name = "textPanel";
        textPanel.Size = new Size(145, 926);
        textPanel.TabIndex = 1;
        // 
        // boardPanel
        // 
        boardPanel.BackColor = Color.BurlyWood;
        boardPanel.Location = new Point(12, 11);
        boardPanel.Margin = new Padding(3, 2, 3, 2);
        boardPanel.Name = "boardPanel";
        boardPanel.Size = new Size(850, 850);
        boardPanel.TabIndex = 0;
        boardPanel.Paint += boardPanel_Paint;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1084, 926);
        Controls.Add(textPanel);
        Controls.Add(boardPanel);
        Margin = new Padding(3, 2, 3, 2);
        Name = "Form1";
        Text = "w";
        textPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel textPanel;

    private System.Windows.Forms.Label labelCheck;

    private System.Windows.Forms.Label labelMove;

    #endregion

    private Panel boardPanel;
}