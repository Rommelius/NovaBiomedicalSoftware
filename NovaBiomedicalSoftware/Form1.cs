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
using Word = Microsoft.Office.Interop.Word;
using System.Collections;
using NovaBiomedicalSoftware.Performance_Test;

namespace NovaBiomedicalSoftware
{

    public partial class Form1 : MetroForm
    {
        public bool PerformElectricalSafetyTest, PerformPerformanceTest, PerformBothTest, YesNoSaveDestination;
        public bool runProgram, yesNoPerformanceTest, PTisSubmitted, _electricaltestResult, _PTStestResult, class1ASNZtest, class2ASNZtest, ecgclass1ASNZtest, ecgclass2ASNZtest;

        public bool PTpefusorSpaceCompleted, PTECGCompleted, PTNIBPGenericCompleted, PTEdanDopplerCompleted, PTSphygmomanometerCompleted, PTGenius2Completed;

        public bool PTtestIsDone;


        // Split line on commas followed by zero or more spaces.
        List<string> listUserNames = new List<string>();
        public string[] fields;
        public string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
        public string saveDestination;

        static SerialPort mySerialPort;
        DateTime date = DateTime.Today;
        private delegate void SetTextDeleg(string text);

        public string kindofPerformanceTest, ESTResults, COMPORTNUMBER, _kindofElectricalSafetyTest, _earthResistance, _versionNumber, _MV1, _MV2, _MV3, _insulationResistance,
        _EL1, _EL2, _EnL1, _EnL2, _EnL3, _EnL4, _EnL5, _EnL6, PLT1, PLT2, PLT3, SFN, _PTSResult, _currentCOMPort, set_sig;



        public double _earthResistance_double, _EL1_double, _EL2_double, _EnL1_double, _EnL2_double, _EnL3_double,
         _EnL4_double, _EnL5_double, _EnL6_double, PLT1_double, PLT2_double, PLT3_double, SFN_double;


        private void bothTile_Click(object sender, EventArgs e)
        {

            //set parameters for bool
            PerformBothTest = true;
            PerformElectricalSafetyTest = false;
            PerformPerformanceTest = false;
            tabMenu.SelectedTab = estTab;

        }

        private void performanceTestTile_Click(object sender, EventArgs e)
        {
            //set parameters for bool
            PerformPerformanceTest = true;
            PerformElectricalSafetyTest = false;
            PerformBothTest = false;
            tabMenu.SelectedTab = ptTab;

        }

        private void electricalSafetyTile_Click(object sender, EventArgs e)
        {
            //set parameters for bool
            PerformElectricalSafetyTest = true;
            PerformPerformanceTest = false;
            PerformBothTest = false;
            tabMenu.SelectedTab = estTab;
            ConnectToSerial();

        }

        public Form1()
        {
            InitializeComponent();
            
            //set first prompt location
            firstPrompt.Location = new Point(13, 25);

            ActiveControl = assetNumber;
            assetNumber.Focus();

            loadUserName();
            //disable all background
            tabMenu.Enabled = false;
            newproductBtn.Enabled = false;
            statusText.Visible = false;
            statusBar.Hide();
        }

        //connect to SerialCOM
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

                DialogResult noflukeQuestion = MetroFramework.MetroMessageBox.Show(this,"Please connect the Fluke on your computer then press Retry",
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

        //Function to Load userNames
        public void loadUserName()
        {
            using (StreamReader sr = new StreamReader(appRootDir + "/Employees/names.txt"))
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

        //Global Controls
        public void clearBtn_1_Click(object sender, EventArgs e)
        {
            assetNumber.Text = "";
            serialNumber.Text = "";
            location.Text = "";
            model.Text = "";
            manufacturer.Text = "";

            assetNumber.Focus();
        }

        public void submitBtn_Click(object sender, EventArgs e)
        {
            if (assetNumber.Text == "" || serialNumber.Text == "" || location.Text == ""
                || model.Text == "" || userName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please fill all the details required");
            }
            else
            {
                if (YesNoSaveDestination != true)
                {
                    while (YesNoSaveDestination != true)
                    {
                        DialogResult drbox = MetroFramework.MetroMessageBox.Show(this, "Please select the folder to save your files");

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
                                saveFolder.Text = "Folder Destination: " + folderDlg.SelectedPath;
                            }
                        }
                    }
                   
                
                }
                firstPrompt.Visible = false;
                tabMenu.SelectedTab = initialTab;
                tabMenu.Enabled = true;
                newproductBtn.Enabled = true;
                statusText.Text = "Hello " + userName.Text;
                
            }
        }

        public void newproductBtn_Click(object  sender, EventArgs e)
        {
            PTtestIsDone = false;
            assetNumber.Focus();
            firstPrompt.Visible = true;
            firstPrompt.Location = new Point(13, 25);
            tabMenu.Enabled = false;
            if (PerformBothTest == true || PerformElectricalSafetyTest == true)
            {
                mySerialPort.Close();
            }


            //get rid of all booleans for performance test
            PTpefusorSpaceCompleted = false;
            PTECGCompleted = false;
            PTNIBPGenericCompleted = false;
            PTEdanDopplerCompleted = false;
            PTSphygmomanometerCompleted = false;
            PTGenius2Completed = false;

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
                manufacturer.Focus();
        }

        private void manufacturer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                location.Focus();
        }

        private void location_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (assetNumber.Text == "" || serialNumber.Text == "" || location.Text == ""
                    || model.Text == "" || userName.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this,"Please fill all the details required");
                }
                else
                {
                    firstPrompt.Visible = false;
                    tabMenu.SelectedTab = estTab;
                    tabMenu.Enabled = true;
                    newproductBtn.Enabled = true;
                    statusText.Text = "Hello " + userName.Text;
                    ConnectToSerial();
                }
            }
                
        }

        //Manual Test

        private void buttonPE_Click(object sender, EventArgs e)
        {
            Thread PE_test = new Thread(PETest);

            PE_test.Start();
        }

        private void PETest()
        {
            earthResistance();
        }

        
        // Class Test Buttons Click Events:
        private void class1testBtn_Click(object sender, EventArgs e)
        {
            statusBar.Show();
            statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            statusBar.MarqueeAnimationSpeed = 30;

            _kindofElectricalSafetyTest = "AS NZS 3551 – Class 1";
            class1ASNZtest = true;

            Thread class1NTest = new Thread(class1NormalTest);

            class1NTest.Start();


        }

        private void class2testBtn_Click(object sender, EventArgs e)
        {
            statusBar.Show();
            statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            statusBar.MarqueeAnimationSpeed = 30;

            _kindofElectricalSafetyTest = "AS NZS 3551 – Class 2";
            class2ASNZtest = true;

            Thread class2NTest = new Thread(class2NormalTest);

            class2NTest.Start();
        }


        // Performance Test Button Click Events:
        private void bbraunPerfusor_Click(object sender, EventArgs e)
        {
            while (PTtestIsDone == false)
            {
                perfusorSpace perfusorSpaceTest = new perfusorSpace();
                DialogResult perfusorSpaceTestDR = perfusorSpaceTest.ShowDialog();
                if (perfusorSpaceTestDR == DialogResult.Cancel)
                {
                    if (perfusorSpaceTest.perfusorTest_Submit == true)
                    {
                        yesNoPerformanceTest = true;
                        PTtestIsDone = true;
                        PTpefusorSpaceCompleted = true;
                        createReport();
                    }
                    else
                    {
                        DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this,"Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            yesNoPerformanceTest = false;
                            PTtestIsDone = false;

                            MetroFramework.MetroMessageBox.Show(this, "Performance Test Cancelled - No Report");
                            break;
                        }
                    }
                }

            }
        }

        private void ptECG_Click(object sender, EventArgs e)
        {
            while (PTtestIsDone == false)
            {
                GenericECG ecg = new GenericECG();
                DialogResult dialog1 = ecg.ShowDialog();
                if (dialog1 == DialogResult.Cancel)
                {
                    if (ecg.ecgTest_Submit == true)
                    {
                        yesNoPerformanceTest = true;
                        PTtestIsDone = true;
                        PTECGCompleted = true;
                        createReport();
                    }
                    else
                    {
                        DialogResult dialog2 = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo);
                        if (dialog2 == DialogResult.Yes)
                        {
                            yesNoPerformanceTest = false;
                            PTtestIsDone = false;
                            MetroFramework.MetroMessageBox.Show(this, "Performance Test Cancelled - No Report");
                            break;
                        }
                    }
                }

            }
        }

        private void ptNIBP_Click(object sender, EventArgs e)
        {
            while (PTtestIsDone == false)
            {
                GenericNIBPMonitor dg = new GenericNIBPMonitor();
                DialogResult dialog1 = dg.ShowDialog();
                if (dialog1 == DialogResult.Cancel)
                {
                    if (dg.nibpTest_Submit == true)
                    {
                        yesNoPerformanceTest = true;
                        PTtestIsDone = true;
                        PTNIBPGenericCompleted = true;
                        createReport();
                    }
                    else
                    {
                        DialogResult dialog2 = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo);
                        if (dialog2 == DialogResult.Yes)
                        {
                            yesNoPerformanceTest = false;
                            PTtestIsDone = false;
                            MetroFramework.MetroMessageBox.Show(this, "Performance Test Cancelled - No Report");
                            break;
                        }
                    }
                }

            }
        }

        private void eddanDoppler_btn_Click(object sender, EventArgs e)
        {
            while (PTtestIsDone == false)
            {
                EdanDoppler dg = new EdanDoppler();
                DialogResult dialog1 = dg.ShowDialog();
                if (dialog1 == DialogResult.Cancel)
                {
                    if (dg.edanTest_Submit == true)
                    {
                        yesNoPerformanceTest = true;
                        PTtestIsDone = true;
                        PTEdanDopplerCompleted = true;
                        createReport();
                    }
                    else
                    {
                        DialogResult dialog2 = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo);
                        if (dialog2 == DialogResult.Yes)
                        {
                            yesNoPerformanceTest = false;
                            PTtestIsDone = false;
                            MetroFramework.MetroMessageBox.Show(this, "Performance Test Cancelled - No Report");
                            break;
                        }
                    }
                }

            }
        }

        private void sphygmomanometer_btn_Click(object sender, EventArgs e)
        {
            while (PTtestIsDone == false)
            {
                GenericSphygmomanometer dg = new GenericSphygmomanometer();
                DialogResult dialog1 = dg.ShowDialog();
                if (dialog1 == DialogResult.Cancel)
                {
                    if (dg.sphygmomanometerTest_Submit == true)
                    {
                        yesNoPerformanceTest = true;
                        PTtestIsDone = true;
                        PTSphygmomanometerCompleted = true;
                        createReport();
                    }
                    else
                    {
                        DialogResult dialog2 = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo);
                        if (dialog2 == DialogResult.Yes)
                        {
                            yesNoPerformanceTest = false;
                            PTtestIsDone = false;
                            MetroFramework.MetroMessageBox.Show(this, "Performance Test Cancelled - No Report");
                            break;
                        }
                    }
                }

            }
        }


        private void genius2_btn_Click(object sender, EventArgs e)
        {
            while (PTtestIsDone == false)
            {
                Genius2Thermometer dg = new Genius2Thermometer();
                DialogResult dialog1 = dg.ShowDialog();
                if (dialog1 == DialogResult.Cancel)
                {
                    if (dg.genius2Test_Submit == true)
                    {
                        yesNoPerformanceTest = true;
                        PTtestIsDone = true;
                        PTGenius2Completed = true;
                        createReport();
                    }
                    else
                    {
                        DialogResult dialog2 = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo);
                        if (dialog2 == DialogResult.Yes)
                        {
                            yesNoPerformanceTest = false;
                            PTtestIsDone = false;
                            MetroFramework.MetroMessageBox.Show(this, "Performance Test Cancelled - No Report");
                            break;
                        }
                    }
                }

            }
        }

        // Test Functions:
        public void class1NormalTest()
        {
            initialisedDevice();
            getVersionNumber();
            mainsVoltage();
            earthResistance();
            insulationResistance();
            enclousureLeakage();
            earthLeakage();
            testComplete();
        }

        public void class2NormalTest()
        {
            initialisedDevice();
            getVersionNumber();
            mainsVoltage();
            insulationResistance();
            enclousureLeakage();
            testComplete();
        }

        // Electrical Test Complete Function
        public void testComplete()
        {

            this.Invoke((MethodInvoker)delegate
            {
                

                statusBar.Hide();

                //show complete
                statusText.Text = "Test Completed";

                if (PerformBothTest == true)
                {
                    statusText.Text = "Please select the equipment";
                    tabMenu.SelectedTab = ptTab;
                    yesNoPerformanceTest = true;
                }

                if (PerformPerformanceTest == true)
                {
                    yesNoPerformanceTest = true;
                    createReport();
                }

                if (PerformElectricalSafetyTest == true)
                {
                    yesNoPerformanceTest = false;
                    createReport();
                }

            });
        }

        // Serial Communication for the FLUKE ESA620 with real-time checker
        #region CommunicationToFluke
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

                labelAnsurVersion.Text = _versionNumber;

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
                labelM1.ForeColor = Color.Green;
                labelM1.Text = _MV1;
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
                labelM2.ForeColor = Color.Green;
                labelM2.Text = _MV2;
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
                labelM3.ForeColor = Color.Green;
                labelM3.Text = _MV3;
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
            Double.TryParse(_earthResistance_m.Value, out _earthResistance_double);
            //_earthResistance_double = Double.Parse(_earthResistance_m.Value);

            this.Invoke((MethodInvoker)delegate
            {

                if (_earthResistance_double > 0.2)
                {
                    buttonPE.Visible = true;
                    Thread.CurrentThread.Interrupt();
                    labelPE.Text = _earthResistance_double.ToString() + " OHMS";
                    labelPE.ForeColor = Color.Red;
                    MetroFramework.MetroMessageBox.Show(this,"Manually do the test to try again", "Earth Resistance Test Failed");
                }
                else
                {
                    labelPE.Text = _earthResistance_double.ToString() + " OHMS";
                    labelPE.ForeColor = Color.Green;
                }

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
            Thread.Sleep(5000);
            _insulationResistance = mySerialPort.ReadExisting();
            if (string.Compare(_insulationResistance, "!21") == -1)
            {
                _insulationResistance = ">100 MOhms";
                this.Invoke((MethodInvoker)delegate
                {
                    labelIR.Text = _insulationResistance;
                });
            }
            else
            {
                _insulationResistance = "FAILED";
                this.Invoke((MethodInvoker)delegate
                {
                    Thread.CurrentThread.Abort();
                    MetroFramework.MetroMessageBox.Show(this,"Manually do the test to try again", "Insulation Resistance Test Failed");
                    labelIR.ForeColor = Color.Red;
                    labelIR.Text = _insulationResistance;
                    buttonIR.Visible = true;
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
                if (_EL1_double > 500)
                {
                    Thread.CurrentThread.Abort();
                    MetroFramework.MetroMessageBox.Show(this,"Manually do the test to try again", "Earth Leakage Current (Normal Condition) Test Failed");
                    labelEL1.Text = _EL1_double.ToString() + " uA";
                    labelEL1.ForeColor = Color.Red;
                    buttonEL1.Visible = true;
                }
                else
                {
                    labelEL1.Text = _EL1_double.ToString() + " uA";
                }
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
                if (_EL2_double > 1000)
                {
                    Thread.CurrentThread.Abort();
                    MetroFramework.MetroMessageBox.Show(this,"Manually do the test to try again", "Earth Leakage Current (Open Neutral) Test Failed");
                    labelEL2.Text = _EL2_double.ToString() + " uA";
                    labelEL2.ForeColor = Color.Red;
                    buttonEL2.Visible = true;
                }
                else
                    labelEL2.Text = _EL2_double.ToString() + " uA";
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);
        }

        public void enclousureLeakage()
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
                if (_EnL1_double > 100)
                {
                    Thread.CurrentThread.Abort();
                    MetroFramework.MetroMessageBox.Show(this,"Manually do the test to try again", "Enclousure Leakage Current (Normal Condition) Test Failed");
                    labelEnL1.Text = _EnL1_double.ToString() + " uA";
                    labelEnL1.ForeColor = Color.Red;
                    buttonEnL1.Visible = true;
                }
                else
                    labelEnL1.Text = _EnL1_double.ToString() + " uA";
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
                if (_EnL2_double > 500)
                {
                    Thread.CurrentThread.Abort();
                    MetroFramework.MetroMessageBox.Show(this,"Manually do the test to try again", "Enclousure Leakage Current (Open Neutral) Test Failed");
                    labelEnL2.Text = _EnL2_double.ToString() + " uA";
                    labelEnL2.ForeColor = Color.Red;
                    buttonEnL2.Visible = true;
                }
                else
                    labelEnL2.Text = _EnL2_double.ToString() + " uA";
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
                if (_EnL3_double > 500)
                {
                    Thread.CurrentThread.Abort();
                    MetroFramework.MetroMessageBox.Show(this,"Manually do the test to try again", "Enclousure Leakage Current (Open Earth) Test Failed");
                    labelEnL3.Text = _EnL3_double.ToString() + " uA";
                    labelEnL3.ForeColor = Color.Red;
                    buttonEnL3.Visible = true;
                }
                else
                    labelEnL3.Text = _EnL3_double.ToString() + " uA";
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
                if (_EnL4_double > 100)
                {
                    Thread.CurrentThread.Abort();
                    MetroFramework.MetroMessageBox.Show(this,"Manually do the test to try again", "Enclousure Leakage Current (Normal Condition, Reversed Mains) Test Failed");
                    labelEnL4.Text = _EnL4_double.ToString() + " uA";
                    labelEnL4.ForeColor = Color.Red;
                    buttonEnL4.Visible = true;
                }
                else
                    labelEnL4.Text = _EnL4_double.ToString() + " uA";
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
                if (_EnL5_double > 500)
                {
                    Thread.CurrentThread.Abort();
                    MetroFramework.MetroMessageBox.Show(this,"Manually do the test to try again", "Enclousure Leakage Current (Open Neutral, Reversed Mains) Test Failed");
                    labelEnL5.Text = _EnL5_double.ToString() + " uA";
                    labelEnL5.ForeColor = Color.Red;
                    buttonEnL5.Visible = true;
                }
                else
                    labelEnL5.Text = _EnL5_double.ToString() + " uA";
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
                if (_EnL6_double > 500)
                {
                    Thread.CurrentThread.Abort();
                    MetroFramework.MetroMessageBox.Show(this,"Manually do the test to try again", "Enclousure Leakage Current (Open Earth, Reversed Mains) Test Failed");
                    labelEnL6.Text = _EnL6_double.ToString() + " uA";
                    labelEnL6.ForeColor = Color.Red;
                    buttonEnL6.Visible = true;
                }
                else
                    labelEnL6.Text = _EnL6_double.ToString() + " uA";
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);





        } 
        #endregion

        //Create a Report
        public void createReport()
        {

            if (class1ASNZtest == true)
            {
                if (_earthResistance_double > 0.2 || _EL1_double > 5000
                    || _EL2_double > 10000 || _EnL1_double > 100 || _EnL2_double > 500 || _EnL3_double > 500
                    || _EnL4_double > 100 || _EnL5_double > 500 || _EnL6_double > 500 || _insulationResistance == "FAILED"
                    || _earthResistance_double == 0 || _EL1_double == 0 || _EL2_double == 0 || _EnL1_double == 0 || _EnL2_double == 0 || _EnL3_double == 0
                    || _EnL4_double == 0 || _EnL5_double == 0 || _EnL6_double == 0 || _insulationResistance == null)
                {
                    
                    _electricaltestResult = false;
                }
                else
                {
                    ESTResults = "PASS";
                    _electricaltestResult = true;

                }
            }
            if (class2ASNZtest == true)
            {
                if (_EnL1_double > 100 || _EnL2_double > 500 || _EnL3_double > 500
                    || _EnL4_double > 100 || _EnL5_double > 500 || _EnL6_double > 500 || _insulationResistance == "FAILED"
                    || _EnL1_double == 0 || _EnL2_double == 0 || _EnL3_double == 0
                    || _EnL4_double == 0 || _EnL5_double == 0 || _EnL6_double == 0 || _insulationResistance == null)
                {
                    _electricaltestResult = false;
                }
                else
                {
                    ESTResults = "PASS";
                    _electricaltestResult = true;

                }
            }

            if (PerformBothTest == true)
            {
                editElectricalSafetyTemplate(appRootDir + "/Report Templates/temp.docx");
                editPerformanceTemplate(appRootDir + "/Report Templates/temp2.docx");
                combineBothTemplate();
                MetroFramework.MetroMessageBox.Show(this,"Report is done");
            }
            if (PerformPerformanceTest == true)
            {
                editPerformanceTemplate(appRootDir + "/Report Templates/temp2.docx");
                MetroFramework.MetroMessageBox.Show(this,"Report is done");
            }
            if (PerformElectricalSafetyTest == true)
            {
                editElectricalSafetyTemplate(appRootDir + "/Report Templates/temp.docx");
                MetroFramework.MetroMessageBox.Show(this,"Report is done");

            }


        }


        private void combineBothTemplate()
        {
            //Setup the Word.Application class.
            Word.Application wordApp =
                new Word.Application();

            //set objects
            object missing = System.Reflection.Missing.Value;
            object what = Word.WdGoToItem.wdGoToLine;
            object which = Word.WdGoToDirection.wdGoToLast;
            //Set Word to be not visible.
            wordApp.Visible = false;

            //open temp1 docx - electrical safety
            Word.Document wDoc1 = wordApp.Documents.Open(appRootDir + "/Report Templates/temp.docx");
            //open temp2 docx - performance test
            Word.Document wDoc2 = wordApp.Documents.Open(appRootDir + "/Report Templates/temp2.docx");

            wDoc2.Activate();
            Word.Range docRange = wDoc2.Content;

            docRange.Select();
            wordApp.Selection.Copy();

            wDoc1.Activate();
            wordApp.Selection.GoTo(what, which, missing, missing);
            //wordApp.Selection.InsertNewPage();
            wordApp.Selection.Paste();

            wDoc1.ExportAsFixedFormat(saveDestination + "/" + assetNumber.Text + "-" + location.Text + "- Electrical Safety Test and Performance Test.pdf", Word.WdExportFormat.wdExportFormatPDF);

            GC.Collect();
            wDoc1.Close();
            wDoc2.Close();
            wordApp.Quit();
        }

        private void editPerformanceTemplate(object fileName)
        {
            //Setup the Word.Application class.
            Word.Application wordApp =
                new Word.Application();

            if (yesNoPerformanceTest == true)
            {
                if (File.Exists(appRootDir + "/Report Templates/temp2.docx"))
                {
                    File.Delete(appRootDir + "/Report Templates/temp2.docx");
                }

                ///add different performance test

                //bbraun perfusor space
                if (PTpefusorSpaceCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/BBraun Perfusor Space-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //generic ecg
                if (PTECGCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Generic ECG-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //generic nibp
                if (PTNIBPGenericCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/NIBP Monitor-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //edan doppler
                if (PTEdanDopplerCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Edan Doppler-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //sphygmomanometer
                if (PTSphygmomanometerCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Generic Sphygmomanometer-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //genius2 thermometer
                if (PTGenius2Completed == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Genius 2 Thermometer-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }

            }

            object missing = System.Reflection.Missing.Value;


            // Check to see that file exists
            //Open the word document
            Word.Document wDoc = wordApp.Documents.Open(appRootDir + "/Report Templates/temp2.docx");

            // Activate the document
            wDoc.Activate();


            // for changing signatures
            int count = wDoc.Bookmarks.Count;
            for (int i = 1; i < count + 1; i++)
            {
                object oRange = wDoc.Bookmarks[i].Range;
                object saveWithDocument = true;
                string pictureName = appRootDir + "/Signatures/" + userName.Text + ".png";
                wDoc.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, ref oRange);
            }


            ///if statements on what kind of performance test

            //perfusor Space
            if (PTpefusorSpaceCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", userName.Text);
                this.FindAndReplace(wordApp, "<AssetNumber>", assetNumber.Text);
                this.FindAndReplace(wordApp, "<SerialNumber>", serialNumber.Text);
                this.FindAndReplace(wordApp, "<Location>", location.Text);
                this.FindAndReplace(wordApp, "<Manufacturer>", manufacturer.Text);
                this.FindAndReplace(wordApp, "<Model>", model.Text);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<Items>", perfusorSpace.items);
                this.FindAndReplace(wordApp, "<visualresult1>", perfusorSpace.visualoption1);
                this.FindAndReplace(wordApp, "<visualresult2>", perfusorSpace.visualoption2);
                this.FindAndReplace(wordApp, "<visualresult3>", perfusorSpace.visualoption3);
                this.FindAndReplace(wordApp, "<visualresult4>", perfusorSpace.visualoption4);
                this.FindAndReplace(wordApp, "<visualresult5>", perfusorSpace.visualoption5);
                this.FindAndReplace(wordApp, "<visualresult6>", perfusorSpace.visualoption6);
                this.FindAndReplace(wordApp, "<visualresult7>", perfusorSpace.visualoption7);
                this.FindAndReplace(wordApp, "<visualresult8>", perfusorSpace.visualoption8);
                this.FindAndReplace(wordApp, "<funcresult1>", perfusorSpace.functionaloption1);
                this.FindAndReplace(wordApp, "<funcresult2>", perfusorSpace.functionaloption2);
                this.FindAndReplace(wordApp, "<funcresult3>", perfusorSpace.functionaloption3);
                this.FindAndReplace(wordApp, "<funcresult4>", perfusorSpace.functionaloption4);
                this.FindAndReplace(wordApp, "<funcresult5>", perfusorSpace.functionaloption5);
                this.FindAndReplace(wordApp, "<funcresult6>", perfusorSpace.functionaloption6);
                this.FindAndReplace(wordApp, "<funcresult7>", perfusorSpace.functionaloption7);
                this.FindAndReplace(wordApp, "<funcresult8>", perfusorSpace.functionaloption8);
                this.FindAndReplace(wordApp, "<funcresult9>", perfusorSpace.functionaloption9);
                this.FindAndReplace(wordApp, "<funcresult10>", perfusorSpace.functionaloption10);
                this.FindAndReplace(wordApp, "<funcresult11>", perfusorSpace.functionaloption11);
                this.FindAndReplace(wordApp, "<funcresult12>", perfusorSpace.functionaloption12);
                this.FindAndReplace(wordApp, "<funcresult13>", perfusorSpace.functionaloption13);
                this.FindAndReplace(wordApp, "<funcresult14>", perfusorSpace.functionaloption14);
                this.FindAndReplace(wordApp, "<funcresult15>", perfusorSpace.functionaloption15);
                this.FindAndReplace(wordApp, "<funcresult16>", perfusorSpace.functionaloption16);
                this.FindAndReplace(wordApp, "<funcresult17>", perfusorSpace.functionaloption17);
                this.FindAndReplace(wordApp, "<funcresult18>", perfusorSpace.functionaloption18);
                this.FindAndReplace(wordApp, "<funcresult19>", perfusorSpace.functionaloption19);
                this.FindAndReplace(wordApp, "<funcresult20>", perfusorSpace.functionaloption20);
                this.FindAndReplace(wordApp, "<funcresult21>", perfusorSpace.functionaloption21);
                this.FindAndReplace(wordApp, "<funcresult25>", perfusorSpace.functionaloption25);
                this.FindAndReplace(wordApp, "<funcresult26>", perfusorSpace.functionaloption26);
                this.FindAndReplace(wordApp, "<funcresult27>", perfusorSpace.functionaloption27);
                this.FindAndReplace(wordApp, "<funcresult28>", perfusorSpace.functionaloption28);
                this.FindAndReplace(wordApp, "<funcresult29>", perfusorSpace.functionaloption29);
                this.FindAndReplace(wordApp, "<funcresult30>", perfusorSpace.functionaloption30);
                this.FindAndReplace(wordApp, "<funcresult31>", perfusorSpace.functionaloption31);
                this.FindAndReplace(wordApp, "<funcresult32>", perfusorSpace.functionaloption32);
                this.FindAndReplace(wordApp, "<funcresult33>", perfusorSpace.functionaloption33);
                this.FindAndReplace(wordApp, "<funcresult34>", perfusorSpace.functionaloption34);
                this.FindAndReplace(wordApp, "<funcresult35>", perfusorSpace.functionaloption35);
                this.FindAndReplace(wordApp, "<funcresult36>", perfusorSpace.functionaloption36);
                this.FindAndReplace(wordApp, "<Comments>", perfusorSpace.comments); 
                #endregion
            }
            //Generic ECG
            if (PTECGCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", userName.Text);
                this.FindAndReplace(wordApp, "<AssetNumber>", assetNumber.Text);
                this.FindAndReplace(wordApp, "<SerialNumber>", serialNumber.Text);
                this.FindAndReplace(wordApp, "<Location>", location.Text);
                this.FindAndReplace(wordApp, "<Manufacturer>", manufacturer.Text);
                this.FindAndReplace(wordApp, "<Model>", model.Text);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<Items>", GenericECG.items);
                this.FindAndReplace(wordApp, "<result1>", GenericECG.result1);
                this.FindAndReplace(wordApp, "<result2>", GenericECG.result2);
                this.FindAndReplace(wordApp, "<result3>", GenericECG.result3);
                this.FindAndReplace(wordApp, "<result4>", GenericECG.result4);
                this.FindAndReplace(wordApp, "<Comments>", GenericECG.comments);
                #endregion
            }
            //Generic NIBP
            if (PTNIBPGenericCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", userName.Text);
                this.FindAndReplace(wordApp, "<AssetNumber>", assetNumber.Text);
                this.FindAndReplace(wordApp, "<SerialNumber>", serialNumber.Text);
                this.FindAndReplace(wordApp, "<Location>", location.Text);
                this.FindAndReplace(wordApp, "<Manufacturer>", manufacturer.Text);
                this.FindAndReplace(wordApp, "<Model>", model.Text);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<Items>", GenericNIBPMonitor.items);
                this.FindAndReplace(wordApp, "<result1>", GenericNIBPMonitor.result1);
                this.FindAndReplace(wordApp, "<result2>", GenericNIBPMonitor.result2);
                this.FindAndReplace(wordApp, "<result3>", GenericNIBPMonitor.result3);
                this.FindAndReplace(wordApp, "<result4>", GenericNIBPMonitor.result4);
                this.FindAndReplace(wordApp, "<result5>", GenericNIBPMonitor.result1);
                this.FindAndReplace(wordApp, "<result6>", GenericNIBPMonitor.result2);
                this.FindAndReplace(wordApp, "<result7>", GenericNIBPMonitor.result3);
                this.FindAndReplace(wordApp, "<result8>", GenericNIBPMonitor.result4);
                this.FindAndReplace(wordApp, "<Comments>", GenericNIBPMonitor.comments);
                #endregion
            }
            //Edan Doppler
            if (PTEdanDopplerCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", userName.Text);
                this.FindAndReplace(wordApp, "<AssetNumber>", assetNumber.Text);
                this.FindAndReplace(wordApp, "<SerialNumber>", serialNumber.Text);
                this.FindAndReplace(wordApp, "<Location>", location.Text);
                this.FindAndReplace(wordApp, "<Manufacturer>", manufacturer.Text);
                this.FindAndReplace(wordApp, "<Model>", model.Text);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<Items>", EdanDoppler.items);
                this.FindAndReplace(wordApp, "<result1>", EdanDoppler.result1);
                this.FindAndReplace(wordApp, "<result2>", EdanDoppler.result2);
                this.FindAndReplace(wordApp, "<Comments>", EdanDoppler.comments);
                #endregion
            }
            //Generic Sphygmomanometer
            if (PTSphygmomanometerCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", userName.Text);
                this.FindAndReplace(wordApp, "<AssetNumber>", assetNumber.Text);
                this.FindAndReplace(wordApp, "<SerialNumber>", serialNumber.Text);
                this.FindAndReplace(wordApp, "<Location>", location.Text);
                this.FindAndReplace(wordApp, "<Manufacturer>", manufacturer.Text);
                this.FindAndReplace(wordApp, "<Model>", model.Text);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<Items>", GenericSphygmomanometer.items);
                this.FindAndReplace(wordApp, "<result1>", GenericSphygmomanometer.result1);
                this.FindAndReplace(wordApp, "<result2>", GenericSphygmomanometer.result2);
                this.FindAndReplace(wordApp, "<result3>", GenericSphygmomanometer.result3);
                this.FindAndReplace(wordApp, "<result4>", GenericSphygmomanometer.result4);
                this.FindAndReplace(wordApp, "<result5>", GenericSphygmomanometer.result1);
                this.FindAndReplace(wordApp, "<result6>", GenericSphygmomanometer.result2);
                this.FindAndReplace(wordApp, "<result7>", GenericSphygmomanometer.result3);
                this.FindAndReplace(wordApp, "<Comments>", GenericSphygmomanometer.comments);
                #endregion
            }
            //Edan Doppler
            if (PTGenius2Completed == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", userName.Text);
                this.FindAndReplace(wordApp, "<AssetNumber>", assetNumber.Text);
                this.FindAndReplace(wordApp, "<SerialNumber>", serialNumber.Text);
                this.FindAndReplace(wordApp, "<Location>", location.Text);
                this.FindAndReplace(wordApp, "<Manufacturer>", manufacturer.Text);
                this.FindAndReplace(wordApp, "<Model>", model.Text);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<Items>", Genius2Thermometer.items);
                this.FindAndReplace(wordApp, "<result1>", Genius2Thermometer.result1);
                this.FindAndReplace(wordApp, "<result2>", Genius2Thermometer.result2);
                this.FindAndReplace(wordApp, "<Comments>", Genius2Thermometer.comments);
                #endregion
            }


            //create PDF
            if (PerformPerformanceTest == true)
            {
                wDoc.ExportAsFixedFormat(saveDestination + "/" + assetNumber.Text + "-" + location.Text + "- Performance Test Report" + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
            }

            //Close the document - you have to do this.
            GC.Collect();
            wDoc.Close();
            wordApp.Quit();
        }

        private void editElectricalSafetyTemplate(object fileName)
        {
            //Setup the Word.Application class.
            Word.Application wordApp =
                new Word.Application();

            if (_electricaltestResult == true)
            {
                if (class1ASNZtest == true)
                {
                    if (File.Exists(appRootDir + "/Report Templates/temp.docx"))
                    {
                        File.Delete(appRootDir + "/Report Templates/temp.docx");
                    }
                    File.Copy(appRootDir + "/Report Templates/ASNZCLASS1-TEMPLATE.docx", appRootDir + "/Report Templates/temp.docx");
                }
                if (class2ASNZtest == true)
                {
                    if (File.Exists(appRootDir + "/Report Templates/temp.docx"))
                    {
                        File.Delete(appRootDir + "/Report Templates/temp.docx");
                    }
                    File.Copy(appRootDir + "/Report Templates/ASNZCLASS2-TEMPLATE.docx", appRootDir + "/Report Templates/temp.docx");

                }
            }

            object missing = System.Reflection.Missing.Value;

            Word.Document wDoc = null;

            // Check to see that file exists
            if (File.Exists((string)fileName))
            {
                DateTime today = DateTime.Now;

                object readOnly = false;
                object isVisible = false;
                object what = Word.WdGoToItem.wdGoToLine;
                object which = Word.WdGoToDirection.wdGoToLast;
                //Set Word to be not visible.
                wordApp.Visible = false;

                //Open the word document
                wDoc = wordApp.Documents.Open(ref fileName, ref missing,
                    ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref isVisible, ref missing, ref missing,
                    ref missing, ref missing);

                // Activate the document
                wDoc.Activate();

                // for changing signatures
                int count = wDoc.Bookmarks.Count;
                for (int i = 1; i < count + 1; i++)
                {
                    object oRange = wDoc.Bookmarks[i].Range;
                    object saveWithDocument = true;
                    string pictureName = appRootDir + "/Signatures/" + userName.Text + ".png";
                    wDoc.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, ref oRange);
                }

                if (class1ASNZtest == true)
                {
                    #region Find and Replace
                    // Find Place Holders and Replace them with Values.
                    this.FindAndReplace(wordApp, "<Name>", userName.Text);
                    this.FindAndReplace(wordApp, "<AssetNumber>", assetNumber.Text);
                    this.FindAndReplace(wordApp, "<SerialNumber>", serialNumber.Text);
                    this.FindAndReplace(wordApp, "<Location>", location.Text);
                    this.FindAndReplace(wordApp, "<Manufacturer>", manufacturer.Text);
                    this.FindAndReplace(wordApp, "<Model>", model.Text);
                    this.FindAndReplace(wordApp, "<ElectricalSafetyTestResult>", ESTResults);
                    this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                    this.FindAndReplace(wordApp, "<AnsurVersion>", _versionNumber);
                    this.FindAndReplace(wordApp, "<ClassStandard>", _kindofElectricalSafetyTest);
                    this.FindAndReplace(wordApp, "<MainsLN>", _MV1);
                    this.FindAndReplace(wordApp, "<MainsNE>", _MV2);
                    this.FindAndReplace(wordApp, "<MainsLE>", _MV3);
                    this.FindAndReplace(wordApp, "<ProtectiveEarth>", _earthResistance_double + " OHMS");
                    this.FindAndReplace(wordApp, "<InsulationResistance>", _insulationResistance);
                    this.FindAndReplace(wordApp, "<EarthLeakageNC>", _EL1_double + " uA");
                    this.FindAndReplace(wordApp, "<EarthLeakageON>", _EL2_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageNC>", _EnL1_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageON>", _EnL2_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageOE>", _EnL3_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageNCRM>", _EnL4_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageONR>", _EnL5_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageOER>", _EnL6_double + " uA"); 
                    #endregion
                }

                if (class2ASNZtest == true)
                {
                    #region Find and Replace
                    // Find Place Holders and Replace them with Values.
                    this.FindAndReplace(wordApp, "<Name>", userName.Text);
                    this.FindAndReplace(wordApp, "<AssetNumber>", assetNumber.Text);
                    this.FindAndReplace(wordApp, "<SerialNumber>", serialNumber.Text);
                    this.FindAndReplace(wordApp, "<Location>", location.Text);
                    this.FindAndReplace(wordApp, "<Manufacturer>", manufacturer.Text);
                    this.FindAndReplace(wordApp, "<Model>", model.Text);
                    this.FindAndReplace(wordApp, "<ElectricalSafetyTestResult>", ESTResults);
                    this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                    this.FindAndReplace(wordApp, "<AnsurVersion>", _versionNumber);
                    this.FindAndReplace(wordApp, "<ClassStandard>", _kindofElectricalSafetyTest);
                    this.FindAndReplace(wordApp, "<MainsLN>", _MV1);
                    this.FindAndReplace(wordApp, "<MainsNE>", _MV2);
                    this.FindAndReplace(wordApp, "<MainsLE>", _MV3);
                    this.FindAndReplace(wordApp, "<InsulationResistance>", _insulationResistance);
                    this.FindAndReplace(wordApp, "<EnLeakageNC>", _EnL1_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageON>", _EnL2_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageOE>", _EnL3_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageNCRM>", _EnL4_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageONR>", _EnL5_double + " uA");
                    this.FindAndReplace(wordApp, "<EnLeakageOER>", _EnL6_double + " uA"); 
                    #endregion
                }

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this,"File does not exist.");
                return;
            }

            //as where to save the files
            //export to pdf
            if (PerformElectricalSafetyTest == true)
            {
                wDoc.ExportAsFixedFormat(saveDestination + "/" + assetNumber.Text + "-" + location.Text + "- Electrical Safety Test Report" + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
            }

            //Close the document - you have to do this.
            GC.Collect();
            wDoc.Close();
            wordApp.Quit();
        }


        //Function to Edit
        private void FindAndReplace(Word.Application WordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object nmatchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            WordApp.Selection.Find.Execute(ref findText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike,
                ref nmatchAllWordForms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiacritics, ref matchAlefHamza,
                ref matchControl);
        }
    }
}
