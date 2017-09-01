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
    public partial class GenericDefibrillator : MetroForm
    {
        public bool philipsMrxTest_Submit;

        public static string result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15, result16,
            result17, result18, result19, result20, result21, result22, result23, performanceresult;

        private void metroButton1_Click(object sender, EventArgs e)
        {
            foreach (Control item in panel1.Controls)
            {
                if (item is MetroFramework.Controls.MetroComboBox)
                {
                    (item as MetroFramework.Controls.MetroComboBox).SelectedIndex = 0;
                }
            }
        }

        private void GenericDefibrillator_SizeChanged(object sender, EventArgs e)
        {
            
            commentBox.Width = safetyCheck.Width - 10;
            listBox1.Width = safetyCheck.Width - 10;
            panel1.Height = metroPanel2.Location.Y - 20;
        }

        //comment box and item box
        public static string comments, items;

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //check if the combobox are answered
            if (result_1.SelectedItem == null || result_2.SelectedItem == null || result_3.Text == "" ||
                result_4.Text == "" || result_5.Text == "" || result_6.Text == "" || result_7.Text == "" ||
                result_8.Text == "" || result_9.Text == "" || result_10.Text == "" || result_11.Text == "" ||
                result_12.Text == "" || result_13.Text == "" || result_14.SelectedItem == null || result_15.SelectedItem == null ||
                result_16.SelectedItem == null || result_17.SelectedItem == null || result_18.SelectedItem == null || result_19.SelectedItem == null ||
                result_20.SelectedItem == null || result_21.SelectedItem == null || result_22.SelectedItem == null || result_23.SelectedItem == null||overall.SelectedItem == null)
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

                performanceresult = overall.Text;

                //comments box
                comments = commentBox.Text;

                addItems();

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





        public GenericDefibrillator()
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
