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
using System.Reflection;

namespace NovaBiomedicalSoftware
{
    public partial class LogInPage : MetroForm
    {
        // Split line on commas followed by zero or more spaces.
        List<string> listUserNames = new List<string>();
        public string[] fields;

        public bool YesNoSaveDestination;

        public static string currentUser, clientName;

        //public static string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).FullName;
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
            using (StreamReader sr = new StreamReader(MainMenu.appRootDir + "/Employees/names.txt"))
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
            if (userName.Text == "" || clientBox.Text=="")
            {
                MetroFramework.MetroMessageBox.Show(this, "", "Please fill in the details required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                currentUser = userName.Text;
                clientName = clientBox.Text;
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
