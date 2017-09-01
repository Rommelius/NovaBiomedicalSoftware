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
    public partial class PhilipsCO : MetroForm
    {
        public PhilipsCO()
        {
            InitializeComponent();
            commentBox.ResetText();
            safetyCheck.SelectedTab = performanceVerification;

            foreach (var item in MainMenu.testequipmentlist)
            {
                testequipmentBox.Items.Add(item);
            }
        }

        private void PhilipsCO_SizeChanged(object sender, EventArgs e)
        {
            commentBox.Width = safetyCheck.Width - 10;
            testequipmentBox.Width = safetyCheck.Width - 10;
        }

        public bool Test_Submit;

        public static string result1, result2, result3, result8, performanceresult;
        //comment box and item box
        public static string comments, items;

        private void metroButton1_Click(object sender, EventArgs e)
        {
            foreach (Control item in performanceVerification.Controls)
            {
                if (item is MetroFramework.Controls.MetroComboBox)
                {
                    (item as MetroFramework.Controls.MetroComboBox).SelectedIndex = 0;
                }
            }
        }

        private void close1_btn_Click(object sender, EventArgs e)
        {
            Test_Submit = false;
            this.Close();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;

        }

        private void close3_btn_Click(object sender, EventArgs e)
        {
            Test_Submit = false;
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.SelectedItem == null || result_2.SelectedItem == null || result_3.Text == "" || result_8.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                performanceresult = result_8.Text;
                //visual
                result1 = result_1.Text;
                result2 = result_2.Text;
                result3 = result_3.Text;
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
            foreach (var item in testequipmentBox.SelectedItems)
            {
                testequipment.Add(item.ToString());
            }
        }
    }
}
