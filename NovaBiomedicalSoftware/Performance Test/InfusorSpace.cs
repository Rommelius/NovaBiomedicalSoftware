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
    public partial class InfusorSpace : MetroForm
    {
        public InfusorSpace()
        {
            InitializeComponent();
            safetyCheck.SelectedTab = visualCheck;
            commentBox.ResetText();
            listBox1.Items.Clear();
            foreach (var item in MainMenu.testequipmentlist)
            {
                listBox1.Items.Add(item);
            }

        }
        //note NO 22,23,24 functional check

        public bool infusorTest_Submit;

        //static string for visualCheck
        public static string visualoption1, visualoption2, visualoption3, visualoption4, visualoption5,
            visualoption6, visualoption7, visualoption8;

        //static string for functionalCheck
        public static string functionaloption1, functionaloption2, functionaloption3, functionaloption4,
            functionaloption5, functionaloption6, functionaloption7, functionaloption8, functionaloption9,
            functionaloption10, functionaloption11, functionaloption12, functionaloption13, functionaloption14,
            functionaloption15, functionaloption16, functionaloption17, functionaloption18, functionaloption19,
            functionaloption20, functionaloption21, functionaloption25, functionaloption26, functionaloption27,
            functionaloption28, functionaloption29,
            functionaloption30, functionaloption31, functionaloption32, functionaloption33, functionaloption34,
            functionaloption35, functionaloption36, functionaloption37, functionaloption38,
            functionaloption39, functionaloption40, comments, items, performanceresult;

        private void metroButton2_Click(object sender, EventArgs e)
        {
            foreach (Control item in functionalCheck.Controls)
            {
                if (item is MetroFramework.Controls.MetroComboBox)
                {
                    (item as MetroFramework.Controls.MetroComboBox).SelectedIndex = 0;
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            foreach (Control item in visualCheck.Controls)
            {
                if (item is MetroFramework.Controls.MetroComboBox)
                {
                    (item as MetroFramework.Controls.MetroComboBox).SelectedIndex = 0;
                }
            }
        }

        private void InfusorSpace_SizeChanged(object sender, EventArgs e)
        {
            commentBox.Width = safetyCheck.Width - 10;
            listBox1.Width = safetyCheck.Width - 10;
        }
        private void checkBattery_Click(object sender, EventArgs e)
        {
            BatteryChecker batteryCheck = new BatteryChecker();
            batteryCheck.Show();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = functionalCheck;
        }

        private void close2_btn_Click(object sender, EventArgs e)
        {
            infusorTest_Submit = false;
            this.Close();
        }

        private void close1_btn_Click(object sender, EventArgs e)
        {
            infusorTest_Submit = false;
            this.Close();
        }

        private void submitBtn_Click_1(object sender, EventArgs e)
        {

            //check if the combobox are answered
            if (visual_option1.SelectedItem == null || visual_option2.SelectedItem == null || visual_option3.SelectedItem == null ||
                visual_option4.SelectedItem == null || visual_option5.SelectedItem == null || visual_option6.SelectedItem == null ||
                visual_option7.SelectedItem == null || visual_option8.SelectedItem == null || functionalOption1.SelectedItem == null
                || functionalOption2.SelectedItem == null || functionalOption3.SelectedItem == null || functionalOption4.SelectedItem == null
                || functionalOption5.SelectedItem == null || functionalOption6.SelectedItem == null || functionalOption7.SelectedItem == null
                || functionalOption8.SelectedItem == null || functionalOption9.SelectedItem == null || functionalOption10.SelectedItem == null
                || functionalOption11.SelectedItem == null || functionalOption12.SelectedItem == null || functionalOption13.SelectedItem == null
                || functionalOption14.SelectedItem == null || functionalOption16.SelectedItem == null
                || functionalOption17.SelectedItem == null || functionalOption18.SelectedItem == null || functionalOption19.SelectedItem == null
                || functionalOption20.SelectedItem == null || functionalOption21.SelectedItem == null || functionalOption25.SelectedItem == null
                || functionalOption26.SelectedItem == null || functionalOption27.SelectedItem == null || functionalOption28.SelectedItem == null
                || functionalOption29.SelectedItem == null || functionalOption30.SelectedItem == null || functionalOption31.SelectedItem == null
                || functionalOption32.SelectedItem == null || functionalOption33.SelectedItem == null || functionalOption34.SelectedItem == null
                || functionalOption35.SelectedItem == null || functionalOption36.SelectedItem == null || functionalOption37.SelectedItem == null || functionalOption38.SelectedItem == null
                || functionalOption39.SelectedItem == null || functionalOption40.SelectedItem == null || overall.SelectedItem == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "You need to perform all test.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                performanceresult = overall.Text;
                //visual
                visualoption1 = visual_option1.Text;
                visualoption2 = visual_option2.Text;
                visualoption3 = visual_option3.Text;
                visualoption4 = visual_option4.Text;
                visualoption5 = visual_option5.Text;
                visualoption6 = visual_option6.Text;
                visualoption7 = visual_option7.Text;
                visualoption8 = visual_option8.Text;

                //functional
                functionaloption1 = functionalOption1.Text;
                functionaloption2 = functionalOption2.Text;
                functionaloption3 = functionalOption3.Text;
                functionaloption4 = functionalOption4.Text;
                functionaloption5 = functionalOption5.Text;
                functionaloption6 = functionalOption6.Text;
                functionaloption7 = functionalOption7.Text;
                functionaloption8 = functionalOption8.Text;
                functionaloption9 = functionalOption9.Text;
                functionaloption10 = functionalOption10.Text;
                functionaloption11 = functionalOption11.Text;
                functionaloption12 = functionalOption12.Text;
                functionaloption13 = functionalOption13.Text;
                functionaloption14 = functionalOption14.Text;
                functionaloption16 = functionalOption16.Text;
                functionaloption17 = functionalOption17.Text;
                functionaloption18 = functionalOption18.Text;
                functionaloption19 = functionalOption19.Text;
                functionaloption20 = functionalOption20.Text;
                functionaloption21 = functionalOption21.Text;
                functionaloption25 = functionalOption25.Text;
                functionaloption26 = functionalOption26.Text;
                functionaloption27 = functionalOption27.Text;
                functionaloption28 = functionalOption28.Text;
                functionaloption29 = functionalOption29.Text;
                functionaloption30 = functionalOption30.Text;
                functionaloption31 = functionalOption31.Text;
                functionaloption32 = functionalOption32.Text;
                functionaloption33 = functionalOption33.Text;
                functionaloption34 = functionalOption34.Text;
                functionaloption35 = functionalOption35.Text;
                functionaloption36 = functionalOption36.Text;
                functionaloption37 = functionalOption37.Text;
                functionaloption38 = functionalOption38.Text;
                functionaloption39 = functionalOption39.Text;
                functionaloption40 = functionalOption40.Text;

                //comments box
                comments = commentBox.Text;

                addItems();

                infusorTest_Submit = true;
                this.Hide();
            }
        }

        private void close3_btn_Click(object sender, EventArgs e)
        {
            infusorTest_Submit = false;
            this.Close();
        }

        private void next2_btn_Click(object sender, EventArgs e)
        {
            safetyCheck.SelectedTab = commentsTab;
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

