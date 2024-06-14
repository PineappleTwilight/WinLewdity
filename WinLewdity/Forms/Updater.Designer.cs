namespace WinLewdity
{
    partial class Updater
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updater));
            materialCard1 = new ReaLTaiizor.Controls.MaterialCard();
            prefixImagepackLabel = new ReaLTaiizor.Controls.MaterialLabel();
            imagepackResultLabel = new ReaLTaiizor.Controls.MaterialLabel();
            imagepackUpdaterButton = new ReaLTaiizor.Controls.MaterialButton();
            updateProgressBar = new ReaLTaiizor.Controls.MaterialProgressBar();
            loggingLabel = new ReaLTaiizor.Controls.MaterialLabel();
            logsFolderButton = new ReaLTaiizor.Controls.MaterialButton();
            musicFolderButton = new ReaLTaiizor.Controls.MaterialButton();
            updateButton = new ReaLTaiizor.Controls.MaterialButton();
            startButton = new ReaLTaiizor.Controls.MaterialButton();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(prefixImagepackLabel);
            materialCard1.Controls.Add(imagepackResultLabel);
            materialCard1.Controls.Add(imagepackUpdaterButton);
            materialCard1.Controls.Add(updateProgressBar);
            materialCard1.Controls.Add(loggingLabel);
            materialCard1.Controls.Add(logsFolderButton);
            materialCard1.Controls.Add(musicFolderButton);
            materialCard1.Controls.Add(updateButton);
            materialCard1.Controls.Add(startButton);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1203, 258);
            materialCard1.TabIndex = 0;
            // 
            // prefixImagepackLabel
            // 
            prefixImagepackLabel.Depth = 0;
            prefixImagepackLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            prefixImagepackLabel.Location = new Point(560, 152);
            prefixImagepackLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            prefixImagepackLabel.Name = "prefixImagepackLabel";
            prefixImagepackLabel.Size = new Size(83, 23);
            prefixImagepackLabel.TabIndex = 9;
            prefixImagepackLabel.Text = "Spritepack:";
            prefixImagepackLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // imagepackResultLabel
            // 
            imagepackResultLabel.Depth = 0;
            imagepackResultLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            imagepackResultLabel.ForeColor = Color.Red;
            imagepackResultLabel.HighEmphasis = true;
            imagepackResultLabel.Location = new Point(437, 175);
            imagepackResultLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            imagepackResultLabel.Name = "imagepackResultLabel";
            imagepackResultLabel.Size = new Size(328, 19);
            imagepackResultLabel.TabIndex = 8;
            imagepackResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // imagepackUpdaterButton
            // 
            imagepackUpdaterButton.AutoSize = false;
            imagepackUpdaterButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            imagepackUpdaterButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            imagepackUpdaterButton.Depth = 0;
            imagepackUpdaterButton.HighEmphasis = true;
            imagepackUpdaterButton.Icon = null;
            imagepackUpdaterButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            imagepackUpdaterButton.Location = new Point(18, 111);
            imagepackUpdaterButton.Margin = new Padding(4, 6, 4, 6);
            imagepackUpdaterButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            imagepackUpdaterButton.Name = "imagepackUpdaterButton";
            imagepackUpdaterButton.NoAccentTextColor = Color.Empty;
            imagepackUpdaterButton.Size = new Size(158, 36);
            imagepackUpdaterButton.TabIndex = 0;
            imagepackUpdaterButton.TabStop = false;
            imagepackUpdaterButton.Text = "Change Image Pack";
            imagepackUpdaterButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            imagepackUpdaterButton.UseAccentColor = false;
            imagepackUpdaterButton.UseVisualStyleBackColor = true;
            imagepackUpdaterButton.Click += imagepackUpdaterButton_Click;
            imagepackUpdaterButton.Enter += PreventButtonFocus;
            // 
            // updateProgressBar
            // 
            updateProgressBar.Depth = 0;
            updateProgressBar.Location = new Point(18, 199);
            updateProgressBar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            updateProgressBar.Name = "updateProgressBar";
            updateProgressBar.Size = new Size(1167, 23);
            updateProgressBar.TabIndex = 5;
            updateProgressBar.UseAccentColor = false;
            // 
            // loggingLabel
            // 
            loggingLabel.Depth = 0;
            loggingLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            loggingLabel.Location = new Point(18, 225);
            loggingLabel.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            loggingLabel.Name = "loggingLabel";
            loggingLabel.Size = new Size(1167, 23);
            loggingLabel.TabIndex = 4;
            loggingLabel.Text = "Idle...";
            loggingLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // logsFolderButton
            // 
            logsFolderButton.AutoSize = false;
            logsFolderButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            logsFolderButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            logsFolderButton.Depth = 0;
            logsFolderButton.HighEmphasis = true;
            logsFolderButton.Icon = null;
            logsFolderButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            logsFolderButton.Location = new Point(1027, 63);
            logsFolderButton.Margin = new Padding(4, 6, 4, 6);
            logsFolderButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            logsFolderButton.Name = "logsFolderButton";
            logsFolderButton.NoAccentTextColor = Color.Empty;
            logsFolderButton.Size = new Size(158, 36);
            logsFolderButton.TabIndex = 3;
            logsFolderButton.TabStop = false;
            logsFolderButton.Text = "Open Logs Folder";
            logsFolderButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            logsFolderButton.UseAccentColor = false;
            logsFolderButton.UseVisualStyleBackColor = true;
            logsFolderButton.Click += openLogsButton_Click;
            logsFolderButton.Enter += PreventButtonFocus;
            // 
            // musicFolderButton
            // 
            musicFolderButton.AutoSize = false;
            musicFolderButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            musicFolderButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            musicFolderButton.Depth = 0;
            musicFolderButton.HighEmphasis = true;
            musicFolderButton.Icon = null;
            musicFolderButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            musicFolderButton.Location = new Point(1027, 15);
            musicFolderButton.Margin = new Padding(4, 6, 4, 6);
            musicFolderButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            musicFolderButton.Name = "musicFolderButton";
            musicFolderButton.NoAccentTextColor = Color.Empty;
            musicFolderButton.Size = new Size(158, 36);
            musicFolderButton.TabIndex = 2;
            musicFolderButton.TabStop = false;
            musicFolderButton.Text = "Open Music Folder";
            musicFolderButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            musicFolderButton.UseAccentColor = false;
            musicFolderButton.UseVisualStyleBackColor = true;
            musicFolderButton.Click += musicFolderButton_Click;
            musicFolderButton.Enter += PreventButtonFocus;
            // 
            // updateButton
            // 
            updateButton.AutoSize = false;
            updateButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            updateButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            updateButton.Depth = 0;
            updateButton.HighEmphasis = true;
            updateButton.Icon = null;
            updateButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            updateButton.Location = new Point(18, 63);
            updateButton.Margin = new Padding(4, 6, 4, 6);
            updateButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            updateButton.Name = "updateButton";
            updateButton.NoAccentTextColor = Color.Empty;
            updateButton.Size = new Size(158, 36);
            updateButton.TabIndex = 1;
            updateButton.TabStop = false;
            updateButton.Text = "Update Files";
            updateButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            updateButton.UseAccentColor = false;
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            updateButton.Enter += PreventButtonFocus;
            // 
            // startButton
            // 
            startButton.AutoSize = false;
            startButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startButton.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            startButton.Depth = 0;
            startButton.HighEmphasis = true;
            startButton.Icon = null;
            startButton.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            startButton.Location = new Point(18, 15);
            startButton.Margin = new Padding(4, 6, 4, 6);
            startButton.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            startButton.Name = "startButton";
            startButton.NoAccentTextColor = Color.Empty;
            startButton.Size = new Size(158, 36);
            startButton.TabIndex = 0;
            startButton.TabStop = false;
            startButton.Text = "Start Game";
            startButton.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            startButton.UseAccentColor = false;
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            startButton.Enter += PreventButtonFocus;
            // 
            // Updater
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1203, 258);
            Controls.Add(materialCard1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Updater";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Updater";
            FormClosing += Updater_FormClosing;
            Load += Updater_Load;
            materialCard1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard materialCard1;
        private ReaLTaiizor.Controls.MaterialButton logsFolderButton;
        private ReaLTaiizor.Controls.MaterialButton musicFolderButton;
        private ReaLTaiizor.Controls.MaterialButton updateButton;
        private ReaLTaiizor.Controls.MaterialButton startButton;
        private ReaLTaiizor.Controls.MaterialLabel loggingLabel;
        private ReaLTaiizor.Controls.MaterialProgressBar updateProgressBar;
        private ReaLTaiizor.Controls.MaterialButton imagepackUpdaterButton;
        private ReaLTaiizor.Controls.MaterialLabel imagepackResultLabel;
        private ReaLTaiizor.Controls.MaterialLabel prefixImagepackLabel;
    }
}