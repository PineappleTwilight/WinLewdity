namespace WinLewdity
{
    partial class GameView
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameView));
            fileToolStripMenuItem = new ToolStripMenuItem();
            showHideSettingsBarToolStripMenuItem = new ToolStripMenuItem();
            sFXToolStripMenuItem = new ToolStripMenuItem();
            toggleSfxButton = new ToolStripMenuItem();
            musicToolStripMenuItem = new ToolStripMenuItem();
            toggleMusicButton = new ToolStripMenuItem();
            skipSongToolStripMenuItem = new ToolStripMenuItem();
            mainMenuStrip = new MenuStrip();
            topPanel = new Panel();
            changeImgButton = new Button();
            volumeLabel = new Label();
            globalVolumeSlider = new NAudio.Gui.VolumeSlider();
            gameBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            mainMenuStrip.SuspendLayout();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.BackColor = Color.White;
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { showHideSettingsBarToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = Color.Black;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // showHideSettingsBarToolStripMenuItem
            // 
            showHideSettingsBarToolStripMenuItem.Name = "showHideSettingsBarToolStripMenuItem";
            showHideSettingsBarToolStripMenuItem.Size = new Size(198, 22);
            showHideSettingsBarToolStripMenuItem.Text = "Show/Hide Settings Bar";
            showHideSettingsBarToolStripMenuItem.Click += showHideSettingsBarToolStripMenuItem_Click;
            // 
            // sFXToolStripMenuItem
            // 
            sFXToolStripMenuItem.BackColor = Color.White;
            sFXToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toggleSfxButton });
            sFXToolStripMenuItem.ForeColor = Color.Black;
            sFXToolStripMenuItem.Name = "sFXToolStripMenuItem";
            sFXToolStripMenuItem.Size = new Size(38, 20);
            sFXToolStripMenuItem.Text = "SFX";
            // 
            // toggleSfxButton
            // 
            toggleSfxButton.BackColor = Color.White;
            toggleSfxButton.Checked = true;
            toggleSfxButton.CheckOnClick = true;
            toggleSfxButton.CheckState = CheckState.Checked;
            toggleSfxButton.ForeColor = Color.Black;
            toggleSfxButton.Name = "toggleSfxButton";
            toggleSfxButton.Size = new Size(131, 22);
            toggleSfxButton.Text = "Enable SFX";
            toggleSfxButton.CheckedChanged += toggleSfxButton_CheckedChanged;
            // 
            // musicToolStripMenuItem
            // 
            musicToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toggleMusicButton, skipSongToolStripMenuItem });
            musicToolStripMenuItem.ForeColor = Color.Black;
            musicToolStripMenuItem.Name = "musicToolStripMenuItem";
            musicToolStripMenuItem.Size = new Size(51, 20);
            musicToolStripMenuItem.Text = "Music";
            // 
            // toggleMusicButton
            // 
            toggleMusicButton.BackColor = Color.White;
            toggleMusicButton.Checked = true;
            toggleMusicButton.CheckOnClick = true;
            toggleMusicButton.CheckState = CheckState.Checked;
            toggleMusicButton.ForeColor = Color.Black;
            toggleMusicButton.Name = "toggleMusicButton";
            toggleMusicButton.Size = new Size(144, 22);
            toggleMusicButton.Text = "Enable Music";
            toggleMusicButton.CheckedChanged += toggleMusicButton_CheckedChanged;
            // 
            // skipSongToolStripMenuItem
            // 
            skipSongToolStripMenuItem.Name = "skipSongToolStripMenuItem";
            skipSongToolStripMenuItem.Size = new Size(144, 22);
            skipSongToolStripMenuItem.Text = "Skip Song";
            skipSongToolStripMenuItem.Click += skipSongToolStripMenuItem_Click;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.BackColor = Color.White;
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, sFXToolStripMenuItem, musicToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(800, 24);
            mainMenuStrip.TabIndex = 1;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.White;
            topPanel.Controls.Add(changeImgButton);
            topPanel.Controls.Add(volumeLabel);
            topPanel.Controls.Add(globalVolumeSlider);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 24);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(800, 30);
            topPanel.TabIndex = 2;
            topPanel.Visible = false;
            // 
            // changeImgButton
            // 
            changeImgButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            changeImgButton.Location = new Point(12, 4);
            changeImgButton.Name = "changeImgButton";
            changeImgButton.Size = new Size(132, 23);
            changeImgButton.TabIndex = 2;
            changeImgButton.Text = "Change Image Pack...";
            changeImgButton.UseVisualStyleBackColor = true;
            changeImgButton.Click += changeImgButton_Click;
            // 
            // volumeLabel
            // 
            volumeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            volumeLabel.AutoSize = true;
            volumeLabel.Location = new Point(601, 7);
            volumeLabel.Name = "volumeLabel";
            volumeLabel.Size = new Size(87, 15);
            volumeLabel.TabIndex = 1;
            volumeLabel.Text = "Global Volume:";
            // 
            // globalVolumeSlider
            // 
            globalVolumeSlider.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            globalVolumeSlider.Location = new Point(692, 7);
            globalVolumeSlider.Name = "globalVolumeSlider";
            globalVolumeSlider.Size = new Size(96, 16);
            globalVolumeSlider.TabIndex = 0;
            globalVolumeSlider.Volume = 0.5F;
            globalVolumeSlider.VolumeChanged += globalVolumeSlider_VolumeChanged;
            // 
            // gameBrowser
            // 
            gameBrowser.ActivateBrowserOnCreation = false;
            gameBrowser.Dock = DockStyle.Fill;
            gameBrowser.Location = new Point(0, 54);
            gameBrowser.Name = "gameBrowser";
            gameBrowser.Size = new Size(800, 396);
            gameBrowser.TabIndex = 3;
            // 
            // GameView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gameBrowser);
            Controls.Add(topPanel);
            Controls.Add(mainMenuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mainMenuStrip;
            Name = "GameView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Degrees of Lewdity Plus";
            WindowState = FormWindowState.Maximized;
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem sFXToolStripMenuItem;
        private ToolStripMenuItem toggleSfxButton;
        private ToolStripMenuItem musicToolStripMenuItem;
        private ToolStripMenuItem toggleMusicButton;
        private MenuStrip mainMenuStrip;
        private Panel topPanel;
        private ToolStripMenuItem showHideSettingsBarToolStripMenuItem;
        private NAudio.Gui.VolumeSlider globalVolumeSlider;
        private Label volumeLabel;
        private ToolStripMenuItem skipSongToolStripMenuItem;
        private Button changeImgButton;
        public CefSharp.WinForms.ChromiumWebBrowser gameBrowser;
    }
}
