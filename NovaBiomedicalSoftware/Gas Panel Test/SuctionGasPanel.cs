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

namespace NovaBiomedicalSoftware.Gas_Panel_Test
{
    public partial class SuctionGasPanel : MetroForm
    {
        public SuctionGasPanel()
        {
            InitializeComponent();
            safetyCheck.SelectedTab = functionalCheck;
            commentBox.ResetText();
        }

        private void SuctionGasPanel_SizeChanged(object sender, EventArgs e)
        {
            commentBox.Width = safetyCheck.Width - 10;
            listBox1.Width = safetyCheck.Width - 10;
        }

        public bool Test_Submit;


        //static string for functionalCheck
        public static string functionaloption1, functionaloption2, functionaloption3, functionaloption4,
            functionaloption5, functionaloption6, comments, manufacturer;

        private void metroButton1_Click(object sender, EventArgs e)
        {
            foreach (Control item in functionalCheck.Controls)
            {
                if (item is MetroFramework.Controls.MetroComboBox)
                {
                    (item as MetroFramework.Controls.MetroComboBox).SelectedIndex = 0;
                }
            }
        }

        private void close2_btn_Click(object sender, EventArgs e)
        {
            Test_Submit = false;
            this.Close();
        }

        private void close1_btn_Click(object sender, EventArgs e)
        {
            Test_Submit = false;
            this.Close();
        }

        private void submitBtn_Click_1(object sender, EventArgs e)
        {

            //check if the combobox are answered
            if (functionalOption1.Text == "" || functionalOption2.SelectedItem == null || functionalOption3.SelectedItem == null || functionalOption4.SelectedItem == null
                || functionalOption5.SelectedItem == null || functionalOption6.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //functional
                manufacturer = manu.Text;
                functionaloption1 = functionalOption1.Text;
                functionaloption2 = functionalOption2.Text;
                functionaloption3 = functionalOption3.Text;
                functionaloption4 = functionalOption4.Text;
                functionaloption5 = functionalOption5.Text;
                functionaloption6 = functionalOption6.Text;


                //comments box
                comments = commentBox.Text;

                addItems();

                Test_Submit = true;
                this.Hide();
            }
        }

        private void next2_btn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;
        }

        public static List<string> testequipment = new List<string>();

        private void addItems()
        {
            foreach (var item in listBox1.SelectedItems)
            {
                testequipment.Add(item.ToString());
            }
        }
    }
}
