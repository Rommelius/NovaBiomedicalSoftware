﻿using System;
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
    public partial class RegulatorPT : MetroForm
    {
        public bool RegulatorTest_Submit;

        public static string result1, result2, result3, result4, result5;

        //comment box and item box
        public static string comments, items;


        public RegulatorPT()
        {
            InitializeComponent();
            itemsBox.ResetText();
            commentBox.ResetText();
            itemsBox.Visible = false;
            safetyCheck.SelectedTab = performanceVerification;
        }

        private void close1_btn_Click(object sender, EventArgs e)
        {
            RegulatorTest_Submit = false;
            this.Close();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;

        }

        private void close3_btn_Click(object sender, EventArgs e)
        {
            RegulatorTest_Submit = false;
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.Text == null || result_2.SelectedItem == null || result_3.SelectedItem == null ||
                result_4.SelectedItem == null || result_5.SelectedItem == null)
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

                //comments box
                comments = commentBox.Text;

                addItems();
                items = itemsBox.Text;

                RegulatorTest_Submit = true;
                this.Hide();
            }
        }
        public static List<string> testequipment = new List<string>();
        private void addItems()
        {
            //items
            if (metroCheckBox1.Checked == true)
            {
                testequipment.Add(metroCheckBox1.Text);
            }
            if (metroCheckBox2.Checked == true)
            {
                testequipment.Add(metroCheckBox2.Text);
            }
            if (metroCheckBox3.Checked == true)
            {
                testequipment.Add(metroCheckBox3.Text);
            }
            if (metroCheckBox4.Checked == true)
            {
                testequipment.Add(metroCheckBox4.Text);
            }
            if (metroCheckBox5.Checked == true)
            {
                testequipment.Add(metroCheckBox5.Text);
            }
            if (metroCheckBox6.Checked == true)
            {
                testequipment.Add(metroCheckBox6.Text);
            }
            if (metroCheckBox7.Checked == true)
            {
                testequipment.Add(metroCheckBox7.Text);
            }
            if (metroCheckBox8.Checked == true)
            {
                testequipment.Add(metroCheckBox8.Text);
            }
            if (metroCheckBox8.Checked == true)
            {
                testequipment.Add(metroCheckBox8.Text);
            }
            if (metroCheckBox9.Checked == true)
            {
                testequipment.Add(metroCheckBox9.Text);
            }
            if (metroCheckBox10.Checked == true)
            {
                testequipment.Add(metroCheckBox10.Text);
            }
            if (metroCheckBox11.Checked == true)
            {
                testequipment.Add(metroCheckBox11.Text);
            }
            if (metroCheckBox12.Checked == true)
            {
                testequipment.Add(metroCheckBox12.Text);
            }
            if (metroCheckBox13.Checked == true)
            {
                testequipment.Add(metroCheckBox13.Text);
            }
            if (metroCheckBox14.Checked == true)
            {
                testequipment.Add(metroCheckBox14.Text);
            }
        }
    }
}
