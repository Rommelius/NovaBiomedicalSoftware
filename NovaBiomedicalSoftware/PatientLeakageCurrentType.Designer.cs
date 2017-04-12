namespace NovaBiomedicalSoftware
{
    partial class PatientLeakageCurrentType
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
            this.typeB_btn = new MetroFramework.Controls.MetroTile();
            this.typeBF_btn = new MetroFramework.Controls.MetroTile();
            this.typeCF_btn = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // typeB_btn
            // 
            this.typeB_btn.ActiveControl = null;
            this.typeB_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.typeB_btn.Location = new System.Drawing.Point(37, 364);
            this.typeB_btn.Margin = new System.Windows.Forms.Padding(4);
            this.typeB_btn.Name = "typeB_btn";
            this.typeB_btn.Size = new System.Drawing.Size(653, 135);
            this.typeB_btn.TabIndex = 1;
            this.typeB_btn.Text = "Type B";
            this.typeB_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.typeB_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.typeB_btn.TileImage = global::NovaBiomedicalSoftware.Properties.Resources.typeB;
            this.typeB_btn.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.typeB_btn.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.typeB_btn.UseSelectable = true;
            this.typeB_btn.UseTileImage = true;
            this.typeB_btn.Click += new System.EventHandler(this.typeB_btn_Click);
            // 
            // typeBF_btn
            // 
            this.typeBF_btn.ActiveControl = null;
            this.typeBF_btn.Location = new System.Drawing.Point(37, 221);
            this.typeBF_btn.Margin = new System.Windows.Forms.Padding(4);
            this.typeBF_btn.Name = "typeBF_btn";
            this.typeBF_btn.Size = new System.Drawing.Size(653, 135);
            this.typeBF_btn.TabIndex = 2;
            this.typeBF_btn.Text = "Type BF";
            this.typeBF_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.typeBF_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.typeBF_btn.TileImage = global::NovaBiomedicalSoftware.Properties.Resources.typeBF;
            this.typeBF_btn.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.typeBF_btn.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.typeBF_btn.UseSelectable = true;
            this.typeBF_btn.UseTileImage = true;
            this.typeBF_btn.Click += new System.EventHandler(this.typeBF_btn_Click);
            // 
            // typeCF_btn
            // 
            this.typeCF_btn.ActiveControl = null;
            this.typeCF_btn.Location = new System.Drawing.Point(37, 78);
            this.typeCF_btn.Margin = new System.Windows.Forms.Padding(4);
            this.typeCF_btn.Name = "typeCF_btn";
            this.typeCF_btn.Size = new System.Drawing.Size(653, 135);
            this.typeCF_btn.TabIndex = 3;
            this.typeCF_btn.Text = "Type CF";
            this.typeCF_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.typeCF_btn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.typeCF_btn.TileImage = global::NovaBiomedicalSoftware.Properties.Resources.typeCF;
            this.typeCF_btn.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.typeCF_btn.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.typeCF_btn.UseSelectable = true;
            this.typeCF_btn.UseTileImage = true;
            this.typeCF_btn.Click += new System.EventHandler(this.typeCF_btn_Click);
            // 
            // PatientLeakageCurrentType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 535);
            this.Controls.Add(this.typeB_btn);
            this.Controls.Add(this.typeBF_btn);
            this.Controls.Add(this.typeCF_btn);
            this.Name = "PatientLeakageCurrentType";
            this.Text = "Select from the following:";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile typeB_btn;
        private MetroFramework.Controls.MetroTile typeBF_btn;
        private MetroFramework.Controls.MetroTile typeCF_btn;
    }
}