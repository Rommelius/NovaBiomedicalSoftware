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
    public partial class AppliedPartsSelection : MetroForm
    {
        public static string APCommand;

        public static List<string> commandlist = new List<string>();
        public AppliedPartsSelection()
        {
            InitializeComponent();
        }

        private void RA_Click(object sender, EventArgs e)
        {
            if (RA.Style == MetroFramework.MetroColorStyle.Green)
            {
                RA.Style = MetroFramework.MetroColorStyle.Blue;

            }
            else if (RA.Style == MetroFramework.MetroColorStyle.Blue)
            {
                RA.Style = MetroFramework.MetroColorStyle.Green;
            }
            
        }

        private void LL_Click(object sender, EventArgs e)
        {
            if (LL.Style == MetroFramework.MetroColorStyle.Green)
            {
                LL.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else if (LL.Style == MetroFramework.MetroColorStyle.Blue)
            {
                LL.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void LA_Click(object sender, EventArgs e)
        {
            if (LA.Style == MetroFramework.MetroColorStyle.Green)
            {
                LA.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else if (LA.Style == MetroFramework.MetroColorStyle.Blue)
            {
                LA.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void RL_Click(object sender, EventArgs e)
        {
            if (RL.Style == MetroFramework.MetroColorStyle.Green)
            {
                RL.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else if (RL.Style == MetroFramework.MetroColorStyle.Blue)
            {
                RL.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void V2_Click(object sender, EventArgs e)
        {
            if (V2.Style == MetroFramework.MetroColorStyle.Green)
            {
                V2.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else if (V2.Style == MetroFramework.MetroColorStyle.Blue)
            {
                V2.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void V3_Click(object sender, EventArgs e)
        {
            if (V3.Style == MetroFramework.MetroColorStyle.Green)
            {
                V3.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else if (V3.Style == MetroFramework.MetroColorStyle.Blue)
            {
                V3.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void V4_Click(object sender, EventArgs e)
        {
            if (V4.Style == MetroFramework.MetroColorStyle.Green)
            {
                V4.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else if (V4.Style == MetroFramework.MetroColorStyle.Blue)
            {
                V4.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void V5_Click(object sender, EventArgs e)
        {
            if (V5.Style == MetroFramework.MetroColorStyle.Green)
            {
                V5.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else if (V5.Style == MetroFramework.MetroColorStyle.Blue)
            {
                V5.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void V6_Click(object sender, EventArgs e)
        {
            if (V6.Style == MetroFramework.MetroColorStyle.Green)
            {
                V6.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else if (V6.Style == MetroFramework.MetroColorStyle.Blue)
            {
                V6.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void V1_Click(object sender, EventArgs e)
        {
            if (V1.Style == MetroFramework.MetroColorStyle.Green)
            {
                V1.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else if (V1.Style == MetroFramework.MetroColorStyle.Blue)
            {
                V1.Style = MetroFramework.MetroColorStyle.Green;
            }
        }

        private void submit_Btn_Click(object sender, EventArgs e)
        {
            commandlist.Add("AP=");
            if (RA.Style == MetroFramework.MetroColorStyle.Green)
            {
                commandlist.Add("RA");
            }
            if (LL.Style == MetroFramework.MetroColorStyle.Green)
            {
                commandlist.Add("LL");
            }
            if (LA.Style == MetroFramework.MetroColorStyle.Green)
            {
                commandlist.Add("LA");
            }
            if (RL.Style == MetroFramework.MetroColorStyle.Green)
            {
                commandlist.Add("RL");
            }
            if (RA.Style == MetroFramework.MetroColorStyle.Green)
            {
                commandlist.Add("RA");
            }
            if (RA.Style == MetroFramework.MetroColorStyle.Green)
            {
                commandlist.Add("RA");
            }
            if (RA.Style == MetroFramework.MetroColorStyle.Green)
            {
                commandlist.Add("RA");
            }
            if (RA.Style == MetroFramework.MetroColorStyle.Green)
            {
                commandlist.Add("RA");
            }
            if (RA.Style == MetroFramework.MetroColorStyle.Green)
            {
                commandlist.Add("RA");
            }
            if (RA.Style == MetroFramework.MetroColorStyle.Green)
            {
                commandlist.Add("RA");
            }


            commandlist.Add("//OPEN");
        }
    }
}
