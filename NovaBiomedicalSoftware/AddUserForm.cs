using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.IO;

namespace NovaBiomedicalSoftware
{
    public partial class AddUserForm : MetroForm
    {

        public AddUserForm()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.AppendText(MainMenu.appRootDir + "/Employees/names.txt"))
            {

                if (newUser.Text != null)
                {
                    sw.Write(Environment.NewLine+ newUser.Text);
                }

            }
            this.Close();
        }

    }
}
