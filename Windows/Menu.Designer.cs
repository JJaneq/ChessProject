using System.ComponentModel;

namespace Chess;

partial class Menu
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
        StartButton = new System.Windows.Forms.Button();
        Exit = new System.Windows.Forms.Button();
        HistoryButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // StartButton
        // 
        StartButton.Location = new System.Drawing.Point(68, 65);
        StartButton.Name = "StartButton";
        StartButton.Size = new System.Drawing.Size(100, 38);
        StartButton.TabIndex = 0;
        StartButton.Text = "Start";
        StartButton.UseVisualStyleBackColor = true;
        StartButton.Click += StartButton_Click;
        // 
        // Exit
        // 
        Exit.Location = new System.Drawing.Point(68, 153);
        Exit.Name = "Exit";
        Exit.Size = new System.Drawing.Size(100, 38);
        Exit.TabIndex = 1;
        Exit.Text = "Exit";
        Exit.UseVisualStyleBackColor = true;
        Exit.Click += Exit_Click;
        // 
        // HistoryButton
        // 
        HistoryButton.Location = new System.Drawing.Point(68, 109);
        HistoryButton.Name = "HistoryButton";
        HistoryButton.Size = new System.Drawing.Size(100, 38);
        HistoryButton.TabIndex = 2;
        HistoryButton.Text = "History";
        HistoryButton.UseVisualStyleBackColor = true;
        HistoryButton.Click += HistoryButton_Click;
        // 
        // Menu
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(246, 213);
        Controls.Add(HistoryButton);
        Controls.Add(Exit);
        Controls.Add(StartButton);
        Text = "Menu";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button HistoryButton;

    private System.Windows.Forms.Button Exit;

    private System.Windows.Forms.Button StartButton;

    #endregion
}