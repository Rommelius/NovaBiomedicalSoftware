namespace NovaBiomedicalSoftware
{
    partial class CreateSpreadsheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSpreadsheet));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.folderDestination = new MetroFramework.Controls.MetroLabel();
            this.equipmentFolder = new MetroFramework.Controls.MetroLabel();
            this.changeFolderDestination_btn = new MetroFramework.Controls.MetroButton();
            this.changeEquipmentFolder_btn = new MetroFramework.Controls.MetroButton();
            this.cancel_btn = new MetroFramework.Controls.MetroButton();
            this.submit_btn = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.clientName = new MetroFramework.Controls.MetroTextBox();
            this.datePicker = new MetroFramework.Controls.MetroDateTime();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(23, 237);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(165, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Equipment Folder:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(23, 160);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(170, 25);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Folder Destination:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // folderDestination
            // 
            this.folderDestination.AutoSize = true;
            this.folderDestination.Location = new System.Drawing.Point(23, 201);
            this.folderDestination.Name = "folderDestination";
            this.folderDestination.Size = new System.Drawing.Size(286, 20);
            this.folderDestination.TabIndex = 1;
            this.folderDestination.Text = "Please select where you want to save the file";
            this.folderDestination.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // equipmentFolder
            // 
            this.equipmentFolder.AutoSize = true;
            this.equipmentFolder.Location = new System.Drawing.Point(23, 278);
            this.equipmentFolder.Name = "equipmentFolder";
            this.equipmentFolder.Size = new System.Drawing.Size(264, 20);
            this.equipmentFolder.TabIndex = 1;
            this.equipmentFolder.Text = "Please select where the PDFs are located";
            this.equipmentFolder.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // changeFolderDestination_btn
            // 
            this.changeFolderDestination_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeFolderDestination_btn.Location = new System.Drawing.Point(454, 161);
            this.changeFolderDestination_btn.Name = "changeFolderDestination_btn";
            this.changeFolderDestination_btn.Size = new System.Drawing.Size(75, 24);
            this.changeFolderDestination_btn.TabIndex = 2;
            this.changeFolderDestination_btn.Text = "Change";
            this.changeFolderDestination_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.changeFolderDestination_btn.UseSelectable = true;
            this.changeFolderDestination_btn.Click += new System.EventHandler(this.changeFolderDestination_btn_Click);
            // 
            // changeEquipmentFolder_btn
            // 
            this.changeEquipmentFolder_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.changeEquipmentFolder_btn.Location = new System.Drawing.Point(454, 238);
            this.changeEquipmentFolder_btn.Name = "changeEquipmentFolder_btn";
            this.changeEquipmentFolder_btn.Size = new System.Drawing.Size(75, 24);
            this.changeEquipmentFolder_btn.TabIndex = 2;
            this.changeEquipmentFolder_btn.Text = "Change";
            this.changeEquipmentFolder_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.changeEquipmentFolder_btn.UseSelectable = true;
            this.changeEquipmentFolder_btn.Click += new System.EventHandler(this.changeEquipmentFolder_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(387, 345);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(142, 47);
            this.cancel_btn.TabIndex = 3;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cancel_btn.UseSelectable = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // submit_btn
            // 
            this.submit_btn.Location = new System.Drawing.Point(23, 345);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(142, 47);
            this.submit_btn.TabIndex = 3;
            this.submit_btn.Text = "Submit";
            this.submit_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.submit_btn.UseSelectable = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(23, 78);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(120, 25);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Client Name:";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(23, 119);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(142, 25);
            this.metroLabel4.TabIndex = 4;
            this.metroLabel4.Text = "Date of Service:";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // clientName
            // 
            // 
            // 
            // 
            this.clientName.CustomButton.Image = null;
            this.clientName.CustomButton.Location = new System.Drawing.Point(323, 1);
            this.clientName.CustomButton.Name = "";
            this.clientName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.clientName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.clientName.CustomButton.TabIndex = 1;
            this.clientName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.clientName.CustomButton.UseSelectable = true;
            this.clientName.CustomButton.Visible = false;
            this.clientName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.clientName.Lines = new string[0];
            this.clientName.Location = new System.Drawing.Point(180, 76);
            this.clientName.MaxLength = 32767;
            this.clientName.Name = "clientName";
            this.clientName.PasswordChar = '\0';
            this.clientName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.clientName.SelectedText = "";
            this.clientName.SelectionLength = 0;
            this.clientName.SelectionStart = 0;
            this.clientName.ShortcutsEnabled = true;
            this.clientName.Size = new System.Drawing.Size(349, 27);
            this.clientName.TabIndex = 5;
            this.clientName.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.clientName.UseSelectable = true;
            this.clientName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.clientName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(180, 114);
            this.datePicker.MinimumSize = new System.Drawing.Size(0, 30);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(349, 30);
            this.datePicker.TabIndex = 6;
            this.datePicker.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.datePicker.Value = new System.DateTime(2017, 11, 1, 0, 0, 0, 0);
            // 
            // CreateSpreadsheet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(552, 415);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.clientName);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.changeEquipmentFolder_btn);
            this.Controls.Add(this.changeFolderDestination_btn);
            this.Controls.Add(this.equipmentFolder);
            this.Controls.Add(this.folderDestination);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateSpreadsheet";
            this.Resizable = false;
            this.Text = "Report Generator";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel folderDestination;
        private MetroFramework.Controls.MetroLabel equipmentFolder;
        private MetroFramework.Controls.MetroButton changeFolderDestination_btn;
        private MetroFramework.Controls.MetroButton changeEquipmentFolder_btn;
        private MetroFramework.Controls.MetroButton cancel_btn;
        private MetroFramework.Controls.MetroButton submit_btn;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox clientName;
        private MetroFramework.Controls.MetroDateTime datePicker;
    }
}