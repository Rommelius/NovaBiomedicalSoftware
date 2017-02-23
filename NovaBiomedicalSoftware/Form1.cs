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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NovaBiomedicalSoftware
{

    public partial class Form1 : MetroForm
    {

        static SerialPort mySerialPort;
        DateTime date = DateTime.Today;
        private delegate void SetTextDeleg(string text);



        public string COMPORTNUMBER, _currentTest, _testPDF, _earthResistance, _versionNumber, _MV1, _MV2, _MV3, _insulationResistance,
        _EL1, _EL2, _EnL1, _EnL2, _EnL3, _EnL4, _EnL5, _EnL6, PLT1, PLT2, PLT3, SFN, _electricalResult, _PTSResult, _currentCOMPort, set_sig;


        public double _earthResistance_double, _EL1_double, _EL2_double, _EnL1_double, _EnL2_double, _EnL3_double,
         _EnL4_double, _EnL5_double, _EnL6_double, PLT1_double, PLT2_double, PLT3_double, SFN_double;

        public bool yesNoPerformanceTest, _electricaltestResult, _PTStestResult, class1ASNZtest, class2ASNZtest, ecgclass1ASNZtest, ecgclass2ASNZtest;

        public static string sean_sig = "sean.png", rommel_sig = "rommel.png", scott_sig = "scott.png", joe_sig = "joe.png", luke_sig = "luke.png",
        khoi_sig = "khoi.png";

        public Form1()
        {
            InitializeComponent();

            //disable all background
            tabMenu.Enabled = false;
            newproductBtn.Enabled = false;
            statusText.Text = "Please fill in the details";
            statusBar.Hide();

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
            statusBar.Show();
            statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            statusBar.MarqueeAnimationSpeed = 30;

            class1ASNZtest = true;

            Thread class1NTest = new Thread(class1NormalTest);

            class1NTest.Start();
        }

        private void bbraunPerfusor_Click(object sender, EventArgs e)
        {
            perfusorSpace perfusorSpaceTest = new perfusorSpace();

            DialogResult perfusorSpaceTestDR = perfusorSpaceTest.ShowDialog();

            if (perfusorSpaceTestDR == DialogResult.Cancel)
            {
                makePDF();
            }
        }






        public void class1NormalTest()
        {
            initialisedDevice();
            getVersionNumber();
            mainsVoltage();
            earthResistance();
            insulationResistance();
            earthLeakage();
            enclousureLeakage();
            testComplete();
        }

        public void testComplete()
        {
            this.Invoke((MethodInvoker)delegate
            {
                statusBar.Hide();
                
                //show complete
                statusText.Text = "Test Completed for: XXXXXXX";
                
                //show diaglog
                DialogResult question1 = MessageBox.Show("Would you like to do Performance Test?",
                "Question", MessageBoxButtons.YesNo);
                
                //show perfomance test form if accepted
                //Performance_Test performance_test = new Performance_Test();

                if (question1 == DialogResult.Yes)
                {
                    statusText.Text = "Please select the equipment";
                    tabMenu.SelectedTab = ptTab;
                    yesNoPerformanceTest = true;

                    
                    //DialogResult dr = performance_test.ShowDialog();
                    //if (dr == DialogResult.Cancel)
                    //{
                    //    //makePDF();
                    //}
                }
                else
                {
                    yesNoPerformanceTest = false;

                    makePDF();

                    MessageBox.Show("Nova Biomedical - Fluke ESA620", "Test Completed for: XXXXXXXX without Performance Test");
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

        public void makePDF()

        {
            //check the results first
            if (class1ASNZtest == true)
            {
                if (_earthResistance_double > 0.2 || _EL1_double > 500
                    || _EL2_double > 1000 || _EnL1_double > 100 || _EnL2_double > 500 || _EnL3_double > 500
                    || _EnL4_double > 100 || _EnL5_double > 500 || _EnL6_double > 500 || _insulationResistance == "FAILED")
                {
                    _electricaltestResult = false;
                }
                else
                {
                    _electricaltestResult = true;
                }
            }
            if (class2ASNZtest == true)
            {
                if (_EnL1_double > 100 || _EnL2_double > 500 || _EnL3_double > 500
                    || _EnL4_double > 100 || _EnL5_double > 500 || _EnL6_double > 500 || _insulationResistance == "FAILED")
                {
                    _electricaltestResult = false;
                }
                else
                {
                    _electricaltestResult = true;
                }
            }
            if (ecgclass1ASNZtest == true)
            {
                if (_EnL1_double > 100 || _EnL2_double > 500 || _EnL3_double > 500
                    || _EnL4_double > 100 || _EnL5_double > 500 || _EnL6_double > 500 || PLT1_double > 10
                    || PLT2_double > 50 || PLT3_double > 50 || SFN_double > 50 || _insulationResistance == "FAILED")
                {
                    _electricaltestResult = false;
                }
                else
                {
                    _electricaltestResult = true;
                }
            }
            if (ecgclass2ASNZtest == true)
            {
                if (_earthResistance_double > 0.2 || _EL1_double > 500
                    || _EL2_double > 1000 || _EnL1_double > 100 || _EnL2_double > 500 || _EnL3_double > 500
                    || _EnL4_double > 100 || _EnL5_double > 500 || _EnL6_double > 500 || PLT1_double > 10
                    || PLT2_double > 50 || PLT3_double > 50 || SFN_double > 50 || _insulationResistance == "FAILED")
                {
                    _electricaltestResult = false;
                }
                else
                {
                    _electricaltestResult = true;
                }
            }

            //if (ECG_Machine.PTS_result == true || NIBP_Monitor.NIBP_Result == true)
            //    _PTStestResult = true;
            //else
            //    _PTStestResult = false;


            //making PDF

            string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

            //setup background image
            iTextSharp.text.Image bgImage = iTextSharp.text.Image.GetInstance(appRootDir + "/Images/" + "bg.png");
            bgImage.ScalePercent(25f);
            bgImage.Alignment = iTextSharp.text.Image.UNDERLYING;
            bgImage.SetAbsolutePosition(0f, 0f);

            //setup seperator
            iTextSharp.text.pdf.draw.LineSeparator line1 = new iTextSharp.text.pdf.draw.LineSeparator(2f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
            iTextSharp.text.pdf.draw.DottedLineSeparator line2 = new iTextSharp.text.pdf.draw.DottedLineSeparator();


            if (userName.Text == "Sean Welch")
                set_sig = sean_sig;
            else if (userName.Text == "Luke Brogan")
                set_sig = luke_sig;
            else if (userName.Text == "Khoi Duong")
                set_sig = khoi_sig;
            else if (userName.Text == "Scott Monk")
                set_sig = scott_sig;
            else if (userName.Text == "Rommel Lapuz")
                set_sig = rommel_sig;
            else if (userName.Text == "Joe Welch")
                set_sig = joe_sig;




            //setup signatures
            iTextSharp.text.Image signature = iTextSharp.text.Image.GetInstance(appRootDir + "/Images/" + set_sig);



            try
            {
                //change the NVBXXXXXXX to dynamic later
                using (FileStream fs = new FileStream(appRootDir + "/PDFs/" + assetNumber.Text + "-"+ model.Text + "-"+ location.Text + ".pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                using (Document doc = new Document(PageSize.A4))

                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    // Step 4: Openning the Document
                    doc.Open();

                    //setup GUID
                    var heading = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f);
                    var heading1 = FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 18);
                    var heading2 = FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 18f, iTextSharp.text.Font.UNDERLINE);
                    var boldfont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    var boldfont2 = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    var boldfont1 = FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 9);
                    var boldfont3 = FontFactory.GetFont(FontFactory.HELVETICA_BOLDOBLIQUE, 12);
                    var contentfont = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                    var contentfont1 = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    var contentfont2 = FontFactory.GetFont(FontFactory.HELVETICA, 9);

                    //setting up title and creator
                    doc.AddTitle("Nova Biomedical Service Report");
                    doc.AddCreator("Nova Biomedical");

                    //add bg
                    doc.Add(bgImage);

                    //add logo
                    iTextSharp.text.Image Logo = iTextSharp.text.Image.GetInstance(appRootDir + "/Images/" + "header.png");
                    Logo.ScalePercent(18f);
                    Logo.Alignment = 1;
                    doc.Add(Logo);
                    doc.Add(new Chunk("\n"));
                    doc.Add(line1);

                    ///----------------------------------Table 1
                    doc.Add(new Phrase("Device Under Test", heading2));

                    //table contents
                    PdfPTable page_1_table_content2 = new PdfPTable(4);
                    page_1_table_content2.HorizontalAlignment = Element.ALIGN_CENTER;
                    page_1_table_content2.TotalWidth = 525f;
                    page_1_table_content2.LockedWidth = true;
                    page_1_table_content2.HorizontalAlignment = 1;
                    page_1_table_content2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //serial number
                    PdfPCell assetnumber_title = new PdfPCell(new Phrase("Asset Number: ", boldfont3));
                    assetnumber_title.Border = 0;
                    page_1_table_content2.AddCell(assetnumber_title);
                    //asset val*
                    PdfPCell serialnumber_val = new PdfPCell(new Phrase(assetNumber.Text, contentfont1));
                    serialnumber_val.Border = 0;
                    page_1_table_content2.AddCell(serialnumber_val);
                    PdfPCell serial_title = new PdfPCell(new Phrase("Serial Number: ", boldfont3));
                    serial_title.Border = 0;
                    page_1_table_content2.AddCell(serial_title);
                    //serial val*
                    PdfPCell serial_val = new PdfPCell(new Phrase(serialNumber.Text, contentfont1));
                    serial_val.Border = 0;
                    page_1_table_content2.AddCell(serial_val);
                    //Location title
                    PdfPCell location_title = new PdfPCell(new Phrase("Location: ", boldfont3));
                    location_title.Border = 0;
                    page_1_table_content2.AddCell(location_title);
                    //Location Value*
                    PdfPCell location_val = new PdfPCell(new Phrase(location.Text, contentfont1));
                    location_val.Border = 0;
                    page_1_table_content2.AddCell(location_val);
                    //Model title
                    PdfPCell model_title = new PdfPCell(new Phrase("Model: ", boldfont3));
                    model_title.Border = 0;
                    page_1_table_content2.AddCell(model_title);
                    //model val*
                    PdfPCell model_val = new PdfPCell(new Phrase(model.Text, contentfont1));
                    model_val.Border = 0;
                    page_1_table_content2.AddCell(model_val);

                    //add table
                    doc.Add(page_1_table_content2);

                    doc.Add(new Chunk("\n"));

                    //----------------------------------Test Equipment





                    ///----------------------------------Table 2
                    doc.Add(new Phrase("Electrical Test Summary", heading2));

                    //3 is for columns
                    PdfPTable page1_table_heading1 = new PdfPTable(3);

                    page1_table_heading1.TotalWidth = 525f;
                    page1_table_heading1.LockedWidth = true;
                    page1_table_heading1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results***

                    if (_electricaltestResult == false)
                        _electricalResult = "TEST FAILED";
                    if (_electricaltestResult == true)
                        _electricalResult = "TEST PASSED";



                    PdfPCell page1_heading_Results = new PdfPCell(new Phrase(_electricalResult, boldfont2));
                    page1_heading_Results.Colspan = 3;
                    page1_heading_Results.HorizontalAlignment = Element.ALIGN_CENTER;
                    page1_heading_Results.Border = 0;
                    page1_heading_Results.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    page1_heading_Results.BorderWidthBottom = 1f;
                    page1_heading_Results.BorderWidthTop = 1f;
                    page1_heading_Results.PaddingBottom = 10f;
                    BaseColor color_green = new BaseColor(0, 155, 0);
                    BaseColor color_red = new BaseColor(155, 0, 0);
                    if (_electricaltestResult == false)
                        page1_heading_Results.BackgroundColor = color_red;
                    if (_electricaltestResult == true)
                        page1_heading_Results.BackgroundColor = color_green;
                    page1_table_heading1.AddCell(page1_heading_Results);

                    doc.Add(new Chunk("\n"));
                    //add table
                    doc.Add(page1_table_heading1);

                    //table contents
                    PdfPTable page_1_table_content1 = new PdfPTable(4);
                    page_1_table_content1.HorizontalAlignment = Element.ALIGN_CENTER;
                    page_1_table_content1.TotalWidth = 525f;
                    page_1_table_content1.LockedWidth = true;
                    page_1_table_content1.HorizontalAlignment = 1;
                    page_1_table_content1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //heading 1
                    PdfPCell test_performed = new PdfPCell(new Phrase("Test Details: ", boldfont3));
                    test_performed.Border = 0;
                    page_1_table_content1.AddCell(test_performed);
                    PdfPCell blank1 = new PdfPCell(new Phrase("", boldfont3));
                    blank1.Border = 0;
                    page_1_table_content1.AddCell(blank1);
                    PdfPCell ansur_components = new PdfPCell(new Phrase("Test Instruments: ", boldfont3));
                    ansur_components.Border = 0;
                    page_1_table_content1.AddCell(ansur_components);
                    PdfPCell blank2 = new PdfPCell(new Phrase("", boldfont3));
                    blank2.Border = 0;
                    page_1_table_content1.AddCell(blank2);


                    //Date:
                    PdfPCell date_title = new PdfPCell(new Phrase("Date: ", contentfont1));
                    date_title.Border = 0;
                    page_1_table_content1.AddCell(date_title);
                    //Date Value*
                    PdfPCell date_val = new PdfPCell(new Phrase(date.ToString("d"), contentfont1));
                    date_val.Border = 0;
                    page_1_table_content1.AddCell(date_val);
                    //Ansur
                    PdfPCell ansur_title = new PdfPCell(new Phrase("Ansur Version", contentfont1));
                    ansur_title.Border = 0;
                    page_1_table_content1.AddCell(ansur_title);
                    //Ansur Version*
                    PdfPCell ansur_ver = new PdfPCell(new Phrase(_versionNumber, contentfont1));
                    ansur_ver.Border = 0;
                    page_1_table_content1.AddCell(ansur_ver);
                    //Standard
                    PdfPCell standard_title = new PdfPCell(new Phrase("Standard:", contentfont1));
                    standard_title.Border = 0;
                    page_1_table_content1.AddCell(standard_title);
                    //Standard Version**
                    if (class1ASNZtest == true)
                    {
                        _testPDF = "AS NZS 3551 - Class 1";
                    }
                    if (class2ASNZtest == true)
                    {
                        _testPDF = "AS NZS 3551 - Class 2";
                    }
                    if (ecgclass1ASNZtest == true)
                    {
                        _testPDF = "AS NZS 3551 - Class 1 (ECG)";
                    }
                    if (ecgclass2ASNZtest == true)
                    {
                        _testPDF = "AS NZS 3551 - Class 2 (ECG)";
                    }


                    PdfPCell standard_val = new PdfPCell(new Phrase(_testPDF, contentfont1));
                    standard_val.Border = 0;
                    page_1_table_content1.AddCell(standard_val);
                    //Standard
                    PdfPCell blank3 = new PdfPCell(new Phrase("", contentfont1));
                    blank3.Border = 0;
                    page_1_table_content1.AddCell(blank3);
                    //Standard Version**
                    PdfPCell blank4 = new PdfPCell(new Phrase("", contentfont1));
                    blank4.Border = 0;
                    page_1_table_content1.AddCell(blank4);

                    //add table
                    doc.Add(page_1_table_content1);

                    doc.Add(new Chunk("\n"));


                    ////----------------------------------Performance Test Summary
                    //if (Performance_Test.submit_performance == true)
                    //{
                    //    doc.Add(new Phrase("Performance Test Summary", heading2));

                    //    //3 is for columns
                    //    PdfPTable PTS_heading1 = new PdfPTable(3);

                    //    PTS_heading1.TotalWidth = 525f;
                    //    PTS_heading1.LockedWidth = true;
                    //    PTS_heading1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results***

                    //    if (_PTStestResult == false)
                    //        _PTSResult = "TEST FAILED";
                    //    if (_PTStestResult == true)
                    //        _PTSResult = "TEST PASSED";



                    //    PdfPCell PTS_heading_results = new PdfPCell(new Phrase(_PTSResult, boldfont2));
                    //    PTS_heading_results.Colspan = 3;
                    //    PTS_heading_results.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    PTS_heading_results.Border = 0;
                    //    PTS_heading_results.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    PTS_heading_results.BorderWidthBottom = 1f;
                    //    PTS_heading_results.BorderWidthTop = 1f;
                    //    PTS_heading_results.PaddingBottom = 10f;
                    //    if (_PTSResult == "TEST FAILED")
                    //        PTS_heading_results.BackgroundColor = color_red;
                    //    if (_PTSResult == "TEST PASSED")
                    //        PTS_heading_results.BackgroundColor = color_green;
                    //    PTS_heading1.AddCell(PTS_heading_results);

                    //    doc.Add(new Chunk("\n"));
                    //    //add table
                    //    doc.Add(PTS_heading1);

                    //    //--------------------------Test Equipments
                    //    doc.Add(new Phrase("Test Equipments:", boldfont3));
                    //    PdfPTable _testequipmenttable = new PdfPTable(3);
                    //    _testequipmenttable.TotalWidth = 525f;
                    //    _testequipmenttable.LockedWidth = true;


                    //    //-----------Safety Analyser
                    //    PdfPCell testequipment1_type = new PdfPCell(new Phrase("Safety Analyser"));
                    //    testequipment1_type.BorderWidthRight = 0;
                    //    PdfPCell testequipment1_name = new PdfPCell(new Phrase("ESA620"));
                    //    testequipment1_name.BorderWidthLeft = 0;
                    //    testequipment1_name.BorderWidthRight = 0;
                    //    testequipment1_name.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    PdfPCell testequipment1_SN = new PdfPCell(new Phrase("S/N: 2517025"));
                    //    testequipment1_SN.HorizontalAlignment = Element.ALIGN_RIGHT;
                    //    testequipment1_SN.BorderWidthLeft = 0;
                    //    _testequipmenttable.AddCell(testequipment1_type);
                    //    _testequipmenttable.AddCell(testequipment1_name);
                    //    _testequipmenttable.AddCell(testequipment1_SN);


                    //    if (NIBP_Monitor.NIBP_Result == true)
                    //    {
                    //        //-----------Defibrillator Analyser
                    //        PdfPCell defib_type = new PdfPCell(new Phrase("Defibrillator Analyser"));
                    //        defib_type.BorderWidthRight = 0;
                    //        PdfPCell defib_name = new PdfPCell(new Phrase("NETECH DELTA 300"));
                    //        defib_name.BorderWidthLeft = 0;
                    //        defib_name.BorderWidthRight = 0;
                    //        defib_name.HorizontalAlignment = Element.ALIGN_CENTER;
                    //        PdfPCell defib_SN = new PdfPCell(new Phrase("S/N: 19478"));
                    //        defib_SN.HorizontalAlignment = Element.ALIGN_RIGHT;
                    //        defib_SN.BorderWidthLeft = 0;
                    //        _testequipmenttable.AddCell(defib_type);
                    //        _testequipmenttable.AddCell(defib_name);
                    //        _testequipmenttable.AddCell(defib_SN);


                    //        //-----------Pressure Meter
                    //        PdfPCell pressure_type = new PdfPCell(new Phrase("Pressure Meter"));
                    //        pressure_type.BorderWidthRight = 0;
                    //        PdfPCell pressure_name = new PdfPCell(new Phrase("NETECH PRESSURE METER"));
                    //        pressure_name.BorderWidthLeft = 0;
                    //        pressure_name.BorderWidthRight = 0;
                    //        pressure_name.HorizontalAlignment = Element.ALIGN_CENTER;
                    //        PdfPCell pressure_SN = new PdfPCell(new Phrase("S/N: 15377"));
                    //        pressure_SN.HorizontalAlignment = Element.ALIGN_RIGHT;
                    //        pressure_SN.BorderWidthLeft = 0;
                    //        _testequipmenttable.AddCell(pressure_type);
                    //        _testequipmenttable.AddCell(pressure_name);
                    //        _testequipmenttable.AddCell(pressure_SN);

                    //        //-----------SpO2 Simulator
                    //        PdfPCell spo2_type = new PdfPCell(new Phrase("SpO2 Simulator"));
                    //        spo2_type.BorderWidthRight = 0;
                    //        PdfPCell spo2_name = new PdfPCell(new Phrase("OXITEST PLUS 7 ANALYSER"));
                    //        spo2_name.BorderWidthLeft = 0;
                    //        spo2_name.BorderWidthRight = 0;
                    //        spo2_name.HorizontalAlignment = Element.ALIGN_CENTER;
                    //        PdfPCell spo2_SN = new PdfPCell(new Phrase("S/N: DOS04090718"));
                    //        spo2_SN.HorizontalAlignment = Element.ALIGN_RIGHT;
                    //        spo2_SN.BorderWidthLeft = 0;
                    //        _testequipmenttable.AddCell(spo2_type);
                    //        _testequipmenttable.AddCell(spo2_name);
                    //        _testequipmenttable.AddCell(spo2_SN);

                    //        //-----------NIBP Simulator
                    //        PdfPCell nibp_type = new PdfPCell(new Phrase("NIBP Simulator"));
                    //        nibp_type.BorderWidthRight = 0;
                    //        PdfPCell nibp_name = new PdfPCell(new Phrase("PRONK SYSTEMS NIBP SIM CUBE SC-5"));
                    //        nibp_name.BorderWidthLeft = 0;
                    //        nibp_name.BorderWidthRight = 0;
                    //        nibp_name.HorizontalAlignment = Element.ALIGN_CENTER;
                    //        PdfPCell nibp_SN = new PdfPCell(new Phrase("S/N: 5813"));
                    //        nibp_SN.HorizontalAlignment = Element.ALIGN_RIGHT;
                    //        nibp_SN.BorderWidthLeft = 0;
                    //        _testequipmenttable.AddCell(nibp_type);
                    //        _testequipmenttable.AddCell(nibp_name);
                    //        _testequipmenttable.AddCell(nibp_SN);


                    //    }


                    //    doc.Add(_testequipmenttable);






                    //}


                    //---------------------------------Signature
                    doc.Add(new Phrase("Signatures", heading2));
                    doc.Add(new Chunk("\n"));
                    doc.Add(signature);
                    //name **
                    doc.Add(new Paragraph("Name: " + userName.Text, contentfont1));
                    doc.Add(new Paragraph("Date: " + date.ToString("d"), contentfont1));

                    //----------------------------------Page 2
                    doc.NewPage();
                    //add bg
                    doc.Add(bgImage);


                    doc.Add(new Phrase("Test Results", heading2));

                    //----------------------------------Mains Voltage - L2N
                    //3 is for columns
                    PdfPTable table_heading1 = new PdfPTable(3);

                    table_heading1.TotalWidth = 500f;
                    table_heading1.LockedWidth = true;
                    table_heading1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results
                    PdfPCell heading_L2N = new PdfPCell(new Phrase("Mains Voltage - Live to Neutral", heading));
                    heading_L2N.Colspan = 3;
                    heading_L2N.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    heading_L2N.BorderWidthBottom = 0.5f;
                    heading_L2N.BorderWidthTop = 0.5f;
                    heading_L2N.PaddingBottom = 10f;
                    heading_L2N.HorizontalAlignment = Element.ALIGN_CENTER;
                    table_heading1.AddCell(heading_L2N);

                    //add table
                    doc.Add(table_heading1);

                    //table contents
                    PdfPTable table_content1 = new PdfPTable(5);
                    table_content1.TotalWidth = 500f;
                    table_content1.LockedWidth = true;
                    table_content1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //heading 1
                    PdfPCell results = new PdfPCell(new Phrase("Results: ", boldfont1));
                    results.Border = 0;
                    table_content1.AddCell(results);
                    PdfPCell value = new PdfPCell(new Phrase("Value", boldfont1));
                    value.Border = 0;
                    table_content1.AddCell(value);
                    PdfPCell highlimit = new PdfPCell(new Phrase("High Limit", boldfont1));
                    highlimit.Border = 0;
                    table_content1.AddCell(highlimit);
                    PdfPCell lowlimit = new PdfPCell(new Phrase("Low Limit", boldfont1));
                    lowlimit.Border = 0;
                    table_content1.AddCell(lowlimit);
                    PdfPCell standard = new PdfPCell(new Phrase("Standard", boldfont1));
                    standard.Border = 0;
                    table_content1.AddCell(standard);


                    //results:
                    PdfPCell L2N = new PdfPCell(new Phrase("Live to Neutral: ", contentfont));
                    L2N.Border = 0;
                    table_content1.AddCell(L2N);
                    //value
                    PdfPCell value_L2N = new PdfPCell(new Phrase(_MV1, contentfont));
                    value_L2N.Border = 0;
                    table_content1.AddCell(value_L2N);
                    //High Limit
                    PdfPCell highlimit_L2N = new PdfPCell(new Phrase("", contentfont));
                    highlimit_L2N.Border = 0;
                    table_content1.AddCell(highlimit_L2N);
                    //Low Limit
                    PdfPCell lowlimit_L2N = new PdfPCell(new Phrase("", contentfont));
                    lowlimit_L2N.Border = 0;
                    table_content1.AddCell(lowlimit_L2N); //nothing for protective earth
                    //standard
                    PdfPCell standard_L2N = new PdfPCell(new Phrase(_testPDF, contentfont));
                    standard_L2N.Border = 0;
                    table_content1.AddCell(standard_L2N);

                    doc.Add(table_content1);

                    //----------------------------------------Mains Voltage - N2E
                    PdfPTable table_heading2 = new PdfPTable(3);

                    table_heading2.TotalWidth = 500f;
                    table_heading2.LockedWidth = true;
                    table_heading2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results
                    PdfPCell heading_N2E = new PdfPCell(new Phrase("Mains Voltage - Neutral to Earth", heading));
                    heading_N2E.Colspan = 3;
                    heading_N2E.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    heading_N2E.BorderWidthBottom = 0.5f;
                    heading_N2E.BorderWidthTop = 0.5f;
                    heading_N2E.PaddingBottom = 10f;
                    heading_N2E.HorizontalAlignment = Element.ALIGN_CENTER;
                    table_heading2.AddCell(heading_N2E);

                    //add table
                    doc.Add(table_heading2);

                    //table contents
                    PdfPTable table_content2 = new PdfPTable(5);
                    table_content2.TotalWidth = 500f;
                    table_content2.LockedWidth = true;
                    table_content2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //headings
                    table_content2.AddCell(results);
                    table_content2.AddCell(value);
                    table_content2.AddCell(highlimit);
                    table_content2.AddCell(lowlimit);
                    table_content2.AddCell(standard);


                    //results:
                    PdfPCell N2E = new PdfPCell(new Phrase("Neutral to Earth: ", contentfont));
                    N2E.Border = 0;
                    table_content2.AddCell(N2E);
                    //value
                    PdfPCell value_N2E = new PdfPCell(new Phrase(_MV2, contentfont));
                    value_N2E.Border = 0;
                    table_content2.AddCell(value_N2E);
                    //High Limit
                    PdfPCell highlimit_N2E = new PdfPCell(new Phrase("", contentfont));
                    highlimit_N2E.Border = 0;
                    table_content2.AddCell(highlimit_N2E);
                    //Low Limit
                    PdfPCell lowlimit_N2E = new PdfPCell(new Phrase("", contentfont));
                    lowlimit_N2E.Border = 0;
                    table_content2.AddCell(lowlimit_N2E); //nothing for protective earth
                    //standard
                    PdfPCell standard_N2E = new PdfPCell(new Phrase(_testPDF, contentfont));
                    standard_N2E.Border = 0;
                    table_content2.AddCell(standard_N2E);

                    doc.Add(table_content2);


                    //----------------------------------------Mains Voltage - L2E
                    PdfPTable table_heading3 = new PdfPTable(3);

                    table_heading3.TotalWidth = 500f;
                    table_heading3.LockedWidth = true;
                    table_heading3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results
                    PdfPCell heading_L2E = new PdfPCell(new Phrase("Mains Voltage - Live to Earth", heading));
                    heading_L2E.Colspan = 3;
                    heading_L2E.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    heading_L2E.BorderWidthBottom = 0.5f;
                    heading_L2E.BorderWidthTop = 0.5f;
                    heading_L2E.PaddingBottom = 10f;
                    heading_L2E.HorizontalAlignment = Element.ALIGN_CENTER;
                    table_heading3.AddCell(heading_L2E);

                    //add table
                    doc.Add(table_heading3);

                    //table contents
                    PdfPTable table_content3 = new PdfPTable(5);
                    table_content3.TotalWidth = 500f;
                    table_content3.LockedWidth = true;
                    table_content3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //headings
                    table_content3.AddCell(results);
                    table_content3.AddCell(value);
                    table_content3.AddCell(highlimit);
                    table_content3.AddCell(lowlimit);
                    table_content3.AddCell(standard);


                    //results:
                    PdfPCell L2E = new PdfPCell(new Phrase("Live to Earth: ", contentfont));
                    L2E.Border = 0;
                    table_content3.AddCell(L2E);
                    //value
                    PdfPCell value_L2E = new PdfPCell(new Phrase(_MV3, contentfont));
                    value_L2E.Border = 0;
                    table_content3.AddCell(value_L2E);
                    //High Limit
                    PdfPCell highlimit_L2E = new PdfPCell(new Phrase("", contentfont));
                    highlimit_L2E.Border = 0;
                    table_content3.AddCell(highlimit_L2E);
                    //Low Limit
                    PdfPCell lowlimit_L2E = new PdfPCell(new Phrase("", contentfont));
                    lowlimit_L2E.Border = 0;
                    table_content3.AddCell(lowlimit_L2E); //nothing for protective earth
                    //standard
                    PdfPCell standard_L2E = new PdfPCell(new Phrase(_testPDF, contentfont));
                    standard_L2E.Border = 0;
                    table_content3.AddCell(standard_L2E);

                    doc.Add(table_content3);

                    //----------------------------------------Protective Earth****

                    if (_currentTest == "ASNZ Standard 3551 - Class 1")
                    {
                        PdfPTable table_heading4 = new PdfPTable(3);

                        table_heading4.TotalWidth = 500f;
                        table_heading4.LockedWidth = true;
                        table_heading4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //title for the results
                        PdfPCell heading_PE = new PdfPCell(new Phrase("Protective Earth - Configuration: " + "Low", heading));
                        heading_PE.Colspan = 3;
                        heading_PE.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                        heading_PE.BorderWidthBottom = 0.5f;
                        heading_PE.BorderWidthTop = 0.5f;
                        heading_PE.PaddingBottom = 10f;
                        heading_PE.HorizontalAlignment = Element.ALIGN_CENTER;
                        table_heading4.AddCell(heading_PE);

                        //add table
                        doc.Add(table_heading4);

                        //table contents
                        PdfPTable table_content4 = new PdfPTable(5);
                        table_content4.TotalWidth = 500f;
                        table_content4.LockedWidth = true;
                        table_content4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //headings
                        table_content4.AddCell(results);
                        table_content4.AddCell(value);
                        table_content4.AddCell(highlimit);
                        table_content4.AddCell(lowlimit);
                        table_content4.AddCell(standard);


                        //results:
                        PdfPCell PE = new PdfPCell(new Phrase("Protective Earth Resistance: ", contentfont));
                        PE.Border = 0;
                        table_content4.AddCell(PE);
                        //value
                        PdfPCell value_PE = new PdfPCell(new Phrase(_earthResistance, contentfont));
                        value_PE.Border = 0;
                        table_content4.AddCell(value_PE);
                        //High Limit
                        PdfPCell highlimit_PE = new PdfPCell(new Phrase("", contentfont));
                        highlimit_PE.Border = 0;
                        table_content4.AddCell(highlimit_PE);
                        //Low Limit
                        PdfPCell lowlimit_PE = new PdfPCell(new Phrase("0.2 OHMS", contentfont));
                        lowlimit_PE.Border = 0;
                        table_content4.AddCell(lowlimit_PE); //nothing for protective earth
                                                             //standard
                        PdfPCell standard_PE = new PdfPCell(new Phrase(_testPDF, contentfont));
                        standard_PE.Border = 0;
                        table_content4.AddCell(standard_PE);

                        doc.Add(table_content4);
                    }



                    //----------------------------------------Insulation Resistance****
                    PdfPTable table_heading5 = new PdfPTable(3);

                    table_heading5.TotalWidth = 500f;
                    table_heading5.LockedWidth = true;
                    table_heading5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results
                    PdfPCell heading_IR = new PdfPCell(new Phrase("Insulation Resistance - Configuration: " + "Test Voltage: 500V", heading));
                    heading_IR.Colspan = 3;
                    heading_IR.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    heading_IR.BorderWidthBottom = 0.5f;
                    heading_IR.BorderWidthTop = 0.5f;
                    heading_IR.PaddingBottom = 10f;
                    heading_IR.HorizontalAlignment = Element.ALIGN_CENTER;
                    table_heading5.AddCell(heading_IR);

                    //add table
                    doc.Add(table_heading5);

                    //table contents
                    PdfPTable table_content5 = new PdfPTable(5);
                    table_content5.TotalWidth = 500f;
                    table_content5.LockedWidth = true;
                    table_content5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //headings
                    table_content5.AddCell(results);
                    table_content5.AddCell(value);
                    table_content5.AddCell(highlimit);
                    table_content5.AddCell(lowlimit);
                    table_content5.AddCell(standard);


                    //results:
                    PdfPCell M2PE = new PdfPCell(new Phrase("Mains to Protective Earth: ", contentfont));
                    M2PE.Border = 0;
                    table_content5.AddCell(M2PE);
                    //value***
                    PdfPCell value_M2PE = new PdfPCell(new Phrase(_insulationResistance, contentfont));
                    value_M2PE.Border = 0;
                    table_content5.AddCell(value_M2PE);
                    //High Limit
                    PdfPCell highlimit_M2PE = new PdfPCell(new Phrase("", contentfont));
                    highlimit_M2PE.Border = 0;
                    table_content5.AddCell(highlimit_M2PE);
                    //Low Limit
                    PdfPCell lowlimit_M2PE = new PdfPCell(new Phrase("1", contentfont));
                    lowlimit_M2PE.Border = 0;
                    table_content5.AddCell(lowlimit_M2PE);
                    //standard
                    PdfPCell standard_M2PE = new PdfPCell(new Phrase(_testPDF, contentfont));
                    standard_M2PE.Border = 0;
                    table_content5.AddCell(standard_M2PE);

                    doc.Add(table_content5);

                    //----------------------------------------Earth Leakage Current

                    if (_currentTest == "ASNZ Standard 3551 - Class 1")
                    {
                        //----------------------------------------Earth Leakage Current Normal Condition****

                        PdfPTable table_heading6 = new PdfPTable(3);

                        table_heading6.TotalWidth = 500f;
                        table_heading6.LockedWidth = true;
                        table_heading6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //title for the results
                        PdfPCell heading_ELC_NC = new PdfPCell(new Phrase("Earth Leakage Current - " + "Unused Applied Parts (Floating)", heading));
                        heading_ELC_NC.Colspan = 3;
                        heading_ELC_NC.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                        heading_ELC_NC.BorderWidthBottom = 0.5f;
                        heading_ELC_NC.BorderWidthTop = 0.5f;
                        heading_ELC_NC.PaddingBottom = 10f;
                        heading_ELC_NC.HorizontalAlignment = Element.ALIGN_CENTER;
                        table_heading6.AddCell(heading_ELC_NC);

                        //add table
                        doc.Add(table_heading6);

                        //table contents
                        PdfPTable table_content6 = new PdfPTable(5);
                        table_content6.TotalWidth = 500f;
                        table_content6.LockedWidth = true;
                        table_content6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //headings
                        table_content6.AddCell(results);
                        table_content6.AddCell(value);
                        table_content6.AddCell(highlimit);
                        table_content6.AddCell(lowlimit);
                        table_content6.AddCell(standard);


                        //results:
                        PdfPCell ELC_NM = new PdfPCell(new Phrase("Normal Condition: ", contentfont));
                        ELC_NM.Border = 0;
                        table_content6.AddCell(ELC_NM);
                        //value***
                        PdfPCell value_ELC_NM = new PdfPCell(new Phrase(_EL1, contentfont));
                        value_ELC_NM.Border = 0;
                        table_content6.AddCell(value_ELC_NM);
                        //High Limit
                        PdfPCell highlimit_ELC_NM = new PdfPCell(new Phrase("500", contentfont));
                        highlimit_ELC_NM.Border = 0;
                        table_content6.AddCell(highlimit_ELC_NM);
                        //Low Limit
                        PdfPCell lowlimit_ELC_NM = new PdfPCell(new Phrase("", contentfont));
                        lowlimit_ELC_NM.Border = 0;
                        table_content6.AddCell(lowlimit_ELC_NM);
                        //standard
                        PdfPCell standard_ELC_NM = new PdfPCell(new Phrase(_testPDF, contentfont));
                        standard_ELC_NM.Border = 0;
                        table_content6.AddCell(standard_ELC_NM);

                        doc.Add(table_content6);


                        //----------------------------------------Earth Leakage Current Open Neutral****
                        PdfPTable table_heading7 = new PdfPTable(3);

                        table_heading7.TotalWidth = 500f;
                        table_heading7.LockedWidth = true;
                        table_heading7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //title for the results
                        PdfPCell heading_ELC_ON = new PdfPCell(new Phrase("Earth Leakage Current - " + "Unused Applied Parts (Floating)", heading));
                        heading_ELC_ON.Colspan = 3;
                        heading_ELC_ON.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                        heading_ELC_ON.BorderWidthBottom = 0.5f;
                        heading_ELC_ON.BorderWidthTop = 0.5f;
                        heading_ELC_ON.PaddingBottom = 10f;
                        heading_ELC_ON.HorizontalAlignment = Element.ALIGN_CENTER;
                        table_heading7.AddCell(heading_ELC_ON);

                        //add table
                        doc.Add(table_heading7);

                        //table contents
                        PdfPTable table_content7 = new PdfPTable(5);
                        table_content7.TotalWidth = 500f;
                        table_content7.LockedWidth = true;
                        table_content7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //headings
                        table_content7.AddCell(results);
                        table_content7.AddCell(value);
                        table_content7.AddCell(highlimit);
                        table_content7.AddCell(lowlimit);
                        table_content7.AddCell(standard);


                        //results:
                        PdfPCell ELC_ON = new PdfPCell(new Phrase("Open Neutral: ", contentfont));
                        ELC_ON.Border = 0;
                        table_content7.AddCell(ELC_ON);
                        //value***
                        PdfPCell value_ELC_ON = new PdfPCell(new Phrase(_EL2, contentfont));
                        value_ELC_ON.Border = 0;
                        table_content7.AddCell(value_ELC_ON);
                        //High Limit
                        PdfPCell highlimit_ELC_ON = new PdfPCell(new Phrase("1000", contentfont));
                        highlimit_ELC_ON.Border = 0;
                        table_content7.AddCell(highlimit_ELC_ON);
                        //Low Limit
                        PdfPCell lowlimit_ELC_ON = new PdfPCell(new Phrase("", contentfont));
                        lowlimit_ELC_ON.Border = 0;
                        table_content7.AddCell(lowlimit_ELC_ON);
                        //standard
                        PdfPCell standard_ELC_ON = new PdfPCell(new Phrase(_testPDF, contentfont));
                        standard_ELC_ON.Border = 0;
                        table_content7.AddCell(standard_ELC_ON);

                        doc.Add(table_content7);
                    }

                    if (_currentTest == "ASNZ Standard 3551 - Class 1 (ECG)" || _currentTest == "ASNZ Standard 3551 - Class 2 (ECG)")
                    {
                        //----------------------------------------Patient Leakage Current Normal Condition****
                        PdfPTable PatientLeakage_heading = new PdfPTable(3);

                        PatientLeakage_heading.TotalWidth = 500f;
                        PatientLeakage_heading.LockedWidth = true;
                        PatientLeakage_heading.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //title for the results
                        PdfPCell PatientLeakage_heading_NC = new PdfPCell(new Phrase("Patient Leakage Current", heading));
                        PatientLeakage_heading_NC.Colspan = 3;
                        PatientLeakage_heading_NC.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                        PatientLeakage_heading_NC.BorderWidthBottom = 0.5f;
                        PatientLeakage_heading_NC.BorderWidthTop = 0.5f;
                        PatientLeakage_heading_NC.PaddingBottom = 10f;
                        PatientLeakage_heading_NC.HorizontalAlignment = Element.ALIGN_CENTER;
                        PatientLeakage_heading.AddCell(PatientLeakage_heading_NC);

                        //add table
                        doc.Add(PatientLeakage_heading);

                        //table contents
                        PdfPTable PatientLeakage_content = new PdfPTable(5);
                        PatientLeakage_content.TotalWidth = 500f;
                        PatientLeakage_content.LockedWidth = true;
                        PatientLeakage_content.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //headings
                        PatientLeakage_content.AddCell(results);
                        PatientLeakage_content.AddCell(value);
                        PatientLeakage_content.AddCell(highlimit);
                        PatientLeakage_content.AddCell(lowlimit);
                        PatientLeakage_content.AddCell(standard);

                        //results:
                        PdfPCell PatientLeakage_NC = new PdfPCell(new Phrase("Normal Condition: ", contentfont));
                        PatientLeakage_NC.Border = 0;
                        PatientLeakage_content.AddCell(PatientLeakage_NC);
                        //value***
                        PdfPCell value_PatientLeakage_NC = new PdfPCell(new Phrase(PLT1, contentfont));
                        value_PatientLeakage_NC.Border = 0;
                        PatientLeakage_content.AddCell(value_PatientLeakage_NC);
                        //High Limit
                        PdfPCell highlimit_PatientLeakage_NC = new PdfPCell(new Phrase("10", contentfont));
                        highlimit_PatientLeakage_NC.Border = 0;
                        PatientLeakage_content.AddCell(highlimit_PatientLeakage_NC);
                        //Low Limit
                        PdfPCell lowlimit_PatientLeakage_NC = new PdfPCell(new Phrase("", contentfont));
                        lowlimit_PatientLeakage_NC.Border = 0;
                        PatientLeakage_content.AddCell(lowlimit_PatientLeakage_NC);
                        //standard
                        PdfPCell standard_PatientLeakage_NC = new PdfPCell(new Phrase(_testPDF, contentfont));
                        standard_PatientLeakage_NC.Border = 0;
                        PatientLeakage_content.AddCell(standard_PatientLeakage_NC);

                        doc.Add(PatientLeakage_content);

                        //----------------------------------------Patient Leakage Current Open Neutral Condition****
                        PdfPTable PatientLeakage2_heading = new PdfPTable(3);

                        PatientLeakage2_heading.TotalWidth = 500f;
                        PatientLeakage2_heading.LockedWidth = true;
                        PatientLeakage2_heading.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //title for the results
                        PdfPCell PatientLeakage_heading_ON = new PdfPCell(new Phrase("Patient Leakage Current", heading));
                        PatientLeakage_heading_ON.Colspan = 3;
                        PatientLeakage_heading_ON.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                        PatientLeakage_heading_ON.BorderWidthBottom = 0.5f;
                        PatientLeakage_heading_ON.BorderWidthTop = 0.5f;
                        PatientLeakage_heading_ON.PaddingBottom = 10f;
                        PatientLeakage_heading_ON.HorizontalAlignment = Element.ALIGN_CENTER;
                        PatientLeakage2_heading.AddCell(PatientLeakage_heading_ON);

                        //add table
                        doc.Add(PatientLeakage2_heading);

                        //table contents
                        PdfPTable PatientLeakage2_content = new PdfPTable(5);
                        PatientLeakage2_content.TotalWidth = 500f;
                        PatientLeakage2_content.LockedWidth = true;
                        PatientLeakage2_content.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //headings
                        PatientLeakage2_content.AddCell(results);
                        PatientLeakage2_content.AddCell(value);
                        PatientLeakage2_content.AddCell(highlimit);
                        PatientLeakage2_content.AddCell(lowlimit);
                        PatientLeakage2_content.AddCell(standard);

                        //results:
                        PdfPCell PatientLeakage_ON = new PdfPCell(new Phrase("Normal Condition: ", contentfont));
                        PatientLeakage_ON.Border = 0;
                        PatientLeakage2_content.AddCell(PatientLeakage_ON);
                        //value***
                        PdfPCell value_PatientLeakage_ON = new PdfPCell(new Phrase(PLT2, contentfont));
                        value_PatientLeakage_ON.Border = 0;
                        PatientLeakage2_content.AddCell(value_PatientLeakage_ON);
                        //High Limit
                        PdfPCell highlimit_PatientLeakage_ON = new PdfPCell(new Phrase("50", contentfont));
                        highlimit_PatientLeakage_ON.Border = 0;
                        PatientLeakage2_content.AddCell(highlimit_PatientLeakage_ON);
                        //Low Limit
                        PdfPCell lowlimit_PatientLeakage_ON = new PdfPCell(new Phrase("", contentfont));
                        lowlimit_PatientLeakage_ON.Border = 0;
                        PatientLeakage2_content.AddCell(lowlimit_PatientLeakage_ON);
                        //standard
                        PdfPCell standard_PatientLeakage_ON = new PdfPCell(new Phrase(_testPDF, contentfont));
                        standard_PatientLeakage_ON.Border = 0;
                        PatientLeakage2_content.AddCell(standard_PatientLeakage_ON);

                        doc.Add(PatientLeakage2_content);

                        //----------------------------------------Patient Leakage Current Open Earth Condition****
                        PdfPTable PatientLeakage3_heading = new PdfPTable(3);

                        PatientLeakage3_heading.TotalWidth = 500f;
                        PatientLeakage3_heading.LockedWidth = true;
                        PatientLeakage3_heading.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //title for the results
                        PdfPCell PatientLeakage_heading_OE = new PdfPCell(new Phrase("Patient Leakage Current", heading));
                        PatientLeakage_heading_OE.Colspan = 3;
                        PatientLeakage_heading_OE.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                        PatientLeakage_heading_OE.BorderWidthBottom = 0.5f;
                        PatientLeakage_heading_OE.BorderWidthTop = 0.5f;
                        PatientLeakage_heading_OE.PaddingBottom = 10f;
                        PatientLeakage_heading_OE.HorizontalAlignment = Element.ALIGN_CENTER;
                        PatientLeakage3_heading.AddCell(PatientLeakage_heading_OE);

                        //add table
                        doc.Add(PatientLeakage3_heading);

                        //table contents
                        PdfPTable PatientLeakage3_content = new PdfPTable(5);
                        PatientLeakage3_content.TotalWidth = 500f;
                        PatientLeakage3_content.LockedWidth = true;
                        PatientLeakage3_content.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //headings
                        PatientLeakage3_content.AddCell(results);
                        PatientLeakage3_content.AddCell(value);
                        PatientLeakage3_content.AddCell(highlimit);
                        PatientLeakage3_content.AddCell(lowlimit);
                        PatientLeakage3_content.AddCell(standard);

                        //results:
                        PdfPCell PatientLeakage_OE = new PdfPCell(new Phrase("Normal Condition: ", contentfont));
                        PatientLeakage_OE.Border = 0;
                        PatientLeakage3_content.AddCell(PatientLeakage_OE);
                        //value***
                        PdfPCell value_PatientLeakage_OE = new PdfPCell(new Phrase(PLT3, contentfont));
                        value_PatientLeakage_OE.Border = 0;
                        PatientLeakage3_content.AddCell(value_PatientLeakage_OE);
                        //High Limit
                        PdfPCell highlimit_PatientLeakage_OE = new PdfPCell(new Phrase("50", contentfont));
                        highlimit_PatientLeakage_OE.Border = 0;
                        PatientLeakage3_content.AddCell(highlimit_PatientLeakage_OE);
                        //Low Limit
                        PdfPCell lowlimit_PatientLeakage_OE = new PdfPCell(new Phrase("", contentfont));
                        lowlimit_PatientLeakage_OE.Border = 0;
                        PatientLeakage3_content.AddCell(lowlimit_PatientLeakage_OE);
                        //standard
                        PdfPCell standard_PatientLeakage_OE = new PdfPCell(new Phrase(_testPDF, contentfont));
                        standard_PatientLeakage_OE.Border = 0;
                        PatientLeakage3_content.AddCell(standard_PatientLeakage_OE);

                        doc.Add(PatientLeakage3_content);

                        //----------------------------------------Single Fault Condition****
                        PdfPTable SingleFault_heading = new PdfPTable(3);

                        SingleFault_heading.TotalWidth = 500f;
                        SingleFault_heading.LockedWidth = true;
                        SingleFault_heading.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //title for the results
                        PdfPCell SingleFault = new PdfPCell(new Phrase("Single Fault Condition", heading));
                        SingleFault.Colspan = 3;
                        SingleFault.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                        SingleFault.BorderWidthBottom = 0.5f;
                        SingleFault.BorderWidthTop = 0.5f;
                        SingleFault.PaddingBottom = 10f;
                        SingleFault.HorizontalAlignment = Element.ALIGN_CENTER;
                        SingleFault_heading.AddCell(SingleFault);

                        //add table
                        doc.Add(SingleFault_heading);

                        //table contents
                        PdfPTable SingleFault_content = new PdfPTable(5);
                        SingleFault_content.TotalWidth = 500f;
                        SingleFault_content.LockedWidth = true;
                        SingleFault_content.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                        //headings
                        SingleFault_content.AddCell(results);
                        SingleFault_content.AddCell(value);
                        SingleFault_content.AddCell(highlimit);
                        SingleFault_content.AddCell(lowlimit);
                        SingleFault_content.AddCell(standard);

                        //results:
                        PdfPCell SingleFault_OE = new PdfPCell(new Phrase("Results: ", contentfont));
                        SingleFault_OE.Border = 0;
                        SingleFault_content.AddCell(SingleFault_OE);
                        //value***
                        PdfPCell value_SingleFault_OE = new PdfPCell(new Phrase(SFN, contentfont));
                        value_SingleFault_OE.Border = 0;
                        SingleFault_content.AddCell(value_SingleFault_OE);
                        //High Limit
                        PdfPCell highlimit_SingleFault_OE = new PdfPCell(new Phrase("50", contentfont));
                        highlimit_SingleFault_OE.Border = 0;
                        SingleFault_content.AddCell(highlimit_SingleFault_OE);
                        //Low Limit
                        PdfPCell lowlimit_SingleFault_OE = new PdfPCell(new Phrase("", contentfont));
                        lowlimit_SingleFault_OE.Border = 0;
                        SingleFault_content.AddCell(lowlimit_SingleFault_OE);
                        //standard
                        PdfPCell standard_SingleFault_OE = new PdfPCell(new Phrase(_testPDF, contentfont));
                        standard_SingleFault_OE.Border = 0;
                        SingleFault_content.AddCell(standard_SingleFault_OE);

                        doc.Add(SingleFault_content);

                    }


                    //----------------------------------------Enclosure Leakage Current Normal Condition****
                    PdfPTable table_heading8 = new PdfPTable(3);

                    table_heading8.TotalWidth = 500f;
                    table_heading8.LockedWidth = true;
                    table_heading8.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results
                    PdfPCell heading_EnLC_NC = new PdfPCell(new Phrase("Enclosure Leakage Current - " + "Unused Applied Parts (Floating)", heading));
                    heading_EnLC_NC.Colspan = 3;
                    heading_EnLC_NC.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    heading_EnLC_NC.BorderWidthBottom = 0.5f;
                    heading_EnLC_NC.BorderWidthTop = 0.5f;
                    heading_EnLC_NC.PaddingBottom = 10f;
                    heading_EnLC_NC.HorizontalAlignment = Element.ALIGN_CENTER;
                    table_heading8.AddCell(heading_EnLC_NC);

                    //add table
                    doc.Add(table_heading8);

                    //table contents
                    PdfPTable table_content8 = new PdfPTable(5);
                    table_content8.TotalWidth = 500f;
                    table_content8.LockedWidth = true;
                    table_content8.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //headings
                    table_content8.AddCell(results);
                    table_content8.AddCell(value);
                    table_content8.AddCell(highlimit);
                    table_content8.AddCell(lowlimit);
                    table_content8.AddCell(standard);


                    //results:
                    PdfPCell EnLC_NC = new PdfPCell(new Phrase("Normal Condition: ", contentfont));
                    EnLC_NC.Border = 0;
                    table_content8.AddCell(EnLC_NC);
                    //value***
                    PdfPCell value_EnLC_NC = new PdfPCell(new Phrase(_EnL1, contentfont));
                    value_EnLC_NC.Border = 0;
                    table_content8.AddCell(value_EnLC_NC);
                    //High Limit
                    PdfPCell highlimit_EnLC_NC = new PdfPCell(new Phrase("100", contentfont));
                    highlimit_EnLC_NC.Border = 0;
                    table_content8.AddCell(highlimit_EnLC_NC);
                    //Low Limit
                    PdfPCell lowlimit_EnLC_NC = new PdfPCell(new Phrase("", contentfont));
                    lowlimit_EnLC_NC.Border = 0;
                    table_content8.AddCell(lowlimit_EnLC_NC);
                    //standard
                    PdfPCell standard_EnLC_NC = new PdfPCell(new Phrase(_testPDF, contentfont));
                    standard_EnLC_NC.Border = 0;
                    table_content8.AddCell(standard_EnLC_NC);

                    doc.Add(table_content8);


                    //----------------------------------------Enclosure Leakage Current Open Neutral****
                    PdfPTable table_heading9 = new PdfPTable(3);

                    table_heading9.TotalWidth = 500f;
                    table_heading9.LockedWidth = true;
                    table_heading9.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results
                    PdfPCell heading_EnLC_ON = new PdfPCell(new Phrase("Enclosure Leakage Current - " + "Unused Applied Parts (Floating)", heading));
                    heading_EnLC_ON.Colspan = 3;
                    heading_EnLC_ON.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    heading_EnLC_ON.BorderWidthBottom = 0.5f;
                    heading_EnLC_ON.BorderWidthTop = 0.5f;
                    heading_EnLC_ON.PaddingBottom = 10f;
                    heading_EnLC_ON.HorizontalAlignment = Element.ALIGN_CENTER;
                    table_heading9.AddCell(heading_EnLC_ON);

                    //add table
                    doc.Add(table_heading9);

                    //table contents
                    PdfPTable table_content9 = new PdfPTable(5);
                    table_content9.TotalWidth = 500f;
                    table_content9.LockedWidth = true;
                    table_content9.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //headings
                    table_content9.AddCell(results);
                    table_content9.AddCell(value);
                    table_content9.AddCell(highlimit);
                    table_content9.AddCell(lowlimit);
                    table_content9.AddCell(standard);


                    //results:
                    PdfPCell EnLC_ON = new PdfPCell(new Phrase("Open Neutral: ", contentfont));
                    EnLC_ON.Border = 0;
                    table_content9.AddCell(EnLC_ON);
                    //value***
                    PdfPCell value_EnLC_ON = new PdfPCell(new Phrase(_EnL2, contentfont));
                    value_EnLC_ON.Border = 0;
                    table_content9.AddCell(value_EnLC_ON);
                    //High Limit
                    PdfPCell highlimit_EnLC_ON = new PdfPCell(new Phrase("500", contentfont));
                    highlimit_EnLC_ON.Border = 0;
                    table_content9.AddCell(highlimit_EnLC_ON);
                    //Low Limit
                    PdfPCell lowlimit_EnLC_ON = new PdfPCell(new Phrase("", contentfont));
                    lowlimit_EnLC_ON.Border = 0;
                    table_content9.AddCell(lowlimit_EnLC_ON);
                    //standard
                    PdfPCell standard_EnLC_ON = new PdfPCell(new Phrase(_testPDF, contentfont));
                    standard_EnLC_ON.Border = 0;
                    table_content9.AddCell(standard_EnLC_ON);

                    doc.Add(table_content9);


                    //----------------------------------------Enclosure Leakage Current Open Earth****
                    PdfPTable table_heading10 = new PdfPTable(3);

                    table_heading10.TotalWidth = 500f;
                    table_heading10.LockedWidth = true;
                    table_heading10.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results
                    PdfPCell heading_EnLC_OP = new PdfPCell(new Phrase("Enclosure Leakage Current - " + "Unused Applied Parts (Floating)", heading));
                    heading_EnLC_OP.Colspan = 3;
                    heading_EnLC_OP.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    heading_EnLC_OP.BorderWidthBottom = 0.5f;
                    heading_EnLC_OP.BorderWidthTop = 0.5f;
                    heading_EnLC_OP.PaddingBottom = 10f;
                    heading_EnLC_OP.HorizontalAlignment = Element.ALIGN_CENTER;
                    table_heading10.AddCell(heading_EnLC_OP);

                    //add table
                    doc.Add(table_heading10);

                    //table contents
                    PdfPTable table_content10 = new PdfPTable(5);
                    table_content10.TotalWidth = 500f;
                    table_content10.LockedWidth = true;
                    table_content10.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //headings
                    table_content10.AddCell(results);
                    table_content10.AddCell(value);
                    table_content10.AddCell(highlimit);
                    table_content10.AddCell(lowlimit);
                    table_content10.AddCell(standard);


                    //results:
                    PdfPCell EnLC_OP = new PdfPCell(new Phrase("Open Earth: ", contentfont));
                    EnLC_OP.Border = 0;
                    table_content10.AddCell(EnLC_OP);
                    //value***
                    PdfPCell value_EnLC_OP = new PdfPCell(new Phrase(_EnL3, contentfont));
                    value_EnLC_OP.Border = 0;
                    table_content10.AddCell(value_EnLC_OP);
                    //High Limit
                    PdfPCell highlimit_EnLC_OP = new PdfPCell(new Phrase("500", contentfont));
                    highlimit_EnLC_OP.Border = 0;
                    table_content10.AddCell(highlimit_EnLC_OP);
                    //Low Limit
                    PdfPCell lowlimit_EnLC_OP = new PdfPCell(new Phrase("", contentfont));
                    lowlimit_EnLC_OP.Border = 0;
                    table_content10.AddCell(lowlimit_EnLC_OP);
                    //standard
                    PdfPCell standard_EnLC_OP = new PdfPCell(new Phrase(_testPDF, contentfont));
                    standard_EnLC_OP.Border = 0;
                    table_content10.AddCell(standard_EnLC_OP);

                    doc.Add(table_content10);


                    //----------------------------------------Enclosure Leakage Current NC Reversed Mains****
                    PdfPTable table_heading11 = new PdfPTable(3);

                    table_heading11.TotalWidth = 500f;
                    table_heading11.LockedWidth = true;
                    table_heading11.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results
                    PdfPCell heading_EnLC_NC_R = new PdfPCell(new Phrase("Enclosure Leakage Current - " + "Unused Applied Parts (Floating)", heading));
                    heading_EnLC_NC_R.Colspan = 3;
                    heading_EnLC_NC_R.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    heading_EnLC_NC_R.BorderWidthBottom = 0.5f;
                    heading_EnLC_NC_R.BorderWidthTop = 0.5f;
                    heading_EnLC_NC_R.PaddingBottom = 10f;
                    heading_EnLC_NC_R.HorizontalAlignment = Element.ALIGN_CENTER;
                    table_heading11.AddCell(heading_EnLC_NC_R);

                    //add table
                    doc.Add(table_heading11);

                    //table contents
                    PdfPTable table_content11 = new PdfPTable(5);
                    table_content11.TotalWidth = 500f;
                    table_content11.LockedWidth = true;
                    table_content11.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //headings
                    table_content11.AddCell(results);
                    table_content11.AddCell(value);
                    table_content11.AddCell(highlimit);
                    table_content11.AddCell(lowlimit);
                    table_content11.AddCell(standard);


                    //results:
                    PdfPCell EnLC_NC_R = new PdfPCell(new Phrase("Normal Condition, Reversed Mains: ", contentfont));
                    EnLC_NC_R.Border = 0;
                    table_content11.AddCell(EnLC_NC_R);
                    //value***
                    PdfPCell value_EnLC_NC_R = new PdfPCell(new Phrase(_EnL4, contentfont));
                    value_EnLC_NC_R.Border = 0;
                    table_content11.AddCell(value_EnLC_NC_R);
                    //High Limit
                    PdfPCell highlimit_EnLC_NC_R = new PdfPCell(new Phrase("100", contentfont));
                    highlimit_EnLC_NC_R.Border = 0;
                    table_content11.AddCell(highlimit_EnLC_NC_R);
                    //Low Limit
                    PdfPCell lowlimit_EnLC_NC_R = new PdfPCell(new Phrase("", contentfont));
                    lowlimit_EnLC_NC_R.Border = 0;
                    table_content11.AddCell(lowlimit_EnLC_NC_R);
                    //standard
                    PdfPCell standard_EnLC_NC_R = new PdfPCell(new Phrase(_testPDF, contentfont));
                    standard_EnLC_NC_R.Border = 0;
                    table_content11.AddCell(standard_EnLC_NC_R);

                    doc.Add(table_content11);

                    //----------------------------------------Enclosure Leakage Current Open Neutral Reversed Mains****
                    PdfPTable table_heading12 = new PdfPTable(3);

                    table_heading12.TotalWidth = 500f;
                    table_heading12.LockedWidth = true;
                    table_heading12.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results
                    PdfPCell heading_EnLC_ON_R = new PdfPCell(new Phrase("Enclosure Leakage Current - " + "Unused Applied Parts (Floating)", heading));
                    heading_EnLC_ON_R.Colspan = 3;
                    heading_EnLC_ON_R.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    heading_EnLC_ON_R.BorderWidthBottom = 0.5f;
                    heading_EnLC_ON_R.BorderWidthTop = 0.5f;
                    heading_EnLC_ON_R.PaddingBottom = 10f;
                    heading_EnLC_ON_R.HorizontalAlignment = Element.ALIGN_CENTER;
                    table_heading12.AddCell(heading_EnLC_ON_R);

                    //add table
                    doc.Add(table_heading12);

                    //table contents
                    PdfPTable table_content12 = new PdfPTable(5);
                    table_content12.TotalWidth = 500f;
                    table_content12.LockedWidth = true;
                    table_content12.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //headings
                    table_content12.AddCell(results);
                    table_content12.AddCell(value);
                    table_content12.AddCell(highlimit);
                    table_content12.AddCell(lowlimit);
                    table_content12.AddCell(standard);


                    //results:
                    PdfPCell EnLC_ON_R = new PdfPCell(new Phrase("Open Neutral, Reversed: ", contentfont));
                    EnLC_ON_R.Border = 0;
                    table_content12.AddCell(EnLC_ON_R);
                    //value***
                    PdfPCell value_EnLC_ON_R = new PdfPCell(new Phrase(_EnL5, contentfont));
                    value_EnLC_ON_R.Border = 0;
                    table_content12.AddCell(value_EnLC_ON_R);
                    //High Limit
                    PdfPCell highlimit_EnLC_ON_R = new PdfPCell(new Phrase("500", contentfont));
                    highlimit_EnLC_ON_R.Border = 0;
                    table_content12.AddCell(highlimit_EnLC_ON_R);
                    //Low Limit
                    PdfPCell lowlimit_EnLC_ON_R = new PdfPCell(new Phrase("", contentfont));
                    lowlimit_EnLC_ON_R.Border = 0;
                    table_content12.AddCell(lowlimit_EnLC_ON_R);
                    //standard
                    PdfPCell standard_EnLC_ON_R = new PdfPCell(new Phrase(_testPDF, contentfont));
                    standard_EnLC_ON_R.Border = 0;
                    table_content12.AddCell(standard_EnLC_ON_R);

                    doc.Add(table_content12);


                    //----------------------------------------Enclosure Leakage Current Open Earth Reversed Mains****
                    PdfPTable table_heading13 = new PdfPTable(3);

                    table_heading13.TotalWidth = 500f;
                    table_heading13.LockedWidth = true;
                    table_heading13.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //title for the results
                    PdfPCell heading_EnLC_OP_R = new PdfPCell(new Phrase("Enclosure Leakage Current - " + "Unused Applied Parts (Floating)", heading));
                    heading_EnLC_OP_R.Colspan = 3;
                    heading_EnLC_OP_R.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    heading_EnLC_OP_R.BorderWidthBottom = 0.5f;
                    heading_EnLC_OP_R.BorderWidthTop = 0.5f;
                    heading_EnLC_OP_R.PaddingBottom = 10f;
                    heading_EnLC_OP_R.HorizontalAlignment = Element.ALIGN_CENTER;
                    table_heading13.AddCell(heading_EnLC_OP_R);

                    //add table
                    doc.Add(table_heading13);

                    //table contents
                    PdfPTable table_content13 = new PdfPTable(5);
                    table_content13.TotalWidth = 500f;
                    table_content13.LockedWidth = true;
                    table_content13.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //headings
                    table_content13.AddCell(results);
                    table_content13.AddCell(value);
                    table_content13.AddCell(highlimit);
                    table_content13.AddCell(lowlimit);
                    table_content13.AddCell(standard);


                    //results:
                    PdfPCell EnLC_OP_R = new PdfPCell(new Phrase("Open Earth, Reversed: ", contentfont));
                    EnLC_OP_R.Border = 0;
                    table_content13.AddCell(EnLC_OP_R);
                    //value***
                    PdfPCell value_EnLC_OP_R = new PdfPCell(new Phrase(_EnL6, contentfont));
                    value_EnLC_OP_R.Border = 0;
                    table_content13.AddCell(value_EnLC_OP_R);
                    //High Limit
                    PdfPCell highlimit_EnLC_OP_R = new PdfPCell(new Phrase("500", contentfont));
                    highlimit_EnLC_OP_R.Border = 0;
                    table_content13.AddCell(highlimit_EnLC_OP_R);
                    //Low Limit
                    PdfPCell lowlimit_EnLC_OP_R = new PdfPCell(new Phrase("", contentfont));
                    lowlimit_EnLC_OP_R.Border = 0;
                    table_content13.AddCell(lowlimit_EnLC_OP_R);
                    //standard
                    PdfPCell standard_EnLC_OP_R = new PdfPCell(new Phrase(_testPDF, contentfont));
                    standard_EnLC_OP_R.Border = 0;
                    table_content13.AddCell(standard_EnLC_OP_R);

                    doc.Add(table_content13);







                    ////----------------------------------------Perfomance Verification - ECG
                    //if (ECG_Machine.PVT_ECG == true)
                    //{
                    //    doc.NewPage();
                    //    //add bg
                    //    doc.Add(bgImage);


                    //    doc.Add(new Phrase("Performance Verification Test Results", heading2));

                    //    //----------------------------------Heading 1
                    //    PdfPTable ECG_main_heading1 = new PdfPTable(3);

                    //    ECG_main_heading1.TotalWidth = 500f;
                    //    ECG_main_heading1.LockedWidth = true;
                    //    ECG_main_heading1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell ECG_heading1 = new PdfPCell(new Phrase(ECG_Machine.option1_label, heading));
                    //    ECG_heading1.Colspan = 3;
                    //    ECG_heading1.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    ECG_heading1.BorderWidthBottom = 0.5f;
                    //    ECG_heading1.BorderWidthTop = 0.5f;
                    //    ECG_heading1.PaddingBottom = 10f;
                    //    ECG_heading1.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    ECG_main_heading1.AddCell(ECG_heading1);

                    //    //add table
                    //    doc.Add(ECG_main_heading1);

                    //    //table contents
                    //    PdfPTable ECG_content1 = new PdfPTable(2);
                    //    ECG_content1.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    ECG_content1.TotalWidth = 500f;
                    //    ECG_content1.LockedWidth = true;
                    //    ECG_content1.SetWidths(new float[] { 440f, 60f });
                    //    ECG_content1.HorizontalAlignment = 1;
                    //    ECG_content1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell ECG_heading1_description = new PdfPCell(new Phrase(ECG_Machine.desc1_text, contentfont2));
                    //    ECG_heading1_description.Border = 0;
                    //    ECG_content1.AddCell(ECG_heading1_description);

                    //    PdfPCell ECG_results1 = new PdfPCell(new Phrase(ECG_Machine.option1, boldfont3));
                    //    ECG_results1.Border = 0;
                    //    ECG_results1.PaddingBottom = 10f;
                    //    ECG_content1.AddCell(ECG_results1);

                    //    //add table
                    //    doc.Add(ECG_content1);


                    //    //----------------------------------Heading 2
                    //    PdfPTable ECG_main_heading2 = new PdfPTable(3);

                    //    ECG_main_heading2.TotalWidth = 500f;
                    //    ECG_main_heading2.LockedWidth = true;
                    //    ECG_main_heading2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell ECG_heading2 = new PdfPCell(new Phrase(ECG_Machine.option2_label, heading));
                    //    ECG_heading2.Colspan = 3;
                    //    ECG_heading2.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    ECG_heading2.BorderWidthBottom = 0.5f;
                    //    ECG_heading2.BorderWidthTop = 0.5f;
                    //    ECG_heading2.PaddingBottom = 10f;
                    //    ECG_heading2.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    ECG_main_heading2.AddCell(ECG_heading2);

                    //    //add table
                    //    doc.Add(ECG_main_heading2);



                    //    //table contents
                    //    PdfPTable ECG_content2 = new PdfPTable(2);
                    //    ECG_content2.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    ECG_content2.TotalWidth = 500f;
                    //    ECG_content2.LockedWidth = true;
                    //    ECG_content2.SetWidths(new float[] { 440f, 60f });
                    //    ECG_content2.HorizontalAlignment = 1;
                    //    ECG_content2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell ECG_heading2_description = new PdfPCell(new Phrase(ECG_Machine.desc2_text, contentfont2));
                    //    ECG_heading2_description.Border = 0;
                    //    ECG_content2.AddCell(ECG_heading2_description);

                    //    PdfPCell ECG_results2 = new PdfPCell(new Phrase(ECG_Machine.option2, boldfont3));
                    //    ECG_results2.Border = 0;
                    //    ECG_results2.PaddingBottom = 10f;
                    //    ECG_content2.AddCell(ECG_results2);

                    //    //add table
                    //    doc.Add(ECG_content2);


                    //    //----------------------------------Heading 3
                    //    PdfPTable ECG_main_heading3 = new PdfPTable(3);

                    //    ECG_main_heading3.TotalWidth = 500f;
                    //    ECG_main_heading3.LockedWidth = true;
                    //    ECG_main_heading3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell ECG_heading3 = new PdfPCell(new Phrase(ECG_Machine.option3_label, heading));
                    //    ECG_heading3.Colspan = 3;
                    //    ECG_heading3.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    ECG_heading3.BorderWidthBottom = 0.5f;
                    //    ECG_heading3.BorderWidthTop = 0.5f;
                    //    ECG_heading3.PaddingBottom = 10f;
                    //    ECG_heading3.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    ECG_main_heading3.AddCell(ECG_heading3);

                    //    //add table
                    //    doc.Add(ECG_main_heading3);

                    //    //table contents
                    //    PdfPTable ECG_content3 = new PdfPTable(2);
                    //    ECG_content3.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    ECG_content3.TotalWidth = 500f;
                    //    ECG_content3.LockedWidth = true;
                    //    ECG_content3.SetWidths(new float[] { 440f, 60f });
                    //    ECG_content3.HorizontalAlignment = 1;
                    //    ECG_content3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell ECG_heading3_description = new PdfPCell(new Phrase(ECG_Machine.desc3_text, contentfont2));
                    //    ECG_heading3_description.Border = 0;
                    //    ECG_content3.AddCell(ECG_heading3_description);

                    //    PdfPCell ECG_results3 = new PdfPCell(new Phrase(ECG_Machine.option3, boldfont3));
                    //    ECG_results3.Border = 0;
                    //    ECG_results3.PaddingBottom = 10f;
                    //    ECG_content3.AddCell(ECG_results3);

                    //    //add table
                    //    doc.Add(ECG_content3);


                    //    //----------------------------------Heading 4
                    //    PdfPTable ECG_main_heading4 = new PdfPTable(3);

                    //    ECG_main_heading4.TotalWidth = 500f;
                    //    ECG_main_heading4.LockedWidth = true;
                    //    ECG_main_heading4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell ECG_heading4 = new PdfPCell(new Phrase(ECG_Machine.option4_label, heading));
                    //    ECG_heading4.Colspan = 3;
                    //    ECG_heading4.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    ECG_heading4.BorderWidthBottom = 0.5f;
                    //    ECG_heading4.BorderWidthTop = 0.5f;
                    //    ECG_heading4.PaddingBottom = 10f;
                    //    ECG_heading4.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    ECG_main_heading4.AddCell(ECG_heading4);

                    //    //add table
                    //    doc.Add(ECG_main_heading4);

                    //    //table contents
                    //    PdfPTable ECG_content4 = new PdfPTable(2);
                    //    ECG_content4.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    ECG_content4.TotalWidth = 500f;
                    //    ECG_content4.LockedWidth = true;
                    //    ECG_content4.SetWidths(new float[] { 440f, 60f });
                    //    ECG_content4.HorizontalAlignment = 1;
                    //    ECG_content4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell ECG_heading4_description = new PdfPCell(new Phrase(ECG_Machine.desc4_text, contentfont2));
                    //    ECG_heading4_description.Border = 0;
                    //    ECG_content4.AddCell(ECG_heading4_description);

                    //    PdfPCell ECG_results4 = new PdfPCell(new Phrase(ECG_Machine.option4, boldfont3));
                    //    ECG_results4.Border = 0;
                    //    ECG_results4.PaddingBottom = 10f;
                    //    ECG_content4.AddCell(ECG_results4);

                    //    //add table
                    //    doc.Add(ECG_content4);

                    //}

                    ////----------------------------------------Perfomance Verification - NIBP
                    //if (NIBP_Monitor.PVT_NIBP == true)
                    //{
                    //    doc.NewPage();
                    //    //add bg
                    //    doc.Add(bgImage);


                    //    doc.Add(new Phrase("Performance Verification Test Results", heading2));

                    //    //----------------------------------Heading 1
                    //    PdfPTable NIBP_main_heading1 = new PdfPTable(3);

                    //    NIBP_main_heading1.TotalWidth = 500f;
                    //    NIBP_main_heading1.LockedWidth = true;
                    //    NIBP_main_heading1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell NIBP_heading1 = new PdfPCell(new Phrase(NIBP_Monitor.option1_label, heading));
                    //    NIBP_heading1.Colspan = 3;
                    //    NIBP_heading1.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    NIBP_heading1.BorderWidthBottom = 0.5f;
                    //    NIBP_heading1.BorderWidthTop = 0.5f;
                    //    NIBP_heading1.PaddingBottom = 10f;
                    //    NIBP_heading1.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_main_heading1.AddCell(NIBP_heading1);

                    //    //add table
                    //    doc.Add(NIBP_main_heading1);

                    //    //table contents
                    //    PdfPTable NIBP_content1 = new PdfPTable(2);
                    //    NIBP_content1.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_content1.TotalWidth = 500f;
                    //    NIBP_content1.LockedWidth = true;
                    //    NIBP_content1.SetWidths(new float[] { 440f, 60f });
                    //    NIBP_content1.HorizontalAlignment = 1;
                    //    NIBP_content1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell NIBP_heading1_description = new PdfPCell(new Phrase(NIBP_Monitor.desc1_text, contentfont2));
                    //    NIBP_heading1_description.Border = 0;
                    //    NIBP_content1.AddCell(NIBP_heading1_description);

                    //    PdfPCell NIBP_results1 = new PdfPCell(new Phrase(NIBP_Monitor.option1, boldfont3));
                    //    NIBP_results1.Border = 0;
                    //    NIBP_results1.PaddingBottom = 10f;
                    //    NIBP_content1.AddCell(NIBP_results1);

                    //    //add table
                    //    doc.Add(NIBP_content1);

                    //    //----------------------------------Heading 2
                    //    PdfPTable NIBP_main_heading2 = new PdfPTable(3);

                    //    NIBP_main_heading2.TotalWidth = 500f;
                    //    NIBP_main_heading2.LockedWidth = true;
                    //    NIBP_main_heading2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell NIBP_heading2 = new PdfPCell(new Phrase(NIBP_Monitor.option1_label, heading));
                    //    NIBP_heading2.Colspan = 3;
                    //    NIBP_heading2.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    NIBP_heading2.BorderWidthBottom = 0.5f;
                    //    NIBP_heading2.BorderWidthTop = 0.5f;
                    //    NIBP_heading2.PaddingBottom = 10f;
                    //    NIBP_heading2.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_main_heading2.AddCell(NIBP_heading2);

                    //    //add table
                    //    doc.Add(NIBP_main_heading2);

                    //    //table contents
                    //    PdfPTable NIBP_content2 = new PdfPTable(2);
                    //    NIBP_content2.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_content2.TotalWidth = 500f;
                    //    NIBP_content2.LockedWidth = true;
                    //    NIBP_content2.SetWidths(new float[] { 440f, 60f });
                    //    NIBP_content2.HorizontalAlignment = 1;
                    //    NIBP_content2.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell NIBP_heading2_description = new PdfPCell(new Phrase(NIBP_Monitor.desc2_text, contentfont2));
                    //    NIBP_heading2_description.Border = 0;
                    //    NIBP_content2.AddCell(NIBP_heading2_description);

                    //    PdfPCell NIBP_results2 = new PdfPCell(new Phrase(NIBP_Monitor.option2, boldfont3));
                    //    NIBP_results2.Border = 0;
                    //    NIBP_results2.PaddingBottom = 10f;
                    //    NIBP_content2.AddCell(NIBP_results2);

                    //    //add table
                    //    doc.Add(NIBP_content2);

                    //    //----------------------------------Heading 3
                    //    PdfPTable NIBP_main_heading3 = new PdfPTable(3);

                    //    NIBP_main_heading3.TotalWidth = 500f;
                    //    NIBP_main_heading3.LockedWidth = true;
                    //    NIBP_main_heading3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell NIBP_heading3 = new PdfPCell(new Phrase(NIBP_Monitor.option1_label, heading));
                    //    NIBP_heading3.Colspan = 3;
                    //    NIBP_heading3.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    NIBP_heading3.BorderWidthBottom = 0.5f;
                    //    NIBP_heading3.BorderWidthTop = 0.5f;
                    //    NIBP_heading3.PaddingBottom = 10f;
                    //    NIBP_heading3.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_main_heading3.AddCell(NIBP_heading3);

                    //    //add table
                    //    doc.Add(NIBP_main_heading3);

                    //    //table contents
                    //    PdfPTable NIBP_content3 = new PdfPTable(2);
                    //    NIBP_content3.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_content3.TotalWidth = 500f;
                    //    NIBP_content3.LockedWidth = true;
                    //    NIBP_content3.SetWidths(new float[] { 440f, 60f });
                    //    NIBP_content3.HorizontalAlignment = 1;
                    //    NIBP_content3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell NIBP_heading3_description = new PdfPCell(new Phrase(NIBP_Monitor.desc3_text, contentfont2));
                    //    NIBP_heading3_description.Border = 0;
                    //    NIBP_content3.AddCell(NIBP_heading3_description);

                    //    PdfPCell NIBP_results3 = new PdfPCell(new Phrase(NIBP_Monitor.option3, boldfont3));
                    //    NIBP_results3.Border = 0;
                    //    NIBP_results3.PaddingBottom = 10f;
                    //    NIBP_content3.AddCell(NIBP_results3);

                    //    //add table
                    //    doc.Add(NIBP_content3);

                    //    //----------------------------------Heading 4
                    //    PdfPTable NIBP_main_heading4 = new PdfPTable(3);

                    //    NIBP_main_heading4.TotalWidth = 500f;
                    //    NIBP_main_heading4.LockedWidth = true;
                    //    NIBP_main_heading4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell NIBP_heading4 = new PdfPCell(new Phrase(NIBP_Monitor.option2_label, heading));
                    //    NIBP_heading4.Colspan = 3;
                    //    NIBP_heading4.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    NIBP_heading4.BorderWidthBottom = 0.5f;
                    //    NIBP_heading4.BorderWidthTop = 0.5f;
                    //    NIBP_heading4.PaddingBottom = 10f;
                    //    NIBP_heading4.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_main_heading4.AddCell(NIBP_heading4);

                    //    //add table
                    //    doc.Add(NIBP_main_heading4);

                    //    //table contents
                    //    PdfPTable NIBP_content4 = new PdfPTable(2);
                    //    NIBP_content4.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_content4.TotalWidth = 500f;
                    //    NIBP_content4.LockedWidth = true;
                    //    NIBP_content4.SetWidths(new float[] { 440f, 60f });
                    //    NIBP_content4.HorizontalAlignment = 1;
                    //    NIBP_content4.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell NIBP_heading4_description = new PdfPCell(new Phrase(NIBP_Monitor.desc4_text, contentfont2));
                    //    NIBP_heading4_description.Border = 0;
                    //    NIBP_content4.AddCell(NIBP_heading4_description);

                    //    PdfPCell NIBP_results4 = new PdfPCell(new Phrase(NIBP_Monitor.option4, boldfont3));
                    //    NIBP_results4.Border = 0;
                    //    NIBP_results4.PaddingBottom = 10f;
                    //    NIBP_content4.AddCell(NIBP_results4);

                    //    //add table
                    //    doc.Add(NIBP_content4);

                    //    //----------------------------------Heading 5
                    //    PdfPTable NIBP_main_heading5 = new PdfPTable(3);

                    //    NIBP_main_heading5.TotalWidth = 500f;
                    //    NIBP_main_heading5.LockedWidth = true;
                    //    NIBP_main_heading5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell NIBP_heading5 = new PdfPCell(new Phrase(NIBP_Monitor.option3_label, heading));
                    //    NIBP_heading5.Colspan = 3;
                    //    NIBP_heading5.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    NIBP_heading5.BorderWidthBottom = 0.5f;
                    //    NIBP_heading5.BorderWidthTop = 0.5f;
                    //    NIBP_heading5.PaddingBottom = 10f;
                    //    NIBP_heading5.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_main_heading5.AddCell(NIBP_heading5);

                    //    //add table
                    //    doc.Add(NIBP_main_heading5);

                    //    //table contents
                    //    PdfPTable NIBP_content5 = new PdfPTable(2);
                    //    NIBP_content5.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_content5.TotalWidth = 500f;
                    //    NIBP_content5.LockedWidth = true;
                    //    NIBP_content5.SetWidths(new float[] { 440f, 60f });
                    //    NIBP_content5.HorizontalAlignment = 1;
                    //    NIBP_content5.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell NIBP_heading5_description = new PdfPCell(new Phrase(NIBP_Monitor.desc5_text, contentfont2));
                    //    NIBP_heading5_description.Border = 0;
                    //    NIBP_content5.AddCell(NIBP_heading5_description);

                    //    PdfPCell NIBP_results5 = new PdfPCell(new Phrase(NIBP_Monitor.option5, boldfont3));
                    //    NIBP_results5.Border = 0;
                    //    NIBP_results5.PaddingBottom = 10f;
                    //    NIBP_content5.AddCell(NIBP_results5);

                    //    //add table
                    //    doc.Add(NIBP_content5);

                    //    //----------------------------------Heading 6
                    //    PdfPTable NIBP_main_heading6 = new PdfPTable(3);

                    //    NIBP_main_heading6.TotalWidth = 500f;
                    //    NIBP_main_heading6.LockedWidth = true;
                    //    NIBP_main_heading6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell NIBP_heading6 = new PdfPCell(new Phrase(NIBP_Monitor.option3_label, heading));
                    //    NIBP_heading6.Colspan = 3;
                    //    NIBP_heading6.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    NIBP_heading6.BorderWidthBottom = 0.5f;
                    //    NIBP_heading6.BorderWidthTop = 0.5f;
                    //    NIBP_heading6.PaddingBottom = 10f;
                    //    NIBP_heading6.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_main_heading6.AddCell(NIBP_heading6);

                    //    //add table
                    //    doc.Add(NIBP_main_heading6);

                    //    //table contents
                    //    PdfPTable NIBP_content6 = new PdfPTable(2);
                    //    NIBP_content6.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_content6.TotalWidth = 500f;
                    //    NIBP_content6.LockedWidth = true;
                    //    NIBP_content6.SetWidths(new float[] { 440f, 60f });
                    //    NIBP_content6.HorizontalAlignment = 1;
                    //    NIBP_content6.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell NIBP_heading6_description = new PdfPCell(new Phrase(NIBP_Monitor.desc6_text, contentfont2));
                    //    NIBP_heading6_description.Border = 0;
                    //    NIBP_content6.AddCell(NIBP_heading6_description);

                    //    PdfPCell NIBP_results6 = new PdfPCell(new Phrase(NIBP_Monitor.option6, boldfont3));
                    //    NIBP_results6.Border = 0;
                    //    NIBP_results6.PaddingBottom = 10f;
                    //    NIBP_content6.AddCell(NIBP_results6);

                    //    //add table
                    //    doc.Add(NIBP_content6);

                    //    //----------------------------------Heading 7
                    //    PdfPTable NIBP_main_heading7 = new PdfPTable(3);

                    //    NIBP_main_heading7.TotalWidth = 500f;
                    //    NIBP_main_heading7.LockedWidth = true;
                    //    NIBP_main_heading7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell NIBP_heading7 = new PdfPCell(new Phrase(NIBP_Monitor.option3_label, heading));
                    //    NIBP_heading7.Colspan = 3;
                    //    NIBP_heading7.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    NIBP_heading7.BorderWidthBottom = 0.5f;
                    //    NIBP_heading7.BorderWidthTop = 0.5f;
                    //    NIBP_heading7.PaddingBottom = 10f;
                    //    NIBP_heading7.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_main_heading7.AddCell(NIBP_heading7);

                    //    //add table
                    //    doc.Add(NIBP_main_heading7);

                    //    //table contents
                    //    PdfPTable NIBP_content7 = new PdfPTable(2);
                    //    NIBP_content7.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_content7.TotalWidth = 500f;
                    //    NIBP_content7.LockedWidth = true;
                    //    NIBP_content7.SetWidths(new float[] { 440f, 60f });
                    //    NIBP_content7.HorizontalAlignment = 1;
                    //    NIBP_content7.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell NIBP_heading7_description = new PdfPCell(new Phrase(NIBP_Monitor.desc7_text, contentfont2));
                    //    NIBP_heading7_description.Border = 0;
                    //    NIBP_content7.AddCell(NIBP_heading7_description);

                    //    PdfPCell NIBP_results7 = new PdfPCell(new Phrase(NIBP_Monitor.option7, boldfont3));
                    //    NIBP_results7.Border = 0;
                    //    NIBP_results7.PaddingBottom = 10f;
                    //    NIBP_content7.AddCell(NIBP_results7);

                    //    //add table
                    //    doc.Add(NIBP_content7);

                    //    //----------------------------------Heading 8
                    //    PdfPTable NIBP_main_heading8 = new PdfPTable(3);

                    //    NIBP_main_heading8.TotalWidth = 500f;
                    //    NIBP_main_heading8.LockedWidth = true;
                    //    NIBP_main_heading8.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    //title for the results
                    //    PdfPCell NIBP_heading8 = new PdfPCell(new Phrase(NIBP_Monitor.option4_label, heading));
                    //    NIBP_heading8.Colspan = 3;
                    //    NIBP_heading8.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER | iTextSharp.text.Rectangle.TOP_BORDER;
                    //    NIBP_heading8.BorderWidthBottom = 0.5f;
                    //    NIBP_heading8.BorderWidthTop = 0.5f;
                    //    NIBP_heading8.PaddingBottom = 10f;
                    //    NIBP_heading8.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_main_heading8.AddCell(NIBP_heading8);

                    //    //add table
                    //    doc.Add(NIBP_main_heading8);

                    //    //table contents
                    //    PdfPTable NIBP_content8 = new PdfPTable(2);
                    //    NIBP_content8.HorizontalAlignment = Element.ALIGN_CENTER;
                    //    NIBP_content8.TotalWidth = 500f;
                    //    NIBP_content8.LockedWidth = true;
                    //    NIBP_content8.SetWidths(new float[] { 440f, 60f });
                    //    NIBP_content8.HorizontalAlignment = 1;
                    //    NIBP_content8.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                    //    PdfPCell NIBP_heading8_description = new PdfPCell(new Phrase(NIBP_Monitor.desc8_text, contentfont2));
                    //    NIBP_heading8_description.Border = 0;
                    //    NIBP_content8.AddCell(NIBP_heading8_description);

                    //    PdfPCell NIBP_results8 = new PdfPCell(new Phrase(NIBP_Monitor.option8, boldfont3));
                    //    NIBP_results8.Border = 0;
                    //    NIBP_results8.PaddingBottom = 10f;
                    //    NIBP_content8.AddCell(NIBP_results8);

                    //    //add table
                    //    doc.Add(NIBP_content8);
                    //}


                    //----------------------------------------Performance Verification - X2



                    // Step 6: Closing the Document
                    doc.Close();

                    MessageBox.Show("Test Report for " + assetNumber.Text +"-" + model.Text + "-" + location.Text + " is done");

                }
            }
            catch (DocumentException)
            {
                MessageBox.Show("Make sure the folder destination is valid and the document is not opened");
            }
            catch (IOException)
            {
                MessageBox.Show("Make sure the folder destination is valid and the document is not opened");
            }
        }

    }
}
