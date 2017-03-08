using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        int A = 2, counter =0 ;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createNewItem();

        }

        public System.Windows.Forms.ComboBox createNewItem()
        {
            counter += 1;
            System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
            this.Controls.Add(comboBox);
            comboBox.Name = "wahahaha" + counter.ToString() ;
            comboBox.Top = A * 28;
            comboBox.Left = 50;
            comboBox.Text = comboBox.Name;
            A = A + 1;
            return comboBox;
        }


    }
}
