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
    public partial class GenericNIBPMonitor : MetroForm
    {
        public bool nibpTest_Submit;

        public static string result1, result2, result3, result4, result5, result6, result7, result8, performanceresult;

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

        private void GenericNIBPMonitor_SizeChanged(object sender, EventArgs e)
        {
            commentBox.Width = safetyCheck.Width - 10;
            listBox1.Width = safetyCheck.Width - 10;
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;
        }

        private void close1_btn_Click(object sender, EventArgs e)
        {
            nibpTest_Submit = false;
            this.Close();
        }

        private void close3_btn_Click(object sender, EventArgs e)
        {
            nibpTest_Submit = false;
            this.Close();
        }



        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.SelectedItem == null || result_2.SelectedItem == null || result_3.SelectedItem == null ||
                result_4.SelectedItem == null || result_5.SelectedItem == null || result_6.SelectedItem == null || result_7.SelectedItem == null ||
                result_8.SelectedItem == null || overall.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //visual
                result1 = result_1.Text;
                result2 = result_2.Text;
                result3 = result_3.Text;
                result4 = result_4.Text;
                result5 = result_5.Text;
                result6 = result_6.Text;
                result7 = result_7.Text;
                result8 = result_8.Text;

                performanceresult = overall.Text;

                //comments box
                comments = commentBox.Text;

                addItems();

                nibpTest_Submit = true;
                this.Hide();
            }
        }

        public GenericNIBPMonitor()
        {
            InitializeComponent();
            commentBox.ResetText();
            safetyCheck.SelectedTab = performanceVerification;
            this.StyleManager = metroStyleManager1;
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            listBox1.Items.Clear();
            foreach (var item in MainMenu.testequipmentlist)
            {
                listBox1.Items.Add(item);
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
