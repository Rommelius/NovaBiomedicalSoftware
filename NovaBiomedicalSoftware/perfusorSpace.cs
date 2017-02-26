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
using MetroFramework.Controls;

namespace NovaBiomedicalSoftware
{
    public partial class perfusorSpace : MetroForm
    {

        public bool perfusorTest_Submit, visualComboBox, functionalComboBox;


        public perfusorSpace()
        {
            InitializeComponent();
            safetyCheck.SelectedTab = visualCheck;

        }


        private void checkBattery_Click(object sender, EventArgs e)
        {
            BatteryChecker batteryCheck = new BatteryChecker();
            batteryCheck.Show();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if comboBox are answered


            perfusorTest_Submit = true;


            foreach (Control c in this.Controls)
            {
                if (c is MetroComboBox)
                    MessageBox.Show("hi");

            }

        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = functionalCheck;
        }

        private void close2_btn_Click(object sender, EventArgs e)
        {
            perfusorTest_Submit = false;
            this.Close();
        }

        private void close1_btn_Click(object sender, EventArgs e)
        {
            perfusorTest_Submit = false;
            this.Close();
        }


    }
}
