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
        labelMove = new System.Windows.Forms.Label();
        labelCheck = new System.Windows.Forms.Label();
        textPanel = new System.Windows.Forms.Panel();
        textPanel.SuspendLayout();
        SuspendLayout();
        // 
        // boardPanel
        // 
        boardPanel.BackColor = System.Drawing.Color.BurlyWood;
        boardPanel.Location = new System.Drawing.Point(10, 9);
        boardPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        boardPanel.Name = "boardPanel";
        boardPanel.Size = new System.Drawing.Size(800, 800);
        boardPanel.TabIndex = 0;
        // 
        // labelMove
        // 
        labelMove.Location = new System.Drawing.Point(3, 9);
        labelMove.Name = "labelMove";
        labelMove.Size = new System.Drawing.Size(151, 29);
        labelMove.TabIndex = 1;
        labelMove.Text = "Ruch: białe";
        // 
        // labelCheck
        // 
        labelCheck.Location = new System.Drawing.Point(3, 38);
        labelCheck.Name = "labelCheck";
        labelCheck.Size = new System.Drawing.Size(151, 52);
        labelCheck.TabIndex = 2;
        labelCheck.Text = "Check Info";
        // 
        // textPanel
        // 
        textPanel.Controls.Add(labelCheck);
        textPanel.Controls.Add(labelMove);
        textPanel.Dock = System.Windows.Forms.DockStyle.Right;
        textPanel.Location = new System.Drawing.Point(816, 0);
        textPanel.Name = "textPanel";
        textPanel.Size = new System.Drawing.Size(166, 818);
        textPanel.TabIndex = 1;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(982, 818);
        Controls.Add(textPanel);
        Controls.Add(boardPanel);
        Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
        Text = "Szachy";
        textPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel textPanel;

    private System.Windows.Forms.Label labelCheck;

    private System.Windows.Forms.Label labelMove;

    private System.Windows.Forms.Panel boardPanel;

    #endregion
}