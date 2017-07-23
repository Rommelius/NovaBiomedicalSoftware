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
    public partial class Oxylog : MetroForm
    {
        public bool oxylogTest_Submit;

        public static string result1, result2, performanceresult, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12,result13,result14, text_result1, text_result2, text_result3, text_result4,text_result5, text_result6;

        private void PassAll_Click(object sender, EventArgs e)
        {
            foreach (Control item in performanceVerification.Controls)
            {
                if (item is MetroFramework.Controls.MetroComboBox)
                {
                    (item as MetroFramework.Controls.MetroComboBox).SelectedIndex = 0;
                }
            }
        }

        private void Oxylog_SizeChanged(object sender, EventArgs e)
        {
            commentBox.Width = safetyCheck.Width - 10;
            listBox1.Width = safetyCheck.Width - 10;
        }

        //comment box and item box
        public static string comments, items;

        public static List<string> testequipment = new List<string>();

        private void addItems()
        {
            foreach (var item in listBox1.SelectedItems)
            {
                testequipment.Add(item.ToString());
            }
        }
        public Oxylog()
        {
            InitializeComponent();
            commentBox.ResetText();
            safetyCheck.SelectedTab = performanceVerification;
        }

        private void close1_btn_Click(object sender, EventArgs e)
        {
            oxylogTest_Submit = false;
            this.Close();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;
        }

        private void close3_btn_Click(object sender, EventArgs e)
        {
            oxylogTest_Submit = false;
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.SelectedItem == null || result_2.SelectedItem == null || result_3.SelectedItem == null ||
                result_4.SelectedItem == null || result_5.SelectedItem == null || result_6.SelectedItem == null || result_7.SelectedItem == null || result_8.SelectedItem == null || result_9.SelectedItem == null ||
                result_10.SelectedItem == null || result_11.SelectedItem == null || result_12.SelectedItem == null || result_13.SelectedItem == null || result_14.SelectedItem == null || text1.Text == "" || text2.Text == "" ||
                text3.Text == "" ||
                text4.Text == "" ||
                text5.Text == "" ||
                text6.Text == "" || overall.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                performanceresult = overall.Text;
                //visual
                result1 = result_1.Text;
                result2 = result_2.Text;
                result3 = result_3.Text;
                result4 = result_4.Text;
                result5 = result_5.Text;
                result6 = result_6.Text;
                result7 = result_7.Text;
                result8 = result_8.Text;
                result9 = result_9.Text;
                result10 = result_10.Text;
                result11= result_11.Text;
                result12= result_12.Text;
                result13= result_13.Text;
                result14 = result_14.Text;
                text_result1 = text1.Text;
                text_result2 = text2.Text;
                text_result3 = text3.Text;
                text_result4 = text4.Text;
                text_result5 = text5.Text;
                text_result6 = text6.Text;

                //comments box
                comments = commentBox.Text;

                addItems();

                oxylogTest_Submit = true;
                this.Hide();
            }
        }


    }
}
