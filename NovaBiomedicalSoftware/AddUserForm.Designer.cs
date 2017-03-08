namespace NovaBiomedicalSoftware
{
    partial class AddUserForm
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.newUser = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.submitBtn = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(23, 74);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(185, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Please fill in the following:";
            // 
            // newUser
            // 
            // 
            // 
            // 
            this.newUser.CustomButton.Image = null;
            this.newUser.CustomButton.Location = new System.Drawing.Point(130, 1);
            this.newUser.CustomButton.Name = "";
            this.newUser.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.newUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.newUser.CustomButton.TabIndex = 1;
            this.newUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.newUser.CustomButton.UseSelectable = true;
            this.newUser.CustomButton.Visible = false;
            this.newUser.Lines = new string[0];
            this.newUser.Location = new System.Drawing.Point(101, 97);
            this.newUser.MaxLength = 32767;
            this.newUser.Name = "newUser";
            this.newUser.PasswordChar = '\0';
            this.newUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.newUser.SelectedText = "";
            this.newUser.SelectionLength = 0;
            this.newUser.SelectionStart = 0;
            this.newUser.ShortcutsEnabled = true;
            this.newUser.Size = new System.Drawing.Size(152, 23);
            this.newUser.TabIndex = 1;
            this.newUser.UseSelectable = true;
            this.newUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.newUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 101);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(72, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Full Name:";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(178, 137);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 3;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseSelectable = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // AddUserForm
            // 
            this.AcceptButton = this.submitBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 175);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.newUser);
            this.Controls.Add(this.metroLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUserForm";
            this.Resizable = false;
            this.Text = "Add New Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox newUser;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton submitBtn;
    }
}