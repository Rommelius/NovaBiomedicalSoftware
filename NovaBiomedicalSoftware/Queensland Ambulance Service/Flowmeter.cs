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

namespace NovaBiomedicalSoftware.Queensland_Ambulance_Service
{
    public partial class Flowmeter : MetroForm
    {
        public Flowmeter()
        {
            InitializeComponent();
        }


        public bool FlowmeterTest_Submit;

        public static string assetNumberText, modelBoxText, makeBoxText, serialNumberText;
        public static string result1, result2, result3;

        private void close_btn_Click(object sender, EventArgs e)
        {
            FlowmeterTest_Submit = false;
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.SelectedItem == null || result_2.SelectedItem == null || result_3.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //visual
                assetNumberText = assetNumber.Text;
                serialNumberText = serialNumber.Text;
                modelBoxText = modelBox.Text;
                makeBoxText = makeBox.Text;
                result1 = result_1.Text;
                result2 = result_2.Text;
                result3 = result_3.Text;

                //comments box
                comments = commentBox.Text;

                FlowmeterTest_Submit = true;
                this.Hide();
            }
        }

        //comment box and item box
        public static string comments, items;
    }
}
