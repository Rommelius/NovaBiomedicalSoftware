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
    public partial class BodyGuardForm : MetroForm
    {
        public BodyGuardForm()
        {
            InitializeComponent();
            safetyCheck.SelectedTab = functionalCheck;
            commentBox.ResetText();
        }

        private void BodyGuardForm_SizeChanged(object sender, EventArgs e)
        {
            commentBox.Width = safetyCheck.Width - 10;
            listBox1.Width = safetyCheck.Width - 10;
        }
        public bool Test_Submit;
        //static string for functionalCheck
        public static string 
            result_1,
            result_2,
            result_3,
            result_4,
            result_5,
            result_6,
            result_7,
            result_8,
            result_9,
            result_10,
            result_11,
            result_12,
            result_13,
            result_14,
            result_15,
            result_16,
            result_17,
            result_18,
            result_19,
            result_20,
            serialnum,
            volume1,
            volume2,
            percent1,
            calibrationfactor,
            comments, 
            items,  
            overallresult;

        private void volume_input1_TextChanged(object sender, EventArgs e)
        {
            if (volume_input1.Text != "")
            {
                double volume = Convert.ToDouble(volume_input1.Text);

                double result = ((volume / 5 * 100) - 100);
                percent_input1.Text = result.ToString("F");
            }
            else
            {
                percent_input1.Text = "";
            }
            
        }


        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

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
            if (result1.SelectedItem == null ||
                result2.SelectedItem == null ||
                result3.SelectedItem == null ||
                result4.SelectedItem == null ||
                result5.SelectedItem == null ||
                result6.SelectedItem == null ||
                result7.SelectedItem == null ||
                result8.SelectedItem == null ||
                result9.SelectedItem == null ||
                result10.SelectedItem == null ||
                result11.SelectedItem == null ||
                result12.SelectedItem == null ||
                result13.SelectedItem == null ||
                result14.SelectedItem == null ||
                result15.SelectedItem == null ||
                result16.SelectedItem == null ||
                result17.SelectedItem == null ||
                result18.SelectedItem == null ||
                result19.SelectedItem == null ||
                result20.SelectedItem == null ||
                volume_input1.Text == "" ||
                calibration_input2.Text == "" ||
                percent_input1.Text == "" ||
                calibration_input2.Text == "" ||
                serial_input.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                //functional
                result_1 = result1.Text;
                result_2 = result2.Text;
                result_3 = result3.Text;
                result_4 = result4.Text;
                result_5 = result5.Text;
                result_6 = result6.Text;
                result_7 = result7.Text;
                result_8 = result8.Text;
                result_9 = result9.Text;
                result_10 = result10.Text;
                result_11 = result11.Text;
                result_12 = result12.Text;
                result_13 = result13.Text;
                result_14 = result14.Text;
                result_15 = result15.Text;
                result_16 = result16.Text;
                result_17 = result17.Text;
                result_18 = result18.Text;
                result_19 = result19.Text;
                volume1 = volume_input1.Text;
                percent1 = percent_input1.Text;
                calibrationfactor = calibration_input2.Text;
                serialnum = serial_input.Text;

                result_20 = result20.Text;


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
