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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.submit_btn = new MetroFramework.Controls.MetroButton();
            this.btnAdduser = new MetroFramework.Controls.MetroButton();
            this.userName = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.submit_btn);
            this.metroPanel1.Controls.Add(this.btnAdduser);
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
            this.metroPanel1.Size = new System.Drawing.Size(676, 367);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 13;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(0, 342);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(111, 25);
            this.metroLabel1.TabIndex = 104;
            this.metroLabel1.Text = "Version 6.0";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // submit_btn
            // 
            this.submit_btn.Location = new System.Drawing.Point(373, 254);
            this.submit_btn.Margin = new System.Windows.Forms.Padding(4);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(171, 44);
            this.submit_btn.TabIndex = 103;
            this.submit_btn.Text = "Submit";
            this.submit_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.submit_btn.UseSelectable = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // btnAdduser
            // 
            this.btnAdduser.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnAdduser.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnAdduser.Location = new System.Drawing.Point(505, 190);
            this.btnAdduser.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdduser.Name = "btnAdduser";
            this.btnAdduser.Size = new System.Drawing.Size(30, 30);
            this.btnAdduser.TabIndex = 100;
            this.btnAdduser.Text = "+";
            this.btnAdduser.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnAdduser.UseSelectable = true;
            this.btnAdduser.Click += new System.EventHandler(this.btnAdduser_Click);
            // 
            // userName
            // 
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
            this.ClientSize = new System.Drawing.Size(676, 404);
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
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton btnAdduser;
        private MetroFramework.Controls.MetroComboBox userName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton submit_btn;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}