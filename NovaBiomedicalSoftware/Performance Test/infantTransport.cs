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

namespace NovaBiomedicalSoftware.Performance_Test
{
    public partial class infantTransport : MetroForm
    {
        public infantTransport()
        {
            InitializeComponent();
            safetyCheck.SelectedTab = functionalCheck;
            commentBox.ResetText();
        }

        //note NO 22,23,24 functional check

        public bool Test_Submit;


        //static string for functionalCheck
        public static string functionaloption1, functionaloption2, functionaloption3, functionaloption4,
            functionaloption5, functionaloption6, functionaloption7, functionaloption8, functionaloption9,
            functionaloption10, functionaloption11, functionaloption12, functionaloption13, functionaloption14,
            functionaloption15, functionaloption16, comments, performanceresult;

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

        private void infantTransport_SizeChanged(object sender, EventArgs e)
        {
            commentBox.Width = safetyCheck.Width - 10;
            listBox1.Width = safetyCheck.Width - 10;
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
            if (functionalOption2.SelectedItem == null || functionalOption3.SelectedItem == null || functionalOption4.SelectedItem == null
                || functionalOption5.SelectedItem == null || functionalOption6.SelectedItem == null || functionalOption7.SelectedItem == null
                || functionalOption8.SelectedItem == null || functionalOption9.SelectedItem == null || functionalOption10.SelectedItem == null
                || functionalOption11.SelectedItem == null || functionalOption12.SelectedItem == null || functionalOption13.SelectedItem == null
                || functionalOption14.SelectedItem == null || functionalOption16.SelectedItem == null || overall.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                performanceresult = overall.Text;
                //functional
                functionaloption1 = functionalOption1.Text;
                functionaloption2 = functionalOption2.Text;
                functionaloption3 = functionalOption3.Text;
                functionaloption4 = functionalOption4.Text;
                functionaloption5 = functionalOption5.Text;
                functionaloption6 = functionalOption6.Text;
                functionaloption7 = functionalOption7.Text;
                functionaloption8 = functionalOption8.Text;
                functionaloption9 = functionalOption9.Text;
                functionaloption10 = functionalOption10.Text;
                functionaloption11 = functionalOption11.Text;
                functionaloption12 = functionalOption12.Text;
                functionaloption13 = functionalOption13.Text;
                functionaloption14 = functionalOption14.Text;
                functionaloption16 = functionalOption16.Text;


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
