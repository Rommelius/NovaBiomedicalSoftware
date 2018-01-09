namespace NovaBiomedicalSoftware
{
    partial class AlarisSoftwareManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarisSoftwareManagementForm));
            this.submitBtn = new MetroFramework.Controls.MetroButton();
            this.exitBtn = new MetroFramework.Controls.MetroButton();
            this.serialNumberBox = new MetroFramework.Controls.MetroTextBox();
            this.modelBox = new MetroFramework.Controls.MetroTextBox();
            this.serviceDateBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.serialCounter = new MetroFramework.Controls.MetroLabel();
            this.modelCounter = new MetroFramework.Controls.MetroLabel();
            this.serviceCounter = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitBtn.Location = new System.Drawing.Point(680, 543);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(220, 53);
            this.submitBtn.TabIndex = 2;
            this.submitBtn.Text = "Submit";
            this.submitBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.submitBtn.UseSelectable = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitBtn.Location = new System.Drawing.Point(24, 543);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(220, 53);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "Exit";
            this.exitBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.exitBtn.UseSelectable = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // serialNumberBox
            // 
            // 
            // 
            // 
            this.serialNumberBox.CustomButton.Image = null;
            this.serialNumberBox.CustomButton.Location = new System.Drawing.Point(-233, 2);
            this.serialNumberBox.CustomButton.Name = "";
            this.serialNumberBox.CustomButton.Size = new System.Drawing.Size(397, 397);
            this.serialNumberBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.serialNumberBox.CustomButton.TabIndex = 1;
            this.serialNumberBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.serialNumberBox.CustomButton.UseSelectable = true;
            this.serialNumberBox.CustomButton.Visible = false;
            this.serialNumberBox.Lines = new string[0];
            this.serialNumberBox.Location = new System.Drawing.Point(24, 83);
            this.serialNumberBox.MaxLength = 32767;
            this.serialNumberBox.Multiline = true;
            this.serialNumberBox.Name = "serialNumberBox";
            this.serialNumberBox.PasswordChar = '\0';
            this.serialNumberBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serialNumberBox.SelectedText = "";
            this.serialNumberBox.SelectionLength = 0;
            this.serialNumberBox.SelectionStart = 0;
            this.serialNumberBox.ShortcutsEnabled = true;
            this.serialNumberBox.Size = new System.Drawing.Size(167, 402);
            this.serialNumberBox.TabIndex = 4;
            this.serialNumberBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.serialNumberBox.UseSelectable = true;
            this.serialNumberBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.serialNumberBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.serialNumberBox.TextChanged += new System.EventHandler(this.serialNumberBox_TextChanged);
            // 
            // modelBox
            // 
            // 
            // 
            // 
            this.modelBox.CustomButton.Image = null;
            this.modelBox.CustomButton.Location = new System.Drawing.Point(-233, 2);
            this.modelBox.CustomButton.Name = "";
            this.modelBox.CustomButton.Size = new System.Drawing.Size(397, 397);
            this.modelBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.modelBox.CustomButton.TabIndex = 1;
            this.modelBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.modelBox.CustomButton.UseSelectable = true;
            this.modelBox.CustomButton.Visible = false;
            this.modelBox.Lines = new string[0];
            this.modelBox.Location = new System.Drawing.Point(208, 83);
            this.modelBox.MaxLength = 32767;
            this.modelBox.Multiline = true;
            this.modelBox.Name = "modelBox";
            this.modelBox.PasswordChar = '\0';
            this.modelBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.modelBox.SelectedText = "";
            this.modelBox.SelectionLength = 0;
            this.modelBox.SelectionStart = 0;
            this.modelBox.ShortcutsEnabled = true;
            this.modelBox.Size = new System.Drawing.Size(167, 402);
            this.modelBox.TabIndex = 5;
            this.modelBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.modelBox.UseSelectable = true;
            this.modelBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.modelBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.modelBox.TextChanged += new System.EventHandler(this.modelBox_TextChanged);
            // 
            // serviceDateBox
            // 
            // 
            // 
            // 
            this.serviceDateBox.CustomButton.Image = null;
            this.serviceDateBox.CustomButton.Location = new System.Drawing.Point(-233, 2);
            this.serviceDateBox.CustomButton.Name = "";
            this.serviceDateBox.CustomButton.Size = new System.Drawing.Size(397, 397);
            this.serviceDateBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.serviceDateBox.CustomButton.TabIndex = 1;
            this.serviceDateBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.serviceDateBox.CustomButton.UseSelectable = true;
            this.serviceDateBox.CustomButton.Visible = false;
            this.serviceDateBox.Lines = new string[0];
            this.serviceDateBox.Location = new System.Drawing.Point(392, 83);
            this.serviceDateBox.MaxLength = 32767;
            this.serviceDateBox.Multiline = true;
            this.serviceDateBox.Name = "serviceDateBox";
            this.serviceDateBox.PasswordChar = '\0';
            this.serviceDateBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serviceDateBox.SelectedText = "";
            this.serviceDateBox.SelectionLength = 0;
            this.serviceDateBox.SelectionStart = 0;
            this.serviceDateBox.ShortcutsEnabled = true;
            this.serviceDateBox.Size = new System.Drawing.Size(167, 402);
            this.serviceDateBox.TabIndex = 6;
            this.serviceDateBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.serviceDateBox.UseSelectable = true;
            this.serviceDateBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.serviceDateBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.serviceDateBox.TextChanged += new System.EventHandler(this.serviceDateBox_TextChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(104, 20);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Serial Numbers";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(208, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(48, 20);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Model";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(392, 60);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(88, 20);
            this.metroLabel3.TabIndex = 9;
            this.metroLabel3.Text = "Service Date";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // serialCounter
            // 
            this.serialCounter.AutoSize = true;
            this.serialCounter.Location = new System.Drawing.Point(137, 488);
            this.serialCounter.Name = "serialCounter";
            this.serialCounter.Size = new System.Drawing.Size(54, 20);
            this.serialCounter.TabIndex = 10;
            this.serialCounter.Text = "0 items";
            this.serialCounter.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // modelCounter
            // 
            this.modelCounter.AutoSize = true;
            this.modelCounter.Location = new System.Drawing.Point(321, 488);
            this.modelCounter.Name = "modelCounter";
            this.modelCounter.Size = new System.Drawing.Size(54, 20);
            this.modelCounter.TabIndex = 11;
            this.modelCounter.Text = "0 items";
            this.modelCounter.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // serviceCounter
            // 
            this.serviceCounter.AutoSize = true;
            this.serviceCounter.Location = new System.Drawing.Point(505, 488);
            this.serviceCounter.Name = "serviceCounter";
            this.serviceCounter.Size = new System.Drawing.Size(54, 20);
            this.serviceCounter.TabIndex = 12;
            this.serviceCounter.Text = "0 items";
            this.serviceCounter.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // AlarisSoftwareManagementForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(923, 619);
            this.Controls.Add(this.serviceCounter);
            this.Controls.Add(this.modelCounter);
            this.Controls.Add(this.serialCounter);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.serviceDateBox);
            this.Controls.Add(this.modelBox);
            this.Controls.Add(this.serialNumberBox);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.submitBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AlarisSoftwareManagementForm";
            this.Resizable = false;
            this.Text = "Alaris Software Management Report Generator";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton submitBtn;
        private MetroFramework.Controls.MetroButton exitBtn;
        private MetroFramework.Controls.MetroTextBox serialNumberBox;
        private MetroFramework.Controls.MetroTextBox modelBox;
        private MetroFramework.Controls.MetroTextBox serviceDateBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel serialCounter;
        private MetroFramework.Controls.MetroLabel modelCounter;
        private MetroFramework.Controls.MetroLabel serviceCounter;
    }
}