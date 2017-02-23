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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.resultsAge = new MetroFramework.Controls.MetroLabel();
            this.checkBattery_btn = new MetroFramework.Controls.MetroButton();
            this.yearBattery = new MetroFramework.Controls.MetroLabel();
            this.monthBattery = new MetroFramework.Controls.MetroLabel();
            this.inputDigits = new MetroFramework.Controls.MetroComboBox();
            this.inputLetter = new MetroFramework.Controls.MetroComboBox();
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
            // checkBattery_btn
            // 
            this.checkBattery_btn.Location = new System.Drawing.Point(167, 188);
            this.checkBattery_btn.Name = "checkBattery_btn";
            this.checkBattery_btn.Size = new System.Drawing.Size(119, 23);
            this.checkBattery_btn.Style = MetroFramework.MetroColorStyle.Blue;
            this.checkBattery_btn.TabIndex = 7;
            this.checkBattery_btn.Text = "Check";
            this.checkBattery_btn.UseSelectable = true;
            this.checkBattery_btn.UseStyleColors = true;
            this.checkBattery_btn.Click += new System.EventHandler(this.checkBattery_btn_Click);
            // 
            // yearBattery
            // 
            this.yearBattery.AutoSize = true;
            this.yearBattery.Location = new System.Drawing.Point(63, 85);
            this.yearBattery.Name = "yearBattery";
            this.yearBattery.Size = new System.Drawing.Size(34, 19);
            this.yearBattery.TabIndex = 8;
            this.yearBattery.Text = "Year";
            // 
            // monthBattery
            // 
            this.monthBattery.AutoSize = true;
            this.monthBattery.Location = new System.Drawing.Point(103, 85);
            this.monthBattery.Name = "monthBattery";
            this.monthBattery.Size = new System.Drawing.Size(115, 19);
            this.monthBattery.TabIndex = 9;
            this.monthBattery.Text = "Number of Weeks";
            // 
            // inputDigits
            // 
            this.inputDigits.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.inputDigits.FormattingEnabled = true;
            this.inputDigits.ItemHeight = 19;
            this.inputDigits.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53"});
            this.inputDigits.Location = new System.Drawing.Point(211, 157);
            this.inputDigits.Name = "inputDigits";
            this.inputDigits.Size = new System.Drawing.Size(75, 25);
            this.inputDigits.TabIndex = 10;
            this.inputDigits.UseSelectable = true;
            // 
            // inputLetter
            // 
            this.inputLetter.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.inputLetter.FormattingEnabled = true;
            this.inputLetter.ItemHeight = 19;
            this.inputLetter.Items.AddRange(new object[] {
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N"});
            this.inputLetter.Location = new System.Drawing.Point(211, 126);
            this.inputLetter.Name = "inputLetter";
            this.inputLetter.Size = new System.Drawing.Size(75, 25);
            this.inputLetter.TabIndex = 11;
            this.inputLetter.UseSelectable = true;
            // 
            // BatteryChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 230);
            this.Controls.Add(this.inputLetter);
            this.Controls.Add(this.inputDigits);
            this.Controls.Add(this.monthBattery);
            this.Controls.Add(this.yearBattery);
            this.Controls.Add(this.checkBattery_btn);
            this.Controls.Add(this.resultsAge);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "BatteryChecker";
            this.Text = "Age of battery";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel resultsAge;
        private MetroFramework.Controls.MetroButton checkBattery_btn;
        private MetroFramework.Controls.MetroLabel yearBattery;
        private MetroFramework.Controls.MetroLabel monthBattery;
        private MetroFramework.Controls.MetroComboBox inputDigits;
        private MetroFramework.Controls.MetroComboBox inputLetter;
    }
}