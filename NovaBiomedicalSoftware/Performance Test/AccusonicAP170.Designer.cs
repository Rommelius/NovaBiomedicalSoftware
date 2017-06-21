namespace NovaBiomedicalSoftware.Performance_Test
{
    partial class AccusonicAP170
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccusonicAP170));
            this.safetyCheck = new MetroFramework.Controls.MetroTabControl();
            this.performanceVerification = new MetroFramework.Controls.MetroTabPage();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.nextBtn = new MetroFramework.Controls.MetroButton();
            this.close1_btn = new MetroFramework.Controls.MetroButton();
            this.result_5 = new MetroFramework.Controls.MetroComboBox();
            this.result_4 = new MetroFramework.Controls.MetroComboBox();
            this.result_3 = new MetroFramework.Controls.MetroComboBox();
            this.result_2 = new MetroFramework.Controls.MetroComboBox();
            this.result_1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
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
            this.msmain = new MetroFramework.Components.MetroStyleManager(this.components);
            this.overall = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.safetyCheck.SuspendLayout();
            this.performanceVerification.SuspendLayout();
            this.commentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msmain)).BeginInit();
            this.SuspendLayout();
            // 
            // safetyCheck
            // 
            this.safetyCheck.Controls.Add(this.performanceVerification);
            this.safetyCheck.Controls.Add(this.commentsTab);
            this.safetyCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.safetyCheck.Location = new System.Drawing.Point(20, 60);
            this.safetyCheck.Name = "safetyCheck";
            this.safetyCheck.SelectedIndex = 0;
            this.safetyCheck.Size = new System.Drawing.Size(796, 586);
            this.safetyCheck.TabIndex = 5;
            this.safetyCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.safetyCheck.UseSelectable = true;
            // 
            // performanceVerification
            // 
            this.performanceVerification.AutoScroll = true;
            this.performanceVerification.Controls.Add(this.overall);
            this.performanceVerification.Controls.Add(this.metroLabel1);
            this.performanceVerification.Controls.Add(this.metroButton1);
            this.performanceVerification.Controls.Add(this.nextBtn);
            this.performanceVerification.Controls.Add(this.close1_btn);
            this.performanceVerification.Controls.Add(this.result_5);
            this.performanceVerification.Controls.Add(this.result_4);
            this.performanceVerification.Controls.Add(this.result_3);
            this.performanceVerification.Controls.Add(this.result_2);
            this.performanceVerification.Controls.Add(this.result_1);
            this.performanceVerification.Controls.Add(this.metroLabel7);
            this.performanceVerification.Controls.Add(this.metroLabel4);
            this.performanceVerification.Controls.Add(this.metroLabel6);
            this.performanceVerification.Controls.Add(this.metroLabel5);
            this.performanceVerification.Controls.Add(this.visual1);
            this.performanceVerification.HorizontalScrollbar = true;
            this.performanceVerification.HorizontalScrollbarBarColor = true;
            this.performanceVerification.HorizontalScrollbarHighlightOnWheel = false;
            this.performanceVerification.HorizontalScrollbarSize = 10;
            this.performanceVerification.Location = new System.Drawing.Point(4, 38);
            this.performanceVerification.Name = "performanceVerification";
            this.performanceVerification.Size = new System.Drawing.Size(788, 544);
            this.performanceVerification.TabIndex = 0;
            this.performanceVerification.Text = "Performance Verification";
            this.performanceVerification.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.performanceVerification.VerticalScrollbar = true;
            this.performanceVerification.VerticalScrollbarBarColor = true;
            this.performanceVerification.VerticalScrollbarHighlightOnWheel = false;
            this.performanceVerification.VerticalScrollbarSize = 10;
            // 
            // metroButton1
            // 
            this.metroButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroButton1.Location = new System.Drawing.Point(0, 0);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(788, 23);
            this.metroButton1.TabIndex = 38;
            this.metroButton1.Text = "Pass All";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextBtn.Location = new System.Drawing.Point(664, 500);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(121, 41);
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
            this.close1_btn.Location = new System.Drawing.Point(3, 501);
            this.close1_btn.Name = "close1_btn";
            this.close1_btn.Size = new System.Drawing.Size(121, 41);
            this.close1_btn.Style = MetroFramework.MetroColorStyle.Blue;
            this.close1_btn.TabIndex = 37;
            this.close1_btn.Text = "Cancel";
            this.close1_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.close1_btn.UseSelectable = true;
            this.close1_btn.UseStyleColors = true;
            this.close1_btn.Click += new System.EventHandler(this.close1_btn_Click);
            // 
            // result_5
            // 
            this.result_5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.result_5.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.result_5.FormattingEnabled = true;
            this.result_5.ItemHeight = 19;
            this.result_5.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.result_5.Location = new System.Drawing.Point(664, 158);
            this.result_5.Name = "result_5";
            this.result_5.Size = new System.Drawing.Size(121, 25);
            this.result_5.TabIndex = 11;
            this.result_5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.result_5.UseSelectable = true;
            // 
            // result_4
            // 
            this.result_4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.result_4.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.result_4.FormattingEnabled = true;
            this.result_4.ItemHeight = 19;
            this.result_4.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.result_4.Location = new System.Drawing.Point(664, 127);
            this.result_4.Name = "result_4";
            this.result_4.Size = new System.Drawing.Size(121, 25);
            this.result_4.TabIndex = 11;
            this.result_4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.result_4.UseSelectable = true;
            // 
            // result_3
            // 
            this.result_3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.result_3.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.result_3.FormattingEnabled = true;
            this.result_3.ItemHeight = 19;
            this.result_3.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.result_3.Location = new System.Drawing.Point(664, 96);
            this.result_3.Name = "result_3";
            this.result_3.Size = new System.Drawing.Size(121, 25);
            this.result_3.TabIndex = 11;
            this.result_3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.result_3.UseSelectable = true;
            // 
            // result_2
            // 
            this.result_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.result_2.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.result_2.FormattingEnabled = true;
            this.result_2.ItemHeight = 19;
            this.result_2.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.result_2.Location = new System.Drawing.Point(664, 66);
            this.result_2.Name = "result_2";
            this.result_2.Size = new System.Drawing.Size(121, 25);
            this.result_2.TabIndex = 11;
            this.result_2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.result_2.UseSelectable = true;
            // 
            // result_1
            // 
            this.result_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.result_1.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.result_1.FormattingEnabled = true;
            this.result_1.ItemHeight = 19;
            this.result_1.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.result_1.Location = new System.Drawing.Point(664, 35);
            this.result_1.Name = "result_1";
            this.result_1.Size = new System.Drawing.Size(121, 25);
            this.result_1.TabIndex = 11;
            this.result_1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.result_1.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(0, 164);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(49, 19);
            this.metroLabel7.TabIndex = 3;
            this.metroLabel7.Text = "Timing";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(0, 133);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(99, 19);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "Continuous/INT";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(0, 102);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(75, 19);
            this.metroLabel6.TabIndex = 3;
            this.metroLabel6.Text = "Output 1+2";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(0, 72);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(104, 19);
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "Functional check";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // visual1
            // 
            this.visual1.AutoSize = true;
            this.visual1.Location = new System.Drawing.Point(2, 41);
            this.visual1.Name = "visual1";
            this.visual1.Size = new System.Drawing.Size(104, 19);
            this.visual1.TabIndex = 3;
            this.visual1.Text = "Visual inspection";
            this.visual1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // commentsTab
            // 
            this.commentsTab.AutoScroll = true;
            this.commentsTab.Controls.Add(this.listBox1);
            this.commentsTab.Controls.Add(this.metroLabel2);
            this.commentsTab.Controls.Add(this.submitBtn);
            this.commentsTab.Controls.Add(this.close3_btn);
            this.commentsTab.Controls.Add(this.commentBox);
            this.commentsTab.Controls.Add(this.metroLabel3);
            this.commentsTab.HorizontalScrollbar = true;
            this.commentsTab.HorizontalScrollbarBarColor = true;
            this.commentsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.commentsTab.HorizontalScrollbarSize = 10;
            this.commentsTab.Location = new System.Drawing.Point(4, 38);
            this.commentsTab.Name = "commentsTab";
            this.commentsTab.Size = new System.Drawing.Size(788, 544);
            this.commentsTab.TabIndex = 2;
            this.commentsTab.Text = "Comments";
            this.commentsTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.commentsTab.VerticalScrollbar = true;
            this.commentsTab.VerticalScrollbarBarColor = true;
            this.commentsTab.VerticalScrollbarHighlightOnWheel = false;
            this.commentsTab.VerticalScrollbarSize = 10;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
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
            this.listBox1.Location = new System.Drawing.Point(0, 107);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(779, 344);
            this.listBox1.TabIndex = 112;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(-4, 85);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(120, 19);
            this.metroLabel2.TabIndex = 104;
            this.metroLabel2.Text = "Test Equipments:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // submitBtn
            // 
            this.submitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitBtn.Location = new System.Drawing.Point(661, 500);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(121, 41);
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
            this.close3_btn.Location = new System.Drawing.Point(3, 500);
            this.close3_btn.Name = "close3_btn";
            this.close3_btn.Size = new System.Drawing.Size(121, 41);
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
            this.commentBox.CustomButton.Location = new System.Drawing.Point(717, 2);
            this.commentBox.CustomButton.Name = "";
            this.commentBox.CustomButton.Size = new System.Drawing.Size(45, 45);
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
            this.commentBox.Size = new System.Drawing.Size(765, 50);
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
            this.metroLabel3.Location = new System.Drawing.Point(-4, 9);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(151, 19);
            this.metroLabel3.TabIndex = 39;
            this.metroLabel3.Text = "Parts and Comments:";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // msmain
            // 
            this.msmain.Owner = this;
            this.msmain.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // overall
            // 
            this.overall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.overall.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.overall.FormattingEnabled = true;
            this.overall.ItemHeight = 19;
            this.overall.Items.AddRange(new object[] {
            "Pass",
            "Fail",
            "N/A"});
            this.overall.Location = new System.Drawing.Point(664, 189);
            this.overall.Name = "overall";
            this.overall.Size = new System.Drawing.Size(121, 25);
            this.overall.TabIndex = 40;
            this.overall.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.overall.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(0, 195);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(89, 19);
            this.metroLabel1.TabIndex = 39;
            this.metroLabel1.Text = "Overall Result";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // AccusonicAP170
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 666);
            this.Controls.Add(this.safetyCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccusonicAP170";
            this.Text = "Technical Safety Check - Accusonic AP170";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.AccusonicAP170_SizeChanged);
            this.safetyCheck.ResumeLayout(false);
            this.performanceVerification.ResumeLayout(false);
            this.performanceVerification.PerformLayout();
            this.commentsTab.ResumeLayout(false);
            this.commentsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msmain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public MetroFramework.Controls.MetroTabControl safetyCheck;
        private MetroFramework.Controls.MetroTabPage performanceVerification;
        private MetroFramework.Controls.MetroButton nextBtn;
        private MetroFramework.Controls.MetroButton close1_btn;
        private MetroFramework.Controls.MetroComboBox result_5;
        private MetroFramework.Controls.MetroComboBox result_4;
        private MetroFramework.Controls.MetroComboBox result_3;
        private MetroFramework.Controls.MetroComboBox result_2;
        private MetroFramework.Controls.MetroComboBox result_1;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel visual1;
        private MetroFramework.Controls.MetroTabPage commentsTab;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton submitBtn;
        private MetroFramework.Controls.MetroButton close3_btn;
        private MetroFramework.Controls.MetroTextBox commentBox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Components.MetroStyleManager msmain;
        private System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroComboBox overall;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}