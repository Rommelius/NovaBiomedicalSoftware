namespace NovaBiomedicalSoftware
{
    partial class LogInPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInPage));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.createSpreadsheet = new MetroFramework.Controls.MetroButton();
            this.clientBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.submit_btn = new MetroFramework.Controls.MetroButton();
            this.userName = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.createSpreadsheet);
            this.metroPanel1.Controls.Add(this.clientBox);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.submit_btn);
            this.metroPanel1.Controls.Add(this.userName);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.pictureBox1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 12;
            this.metroPanel1.Location = new System.Drawing.Point(0, 37);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(676, 444);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // createSpreadsheet
            // 
            this.createSpreadsheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createSpreadsheet.Location = new System.Drawing.Point(469, 401);
            this.createSpreadsheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createSpreadsheet.Name = "createSpreadsheet";
            this.createSpreadsheet.Size = new System.Drawing.Size(204, 39);
            this.createSpreadsheet.TabIndex = 107;
            this.createSpreadsheet.Text = "Create Spreadsheet";
            this.createSpreadsheet.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.createSpreadsheet.UseSelectable = true;
            this.createSpreadsheet.Click += new System.EventHandler(this.createSpreadsheet_Click);
            // 
            // clientBox
            // 
            this.clientBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            // 
            // 
            // 
            this.clientBox.CustomButton.Image = null;
            this.clientBox.CustomButton.Location = new System.Drawing.Point(232, 2);
            this.clientBox.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.clientBox.CustomButton.Name = "";
            this.clientBox.CustomButton.Size = new System.Drawing.Size(29, 29);
            this.clientBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.clientBox.CustomButton.TabIndex = 1;
            this.clientBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.clientBox.CustomButton.UseSelectable = true;
            this.clientBox.CustomButton.Visible = false;
            this.clientBox.Lines = new string[0];
            this.clientBox.Location = new System.Drawing.Point(233, 234);
            this.clientBox.Margin = new System.Windows.Forms.Padding(4);
            this.clientBox.MaxLength = 32767;
            this.clientBox.Name = "clientBox";
            this.clientBox.PasswordChar = '\0';
            this.clientBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.clientBox.SelectedText = "";
            this.clientBox.SelectionLength = 0;
            this.clientBox.SelectionStart = 0;
            this.clientBox.ShortcutsEnabled = true;
            this.clientBox.Size = new System.Drawing.Size(264, 34);
            this.clientBox.TabIndex = 106;
            this.clientBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.clientBox.UseSelectable = true;
            this.clientBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.clientBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.ForeColor = System.Drawing.Color.White;
            this.metroLabel3.Location = new System.Drawing.Point(145, 238);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(65, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 105;
            this.metroLabel3.Text = "Client:";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(0, 419);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(127, 25);
            this.metroLabel1.TabIndex = 104;
            this.metroLabel1.Text = "Version 9.1.4";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // submit_btn
            // 
            this.submit_btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.submit_btn.Location = new System.Drawing.Point(364, 281);
            this.submit_btn.Margin = new System.Windows.Forms.Padding(4);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(171, 44);
            this.submit_btn.TabIndex = 103;
            this.submit_btn.Text = "Submit";
            this.submit_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.submit_btn.UseSelectable = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // userName
            // 
            this.userName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userName.FormattingEnabled = true;
            this.userName.ItemHeight = 24;
            this.userName.Location = new System.Drawing.Point(233, 190);
            this.userName.Margin = new System.Windows.Forms.Padding(4);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(263, 30);
            this.userName.Style = MetroFramework.MetroColorStyle.Blue;
            this.userName.TabIndex = 102;
            this.userName.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.userName.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.ForeColor = System.Drawing.Color.White;
            this.metroLabel2.Location = new System.Drawing.Point(141, 194);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(66, 25);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 101;
            this.metroLabel2.Text = "Name:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::NovaBiomedicalSoftware.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(676, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // LogInPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImagePadding = new System.Windows.Forms.Padding(100);
            this.BackMaxSize = 200;
            this.ClientSize = new System.Drawing.Size(676, 481);
            this.Controls.Add(this.metroPanel1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogInPage";
            this.Padding = new System.Windows.Forms.Padding(0, 37, 0, 0);
            this.Resizable = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroComboBox userName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton submit_btn;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox clientBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton createSpreadsheet;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}