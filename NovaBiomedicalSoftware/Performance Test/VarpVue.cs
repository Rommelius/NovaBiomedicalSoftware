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
    public partial class VarpVue : MetroForm
    {

        public bool VarpVueTest_Submit;

        public static string result1, result2, result3, result4, result5, result6, result7, result8,
            result9, value1, value2, value3, value4, value5, value6, value7, value8;
        //comment box and item box
        public static string comments, items;
        public VarpVue()
        {
            InitializeComponent();
            itemsBox.ResetText();
            commentBox.ResetText();
            itemsBox.Visible = false;
            safetyCheck.SelectedTab = performanceVerification;
        }

        private void close1_btn_Click(object sender, EventArgs e)
        {
            VarpVueTest_Submit = false;
            this.Close();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;

        }

        private void close3_btn_Click(object sender, EventArgs e)
        {
            VarpVueTest_Submit = false;
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.SelectedItem == null || result_2.SelectedItem == null || result_3.SelectedItem == null ||
                result_4.SelectedItem == null || result_5.SelectedItem == null || result_4.SelectedItem == null ||
                result_5.SelectedItem == null || result_6.SelectedItem == null || result_7.SelectedItem == null ||
                result_8.SelectedItem == null || result_9.SelectedItem == null || metroTextBox1.Text == "" || metroTextBox2.Text == "" ||
                metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "" || metroTextBox6.Text == "" ||
                metroTextBox7.Text == "" || metroTextBox8.Text == "")
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

                value1 = metroTextBox1.Text;
                value2 = metroTextBox2.Text;
                value3 = metroTextBox3.Text;
                value4 = metroTextBox4.Text;
                value5 = metroTextBox5.Text;
                value6 = metroTextBox6.Text;
                value7 = metroTextBox7.Text;
                value8 = metroTextBox8.Text;
                //comments box
                comments = commentBox.Text;

                addItems();
                items = itemsBox.Text;

                VarpVueTest_Submit = true;
                this.Hide();
            }
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
