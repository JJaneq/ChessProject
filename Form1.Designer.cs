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
        boardPanel = new System.Windows.Forms.Panel();
        SuspendLayout();
        // 
        // boardPanel
        // 
        boardPanel.BackColor = System.Drawing.Color.BurlyWood;
        boardPanel.Location = new System.Drawing.Point(12, 12);
        boardPanel.Name = "boardPanel";
        boardPanel.Size = new System.Drawing.Size(800, 800);
        boardPanel.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(882, 853);
        Controls.Add(boardPanel);
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel boardPanel;

    #endregion
}