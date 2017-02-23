namespace NovaBiomedicalSoftware
{
    partial class BatteryChecker
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.inputLetter = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.inputDigits = new MetroFramework.Controls.MetroTextBox();
            this.resultsAge = new MetroFramework.Controls.MetroLabel();
            this.detailsAge = new MetroFramework.Controls.MetroLabel();
            this.checkBattery_btn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NovaBiomedicalSoftware.Properties.Resources.batteryChecker;
            this.pictureBox1.Location = new System.Drawing.Point(292, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 184);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // inputLetter
            // 
            // 
            // 
            // 
            this.inputLetter.CustomButton.Image = null;
            this.inputLetter.CustomButton.Location = new System.Drawing.Point(75, 1);
            this.inputLetter.CustomButton.Name = "";
            this.inputLetter.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.inputLetter.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputLetter.CustomButton.TabIndex = 1;
            this.inputLetter.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputLetter.CustomButton.UseSelectable = true;
            this.inputLetter.CustomButton.Visible = false;
            this.inputLetter.Lines = new string[0];
            this.inputLetter.Location = new System.Drawing.Point(189, 127);
            this.inputLetter.MaxLength = 32767;
            this.inputLetter.Name = "inputLetter";
            this.inputLetter.PasswordChar = '\0';
            this.inputLetter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputLetter.SelectedText = "";
            this.inputLetter.SelectionLength = 0;
            this.inputLetter.SelectionStart = 0;
            this.inputLetter.ShortcutsEnabled = true;
            this.inputLetter.Size = new System.Drawing.Size(97, 23);
            this.inputLetter.TabIndex = 1;
            this.inputLetter.UseSelectable = true;
            this.inputLetter.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputLetter.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 131);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(96, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Type the letter:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 163);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(121, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Type the two digits:";
            // 
            // inputDigits
            // 
            // 
            // 
            // 
            this.inputDigits.CustomButton.Image = null;
            this.inputDigits.CustomButton.Location = new System.Drawing.Point(75, 1);
            this.inputDigits.CustomButton.Name = "";
            this.inputDigits.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.inputDigits.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputDigits.CustomButton.TabIndex = 1;
            this.inputDigits.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputDigits.CustomButton.UseSelectable = true;
            this.inputDigits.CustomButton.Visible = false;
            this.inputDigits.Lines = new string[0];
            this.inputDigits.Location = new System.Drawing.Point(189, 159);
            this.inputDigits.MaxLength = 32767;
            this.inputDigits.Name = "inputDigits";
            this.inputDigits.PasswordChar = '\0';
            this.inputDigits.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputDigits.SelectedText = "";
            this.inputDigits.SelectionLength = 0;
            this.inputDigits.SelectionStart = 0;
            this.inputDigits.ShortcutsEnabled = true;
            this.inputDigits.Size = new System.Drawing.Size(97, 23);
            this.inputDigits.TabIndex = 4;
            this.inputDigits.UseSelectable = true;
            this.inputDigits.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputDigits.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // resultsAge
            // 
            this.resultsAge.AutoSize = true;
            this.resultsAge.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.resultsAge.Location = new System.Drawing.Point(63, 60);
            this.resultsAge.Name = "resultsAge";
            this.resultsAge.Size = new System.Drawing.Size(183, 25);
            this.resultsAge.TabIndex = 5;
            this.resultsAge.Text = "Please fill in the details";
            // 
            // detailsAge
            // 
            this.detailsAge.AutoSize = true;
            this.detailsAge.Location = new System.Drawing.Point(115, 85);
            this.detailsAge.Name = "detailsAge";
            this.detailsAge.Size = new System.Drawing.Size(93, 19);
            this.detailsAge.TabIndex = 6;
            this.detailsAge.Text = "--------------";
            // 
            // checkBattery_btn
            // 
            this.checkBattery_btn.Location = new System.Drawing.Point(211, 188);
            this.checkBattery_btn.Name = "checkBattery_btn";
            this.checkBattery_btn.Size = new System.Drawing.Size(75, 23);
            this.checkBattery_btn.Style = MetroFramework.MetroColorStyle.Blue;
            this.checkBattery_btn.TabIndex = 7;
            this.checkBattery_btn.Text = "Check";
            this.checkBattery_btn.UseSelectable = true;
            this.checkBattery_btn.UseStyleColors = true;
            this.checkBattery_btn.Click += new System.EventHandler(this.checkBattery_btn_Click);
            // 
            // BatteryChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 230);
            this.Controls.Add(this.checkBattery_btn);
            this.Controls.Add(this.detailsAge);
            this.Controls.Add(this.resultsAge);
            this.Controls.Add(this.inputDigits);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.inputLetter);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BatteryChecker";
            this.Text = "Age of battery";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox inputLetter;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox inputDigits;
        private MetroFramework.Controls.MetroLabel resultsAge;
        private MetroFramework.Controls.MetroLabel detailsAge;
        private MetroFramework.Controls.MetroButton checkBattery_btn;
    }
}