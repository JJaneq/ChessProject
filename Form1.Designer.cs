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
        boardPanel = new Panel();
        boardPanel.SuspendLayout();
        SuspendLayout();
        // 
        // boardPanel
        // 
        boardPanel.BackColor = Color.BurlyWood;
        boardPanel.Location = new Point(10, 9);
        boardPanel.Margin = new Padding(3, 2, 3, 2);
        boardPanel.Name = "boardPanel";
        boardPanel.Size = new Size(873, 928);
        boardPanel.TabIndex = 0;
        boardPanel.Paint += boardPanel_Paint;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1098, 964);
        Controls.Add(boardPanel);
        Margin = new Padding(3, 2, 3, 2);
        Name = "Form1";
        Text = "Form1";
        boardPanel.ResumeLayout(false);
        boardPanel.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel boardPanel;

    #endregion
}