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
    public partial class EdanDoppler : MetroForm
    {
        public bool edanTest_Submit;

        public static string result1, result2;

        //comment box and item box
        public static string comments, items;

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

        private void close3_btn_Click(object sender, EventArgs e)
        {
            edanTest_Submit = false;
            this.Close();
        }

        private void nextBtn_Click_1(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.SelectedItem == null || result_2.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //visual
                result1 = result_1.Text;
                result2 = result_2.Text;

                //comments box
                comments = commentBox.Text;

                addItems();
                items = itemsBox.Text;

                edanTest_Submit = true;
                this.Hide();
            }
        }

        private void close1_btn_Click_1(object sender, EventArgs e)
        {
            edanTest_Submit = false;
            this.Close();
        }



        public EdanDoppler()
        {
            InitializeComponent();
            itemsBox.ResetText();
            commentBox.ResetText();
            itemsBox.Visible = false;
            safetyCheck.SelectedTab = performanceVerification;
            this.StyleManager = metroStyleManager1;
            metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
        }
    }
}
