using System.ComponentModel;

namespace Chess;

partial class EndWindow
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        exitButton = new System.Windows.Forms.Button();
        menuButton = new System.Windows.Forms.Button();
        newGameButton = new System.Windows.Forms.Button();
        endGameLabel = new System.Windows.Forms.Label();
        reasonLabel = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // exitButton
        // 
        exitButton.Location = new System.Drawing.Point(7, 285);
        exitButton.Name = "exitButton";
        exitButton.Size = new System.Drawing.Size(125, 54);
        exitButton.TabIndex = 0;
        exitButton.Text = "Exit";
        exitButton.UseVisualStyleBackColor = true;
        exitButton.Click += exitButton_Click;
        // 
        // menuButton
        // 
        menuButton.Location = new System.Drawing.Point(138, 285);
        menuButton.Name = "menuButton";
        menuButton.Size = new System.Drawing.Size(125, 54);
        menuButton.TabIndex = 1;
        menuButton.Text = "Menu";
        menuButton.UseVisualStyleBackColor = true;
        menuButton.Click += menuButton_Click;
        // 
        // newGameButton
        // 
        newGameButton.Location = new System.Drawing.Point(269, 285);
        newGameButton.Name = "newGameButton";
        newGameButton.Size = new System.Drawing.Size(125, 54);
        newGameButton.TabIndex = 2;
        newGameButton.Text = "New Game";
        newGameButton.UseVisualStyleBackColor = true;
        newGameButton.Click += newGameButton_Click;
        // 
        // endGameLabel
        // 
        endGameLabel.AutoSize = true;
        endGameLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        endGameLabel.Location = new System.Drawing.Point(107, 10);
        endGameLabel.Name = "endGameLabel";
        endGameLabel.Size = new System.Drawing.Size(205, 46);
        endGameLabel.TabIndex = 3;
        endGameLabel.Text = "Koniec Gry!";
        // 
        // reasonLabel
        // 
        reasonLabel.Location = new System.Drawing.Point(7, 62);
        reasonLabel.Name = "reasonLabel";
        reasonLabel.Size = new System.Drawing.Size(386, 34);
        reasonLabel.TabIndex = 4;
        reasonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // EndWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(402, 353);
        Controls.Add(reasonLabel);
        Controls.Add(endGameLabel);
        Controls.Add(newGameButton);
        Controls.Add(menuButton);
        Controls.Add(exitButton);
        FormClosing += OnClosing;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label reasonLabel;

    private System.Windows.Forms.Button newGameButton;
    private System.Windows.Forms.Label endGameLabel;

    private System.Windows.Forms.Button exitButton;
    private System.Windows.Forms.Button menuButton;

    #endregion
}