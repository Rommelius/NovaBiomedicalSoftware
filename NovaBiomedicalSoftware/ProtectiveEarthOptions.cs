using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace NovaBiomedicalSoftware
{
    public partial class ProtectiveEarthOptions : MetroForm
    {
        public static bool nonDetachableSupplyOption, withApplianceInletOption, detachablePowerSupplyOption;

        public ProtectiveEarthOptions()
        {
            InitializeComponent();
        }

        private void nonDetachableSupply_Click(object sender, EventArgs e)
        {
            nonDetachableSupplyOption = true;
            withApplianceInletOption = false;
            detachablePowerSupplyOption = false;
            this.Close();
        }

        private void withApplianceInlet_Click(object sender, EventArgs e)
        {
            nonDetachableSupplyOption = false;
            withApplianceInletOption = true;
            detachablePowerSupplyOption = false;
            this.Close();
        }

        private void detachablePowerSupply_Click(object sender, EventArgs e)
        {
            nonDetachableSupplyOption = false;
            withApplianceInletOption = false;
            detachablePowerSupplyOption = true;
            this.Close();
        }
    }
}
