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
    public partial class PhilipsMRxDefib : MetroForm
    {
        public bool philipsMrxTest_Submit;

        public static string result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15, result16,
            result17, result18, result19, result20, result21, result22, result23;

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.SelectedItem == null || result_2.SelectedItem == null || result_3.SelectedItem == null ||
                result_4.SelectedItem == null || result_5.SelectedItem == null || result_6.SelectedItem == null || result_7.SelectedItem == null ||
                result_8.SelectedItem == null)
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
                result9 = result_9.Text;
                result10 = result_10.Text;
                result11 = result_11.Text;
                result12 = result_12.Text;
                result13= result_13.Text;
                result14= result_14.Text;
                result15= result_15.Text;
                result16= result_16.Text;
                result17= result_17.Text;
                result18= result_18.Text;
                result19= result_19.Text;
                result20= result_20.Text;
                result21= result_21.Text;
                result22= result_22.Text;
                result23= result_23.Text;

                //comments box
                comments = commentBox.Text;

                addItems();
                items = itemsBox.Text;

                philipsMrxTest_Submit = true;
                this.Hide();
            }
        }

        private void close3_btn_Click(object sender, EventArgs e)
        {
            philipsMrxTest_Submit = false;
            this.Close();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;
        }

        private void close1_btn_Click(object sender, EventArgs e)
        {
            philipsMrxTest_Submit = false;
            this.Close();
        }

        //comment box and item box
        public static string comments, items;



        public PhilipsMRxDefib()
        {
            InitializeComponent();
            itemsBox.ResetText();
            commentBox.ResetText();
            itemsBox.Visible = false;
            safetyCheck.SelectedTab = performanceVerification;
        }

        private void addItems()
        {
            //items
            if (metroCheckBox1.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox1.Text + "\n");
            }
            if (metroCheckBox2.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox2.Text + "\n");
            }
            if (metroCheckBox3.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox3.Text + "\n");
            }
            if (metroCheckBox4.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox4.Text + "\n");
            }
            if (metroCheckBox5.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox5.Text + "\n");
            }
            if (metroCheckBox6.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox6.Text + "\n");
            }
            if (metroCheckBox7.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox7.Text + "\n");
            }
            if (metroCheckBox8.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox8.Text + "\n");
            }
            if (metroCheckBox8.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox8.Text + "\n");
            }
            if (metroCheckBox9.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox9.Text + "\n");
            }
            if (metroCheckBox10.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox10.Text + "\n");
            }
            if (metroCheckBox11.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox11.Text + "\n");
            }
            if (metroCheckBox12.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox12.Text + "\n");
            }
            if (metroCheckBox13.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox13.Text + "\n");
            }
            if (metroCheckBox14.Checked == true)
            {
                itemsBox.AppendText(metroCheckBox14.Text);
            }
        }
    }
}
