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
using System.IO.Ports;

namespace NovaBiomedicalSoftware
{
    public partial class MainMenu : MetroForm
    {
        public bool PerformElectricalSafetyTest, PerformPerformanceTest, PerformBothTest, YesNoSaveDestination, YesNoEquipmentDetails;
        public bool runProgram, yesNoPerformanceTest, PTisSubmitted, _electricaltestResult, _PTStestResult, class1ASNZtest, class2ASNZtest, ecgclass1ASNZtest, ecgclass2ASNZtest;
        public bool PTpefusorSpaceCompleted, PTECGCompleted, PTNIBPGenericCompleted, PTEdanDopplerCompleted, PTSphygmomanometerCompleted, PTGenius2Completed,
            PTHeineNT300Completed, PTPhilipsMRxCompleted, PTAccusonicAP170Completed, PTComweldOxygenFMCompleted;

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public bool PTtestIsDone;
        public bool earthResistanceFailed, insulationResistanceFailed, earthLeakageFailed1, earthLeakageFailed2, touchCurrentFailed1, touchCurrentFailed2,
            touchCurrentFailed3, touchCurrentFailed4, touchCurrentFailed5, touchCurrentFailed6;
        public static string currentUser;
        //public static string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).FullName;
        public static string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static string saveDestination;

        static SerialPort mySerialPort;
        DateTime date = DateTime.Today;


        public MainMenu()
        {
            InitializeComponent();

            topPanel.Visible = false;
            _fileDestination.Text = LogInPage.saveDestination;
            tabMenu.SelectedTab = _tabMainmenu;

            tabMenu.Appearance = TabAppearance.FlatButtons;
            tabMenu.ItemSize = new Size(1, 1);
        }

        private void _qasBackButton_Click(object sender, EventArgs e)
        {
            navigateToMainMenu();
        }

        private void _ptBackButton_Click(object sender, EventArgs e)
        {
            navigateToMainMenu();
        }


        private void _estBackButton_Click(object sender, EventArgs e)
        {
            navigateToMainMenu();
        }

        private void espt_btn_Click(object sender, EventArgs e)
        {
            tabMenu.Visible = true;
            espt_btn.Visible = true;
            est_btn.Visible = false;
            qas_btn.Visible = false;
            pt_btn.Visible = false;

            PerformBothTest = true;
            PerformElectricalSafetyTest = false;
            PerformPerformanceTest = false;
            tabMenu.SelectedTab = _ElectricalSafetyTestTab;
            _ElectricalSafetyTestTab.Enabled = true;
            _PerformanceTestTab.Enabled = true;
            _QASTab.Enabled = false;

            topPanel.Visible = true;
            _programProgressBar.Visible = false;
        }
        private void est_btn_Click(object sender, EventArgs e)
        {
            espt_btn.Visible = false;
            est_btn.Visible = true;
            qas_btn.Visible = false;
            pt_btn.Visible = false;

            tabMenu.Visible = true;
            PerformElectricalSafetyTest = true;
            PerformPerformanceTest = false;
            PerformBothTest = false;
            tabMenu.SelectedTab = _ElectricalSafetyTestTab;
            _ElectricalSafetyTestTab.Enabled = true;
            _PerformanceTestTab.Enabled = false;
            _QASTab.Enabled = false;

            topPanel.Visible = true;
            _programProgressBar.Visible = false;

            //ask for information
            EquipmentDetails _equipmentdetails = new EquipmentDetails();

            DialogResult result = _equipmentdetails.ShowDialog();
            Console.WriteLine(result);
            if (result == DialogResult.OK)
            {
                YesNoEquipmentDetails = true;
            }
            else if (result == DialogResult.Cancel)
            {
                navigateToMainMenu();
            }


            ConnectToSerial();

        }
        private void pt_btn_Click(object sender, EventArgs e)
        {
            espt_btn.Visible = false;
            est_btn.Visible = false;
            qas_btn.Visible = false;
            pt_btn.Visible = true;
            tabMenu.Visible = true;
            PerformPerformanceTest = true;
            PerformElectricalSafetyTest = false;
            PerformBothTest = false;
            tabMenu.SelectedTab = _PerformanceTestTab;
            _PerformanceTestTab.Enabled = true;
            _ElectricalSafetyTestTab.Enabled = false;
            _QASTab.Enabled = false;

            topPanel.Visible = true;
            _programProgressBar.Visible = false;

            //ask for information
            EquipmentDetails _equipmentdetails = new EquipmentDetails();
            
            DialogResult result = _equipmentdetails.ShowDialog();
            Console.WriteLine(result);
            if (result == DialogResult.OK)
            {
                YesNoEquipmentDetails = true;
            }
            else if (result==DialogResult.Cancel)
            {
                navigateToMainMenu();
            }

        }


        private void navigateToMainMenu()
        {
            YesNoEquipmentDetails = false;
            espt_btn.Visible = true;
            est_btn.Visible = true;
            qas_btn.Visible = true;
            pt_btn.Visible = true;

            tabMenu.SelectedTab = _tabMainmenu;
            PerformBothTest = false;
            PerformElectricalSafetyTest = false;
            PerformPerformanceTest = false;
            _ElectricalSafetyTestTab.Enabled = false;
            _PerformanceTestTab.Enabled = false;
            _QASTab.Enabled = false;
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
                    _programStatus.Text = "Connected!";
                }
            }
            catch (IOException)
            {
                _programStatus.Text = "Error - No Fluke ESA620";

                DialogResult noflukeQuestion = MetroFramework.MetroMessageBox.Show(this, "", "Please connect the Fluke on your computer then press Retry", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

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

    }
}
