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
    public partial class OxyVivaResusBox : MetroForm
    {
        public bool oxyvivaTest_Submit;

        public static string result1, result2, result3, result4, result5, result6, manu1, manu2, manu3,manu4,manu5,manu6,
            modelbox1, modelbox2, modelbox3, modelbox4, modelbox5, modelbox6,typebox1, typebox2, typebox3, typebox4, typebox5, typebox6,
            serialnum1, serialnum2, serialnum3, serialnum4, serialnum5, serialnum6, pressure1;

        //comment box and item box
        public static string comments, items;



        public OxyVivaResusBox()
        {
            InitializeComponent();
            itemsBox.ResetText();
            commentBox.ResetText();
            itemsBox.Visible = false;
            safetyCheck.SelectedTab = performanceVerification;
        }

        private void close1_btn_Click(object sender, EventArgs e)
        {
            oxyvivaTest_Submit = false;
            this.Close();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;
        }

        private void close3_btn_Click(object sender, EventArgs e)
        {
            oxyvivaTest_Submit = false;
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.SelectedItem == null || result_2.SelectedItem == null || result_3.SelectedItem == null ||
                result_4.SelectedItem == null || result_5.SelectedItem == null || result_6.SelectedItem == null || manufacturer1.Text == null || manufacturer2.Text== null || manufacturer3.Text == null || manufacturer4.Text == null || manufacturer5.Text == null || manufacturer6.Text == null ||
                type1.Text == null || type2.Text == null || type3.Text == null || type4.Text == null || type5.Text == null || type6.Text == null || model1.Text == null || model2.Text == null || model3.Text == null ||
                model4.Text == null || model5.Text == null || model6.Text == null || serial1.Text == null|| serial2.Text == null || serial3.Text == null || serial4.Text == null || serial5.Text == null || serial6.Text == null || pressure.Text == null)
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
                manu1 = manufacturer1.Text;
                manu2 = manufacturer2.Text;
                manu3 = manufacturer3.Text;
                manu4 = manufacturer4.Text;
                manu5 = manufacturer5.Text;
                manu6 = manufacturer6.Text;
                typebox1 = type1.Text;
                typebox2 = type2.Text;
                typebox3 = type3.Text;
                typebox4 = type4.Text;
                typebox5 = type5.Text;
                typebox6 = type6.Text;
                modelbox1 = model1.Text;
                modelbox2 = model2.Text;
                modelbox3 = model3.Text;
                modelbox4 = model4.Text;
                modelbox5 = model5.Text;
                modelbox6 = model6.Text;
                serialnum1 = serial1.Text;
                serialnum2 = serial2.Text;
                serialnum3 = serial3.Text;
                serialnum4 = serial4.Text;
                serialnum5 = serial5.Text;
                serialnum6 = serial6.Text;
                pressure1 = pressure.Text;

                //comments box
                comments = commentBox.Text;

                addItems();
                items = itemsBox.Text;

                oxyvivaTest_Submit = true;
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
