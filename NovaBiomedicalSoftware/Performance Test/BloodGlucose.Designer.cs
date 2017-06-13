namespace NovaBiomedicalSoftware.Performance_Test
{
    partial class BloodGlucose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BloodGlucose));
            this.safetyCheck = new MetroFramework.Controls.MetroTabControl();
            this.performanceVerification = new MetroFramework.Controls.MetroTabPage();
            this.nextBtn = new MetroFramework.Controls.MetroButton();
            this.close1_btn = new MetroFramework.Controls.MetroButton();
            this.result_3 = new MetroFramework.Controls.MetroComboBox();
            this.result_2 = new MetroFramework.Controls.MetroComboBox();
            this.result_1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.visual1 = new MetroFramework.Controls.MetroLabel();
            this.commentsTab = new MetroFramework.Controls.MetroTabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.submitBtn = new MetroFramework.Controls.MetroButton();
            this.close3_btn = new MetroFramework.Controls.MetroButton();
            this.commentBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.safetyCheck.SuspendLayout();
            this.performanceVerification.SuspendLayout();
            this.commentsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // safetyCheck
            // 
            this.safetyCheck.Controls.Add(this.performanceVerification);
            this.safetyCheck.Controls.Add(this.commentsTab);
            this.safetyCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.safetyCheck.Location = new System.Drawing.Point(20, 60);
            this.safetyCheck.Margin = new System.Windows.Forms.Padding(4);
            this.safetyCheck.Name = "safetyCheck";
            this.safetyCheck.SelectedIndex = 1;
            this.safetyCheck.Size = new System.Drawing.Size(1075, 740);
            this.safetyCheck.TabIndex = 5;
            this.safetyCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.safetyCheck.UseSelectable = true;
            // 
            // performanceVerification
            // 
            this.performanceVerification.AutoScroll = true;
            this.performanceVerification.Controls.Add(this.nextBtn);
            this.performanceVerification.Controls.Add(this.close1_btn);
            this.performanceVerification.Controls.Add(this.result_3);
            this.performanceVerification.Controls.Add(this.result_2);
            this.performanceVerification.Controls.Add(this.result_1);
            this.performanceVerification.Controls.Add(this.metroLabel6);
            this.performanceVerification.Controls.Add(this.metroLabel5);
            this.performanceVerification.Controls.Add(this.visual1);
            this.performanceVerification.HorizontalScrollbar = true;
            this.performanceVerification.HorizontalScrollbarBarColor = true;
            this.performanceVerification.HorizontalScrollbarHighlightOnWheel = false;
            this.performanceVerification.HorizontalScrollbarSize = 12;
            this.performanceVerification.Location = new System.Drawing.Point(4, 38);
            this.performanceVerification.Margin = new System.Windows.Forms.Padding(4);
            this.performanceVerification.Name = "performanceVerification";
            this.performanceVerification.Size = new System.Drawing.Size(1067, 698);
            this.performanceVerification.TabIndex = 0;
            this.performanceVerification.Text = "Performance Verification";
            this.performanceVerification.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.performanceVerification.VerticalScrollbar = true;
            this.performanceVerification.VerticalScrollbarBarColor = true;
            this.performanceVerification.VerticalScrollbarHighlightOnWheel = false;
            this.performanceVerification.VerticalScrollbarSize = 13;
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(902, 644);
            this.nextBtn.Margin = new System.Windows.Forms.Padding(4);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(161, 50);
            this.nextBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.nextBtn.TabIndex = 19;
            this.nextBtn.Text = "Next";
            this.nextBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.nextBtn.UseSelectable = true;
            this.nextBtn.UseStyleColors = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // close1_btn
            // 
            this.close1_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.close1_btn.Location = new System.Drawing.Point(4, 644);
            this.close1_btn.Margin = new System.Windows.Forms.Padding(4);
            this.close1_btn.Name = "close1_btn";
            this.close1_btn.Size = new System.Drawing.Size(161, 50);
            this.close1_btn.Style = MetroFramework.MetroColorStyle.Blue;
            this.close1_btn.TabIndex = 37;
            this.close1_btn.Text = "Cancel";
            this.close1_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.close1_btn.UseSelectable = true;
            this.close1_btn.UseStyleColors = true;
            this.close1_btn.Click += new System.EventHandler(this.close1_btn_Click);
            // 
            // result_3
            // 
            this.result_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.result_3.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.result_3.FormattingEnabled = true;
            this.result_3.ItemHeight = 21;
            this.result_3.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.result_3.Location = new System.Drawing.Point(903, 93);
            this.result_3.Margin = new System.Windows.Forms.Padding(4);
            this.result_3.Name = "result_3";
            this.result_3.Size = new System.Drawing.Size(160, 27);
            this.result_3.TabIndex = 11;
            this.result_3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.result_3.UseSelectable = true;
            // 
            // result_2
            // 
            this.result_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.result_2.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.result_2.FormattingEnabled = true;
            this.result_2.ItemHeight = 21;
            this.result_2.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.result_2.Location = new System.Drawing.Point(903, 56);
            this.result_2.Margin = new System.Windows.Forms.Padding(4);
            this.result_2.Name = "result_2";
            this.result_2.Size = new System.Drawing.Size(160, 27);
            this.result_2.TabIndex = 11;
            this.result_2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.result_2.UseSelectable = true;
            // 
            // result_1
            // 
            this.result_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.result_1.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.result_1.FormattingEnabled = true;
            this.result_1.ItemHeight = 21;
            this.result_1.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.result_1.Location = new System.Drawing.Point(903, 18);
            this.result_1.Margin = new System.Windows.Forms.Padding(4);
            this.result_1.Name = "result_1";
            this.result_1.Size = new System.Drawing.Size(160, 27);
            this.result_1.TabIndex = 11;
            this.result_1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.result_1.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(-3, 100);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(136, 20);
            this.metroLabel6.TabIndex = 3;
            this.metroLabel6.Text = "Overall Performance";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(-3, 63);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(119, 20);
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "Screen Inspection";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // visual1
            // 
            this.visual1.AutoSize = true;
            this.visual1.Location = new System.Drawing.Point(0, 25);
            this.visual1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.visual1.Name = "visual1";
            this.visual1.Size = new System.Drawing.Size(112, 20);
            this.visual1.TabIndex = 3;
            this.visual1.Text = "Visual Inspection";
            this.visual1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // commentsTab
            // 
            this.commentsTab.Controls.Add(this.listBox1);
            this.commentsTab.Controls.Add(this.metroLabel2);
            this.commentsTab.Controls.Add(this.submitBtn);
            this.commentsTab.Controls.Add(this.close3_btn);
            this.commentsTab.Controls.Add(this.commentBox);
            this.commentsTab.Controls.Add(this.metroLabel3);
            this.commentsTab.HorizontalScrollbarBarColor = true;
            this.commentsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.commentsTab.HorizontalScrollbarSize = 12;
            this.commentsTab.Location = new System.Drawing.Point(4, 38);
            this.commentsTab.Margin = new System.Windows.Forms.Padding(4);
            this.commentsTab.Name = "commentsTab";
            this.commentsTab.Size = new System.Drawing.Size(1067, 698);
            this.commentsTab.TabIndex = 2;
            this.commentsTab.Text = "Comments";
            this.commentsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.commentsTab.VerticalScrollbarBarColor = true;
            this.commentsTab.VerticalScrollbarHighlightOnWheel = false;
            this.commentsTab.VerticalScrollbarSize = 13;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Items.AddRange(new object[] {
            "FLUKE PROSIM 3 VITAL SIGN SIMULATOR (SN 3102018)",
            "FLUKE ESA620 ELECTRICAL SAFETY ANALYSER (SN 2629025)",
            "FLUKE ESA620 ELECTRICAL SAFETY ANALYSER (SN 3357047)",
            "DALE 3000 ELECTROSURGICAL ANALYSER (SN 0485)",
            "NETECH DELTA 3000 DEFIBRILLATOR/PACER ANALYSER (SN 22811)",
            "PRONK TECHNOLOGIES SIMCUBE SC-5 (SN5813)",
            "HUATO HE704 THERMOMETER (SN HE20103717)",
            "OXITEST PLUS 7 PULSE OXIMETER TESTER (SN D0S04090718)",
            "TSI 4000 SERIES SPIROMETER (SN 40401327005)",
            "NETECH UNIMANO PRESSURE/VACCUM METER (SN 15377)",
            "FLUKE VT305 GAS FLOW ANALYSER (SN BF102055)",
            "OHAUS SCOUT PRO SCALES (SN 7132081821)",
            "INFUTESTER SOLO INFUSION ANALYSER (SN 1504120001)",
            "FLUKE VT02 VISUAL IR THERMOMETER (SN VT02-13064149)",
            "FLUKE 117 (SN 23092259)",
            "BIO-TEK ULTRASOUND WATTMETER UW-11 (SN 0309)",
            "COOL TECH CT-960 RCD TESTER (SN 10019363)",
            "RIKEN F1-21 GAS DETECTOR TYPE O5 (SN 499030026)",
            "NETECH DELTA 3000 DEFIBRILLATOR/PACER ANALYSER (SN 19478)"});
            this.listBox1.Location = new System.Drawing.Point(0, 129);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(1038, 410);
            this.listBox1.TabIndex = 119;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(-5, 105);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(129, 20);
            this.metroLabel2.TabIndex = 104;
            this.metroLabel2.Text = "Test Equipments:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // submitBtn
            // 
            this.submitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitBtn.Location = new System.Drawing.Point(902, 644);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(161, 50);
            this.submitBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.submitBtn.TabIndex = 103;
            this.submitBtn.Text = "Submit";
            this.submitBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.submitBtn.UseSelectable = true;
            this.submitBtn.UseStyleColors = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // close3_btn
            // 
            this.close3_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.close3_btn.Location = new System.Drawing.Point(4, 644);
            this.close3_btn.Margin = new System.Windows.Forms.Padding(4);
            this.close3_btn.Name = "close3_btn";
            this.close3_btn.Size = new System.Drawing.Size(161, 50);
            this.close3_btn.Style = MetroFramework.MetroColorStyle.Blue;
            this.close3_btn.TabIndex = 102;
            this.close3_btn.Text = "Cancel";
            this.close3_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.close3_btn.UseSelectable = true;
            this.close3_btn.UseStyleColors = true;
            this.close3_btn.Click += new System.EventHandler(this.close3_btn_Click);
            // 
            // commentBox
            // 
            // 
            // 
            // 
            this.commentBox.CustomButton.Image = null;
            this.commentBox.CustomButton.Location = new System.Drawing.Point(584, 2);
            this.commentBox.CustomButton.Margin = new System.Windows.Forms.Padding(5);
            this.commentBox.CustomButton.Name = "";
            this.commentBox.CustomButton.Size = new System.Drawing.Size(57, 57);
            this.commentBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.commentBox.CustomButton.TabIndex = 1;
            this.commentBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.commentBox.CustomButton.UseSelectable = true;
            this.commentBox.CustomButton.Visible = false;
            this.commentBox.Lines = new string[0];
            this.commentBox.Location = new System.Drawing.Point(0, 39);
            this.commentBox.Margin = new System.Windows.Forms.Padding(4);
            this.commentBox.MaxLength = 32767;
            this.commentBox.Multiline = true;
            this.commentBox.Name = "commentBox";
            this.commentBox.PasswordChar = '\0';
            this.commentBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.commentBox.SelectedText = "";
            this.commentBox.SelectionLength = 0;
            this.commentBox.SelectionStart = 0;
            this.commentBox.ShortcutsEnabled = true;
            this.commentBox.Size = new System.Drawing.Size(644, 62);
            this.commentBox.TabIndex = 40;
            this.commentBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.commentBox.UseSelectable = true;
            this.commentBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.commentBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(-5, 11);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(159, 20);
            this.metroLabel3.TabIndex = 39;
            this.metroLabel3.Text = "Parts and Comments:";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // BloodGlucose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 820);
            this.Controls.Add(this.safetyCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BloodGlucose";
            this.Resizable = false;
            this.Text = "Technical Safety Check - Blood Glucose";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.BloodGlucose_SizeChanged);
            this.safetyCheck.ResumeLayout(false);
            this.performanceVerification.ResumeLayout(false);
            this.performanceVerification.PerformLayout();
            this.commentsTab.ResumeLayout(false);
            this.commentsTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MetroFramework.Controls.MetroTabControl safetyCheck;
        private MetroFramework.Controls.MetroTabPage performanceVerification;
        private MetroFramework.Controls.MetroButton nextBtn;
        private MetroFramework.Controls.MetroButton close1_btn;
        private MetroFramework.Controls.MetroComboBox result_3;
        private MetroFramework.Controls.MetroComboBox result_2;
        private MetroFramework.Controls.MetroComboBox result_1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel visual1;
        private MetroFramework.Controls.MetroTabPage commentsTab;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton submitBtn;
        private MetroFramework.Controls.MetroButton close3_btn;
        private MetroFramework.Controls.MetroTextBox commentBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}