namespace SimpleHtmlViewer
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
            updateButton = new Button();
            startButton = new Button();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            musicFolderButton = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            openLogsButton = new Button();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // updateButton
            // 
            updateButton.Anchor = AnchorStyles.None;
            updateButton.Location = new Point(3, 32);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(126, 23);
            updateButton.TabIndex = 0;
            updateButton.Text = "Update Files";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.None;
            startButton.Location = new Point(3, 3);
            startButton.Name = "startButton";
            startButton.Size = new Size(126, 23);
            startButton.TabIndex = 1;
            startButton.Text = "Start Game";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(4, 28);
            label1.Name = "label1";
            label1.Size = new Size(167, 15);
            label1.TabIndex = 4;
            label1.Text = "How do I swap image packs?";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(469, 28);
            label2.Name = "label2";
            label2.Size = new Size(270, 15);
            label2.TabIndex = 5;
            label2.Text = "File -> Toggle Settings Bar -> Change Image Pack";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(150, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1041, 235);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "FAQ";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(linkLabel1, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1035, 213);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 169);
            label5.Name = "label5";
            label5.Size = new Size(135, 15);
            label5.TabIndex = 8;
            label5.Text = "I want sex toy support!";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.Location = new Point(369, 98);
            label4.Name = "label4";
            label4.Size = new Size(471, 15);
            label4.TabIndex = 7;
            label4.Text = "Click \"Open Music Folder\" and place whichever songs you want into each category folder.";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(4, 98);
            label3.Name = "label3";
            label3.Size = new Size(166, 15);
            label3.TabIndex = 6;
            label3.Text = "How do I add custom music?";
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.None;
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(321, 169);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(567, 15);
            linkLabel1.TabIndex = 10;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Download Intiface Central and set it up properly. This app will automatically enable support once detected.";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // musicFolderButton
            // 
            musicFolderButton.Anchor = AnchorStyles.None;
            musicFolderButton.Location = new Point(3, 61);
            musicFolderButton.Name = "musicFolderButton";
            musicFolderButton.Size = new Size(126, 23);
            musicFolderButton.TabIndex = 7;
            musicFolderButton.Text = "Open Music Folder";
            musicFolderButton.UseVisualStyleBackColor = true;
            musicFolderButton.Click += musicFolderButton_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            flowLayoutPanel1.Controls.Add(startButton);
            flowLayoutPanel1.Controls.Add(updateButton);
            flowLayoutPanel1.Controls.Add(musicFolderButton);
            flowLayoutPanel1.Controls.Add(openLogsButton);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(132, 232);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // openLogsButton
            // 
            openLogsButton.Location = new Point(3, 90);
            openLogsButton.Name = "openLogsButton";
            openLogsButton.Size = new Size(126, 23);
            openLogsButton.TabIndex = 8;
            openLogsButton.Text = "Open Logs Folder";
            openLogsButton.UseVisualStyleBackColor = true;
            openLogsButton.Click += openLogsButton_Click;
            // 
            // Updater
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1203, 258);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Updater";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Updater";
            FormClosing += Updater_FormClosing;
            Load += Updater_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button updateButton;
        private Button startButton;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TableLayoutPanel tableLayoutPanel1;
        private Button musicFolderButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label5;
        private LinkLabel linkLabel1;
        private Button openLogsButton;
    }
}