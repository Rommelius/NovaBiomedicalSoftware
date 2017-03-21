namespace NovaBiomedicalSoftware.Performance_Test
{
    partial class Genius2Thermometer
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
            this.safetyCheck = new MetroFramework.Controls.MetroTabControl();
            this.visualCheck = new MetroFramework.Controls.MetroTabPage();
            this.close1_btn = new MetroFramework.Controls.MetroButton();
            this.nextBtn = new MetroFramework.Controls.MetroButton();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.visual_option1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.visual1 = new MetroFramework.Controls.MetroLabel();
            this.commentsTab = new MetroFramework.Controls.MetroTabPage();
            this.itemsBox = new MetroFramework.Controls.MetroTextBox();
            this.metroCheckBox14 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox13 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox12 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox11 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox10 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox9 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox8 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox7 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox6 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox5 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox4 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox3 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.submitBtn = new MetroFramework.Controls.MetroButton();
            this.close3_btn = new MetroFramework.Controls.MetroButton();
            this.commentBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.safetyCheck.SuspendLayout();
            this.visualCheck.SuspendLayout();
            this.commentsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // safetyCheck
            // 
            this.safetyCheck.Controls.Add(this.visualCheck);
            this.safetyCheck.Controls.Add(this.commentsTab);
            this.safetyCheck.Location = new System.Drawing.Point(24, 63);
            this.safetyCheck.Name = "safetyCheck";
            this.safetyCheck.SelectedIndex = 0;
            this.safetyCheck.Size = new System.Drawing.Size(609, 580);
            this.safetyCheck.TabIndex = 3;
            this.safetyCheck.UseSelectable = true;
            // 
            // visualCheck
            // 
            this.visualCheck.Controls.Add(this.close1_btn);
            this.visualCheck.Controls.Add(this.nextBtn);
            this.visualCheck.Controls.Add(this.metroComboBox1);
            this.visualCheck.Controls.Add(this.visual_option1);
            this.visualCheck.Controls.Add(this.metroLabel5);
            this.visualCheck.Controls.Add(this.visual1);
            this.visualCheck.HorizontalScrollbar = true;
            this.visualCheck.HorizontalScrollbarBarColor = true;
            this.visualCheck.HorizontalScrollbarHighlightOnWheel = false;
            this.visualCheck.HorizontalScrollbarSize = 10;
            this.visualCheck.Location = new System.Drawing.Point(4, 38);
            this.visualCheck.Name = "visualCheck";
            this.visualCheck.Size = new System.Drawing.Size(601, 538);
            this.visualCheck.TabIndex = 0;
            this.visualCheck.Text = "Performance Verification";
            this.visualCheck.VerticalScrollbar = true;
            this.visualCheck.VerticalScrollbarBarColor = true;
            this.visualCheck.VerticalScrollbarHighlightOnWheel = false;
            this.visualCheck.VerticalScrollbarSize = 10;
            // 
            // close1_btn
            // 
            this.close1_btn.Location = new System.Drawing.Point(0, 497);
            this.close1_btn.Name = "close1_btn";
            this.close1_btn.Size = new System.Drawing.Size(121, 41);
            this.close1_btn.Style = MetroFramework.MetroColorStyle.Blue;
            this.close1_btn.TabIndex = 37;
            this.close1_btn.Text = "Cancel";
            this.close1_btn.UseSelectable = true;
            this.close1_btn.UseStyleColors = true;
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(484, 494);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(121, 41);
            this.nextBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.nextBtn.TabIndex = 19;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseSelectable = true;
            this.nextBtn.UseStyleColors = true;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 19;
            this.metroComboBox1.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.metroComboBox1.Location = new System.Drawing.Point(477, 43);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(121, 25);
            this.metroComboBox1.TabIndex = 11;
            this.metroComboBox1.UseSelectable = true;
            // 
            // visual_option1
            // 
            this.visual_option1.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.visual_option1.FormattingEnabled = true;
            this.visual_option1.ItemHeight = 19;
            this.visual_option1.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.visual_option1.Location = new System.Drawing.Point(477, 12);
            this.visual_option1.Name = "visual_option1";
            this.visual_option1.Size = new System.Drawing.Size(121, 25);
            this.visual_option1.TabIndex = 11;
            this.visual_option1.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(-4, 49);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(78, 19);
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "Visual check";
            // 
            // visual1
            // 
            this.visual1.AutoSize = true;
            this.visual1.Location = new System.Drawing.Point(-4, 18);
            this.visual1.Name = "visual1";
            this.visual1.Size = new System.Drawing.Size(119, 19);
            this.visual1.TabIndex = 3;
            this.visual1.Text = "Temperature check";
            // 
            // commentsTab
            // 
            this.commentsTab.Controls.Add(this.itemsBox);
            this.commentsTab.Controls.Add(this.metroCheckBox14);
            this.commentsTab.Controls.Add(this.metroCheckBox13);
            this.commentsTab.Controls.Add(this.metroCheckBox12);
            this.commentsTab.Controls.Add(this.metroCheckBox11);
            this.commentsTab.Controls.Add(this.metroCheckBox10);
            this.commentsTab.Controls.Add(this.metroCheckBox9);
            this.commentsTab.Controls.Add(this.metroCheckBox8);
            this.commentsTab.Controls.Add(this.metroCheckBox7);
            this.commentsTab.Controls.Add(this.metroCheckBox6);
            this.commentsTab.Controls.Add(this.metroCheckBox5);
            this.commentsTab.Controls.Add(this.metroCheckBox4);
            this.commentsTab.Controls.Add(this.metroCheckBox3);
            this.commentsTab.Controls.Add(this.metroCheckBox2);
            this.commentsTab.Controls.Add(this.metroCheckBox1);
            this.commentsTab.Controls.Add(this.metroLabel2);
            this.commentsTab.Controls.Add(this.submitBtn);
            this.commentsTab.Controls.Add(this.close3_btn);
            this.commentsTab.Controls.Add(this.commentBox);
            this.commentsTab.Controls.Add(this.metroLabel3);
            this.commentsTab.HorizontalScrollbarBarColor = true;
            this.commentsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.commentsTab.HorizontalScrollbarSize = 10;
            this.commentsTab.Location = new System.Drawing.Point(4, 35);
            this.commentsTab.Name = "commentsTab";
            this.commentsTab.Size = new System.Drawing.Size(601, 541);
            this.commentsTab.TabIndex = 2;
            this.commentsTab.Text = "Comments";
            this.commentsTab.VerticalScrollbarBarColor = true;
            this.commentsTab.VerticalScrollbarHighlightOnWheel = false;
            this.commentsTab.VerticalScrollbarSize = 10;
            // 
            // itemsBox
            // 
            // 
            // 
            // 
            this.itemsBox.CustomButton.Image = null;
            this.itemsBox.CustomButton.Location = new System.Drawing.Point(9, 2);
            this.itemsBox.CustomButton.Name = "";
            this.itemsBox.CustomButton.Size = new System.Drawing.Size(195, 195);
            this.itemsBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.itemsBox.CustomButton.TabIndex = 1;
            this.itemsBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.itemsBox.CustomButton.UseSelectable = true;
            this.itemsBox.CustomButton.Visible = false;
            this.itemsBox.Lines = new string[0];
            this.itemsBox.Location = new System.Drawing.Point(394, 288);
            this.itemsBox.MaxLength = 32767;
            this.itemsBox.Multiline = true;
            this.itemsBox.Name = "itemsBox";
            this.itemsBox.PasswordChar = '\0';
            this.itemsBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.itemsBox.SelectedText = "";
            this.itemsBox.SelectionLength = 0;
            this.itemsBox.SelectionStart = 0;
            this.itemsBox.ShortcutsEnabled = true;
            this.itemsBox.Size = new System.Drawing.Size(207, 200);
            this.itemsBox.TabIndex = 107;
            this.itemsBox.UseSelectable = true;
            this.itemsBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.itemsBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroCheckBox14
            // 
            this.metroCheckBox14.AutoSize = true;
            this.metroCheckBox14.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox14.Location = new System.Drawing.Point(255, 438);
            this.metroCheckBox14.Name = "metroCheckBox14";
            this.metroCheckBox14.Size = new System.Drawing.Size(77, 19);
            this.metroCheckBox14.TabIndex = 106;
            this.metroCheckBox14.Text = "Tester14";
            this.metroCheckBox14.UseSelectable = true;
            // 
            // metroCheckBox13
            // 
            this.metroCheckBox13.AutoSize = true;
            this.metroCheckBox13.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox13.Location = new System.Drawing.Point(255, 413);
            this.metroCheckBox13.Name = "metroCheckBox13";
            this.metroCheckBox13.Size = new System.Drawing.Size(77, 19);
            this.metroCheckBox13.TabIndex = 106;
            this.metroCheckBox13.Text = "Tester13";
            this.metroCheckBox13.UseSelectable = true;
            // 
            // metroCheckBox12
            // 
            this.metroCheckBox12.AutoSize = true;
            this.metroCheckBox12.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox12.Location = new System.Drawing.Point(255, 388);
            this.metroCheckBox12.Name = "metroCheckBox12";
            this.metroCheckBox12.Size = new System.Drawing.Size(77, 19);
            this.metroCheckBox12.TabIndex = 106;
            this.metroCheckBox12.Text = "Tester12";
            this.metroCheckBox12.UseSelectable = true;
            // 
            // metroCheckBox11
            // 
            this.metroCheckBox11.AutoSize = true;
            this.metroCheckBox11.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox11.Location = new System.Drawing.Point(255, 363);
            this.metroCheckBox11.Name = "metroCheckBox11";
            this.metroCheckBox11.Size = new System.Drawing.Size(77, 19);
            this.metroCheckBox11.TabIndex = 106;
            this.metroCheckBox11.Text = "Tester11";
            this.metroCheckBox11.UseSelectable = true;
            // 
            // metroCheckBox10
            // 
            this.metroCheckBox10.AutoSize = true;
            this.metroCheckBox10.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox10.Location = new System.Drawing.Point(255, 338);
            this.metroCheckBox10.Name = "metroCheckBox10";
            this.metroCheckBox10.Size = new System.Drawing.Size(77, 19);
            this.metroCheckBox10.TabIndex = 106;
            this.metroCheckBox10.Text = "Tester10";
            this.metroCheckBox10.UseSelectable = true;
            // 
            // metroCheckBox9
            // 
            this.metroCheckBox9.AutoSize = true;
            this.metroCheckBox9.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox9.Location = new System.Drawing.Point(255, 313);
            this.metroCheckBox9.Name = "metroCheckBox9";
            this.metroCheckBox9.Size = new System.Drawing.Size(69, 19);
            this.metroCheckBox9.TabIndex = 106;
            this.metroCheckBox9.Text = "Tester9";
            this.metroCheckBox9.UseSelectable = true;
            // 
            // metroCheckBox8
            // 
            this.metroCheckBox8.AutoSize = true;
            this.metroCheckBox8.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox8.Location = new System.Drawing.Point(255, 288);
            this.metroCheckBox8.Name = "metroCheckBox8";
            this.metroCheckBox8.Size = new System.Drawing.Size(69, 19);
            this.metroCheckBox8.TabIndex = 106;
            this.metroCheckBox8.Text = "Tester8";
            this.metroCheckBox8.UseSelectable = true;
            // 
            // metroCheckBox7
            // 
            this.metroCheckBox7.AutoSize = true;
            this.metroCheckBox7.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox7.Location = new System.Drawing.Point(52, 438);
            this.metroCheckBox7.Name = "metroCheckBox7";
            this.metroCheckBox7.Size = new System.Drawing.Size(69, 19);
            this.metroCheckBox7.TabIndex = 106;
            this.metroCheckBox7.Text = "Tester7";
            this.metroCheckBox7.UseSelectable = true;
            // 
            // metroCheckBox6
            // 
            this.metroCheckBox6.AutoSize = true;
            this.metroCheckBox6.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox6.Location = new System.Drawing.Point(52, 413);
            this.metroCheckBox6.Name = "metroCheckBox6";
            this.metroCheckBox6.Size = new System.Drawing.Size(69, 19);
            this.metroCheckBox6.TabIndex = 106;
            this.metroCheckBox6.Text = "Tester6";
            this.metroCheckBox6.UseSelectable = true;
            // 
            // metroCheckBox5
            // 
            this.metroCheckBox5.AutoSize = true;
            this.metroCheckBox5.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox5.Location = new System.Drawing.Point(52, 388);
            this.metroCheckBox5.Name = "metroCheckBox5";
            this.metroCheckBox5.Size = new System.Drawing.Size(69, 19);
            this.metroCheckBox5.TabIndex = 106;
            this.metroCheckBox5.Text = "Tester5";
            this.metroCheckBox5.UseSelectable = true;
            // 
            // metroCheckBox4
            // 
            this.metroCheckBox4.AutoSize = true;
            this.metroCheckBox4.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox4.Location = new System.Drawing.Point(52, 363);
            this.metroCheckBox4.Name = "metroCheckBox4";
            this.metroCheckBox4.Size = new System.Drawing.Size(69, 19);
            this.metroCheckBox4.TabIndex = 106;
            this.metroCheckBox4.Text = "Tester4";
            this.metroCheckBox4.UseSelectable = true;
            // 
            // metroCheckBox3
            // 
            this.metroCheckBox3.AutoSize = true;
            this.metroCheckBox3.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox3.Location = new System.Drawing.Point(52, 338);
            this.metroCheckBox3.Name = "metroCheckBox3";
            this.metroCheckBox3.Size = new System.Drawing.Size(69, 19);
            this.metroCheckBox3.TabIndex = 106;
            this.metroCheckBox3.Text = "Tester3";
            this.metroCheckBox3.UseSelectable = true;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox2.Location = new System.Drawing.Point(52, 313);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(69, 19);
            this.metroCheckBox2.TabIndex = 106;
            this.metroCheckBox2.Text = "Tester2";
            this.metroCheckBox2.UseSelectable = true;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox1.Location = new System.Drawing.Point(52, 288);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(69, 19);
            this.metroCheckBox1.TabIndex = 106;
            this.metroCheckBox1.Text = "Tester1";
            this.metroCheckBox1.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(-4, 255);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(120, 19);
            this.metroLabel2.TabIndex = 104;
            this.metroLabel2.Text = "Test Equipments:";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(480, 494);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(121, 41);
            this.submitBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.submitBtn.TabIndex = 103;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseSelectable = true;
            this.submitBtn.UseStyleColors = true;
            // 
            // close3_btn
            // 
            this.close3_btn.Location = new System.Drawing.Point(0, 494);
            this.close3_btn.Name = "close3_btn";
            this.close3_btn.Size = new System.Drawing.Size(121, 41);
            this.close3_btn.Style = MetroFramework.MetroColorStyle.Blue;
            this.close3_btn.TabIndex = 102;
            this.close3_btn.Text = "Cancel";
            this.close3_btn.UseSelectable = true;
            this.close3_btn.UseStyleColors = true;
            // 
            // commentBox
            // 
            // 
            // 
            // 
            this.commentBox.CustomButton.Image = null;
            this.commentBox.CustomButton.Location = new System.Drawing.Point(383, 2);
            this.commentBox.CustomButton.Name = "";
            this.commentBox.CustomButton.Size = new System.Drawing.Size(215, 215);
            this.commentBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.commentBox.CustomButton.TabIndex = 1;
            this.commentBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.commentBox.CustomButton.UseSelectable = true;
            this.commentBox.CustomButton.Visible = false;
            this.commentBox.Lines = new string[0];
            this.commentBox.Location = new System.Drawing.Point(0, 32);
            this.commentBox.MaxLength = 32767;
            this.commentBox.Multiline = true;
            this.commentBox.Name = "commentBox";
            this.commentBox.PasswordChar = '\0';
            this.commentBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.commentBox.SelectedText = "";
            this.commentBox.SelectionLength = 0;
            this.commentBox.SelectionStart = 0;
            this.commentBox.ShortcutsEnabled = true;
            this.commentBox.Size = new System.Drawing.Size(601, 220);
            this.commentBox.TabIndex = 40;
            this.commentBox.UseSelectable = true;
            this.commentBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.commentBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(-4, 9);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(84, 19);
            this.metroLabel3.TabIndex = 39;
            this.metroLabel3.Text = "Comments:";
            // 
            // Genius2Thermometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 666);
            this.Controls.Add(this.safetyCheck);
            this.Name = "Genius2Thermometer";
            this.Text = "Genius 2 Tympanic Thermometer";
            this.safetyCheck.ResumeLayout(false);
            this.visualCheck.ResumeLayout(false);
            this.visualCheck.PerformLayout();
            this.commentsTab.ResumeLayout(false);
            this.commentsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MetroFramework.Controls.MetroTabControl safetyCheck;
        private MetroFramework.Controls.MetroTabPage visualCheck;
        private MetroFramework.Controls.MetroButton close1_btn;
        private MetroFramework.Controls.MetroButton nextBtn;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroComboBox visual_option1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel visual1;
        private MetroFramework.Controls.MetroTabPage commentsTab;
        private MetroFramework.Controls.MetroTextBox itemsBox;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox14;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox13;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox12;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox11;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox10;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox9;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox8;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox7;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox6;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox5;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox4;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox3;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton submitBtn;
        private MetroFramework.Controls.MetroButton close3_btn;
        private MetroFramework.Controls.MetroTextBox commentBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}