using System.ComponentModel;

namespace Chess;

partial class HistoryWindow
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
        GameList = new System.Windows.Forms.ComboBox();
        SuspendLayout();
        // 
        // GameList
        // 
        GameList.FormattingEnabled = true;
        GameList.Location = new System.Drawing.Point(23, 21);
        GameList.Name = "GameList";
        GameList.Size = new System.Drawing.Size(749, 28);
        GameList.TabIndex = 0;
        GameList.Text = "Wybierz grę...";
        // 
        // HistoryWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(GameList);
        Text = "HistoryWindow";
        Load += HistoryWindow_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.ComboBox GameList;

    #endregion
}