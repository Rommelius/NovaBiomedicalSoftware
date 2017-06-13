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
            this.pictureBox1.Location = new System.Drawing.Point(389, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 226);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(31, 161);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(103, 20);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Type the letter:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(31, 201);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(128, 20);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Type the two digits:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // resultsAge
            // 
            this.resultsAge.AutoSize = true;
            this.resultsAge.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.resultsAge.Location = new System.Drawing.Point(84, 74);
            this.resultsAge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resultsAge.Name = "resultsAge";
            this.resultsAge.Size = new System.Drawing.Size(190, 25);
            this.resultsAge.TabIndex = 5;
            this.resultsAge.Text = "Please fill in the details";
            this.resultsAge.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // checkBattery_btn
            // 
            this.checkBattery_btn.Location = new System.Drawing.Point(223, 231);
            this.checkBattery_btn.Margin = new System.Windows.Forms.Padding(4);
            this.checkBattery_btn.Name = "checkBattery_btn";
            this.checkBattery_btn.Size = new System.Drawing.Size(159, 28);
            this.checkBattery_btn.Style = MetroFramework.MetroColorStyle.Blue;
            this.checkBattery_btn.TabIndex = 7;
            this.checkBattery_btn.Text = "Check";
            this.checkBattery_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkBattery_btn.UseSelectable = true;
            this.checkBattery_btn.UseStyleColors = true;
            this.checkBattery_btn.Click += new System.EventHandler(this.checkBattery_btn_Click);
            // 
            // yearBattery
            // 
            this.yearBattery.AutoSize = true;
            this.yearBattery.Location = new System.Drawing.Point(84, 105);
            this.yearBattery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.yearBattery.Name = "yearBattery";
            this.yearBattery.Size = new System.Drawing.Size(35, 20);
            this.yearBattery.TabIndex = 8;
            this.yearBattery.Text = "Year";
            this.yearBattery.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // monthBattery
            // 
            this.monthBattery.AutoSize = true;
            this.monthBattery.Location = new System.Drawing.Point(137, 105);
            this.monthBattery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.monthBattery.Name = "monthBattery";
            this.monthBattery.Size = new System.Drawing.Size(122, 20);
            this.monthBattery.TabIndex = 9;
            this.monthBattery.Text = "Number of Weeks";
            this.monthBattery.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // inputDigits
            // 
            this.inputDigits.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.inputDigits.FormattingEnabled = true;
            this.inputDigits.ItemHeight = 21;
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
            this.inputDigits.Location = new System.Drawing.Point(281, 193);
            this.inputDigits.Margin = new System.Windows.Forms.Padding(4);
            this.inputDigits.Name = "inputDigits";
            this.inputDigits.Size = new System.Drawing.Size(99, 27);
            this.inputDigits.TabIndex = 10;
            this.inputDigits.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.inputDigits.UseSelectable = true;
            // 
            // inputLetter
            // 
            this.inputLetter.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.inputLetter.FormattingEnabled = true;
            this.inputLetter.ItemHeight = 21;
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
            "N",
            "O",
            "P"});
            this.inputLetter.Location = new System.Drawing.Point(281, 155);
            this.inputLetter.Margin = new System.Windows.Forms.Padding(4);
            this.inputLetter.Name = "inputLetter";
            this.inputLetter.Size = new System.Drawing.Size(99, 27);
            this.inputLetter.TabIndex = 11;
            this.inputLetter.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.inputLetter.UseSelectable = true;
            // 
            // BatteryChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 283);
            this.Controls.Add(this.inputLetter);
            this.Controls.Add(this.inputDigits);
            this.Controls.Add(this.monthBattery);
            this.Controls.Add(this.yearBattery);
            this.Controls.Add(this.checkBattery_btn);
            this.Controls.Add(this.resultsAge);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BatteryChecker";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Age of battery";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
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