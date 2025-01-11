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
        historyPanel = new System.Windows.Forms.Panel();
        historyLabel = new System.Windows.Forms.Label();
        historyPanel.SuspendLayout();
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
        GameList.SelectedIndexChanged += GameList_SelectedIndexChanged;
        // 
        // historyPanel
        // 
        historyPanel.AutoScroll = true;
        historyPanel.Controls.Add(historyLabel);
        historyPanel.Location = new System.Drawing.Point(23, 55);
        historyPanel.Name = "historyPanel";
        historyPanel.Size = new System.Drawing.Size(748, 386);
        historyPanel.TabIndex = 1;
        // 
        // historyLabel
        // 
        historyLabel.AutoSize = true;
        historyLabel.Location = new System.Drawing.Point(3, 0);
        historyLabel.Name = "historyLabel";
        historyLabel.Size = new System.Drawing.Size(0, 20);
        historyLabel.TabIndex = 0;
        // 
        // HistoryWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(historyPanel);
        Controls.Add(GameList);
        Text = "HistoryWindow";
        FormClosing += OnClosing;
        Load += HistoryWindow_Load;
        historyPanel.ResumeLayout(false);
        historyPanel.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label historyLabel;

    private System.Windows.Forms.Panel historyPanel;

    private System.Windows.Forms.ComboBox GameList;

    #endregion
}