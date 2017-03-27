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

namespace NovaBiomedicalSoftware.Queensland_Abulance_Service
{
    public partial class TwinOVac : MetroForm
    {
        public TwinOVac()
        {
            InitializeComponent();
        }

        public bool TwinOVacTest_Submit;

        public static string assetNumberText, modelBoxText, makeBoxText, serialNumberText;
        public static string result1, result2, result3, result4, result5, result6;

        private void close_btn_Click(object sender, EventArgs e)
        {
            TwinOVacTest_Submit = false;
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.SelectedItem == null || result_2.SelectedItem == null || result_3.SelectedItem == null ||
                result_4.SelectedItem == null || result_5.SelectedItem == null || result_6.SelectedItem == null)
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
                result4 = result_4.Text;
                result5 = result_5.Text;
                result6 = result_6.Text;

                //comments box
                comments = commentBox.Text;

                TwinOVacTest_Submit = true;
                this.Hide();
            }
        }

        //comment box and item box
        public static string comments, items;
    }
}
