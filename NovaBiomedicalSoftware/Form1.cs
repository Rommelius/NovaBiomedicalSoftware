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
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace NovaBiomedicalSoftware
{
    public partial class Form1 : MetroForm
    {
        static SerialPort mySerialPort;
        DateTime date = DateTime.Today;
        private delegate void SetTextDeleg(string text);

        public string COMPORTNUMBER;

        


        public Form1()
        {
            InitializeComponent();

            //disable all background
            tabMenu.Enabled = false;
            newproductBtn.Enabled = false;
            statusText.Text = "Please fill in the details";
            statusBar.Visible = false;

            ActiveControl = assetNumber;
            assetNumber.Focus();

            //set first prompt location
            firstPrompt.Location = new Point(219, 103);
        }

        ///connect to SerialCOM
        public void ConnectToSerial()
        {
            mySerialPort = new SerialPort();

            List<string> names = COMFinder.ComPortNames("0403", "6001");
            if (names.Count > 0)
            {
                foreach (String s in SerialPort.GetPortNames())
                {
                    if (names.Contains(s))
                    {
                        mySerialPort.PortName = s;
                    }

                }
            }
            
            //serial setup
            mySerialPort.BaudRate = 115200;
            mySerialPort.Parity = Parity.None;
            mySerialPort.DataBits = 8;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.Handshake = Handshake.XOnXOff;
            mySerialPort.DtrEnable = true;
            mySerialPort.RtsEnable = true;

            try
            {
                mySerialPort.Close();
                mySerialPort.Open();
                if (mySerialPort.IsOpen)
                {
                    statusText.Text = "Connected!";
                }
            }
            catch (IOException)
            {
                statusText.Text = "Error - No Fluke ESA620";

                DialogResult noflukeQuestion = MessageBox.Show("Please connect the Fluke on your computer then press Retry",
                "Error", MessageBoxButtons.RetryCancel);

                if (noflukeQuestion == DialogResult.Retry)
                {
                    ConnectToSerial();
                }
                else
                {
                    this.Close();
                }
            }
        }

        public void clearBtn_1_Click(object sender, EventArgs e)
        {
            assetNumber.Text = "";
            serialNumber.Text = "";
            location.Text = "";
            model.Text = "";

            assetNumber.Focus();
        }

        public void submitBtn_Click(object sender, EventArgs e)
        {
            if (assetNumber.Text == "" || serialNumber.Text == "" || location.Text == "" 
                || model.Text == "" || userName.Text == "")
            {
                MessageBox.Show("Please fill all the details required");
            }
            else
            {
                firstPrompt.Visible = false;
                tabMenu.SelectedTab = estTab;
                tabMenu.Enabled = true;
                newproductBtn.Enabled = true;
                statusBar.Visible = true;
                statusText.Text = "Hello " + userName.Text;

                ConnectToSerial();
            }
        }

        public void newproductBtn_Click(object sender, EventArgs e)
        {
            this.ActiveControl = assetNumber;
            firstPrompt.Visible = true;
            firstPrompt.Location = new Point(219, 103);
            tabMenu.Enabled = false;
        }

        public void assetNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                serialNumber.Focus();
        }

        public void serialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.Focus();
        }

        public void model_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                location.Focus();
        }

        private void class1testBtn_Click(object sender, EventArgs e)
        {
            Thread earthResistanceTest = new Thread(new ThreadStart(earthResistance));







            earthResistanceTest.Start();     
        }


        public void earthResistance()
        {
            this.Invoke((MethodInvoker)delegate {
                statusText.Text = "Earth Resist";
                statusBar.Enabled = true;
                statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            });

            //invoke
            //test_status.Text = "Protective Earth Test...";
            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("ERES=HIGH");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("RWIRE=2");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            //_earthResistance = mySerialPort.ReadExisting();
            // Match _earthResistance_m = Regex.Match(_earthResistance, @"^-?\d*\.?\d*");
            // _earthResistance_double = Double.Parse(_earthResistance_m.Value);
            // debug_box.AppendText(_earthResistance_double.ToString());

            mySerialPort.WriteLine("LOCAL");

            this.Invoke((MethodInvoker)delegate {
                statusBar.ProgressBarStyle = ProgressBarStyle.Blocks;

                statusBar.Value = 0;
            });
        }


    }
}
