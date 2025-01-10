using System.ComponentModel;

namespace Chess;

partial class PromotionWindow
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
        QueenButton = new System.Windows.Forms.Button();
        RookButton = new System.Windows.Forms.Button();
        BishopButton = new System.Windows.Forms.Button();
        KnightButton = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // QueenButton
        // 
        QueenButton.BackColor = System.Drawing.Color.SaddleBrown;
        QueenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        QueenButton.FlatAppearance.BorderSize = 0;
        QueenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        QueenButton.Location = new System.Drawing.Point(12, 12);
        QueenButton.Name = "QueenButton";
        QueenButton.Size = new System.Drawing.Size(146, 138);
        QueenButton.TabIndex = 0;
        QueenButton.UseVisualStyleBackColor = false;
        QueenButton.Click += QueenButton_Click;
        // 
        // RookButton
        // 
        RookButton.BackColor = System.Drawing.Color.SaddleBrown;
        RookButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        RookButton.FlatAppearance.BorderSize = 0;
        RookButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        RookButton.Location = new System.Drawing.Point(164, 12);
        RookButton.Name = "RookButton";
        RookButton.Size = new System.Drawing.Size(146, 138);
        RookButton.TabIndex = 1;
        RookButton.UseVisualStyleBackColor = false;
        RookButton.Click += RookButton_Click;
        // 
        // BishopButton
        // 
        BishopButton.BackColor = System.Drawing.Color.SaddleBrown;
        BishopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        BishopButton.FlatAppearance.BorderSize = 0;
        BishopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        BishopButton.Location = new System.Drawing.Point(316, 12);
        BishopButton.Name = "BishopButton";
        BishopButton.Size = new System.Drawing.Size(146, 138);
        BishopButton.TabIndex = 2;
        BishopButton.UseVisualStyleBackColor = false;
        BishopButton.Click += BishopButton_Click;
        // 
        // KnightButton
        // 
        KnightButton.BackColor = System.Drawing.Color.SaddleBrown;
        KnightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        KnightButton.FlatAppearance.BorderSize = 0;
        KnightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        KnightButton.Location = new System.Drawing.Point(468, 12);
        KnightButton.Name = "KnightButton";
        KnightButton.Size = new System.Drawing.Size(146, 138);
        KnightButton.TabIndex = 3;
        KnightButton.UseVisualStyleBackColor = false;
        KnightButton.Click += KnightButton_Click;
        // 
        // PromotionWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.Peru;
        ClientSize = new System.Drawing.Size(626, 162);
        ControlBox = false;
        Controls.Add(KnightButton);
        Controls.Add(BishopButton);
        Controls.Add(RookButton);
        Controls.Add(QueenButton);
        Text = "Wybierz figurę";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button KnightButton;

    private System.Windows.Forms.Button QueenButton;
    private System.Windows.Forms.Button RookButton;
    private System.Windows.Forms.Button BishopButton;

    #endregion
}