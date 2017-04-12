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

namespace NovaBiomedicalSoftware
{
    public partial class PatientLeakageCurrentType : MetroForm
    {
        public static bool typeCF, typeBF, typeB;


        public PatientLeakageCurrentType()
        {
            InitializeComponent();
        }

        private void typeCF_btn_Click(object sender, EventArgs e)
        {
            typeCF = true;
            typeBF = false;
            typeB = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void typeBF_btn_Click(object sender, EventArgs e)
        {
            typeCF = false;
            typeBF = true;
            typeB = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void typeB_btn_Click(object sender, EventArgs e)
        {
            typeCF = false;
            typeBF = false;
            typeB = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
