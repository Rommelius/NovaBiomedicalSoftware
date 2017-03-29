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
using System.IO;

namespace NovaBiomedicalSoftware
{
    public partial class LogInPage : MetroForm
    {
        // Split line on commas followed by zero or more spaces.
        List<string> listUserNames = new List<string>();
        public string[] fields;


        public bool PerformElectricalSafetyTest, PerformPerformanceTest, PerformBothTest, YesNoSaveDestination;
        public bool runProgram, yesNoPerformanceTest, PTisSubmitted, _electricaltestResult, _PTStestResult, class1ASNZtest, class2ASNZtest, ecgclass1ASNZtest, ecgclass2ASNZtest;

        public bool PTpefusorSpaceCompleted, PTECGCompleted, PTNIBPGenericCompleted, PTEdanDopplerCompleted, PTSphygmomanometerCompleted, PTGenius2Completed,
            PTHeineNT300Completed, PTPhilipsMRxCompleted, PTAccusonicAP170Completed, PTComweldOxygenFMCompleted;

        public bool PTtestIsDone;

        public bool earthResistanceFailed, insulationResistanceFailed, earthLeakageFailed1, earthLeakageFailed2, touchCurrentFailed1, touchCurrentFailed2,
            touchCurrentFailed3, touchCurrentFailed4, touchCurrentFailed5, touchCurrentFailed6;

        public static string currentUser;


        //public static string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).FullName;
        public static string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static string saveDestination;


        public LogInPage()
        {
            InitializeComponent();
            this.ActiveControl = userName;
            loadUserName();
        }


        //Function to Load userNames
        public void loadUserName()
        {
            using (StreamReader sr = new StreamReader(Main.appRootDir + "/Employees/names.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listUserNames.Add(line);
                }

                foreach (string username in listUserNames)
                {
                    userName.Items.Add(username);
                }
            }
        }

        private void btnAdduser_Click(object sender, EventArgs e)
        {

            AddUserForm newuser = new AddUserForm();

            DialogResult newuserdg = newuser.ShowDialog();
            if (newuserdg == DialogResult.Cancel)
            {
                userName.Items.Clear();
                listUserNames.Clear();
                loadUserName();
            }
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (userName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "", "Select your Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (YesNoSaveDestination != true)
                {
                    while (YesNoSaveDestination != true)
                    {
                        DialogResult drbox = MetroFramework.MetroMessageBox.Show(this, "", "Please select the folder to save your files", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (drbox == DialogResult.OK)
                        {

                            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                            folderDlg.ShowNewFolderButton = true;
                            // Show the FolderBrowserDialog.

                            DialogResult result = folderDlg.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                YesNoSaveDestination = true;
                                saveDestination = folderDlg.SelectedPath;
                            }
                        }
                    }
                }

                MainMenu _main = new NovaBiomedicalSoftware.MainMenu();
                _main.Show();
                this.Hide();
            }

        }
    }
}
