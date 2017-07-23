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
    public partial class AlarisSyringePumpForm : MetroForm
    {
        public AlarisSyringePumpForm()
        {
            InitializeComponent();
            safetyCheck.SelectedTab = functionalCheck;
            commentBox.ResetText();
        }

        private void AlarisSyringePumpForm_SizeChanged(object sender, EventArgs e)
        {
            commentBox.Width = safetyCheck.Width - 10;
            listBox1.Width = safetyCheck.Width - 10;
        }

        public bool Test_Submit;
        //static string for functionalCheck
        public static string functionaloption1, functionaloption2, functionaloption3, functionaloption4,
            functionaloption5, functionaloption6, functionaloption7, functionaloption8, functionaloption9,
            functionaloption10, functionaloption11, functionaloption12, functionaloption13, functionaloption14,
            functionaloption15, functionaloption16, functionaloption17, functionaloption18, functionaloption19,
            functionaloption20, functionaloption21, functionaloption22, functionaloption23,
            functionaloption24, functionaloption25, functionaloption26, comments, items, performanceresult1, result;

        private void PassAll_Click(object sender, EventArgs e)
        {
            foreach (Control item in functionalCheck.Controls)
            {
                if (item is MetroFramework.Controls.MetroComboBox)
                {
                    (item as MetroFramework.Controls.MetroComboBox).SelectedIndex = 0;
                }
            }
        }


        private void nextBtn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;
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
            if (functionalOption1.SelectedItem == null || functionalOption2.SelectedItem == null || functionalOption3.SelectedItem == null || functionalOption4.Text == ""
                || functionalOption5.SelectedItem == null || functionalOption6.SelectedItem == null || functionalOption7.SelectedItem == null
                || functionalOption8.SelectedItem == null || functionalOption9.Text == "" || functionalOption10.Text == ""
                || functionalOption11.Text == "" || functionalOption12.Text == "" || functionalOption13.Text == ""
                || functionalOption14.SelectedItem == null || functionalOption15.Text == "" || functionalOption16.Text == "" ||
                functionalOption17.SelectedItem == null || functionalOption18.SelectedItem == null || functionalOption19.SelectedItem == null
                || functionalOption20.SelectedItem == null || functionalOption21.SelectedItem == null || functionalOption22.SelectedItem == null || functionalOption23.SelectedItem == null
                || functionalOption24.SelectedItem == null || functionalOption25.SelectedItem == null || functionalOption26.SelectedItem == null || functionalOption48.SelectedItem==null)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
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
                functionaloption15 = functionalOption15.Text;
                functionaloption16 = functionalOption16.Text;
                functionaloption17 = functionalOption17.Text;
                result = functionalOption48.Text;
                functionaloption18 = functionalOption18.Text;
                functionaloption19 = functionalOption19.Text;
                functionaloption20 = functionalOption20.Text;
                functionaloption21 = functionalOption21.Text;
                functionaloption22 = functionalOption22.Text;
                functionaloption23 = functionalOption23.Text;
                functionaloption24 = functionalOption24.Text;
                functionaloption25 = functionalOption25.Text;
                functionaloption26 = functionalOption26.Text;


                //comments box
                comments = commentBox.Text;

                addItems();

                Test_Submit = true;
                this.Hide();
            }
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
