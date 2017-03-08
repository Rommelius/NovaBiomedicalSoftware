﻿using System;
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
        public string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;


        public AddUserForm()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            Form1 newForm1 = new Form1();
            newForm1.Show();


            using (StreamWriter sw = File.AppendText(appRootDir + "/Employees/names.txt"))
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
