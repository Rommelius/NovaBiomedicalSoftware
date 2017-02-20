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
        public string _currentTest, _testPDF, _earthResistance, _versionNumber, _MV1, _MV2, _MV3, _insulationResistance,
    _EL1, _EL2, _EnL1, _EnL2, _EnL3, _EnL4, _EnL5, _EnL6, PLT1, PLT2, PLT3, SFN, _electricalResult, _PTSResult, _currentCOMPort, set_sig;


        public double _earthResistance_double, _EL1_double, _EL2_double, _EnL1_double, _EnL2_double, _EnL3_double,
         _EnL4_double, _EnL5_double, _EnL6_double, PLT1_double, PLT2_double, PLT3_double, SFN_double;


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
            statusBar.Enabled = true;
            statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            statusBar.PerformStep();

            Thread doTestnow = new Thread(doTest);

            doTestnow.Start();

        }

        
        public void doTest()
        {
            initialisedDevice();
            getVersionNumber();
            mainsVoltage();
            earthResistance();
            insulationResistance();
            earthLeakage();
            enclousureLeakage();
            testComplete();

            //invoke all the prompts after        
        }

        public void testComplete()
        {
            this.Invoke((MethodInvoker)delegate
            {
                //show complete
                statusText.Text = "Test Completed for: XXXXXXX";


                //show diaglog
                DialogResult question1 = MessageBox.Show("Would you like to do Performance Test?",
                "Question", MessageBoxButtons.YesNo);


                //show perfomance test form if accepted
                //Performance_Test performance_test = new Performance_Test();

                if (question1 == DialogResult.Yes)
                {
                    statusText.Text = "Pressed YES";
                    //DialogResult dr = performance_test.ShowDialog();
                    //if (dr == DialogResult.Cancel)
                    //{
                    //    //makePDF();
                    //}

                    this.Invoke((MethodInvoker)delegate
                    {
                        statusBar.ProgressBarStyle = ProgressBarStyle.Blocks;

                        statusBar.Value = 0;
                        statusText.Text = "Test Completed - Class 1";
                    });
                }
                else
                {
                    MessageBox.Show("Nova Biomedical - Fluke ESA620", "Test Completed for: XXXXXXXX");
                    //makePDF();
                }
            });
        }

        public void initialisedDevice()
        {
            this.Invoke((MethodInvoker)delegate
            {

                statusText.Text = "Initialising...";

            });

            mySerialPort.WriteLine("LOCAL");

            Thread.Sleep(1000);
        }

        public void getVersionNumber()
        {
            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("IDENT");
            Thread.Sleep(1000);
            _versionNumber = mySerialPort.ReadExisting();
            this.Invoke((MethodInvoker)delegate
            {

                debug_box.AppendText(_versionNumber);

            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);
        }

        public void mainsVoltage()
        {

            this.Invoke((MethodInvoker)delegate
            {

                statusText.Text = "Mains Voltage Test...";
                
            });

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("MAINS=L1-L2");
            Thread.Sleep(1000);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1000);
            _MV1 = mySerialPort.ReadExisting();

            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_MV1);
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);


            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("MAINS=L2-GND");
            Thread.Sleep(1000);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1000);
            _MV2 = mySerialPort.ReadExisting();
            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_MV2);
            }); mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);



            //send command
            mySerialPort.WriteLine("REMOTE");

            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("MAINS=L1-GND");
            Thread.Sleep(1000);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1000);
            _MV3 = mySerialPort.ReadExisting();
            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_MV3);
            }); mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);

            this.Invoke((MethodInvoker)delegate
            {
                statusText.Text = "Mains Voltage Test Complete";

            });

        }

        public void earthResistance()
        {
            this.Invoke((MethodInvoker)delegate
            {
                statusText.Text = "Protective Earth Test...";
                statusBar.Enabled = true;
                statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            });

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("ERES=HIGH");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("RWIRE=2");
            Thread.Sleep(1000);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1000);
            _earthResistance = mySerialPort.ReadExisting();
            Match _earthResistance_m = Regex.Match(_earthResistance, @"^-?\d*\.?\d*");
            _earthResistance_double = Double.Parse(_earthResistance_m.Value);

            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_earthResistance_double.ToString());

            });

            mySerialPort.WriteLine("LOCAL");

        }

        public void insulationResistance()
        {
            this.Invoke((MethodInvoker)delegate
            {
                statusText.Text = "Insulation Resistance Test...";
            });
            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("MINS");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("INS=HIGH");
            Thread.Sleep(1000);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Task.WaitAll(Task.Delay(1000));
            _insulationResistance = mySerialPort.ReadExisting();
            if (string.Compare(_insulationResistance, "!21") == -1)
            {
                _insulationResistance = ">100 MOhms";
                this.Invoke((MethodInvoker)delegate
                {
                    debug_box.AppendText(_insulationResistance);
                });
            }
            else
            {
                _insulationResistance = "FAILED";
                this.Invoke((MethodInvoker)delegate
                {
                    debug_box.AppendText(_insulationResistance);
                });
            }
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);
        }

        public void earthLeakage()
        {
            this.Invoke((MethodInvoker)delegate
            {
                statusText.Text = "Earth Leakage Current Test...";
            });
            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("EARTHL");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=N");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _EL1 = mySerialPort.ReadExisting();
            Match _el1_m = Regex.Match(_EL1, @"^-?\d*\.?\d*");
            _EL1_double = Double.Parse(_el1_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_EL1_double.ToString());
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("EARTHL");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=N");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=O");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _EL2 = mySerialPort.ReadExisting();
            Match _el2_m = Regex.Match(_EL2, @"^-?\d*\.?\d*");
            _EL2_double = Double.Parse(_el2_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_EL2_double.ToString());
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);
        }

        void enclousureLeakage()
        {
            this.Invoke((MethodInvoker)delegate
            {
                statusText.Text = "Enclousure Leakage Current Test...";
            });

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("ENCL");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("EARTH=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=N");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _EnL1 = mySerialPort.ReadExisting();
            Match _enl1_m = Regex.Match(_EnL1, @"^-?\d*\.?\d*");
            _EnL1_double = Double.Parse(_enl1_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_EnL1_double.ToString());
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("ENCL");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("EARTH=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=N");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=O");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _EnL2 = mySerialPort.ReadExisting();
            Match _enl2_m = Regex.Match(_EnL2, @"^-?\d*\.?\d*");
            _EnL2_double = Double.Parse(_enl2_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_EnL2_double.ToString());
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("ENCL");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("EARTH=O");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=N");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _EnL3 = mySerialPort.ReadExisting();
            Match _enl3_m = Regex.Match(_EnL3, @"^-?\d*\.?\d*");
            _EnL3_double = Double.Parse(_enl3_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_EnL3_double.ToString());
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("ENCL");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("EARTH=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=R");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _EnL4 = mySerialPort.ReadExisting();
            Match _enl4_m = Regex.Match(_EnL4, @"^-?\d*\.?\d*");
            _EnL4_double = Double.Parse(_enl4_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_EnL4_double.ToString());
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("ENCL");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("EARTH=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=R");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=O");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _EnL5 = mySerialPort.ReadExisting();
            Match _enl5_m = Regex.Match(_EnL5, @"^-?\d*\.?\d*");
            _EnL5_double = Double.Parse(_enl5_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_EnL5_double.ToString());
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1000);
            mySerialPort.WriteLine("ENCL");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("EARTH=O");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=R");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _EnL6 = mySerialPort.ReadExisting();
            Match _enl6_m = Regex.Match(_EnL6, @"^-?\d*\.?\d*");
            _EnL6_double = Double.Parse(_enl6_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                debug_box.AppendText(_EnL6_double.ToString());
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);





        }
    }
}
