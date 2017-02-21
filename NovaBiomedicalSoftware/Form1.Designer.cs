namespace NovaBiomedicalSoftware
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.firstPrompt = new MetroFramework.Controls.MetroPanel();
            this.userName = new MetroFramework.Controls.MetroComboBox();
            this.location = new MetroFramework.Controls.MetroTextBox();
            this.model = new MetroFramework.Controls.MetroTextBox();
            this.serialNumber = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.assetNumber = new MetroFramework.Controls.MetroTextBox();
            this.submitBtn = new MetroFramework.Controls.MetroButton();
            this.clearBtn_1 = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ptTab = new MetroFramework.Controls.MetroTabPage();
            this.ptEModules = new MetroFramework.Controls.MetroTile();
            this.ptMX450 = new MetroFramework.Controls.MetroTile();
            this.ptX2 = new MetroFramework.Controls.MetroTile();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.ptNIBP = new MetroFramework.Controls.MetroTile();
            this.ptECG = new MetroFramework.Controls.MetroTile();
            this.estTab = new MetroFramework.Controls.MetroTabPage();
            this.debug_box = new System.Windows.Forms.RichTextBox();
            this.ecgClass2 = new MetroFramework.Controls.MetroTile();
            this.ecgClass1 = new MetroFramework.Controls.MetroTile();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.class2testBtn = new MetroFramework.Controls.MetroTile();
            this.class1testBtn = new MetroFramework.Controls.MetroTile();
            this.tabMenu = new MetroFramework.Controls.MetroTabControl();
            this.newproductBtn = new MetroFramework.Controls.MetroTile();
            this.statusText = new MetroFramework.Controls.MetroLabel();
            this.statusBar = new MetroFramework.Controls.MetroProgressBar();
            this.firstPrompt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ptTab.SuspendLayout();
            this.estTab.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstPrompt
            // 
            this.firstPrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstPrompt.Controls.Add(this.userName);
            this.firstPrompt.Controls.Add(this.location);
            this.firstPrompt.Controls.Add(this.model);
            this.firstPrompt.Controls.Add(this.serialNumber);
            this.firstPrompt.Controls.Add(this.metroLabel6);
            this.firstPrompt.Controls.Add(this.metroLabel5);
            this.firstPrompt.Controls.Add(this.metroLabel4);
            this.firstPrompt.Controls.Add(this.metroLabel3);
            this.firstPrompt.Controls.Add(this.metroLabel2);
            this.firstPrompt.Controls.Add(this.metroLabel1);
            this.firstPrompt.Controls.Add(this.assetNumber);
            this.firstPrompt.Controls.Add(this.submitBtn);
            this.firstPrompt.Controls.Add(this.clearBtn_1);
            this.firstPrompt.HorizontalScrollbarBarColor = true;
            this.firstPrompt.HorizontalScrollbarHighlightOnWheel = false;
            this.firstPrompt.HorizontalScrollbarSize = 15;
            this.firstPrompt.Location = new System.Drawing.Point(1102, 68);
            this.firstPrompt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.firstPrompt.Name = "firstPrompt";
            this.firstPrompt.Size = new System.Drawing.Size(1020, 622);
            this.firstPrompt.Style = MetroFramework.MetroColorStyle.Blue;
            this.firstPrompt.TabIndex = 1;
            this.firstPrompt.Theme = MetroFramework.MetroThemeStyle.Light;
            this.firstPrompt.VerticalScrollbarBarColor = true;
            this.firstPrompt.VerticalScrollbarHighlightOnWheel = false;
            this.firstPrompt.VerticalScrollbarSize = 15;
            // 
            // userName
            // 
            this.userName.FormattingEnabled = true;
            this.userName.ItemHeight = 23;
            this.userName.Items.AddRange(new object[] {
            "Sean Welch",
            "Joe Welch",
            "Ken Welch",
            "Luke Brogan",
            "Rommel Lapuz",
            "Khoi Duong",
            "Scott Monk"});
            this.userName.Location = new System.Drawing.Point(442, 146);
            this.userName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(295, 29);
            this.userName.Style = MetroFramework.MetroColorStyle.Blue;
            this.userName.TabIndex = 14;
            this.userName.Theme = MetroFramework.MetroThemeStyle.Light;
            this.userName.UseSelectable = true;
            // 
            // location
            // 
            // 
            // 
            // 
            this.location.CustomButton.Image = null;
            this.location.CustomButton.Location = new System.Drawing.Point(380, 3);
            this.location.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.location.CustomButton.Name = "";
            this.location.CustomButton.Size = new System.Drawing.Size(62, 63);
            this.location.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.location.CustomButton.TabIndex = 1;
            this.location.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.location.CustomButton.UseSelectable = true;
            this.location.CustomButton.Visible = false;
            this.location.Lines = new string[0];
            this.location.Location = new System.Drawing.Point(442, 368);
            this.location.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.location.MaxLength = 32767;
            this.location.Name = "location";
            this.location.PasswordChar = '\0';
            this.location.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.location.SelectedText = "";
            this.location.SelectionLength = 0;
            this.location.SelectionStart = 0;
            this.location.ShortcutsEnabled = true;
            this.location.Size = new System.Drawing.Size(297, 46);
            this.location.TabIndex = 13;
            this.location.Theme = MetroFramework.MetroThemeStyle.Light;
            this.location.UseSelectable = true;
            this.location.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.location.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // model
            // 
            // 
            // 
            // 
            this.model.CustomButton.Image = null;
            this.model.CustomButton.Location = new System.Drawing.Point(380, 3);
            this.model.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.model.CustomButton.Name = "";
            this.model.CustomButton.Size = new System.Drawing.Size(62, 63);
            this.model.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.model.CustomButton.TabIndex = 1;
            this.model.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.model.CustomButton.UseSelectable = true;
            this.model.CustomButton.Visible = false;
            this.model.Lines = new string[0];
            this.model.Location = new System.Drawing.Point(442, 312);
            this.model.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.model.MaxLength = 32767;
            this.model.Name = "model";
            this.model.PasswordChar = '\0';
            this.model.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.model.SelectedText = "";
            this.model.SelectionLength = 0;
            this.model.SelectionStart = 0;
            this.model.ShortcutsEnabled = true;
            this.model.Size = new System.Drawing.Size(297, 46);
            this.model.TabIndex = 12;
            this.model.Theme = MetroFramework.MetroThemeStyle.Light;
            this.model.UseSelectable = true;
            this.model.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.model.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.model.KeyDown += new System.Windows.Forms.KeyEventHandler(this.model_KeyDown);
            // 
            // serialNumber
            // 
            // 
            // 
            // 
            this.serialNumber.CustomButton.Image = null;
            this.serialNumber.CustomButton.Location = new System.Drawing.Point(380, 3);
            this.serialNumber.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serialNumber.CustomButton.Name = "";
            this.serialNumber.CustomButton.Size = new System.Drawing.Size(62, 63);
            this.serialNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.serialNumber.CustomButton.TabIndex = 1;
            this.serialNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.serialNumber.CustomButton.UseSelectable = true;
            this.serialNumber.CustomButton.Visible = false;
            this.serialNumber.Lines = new string[0];
            this.serialNumber.Location = new System.Drawing.Point(442, 257);
            this.serialNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.serialNumber.MaxLength = 32767;
            this.serialNumber.Name = "serialNumber";
            this.serialNumber.PasswordChar = '\0';
            this.serialNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.serialNumber.SelectedText = "";
            this.serialNumber.SelectionLength = 0;
            this.serialNumber.SelectionStart = 0;
            this.serialNumber.ShortcutsEnabled = true;
            this.serialNumber.Size = new System.Drawing.Size(297, 46);
            this.serialNumber.TabIndex = 11;
            this.serialNumber.Theme = MetroFramework.MetroThemeStyle.Light;
            this.serialNumber.UseSelectable = true;
            this.serialNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.serialNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.serialNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serialNumber_KeyDown);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(216, 371);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(64, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel6.TabIndex = 10;
            this.metroLabel6.Text = "Location:";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(216, 315);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(51, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel5.TabIndex = 9;
            this.metroLabel5.Text = "Model:";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(216, 260);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(98, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Serial Number:";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(214, 205);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(99, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Asset Number:";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(216, 149);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(48, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Name:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(366, 42);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(184, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Please Fill in Details:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // assetNumber
            // 
            // 
            // 
            // 
            this.assetNumber.CustomButton.Image = null;
            this.assetNumber.CustomButton.Location = new System.Drawing.Point(380, 3);
            this.assetNumber.CustomButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.assetNumber.CustomButton.Name = "";
            this.assetNumber.CustomButton.Size = new System.Drawing.Size(62, 63);
            this.assetNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.assetNumber.CustomButton.TabIndex = 1;
            this.assetNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.assetNumber.CustomButton.UseSelectable = true;
            this.assetNumber.CustomButton.Visible = false;
            this.assetNumber.Lines = new string[0];
            this.assetNumber.Location = new System.Drawing.Point(442, 202);
            this.assetNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.assetNumber.MaxLength = 32767;
            this.assetNumber.Name = "assetNumber";
            this.assetNumber.PasswordChar = '\0';
            this.assetNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.assetNumber.SelectedText = "";
            this.assetNumber.SelectionLength = 0;
            this.assetNumber.SelectionStart = 0;
            this.assetNumber.ShortcutsEnabled = true;
            this.assetNumber.Size = new System.Drawing.Size(297, 46);
            this.assetNumber.TabIndex = 4;
            this.assetNumber.Theme = MetroFramework.MetroThemeStyle.Light;
            this.assetNumber.UseSelectable = true;
            this.assetNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.assetNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.assetNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.assetNumber_KeyDown);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(618, 508);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(212, 68);
            this.submitBtn.TabIndex = 3;
            this.submitBtn.Text = "Submit";
            this.submitBtn.Theme = MetroFramework.MetroThemeStyle.Light;
            this.submitBtn.UseSelectable = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // clearBtn_1
            // 
            this.clearBtn_1.Location = new System.Drawing.Point(212, 508);
            this.clearBtn_1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearBtn_1.Name = "clearBtn_1";
            this.clearBtn_1.Size = new System.Drawing.Size(212, 68);
            this.clearBtn_1.TabIndex = 2;
            this.clearBtn_1.Text = "Clear";
            this.clearBtn_1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.clearBtn_1.UseSelectable = true;
            this.clearBtn_1.Click += new System.EventHandler(this.clearBtn_1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::NovaBiomedicalSoftware.Properties.Resources.logo1;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(34, 38);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(368, 126);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ptTab
            // 
            this.ptTab.AutoScroll = true;
            this.ptTab.BackColor = System.Drawing.Color.Transparent;
            this.ptTab.BackgroundImage = global::NovaBiomedicalSoftware.Properties.Resources.background;
            this.ptTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptTab.Controls.Add(this.ptEModules);
            this.ptTab.Controls.Add(this.ptMX450);
            this.ptTab.Controls.Add(this.ptX2);
            this.ptTab.Controls.Add(this.metroLabel9);
            this.ptTab.Controls.Add(this.ptNIBP);
            this.ptTab.Controls.Add(this.ptECG);
            this.ptTab.HorizontalScrollbar = true;
            this.ptTab.HorizontalScrollbarBarColor = true;
            this.ptTab.HorizontalScrollbarHighlightOnWheel = false;
            this.ptTab.HorizontalScrollbarSize = 15;
            this.ptTab.Location = new System.Drawing.Point(4, 38);
            this.ptTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptTab.Name = "ptTab";
            this.ptTab.Size = new System.Drawing.Size(1572, 850);
            this.ptTab.TabIndex = 1;
            this.ptTab.Text = "Performance Test";
            this.ptTab.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ptTab.VerticalScrollbar = true;
            this.ptTab.VerticalScrollbarBarColor = true;
            this.ptTab.VerticalScrollbarHighlightOnWheel = false;
            this.ptTab.VerticalScrollbarSize = 15;
            // 
            // ptEModules
            // 
            this.ptEModules.ActiveControl = null;
            this.ptEModules.Enabled = false;
            this.ptEModules.Location = new System.Drawing.Point(1209, 69);
            this.ptEModules.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptEModules.Name = "ptEModules";
            this.ptEModules.Size = new System.Drawing.Size(285, 223);
            this.ptEModules.Style = MetroFramework.MetroColorStyle.Teal;
            this.ptEModules.TabIndex = 8;
            this.ptEModules.Text = "Extension Modules";
            this.ptEModules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptEModules.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ptEModules.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ptEModules.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.ptEModules.UseSelectable = true;
            // 
            // ptMX450
            // 
            this.ptMX450.ActiveControl = null;
            this.ptMX450.Enabled = false;
            this.ptMX450.Location = new System.Drawing.Point(915, 69);
            this.ptMX450.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptMX450.Name = "ptMX450";
            this.ptMX450.Size = new System.Drawing.Size(285, 223);
            this.ptMX450.Style = MetroFramework.MetroColorStyle.Teal;
            this.ptMX450.TabIndex = 7;
            this.ptMX450.Text = "MX450";
            this.ptMX450.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptMX450.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ptMX450.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ptMX450.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.ptMX450.UseSelectable = true;
            this.ptMX450.UseStyleColors = true;
            // 
            // ptX2
            // 
            this.ptX2.ActiveControl = null;
            this.ptX2.Enabled = false;
            this.ptX2.Location = new System.Drawing.Point(620, 69);
            this.ptX2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptX2.Name = "ptX2";
            this.ptX2.Size = new System.Drawing.Size(285, 223);
            this.ptX2.Style = MetroFramework.MetroColorStyle.Teal;
            this.ptX2.TabIndex = 6;
            this.ptX2.Text = "Intellivue X2";
            this.ptX2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptX2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ptX2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ptX2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.ptX2.UseSelectable = true;
            this.ptX2.UseStyleColors = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel9.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel9.Location = new System.Drawing.Point(30, 26);
            this.metroLabel9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(164, 25);
            this.metroLabel9.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel9.TabIndex = 5;
            this.metroLabel9.Text = "Performance Test:";
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel9.UseCustomBackColor = true;
            // 
            // ptNIBP
            // 
            this.ptNIBP.ActiveControl = null;
            this.ptNIBP.Location = new System.Drawing.Point(324, 69);
            this.ptNIBP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptNIBP.Name = "ptNIBP";
            this.ptNIBP.Size = new System.Drawing.Size(285, 223);
            this.ptNIBP.Style = MetroFramework.MetroColorStyle.Teal;
            this.ptNIBP.TabIndex = 3;
            this.ptNIBP.Text = "NIBP Monitors";
            this.ptNIBP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptNIBP.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ptNIBP.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ptNIBP.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.ptNIBP.UseSelectable = true;
            this.ptNIBP.UseStyleColors = true;
            // 
            // ptECG
            // 
            this.ptECG.ActiveControl = null;
            this.ptECG.Location = new System.Drawing.Point(30, 69);
            this.ptECG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ptECG.Name = "ptECG";
            this.ptECG.Size = new System.Drawing.Size(285, 223);
            this.ptECG.Style = MetroFramework.MetroColorStyle.Teal;
            this.ptECG.TabIndex = 2;
            this.ptECG.Text = "ECG Machine";
            this.ptECG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ptECG.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ptECG.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ptECG.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.ptECG.UseSelectable = true;
            this.ptECG.UseStyleColors = true;
            // 
            // estTab
            // 
            this.estTab.BackColor = System.Drawing.Color.Transparent;
            this.estTab.BackgroundImage = global::NovaBiomedicalSoftware.Properties.Resources.background;
            this.estTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.estTab.Controls.Add(this.debug_box);
            this.estTab.Controls.Add(this.ecgClass2);
            this.estTab.Controls.Add(this.ecgClass1);
            this.estTab.Controls.Add(this.metroLabel8);
            this.estTab.Controls.Add(this.metroLabel7);
            this.estTab.Controls.Add(this.class2testBtn);
            this.estTab.Controls.Add(this.class1testBtn);
            this.estTab.HorizontalScrollbarBarColor = true;
            this.estTab.HorizontalScrollbarHighlightOnWheel = false;
            this.estTab.HorizontalScrollbarSize = 15;
            this.estTab.Location = new System.Drawing.Point(4, 38);
            this.estTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.estTab.Name = "estTab";
            this.estTab.Size = new System.Drawing.Size(1572, 850);
            this.estTab.TabIndex = 0;
            this.estTab.Text = "Electrical Safety Test";
            this.estTab.Theme = MetroFramework.MetroThemeStyle.Light;
            this.estTab.UseCustomBackColor = true;
            this.estTab.VerticalScrollbarBarColor = true;
            this.estTab.VerticalScrollbarHighlightOnWheel = false;
            this.estTab.VerticalScrollbarSize = 15;
            // 
            // debug_box
            // 
            this.debug_box.Location = new System.Drawing.Point(1335, 95);
            this.debug_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.debug_box.Name = "debug_box";
            this.debug_box.Size = new System.Drawing.Size(192, 359);
            this.debug_box.TabIndex = 8;
            this.debug_box.Text = "";
            // 
            // ecgClass2
            // 
            this.ecgClass2.ActiveControl = null;
            this.ecgClass2.Location = new System.Drawing.Point(429, 412);
            this.ecgClass2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ecgClass2.Name = "ecgClass2";
            this.ecgClass2.Size = new System.Drawing.Size(392, 212);
            this.ecgClass2.Style = MetroFramework.MetroColorStyle.Green;
            this.ecgClass2.TabIndex = 7;
            this.ecgClass2.Text = "ECG - 3551 Class 2";
            this.ecgClass2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ecgClass2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ecgClass2.TileImage = global::NovaBiomedicalSoftware.Properties.Resources.icon;
            this.ecgClass2.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ecgClass2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ecgClass2.UseSelectable = true;
            this.ecgClass2.UseTileImage = true;
            // 
            // ecgClass1
            // 
            this.ecgClass1.ActiveControl = null;
            this.ecgClass1.Location = new System.Drawing.Point(27, 412);
            this.ecgClass1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ecgClass1.Name = "ecgClass1";
            this.ecgClass1.Size = new System.Drawing.Size(392, 212);
            this.ecgClass1.Style = MetroFramework.MetroColorStyle.Green;
            this.ecgClass1.TabIndex = 6;
            this.ecgClass1.Text = "ECG - 3551 Class 1";
            this.ecgClass1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ecgClass1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ecgClass1.TileImage = global::NovaBiomedicalSoftware.Properties.Resources.icon;
            this.ecgClass1.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ecgClass1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ecgClass1.UseSelectable = true;
            this.ecgClass1.UseTileImage = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel8.Location = new System.Drawing.Point(27, 368);
            this.metroLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(89, 25);
            this.metroLabel8.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel8.TabIndex = 5;
            this.metroLabel8.Text = "ECG Test:";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel8.UseCustomBackColor = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel7.Location = new System.Drawing.Point(27, 54);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(133, 25);
            this.metroLabel7.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel7.TabIndex = 4;
            this.metroLabel7.Text = "Standard Test:";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // class2testBtn
            // 
            this.class2testBtn.ActiveControl = null;
            this.class2testBtn.Location = new System.Drawing.Point(428, 97);
            this.class2testBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.class2testBtn.Name = "class2testBtn";
            this.class2testBtn.Size = new System.Drawing.Size(392, 212);
            this.class2testBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.class2testBtn.TabIndex = 3;
            this.class2testBtn.Text = "ASNZ Standard 3551 - Class 2";
            this.class2testBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.class2testBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.class2testBtn.TileImage = global::NovaBiomedicalSoftware.Properties.Resources.power_cord2;
            this.class2testBtn.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.class2testBtn.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.class2testBtn.UseSelectable = true;
            this.class2testBtn.UseStyleColors = true;
            this.class2testBtn.UseTileImage = true;
            // 
            // class1testBtn
            // 
            this.class1testBtn.ActiveControl = null;
            this.class1testBtn.Location = new System.Drawing.Point(27, 97);
            this.class1testBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.class1testBtn.Name = "class1testBtn";
            this.class1testBtn.Size = new System.Drawing.Size(392, 212);
            this.class1testBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.class1testBtn.TabIndex = 1;
            this.class1testBtn.Text = "ASNZ Standard 3551 - Class 1";
            this.class1testBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.class1testBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.class1testBtn.TileImage = global::NovaBiomedicalSoftware.Properties.Resources.power_cord2;
            this.class1testBtn.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.class1testBtn.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.class1testBtn.UseSelectable = true;
            this.class1testBtn.UseStyleColors = true;
            this.class1testBtn.UseTileImage = true;
            this.class1testBtn.Click += new System.EventHandler(this.class1testBtn_Click);
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.estTab);
            this.tabMenu.Controls.Add(this.ptTab);
            this.tabMenu.Location = new System.Drawing.Point(36, 174);
            this.tabMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(1580, 892);
            this.tabMenu.Style = MetroFramework.MetroColorStyle.Blue;
            this.tabMenu.TabIndex = 2;
            this.tabMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabMenu.UseSelectable = true;
            // 
            // newproductBtn
            // 
            this.newproductBtn.ActiveControl = null;
            this.newproductBtn.Location = new System.Drawing.Point(1430, 38);
            this.newproductBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newproductBtn.Name = "newproductBtn";
            this.newproductBtn.Size = new System.Drawing.Size(180, 185);
            this.newproductBtn.Style = MetroFramework.MetroColorStyle.Teal;
            this.newproductBtn.TabIndex = 4;
            this.newproductBtn.Text = "Next Equipment";
            this.newproductBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.newproductBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.newproductBtn.TileImage = global::NovaBiomedicalSoftware.Properties.Resources.add1;
            this.newproductBtn.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newproductBtn.UseSelectable = true;
            this.newproductBtn.UseStyleColors = true;
            this.newproductBtn.UseTileImage = true;
            this.newproductBtn.Click += new System.EventHandler(this.newproductBtn_Click);
            // 
            // statusText
            // 
            this.statusText.AccessibleName = "";
            this.statusText.AutoSize = true;
            this.statusText.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.statusText.Location = new System.Drawing.Point(996, 68);
            this.statusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(115, 25);
            this.statusText.Style = MetroFramework.MetroColorStyle.Blue;
            this.statusText.TabIndex = 7;
            this.statusText.Text = "Connecting....";
            this.statusText.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(996, 115);
            this.statusBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(424, 35);
            this.statusBar.Step = 30;
            this.statusBar.Style = MetroFramework.MetroColorStyle.Blue;
            this.statusBar.TabIndex = 5;
            this.statusBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Form1
            // 
            this.ApplyImageInvert = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.BackImagePadding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.BackLocation = MetroFramework.Forms.BackLocation.TopRight;
            this.ClientSize = new System.Drawing.Size(1650, 1092);
            this.Controls.Add(this.firstPrompt);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.newproductBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(30, 92, 30, 31);
            this.Resizable = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.firstPrompt.ResumeLayout(false);
            this.firstPrompt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ptTab.ResumeLayout(false);
            this.ptTab.PerformLayout();
            this.estTab.ResumeLayout(false);
            this.estTab.PerformLayout();
            this.tabMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroPanel firstPrompt;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox assetNumber;
        private MetroFramework.Controls.MetroButton submitBtn;
        private MetroFramework.Controls.MetroButton clearBtn_1;
        private MetroFramework.Controls.MetroComboBox userName;
        private MetroFramework.Controls.MetroTextBox location;
        private MetroFramework.Controls.MetroTextBox model;
        private MetroFramework.Controls.MetroTextBox serialNumber;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTabPage ptTab;
        private MetroFramework.Controls.MetroTabPage estTab;
        private MetroFramework.Controls.MetroTabControl tabMenu;
        private MetroFramework.Controls.MetroTile class1testBtn;
        private MetroFramework.Controls.MetroTile class2testBtn;
        private MetroFramework.Controls.MetroTile ecgClass2;
        private MetroFramework.Controls.MetroTile ecgClass1;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTile newproductBtn;
        private MetroFramework.Controls.MetroTile ptNIBP;
        private MetroFramework.Controls.MetroTile ptECG;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTile ptEModules;
        private MetroFramework.Controls.MetroTile ptMX450;
        private MetroFramework.Controls.MetroTile ptX2;
        private System.Windows.Forms.RichTextBox debug_box;
        public MetroFramework.Controls.MetroLabel statusText;
        private MetroFramework.Controls.MetroProgressBar statusBar;
    }
}

