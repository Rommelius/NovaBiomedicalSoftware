namespace NovaBiomedicalSoftware
{
    partial class ProtectiveEarthOptions
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
            this.nonDetachableSupply = new MetroFramework.Controls.MetroTile();
            this.withApplianceInlet = new MetroFramework.Controls.MetroTile();
            this.detachablePowerSupply = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // nonDetachableSupply
            // 
            this.nonDetachableSupply.ActiveControl = null;
            this.nonDetachableSupply.Location = new System.Drawing.Point(23, 63);
            this.nonDetachableSupply.Name = "nonDetachableSupply";
            this.nonDetachableSupply.Size = new System.Drawing.Size(490, 110);
            this.nonDetachableSupply.TabIndex = 0;
            this.nonDetachableSupply.Text = "Class 1 Equipment with a Non-Detachable Supply Cord";
            this.nonDetachableSupply.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.nonDetachableSupply.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.nonDetachableSupply.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.nonDetachableSupply.UseSelectable = true;
            this.nonDetachableSupply.Click += new System.EventHandler(this.nonDetachableSupply_Click);
            // 
            // withApplianceInlet
            // 
            this.withApplianceInlet.ActiveControl = null;
            this.withApplianceInlet.Location = new System.Drawing.Point(23, 179);
            this.withApplianceInlet.Name = "withApplianceInlet";
            this.withApplianceInlet.Size = new System.Drawing.Size(490, 110);
            this.withApplianceInlet.TabIndex = 0;
            this.withApplianceInlet.Text = "Class 1 Equipment with an Appliance Inlet";
            this.withApplianceInlet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.withApplianceInlet.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.withApplianceInlet.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.withApplianceInlet.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.withApplianceInlet.UseSelectable = true;
            this.withApplianceInlet.Click += new System.EventHandler(this.withApplianceInlet_Click);
            // 
            // detachablePowerSupply
            // 
            this.detachablePowerSupply.ActiveControl = null;
            this.detachablePowerSupply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.detachablePowerSupply.Location = new System.Drawing.Point(23, 295);
            this.detachablePowerSupply.Name = "detachablePowerSupply";
            this.detachablePowerSupply.Size = new System.Drawing.Size(490, 110);
            this.detachablePowerSupply.TabIndex = 0;
            this.detachablePowerSupply.Text = "Detachable Power Supply Cord";
            this.detachablePowerSupply.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.detachablePowerSupply.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.detachablePowerSupply.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.detachablePowerSupply.UseSelectable = true;
            this.detachablePowerSupply.Click += new System.EventHandler(this.detachablePowerSupply_Click);
            // 
            // ProtectiveEarthOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 435);
            this.Controls.Add(this.detachablePowerSupply);
            this.Controls.Add(this.withApplianceInlet);
            this.Controls.Add(this.nonDetachableSupply);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProtectiveEarthOptions";
            this.Resizable = false;
            this.Text = "Select from the following:";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile nonDetachableSupply;
        private MetroFramework.Controls.MetroTile withApplianceInlet;
        private MetroFramework.Controls.MetroTile detachablePowerSupply;
    }
}