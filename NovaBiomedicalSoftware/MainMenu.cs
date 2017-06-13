﻿using System;
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
using NovaBiomedicalSoftware.Performance_Test;
using System.Threading;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using System.Collections;
using NovaBiomedicalSoftware.Queensland_Ambulance_Service;
using System.Diagnostics;
using Microsoft.Office.Tools.Word;
using Microsoft.CSharp;
using Microsoft.Office.Core;

namespace NovaBiomedicalSoftware
{
    public partial class MainMenu : MetroForm
    {

        //Location of Project
        //public static string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).FullName;
        public static string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

        //List for QAS
        #region List for QAS
        public static List<string> _EquipmentCounter = new List<string>();
        public static List<string> _PartsCounter = new List<string>();
        public static List<string> AspiratorsAssets = new List<string>();
        public static List<string> AutomaticEDAssets = new List<string>();
        public static List<string> DemandHeadAssets = new List<string>();
        public static List<string> ElectricSuctionAssets = new List<string>();
        public static List<string> FlowmeterAssets = new List<string>();
        public static List<string> OutletPointAssets = new List<string>();
        public static List<string> OxygenReticulationAssets = new List<string>();
        public static List<string> PulseOximeterAssets = new List<string>();
        public static List<string> RecoilBagResuscitatorAssets = new List<string>();
        public static List<string> RegulatorAssets = new List<string>();
        public static List<string> RCDAssets = new List<string>();
        public static List<string> Spygmo1Assets = new List<string>();
        public static List<string> Spygmo2Assets = new List<string>();
        public static List<string> TwinOVacAssets = new List<string>();
        public static List<string> MultiFlowRegulatorAssets = new List<string>();
        #endregion
        //Global Variables
        #region Global Variables
        public bool PerformElectricalSafetyTest, PerformPerformanceTest, PerformBothTest, PerformQAS, YesNoSaveDestination, YesNoEquipmentDetails;
        public bool runProgram, yesNoPerformanceTest, PTisSubmitted, _electricaltestResult, _PTStestResult, class1ASNZtest, class2ASNZtest, ecgclass1ASNZtest, ecgclass2ASNZtest;
        public bool PTpefusorSpaceCompleted, PTECGCompleted, PTNIBPGenericCompleted, PTEdanDopplerCompleted, PTSphygmomanometerCompleted, PTGenius2Completed,
            PTHeineNT300Completed, PTPhilipsMRxCompleted, PTAccusonicAP170Completed, PTComweldOxygenFMCompleted, PTScalesCompleted, PTVarpVueCompleted, PTPulseOximeter2Completed, PTSpirometerCompleted,
            PTVaccineFridgeCompleted, PTManifoldCompleted, PTAEDCompleted, PTRegulator2Completed, PTPhilipsMonitorCompleted, PTVitalsMonitorCompleted,
            PTOxyVivaCompleted, PTSoftPackRescueCompleted, PTOxylogCompleted;
        public bool QASTestisDone;
        public bool typeCF, typeBF, typeB;
        public bool PTMultiFlowRegulatorCompleted, PTOutletPointCompleted, PTOxygenReticulationCompleted, PTRegulatorCompleted,
            PTFlowmeterCompleted, PTElectricSuctionCompleted, PTRecoilBagCompleted, PTSphygmoHHeldCompleted,
            PTSphygmoWallCompleted, PTPulseOximeterCompleted, PTAspiratorCompleted, PTDemanHeadCompleted,
            PTTwinOVacCompleted, PTResidualCurrentDeviceCompleted, PTAutomaticExternalDefibCompleted;
        public int counter_multiflowregulator, counter_outletPoint, counter_oxygenReticulation, counter_regulator, counter_flowmeter, counter_electricSuction,
            counter_recoilBag, counter_shygmoHHeld, counter_sphygmoWall, counter_pulseOximeter, counter_aspirator, counter_demandHead,
            counter_twinOVac, counter_residualCurrentDevice, counter_automaticExternalDefib;
        public bool PTtestIsDone, class1AppliedParts, class2AppliedParts;
        public bool earthResistanceFailed, insulationResistanceFailed, earthLeakageFailed1, earthLeakageFailed2, touchCurrentFailed1, touchCurrentFailed2,
            touchCurrentFailed3, touchCurrentFailed4, touchCurrentFailed5, touchCurrentFailed6, patientLeakageCurrentFailed1, patientLeakageCurrentFailed2, patientLeakageCurrentFailed3,
            mainsContactCurrentFailed;
        public static string currentUser, saveDestination;
        public static SerialPort mySerialPort;
        DateTime date = DateTime.Today;
        public string kindofPerformanceTest, ESTResults, COMPORTNUMBER, _kindofElectricalSafetyTest, _earthResistance, _versionNumber, _MV1, _MV2, _MV3, _insulationResistance,
            _EL1, _EL2, _EnL1, _EnL2, _EnL3, _EnL4, _EnL5, _EnL6, PLT1, PLT2, PLT3, SFN, _PTSResult, _currentCOMPort, set_sig, _PLC1, _PLC2, _PLC3, _MMC;



        public double _earthResistance_double, _EL1_double, _EL2_double, _EnL1_double, _EnL2_double, _EnL3_double,
            _EnL4_double, _EnL5_double, _EnL6_double, PLT1_double, PLT2_double, PLT3_double, SFN_double, _PLC1_double, _PLC2_double, _PLC3_double, _MMC_double;

        #endregion

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public MainMenu()
        {
            InitializeComponent();
            saveDestination = LogInPage.saveDestination;
            topPanel.Visible = true;
            topPanel_right.Visible = false;
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
            PTtestIsDone = false;
            PerformPerformanceTest = false;
            //get rid of all booleans for performance test
            PTpefusorSpaceCompleted = false;
            PTECGCompleted = false;
            PTNIBPGenericCompleted = false;
            PTEdanDopplerCompleted = false;
            PTSphygmomanometerCompleted = false;
            PTGenius2Completed = false;
            PTHeineNT300Completed = false;
            PTPhilipsMRxCompleted = false;
            PTAccusonicAP170Completed = false;
            PTComweldOxygenFMCompleted = false;
            PTVarpVueCompleted = false;
            PTScalesCompleted = false;
            PTPulseOximeter2Completed = false;
            PTSpirometerCompleted = false;
            PTVaccineFridgeCompleted = false;
            PTManifoldCompleted = false;
            PTAEDCompleted = false;
            PTRegulator2Completed = false;
            PTPhilipsMonitorCompleted = false;
            PTVitalsMonitorCompleted = false;
            PTOxyVivaCompleted = false;
            PTSoftPackRescueCompleted = false;
            PTOxylogCompleted = false;

            navigateToMainMenu();
        }
        private void _estBackButton_Click(object sender, EventArgs e)
        {
            navigateToMainMenu();
        }
        private void qas_btn_Click(object sender, EventArgs e)
        {
            //Exit Word First
            ExitWord();

            tabMenu.Visible = true;
            espt_btn.Visible = false;
            est_btn.Visible = false;
            qas_btn.Visible = true;
            pt_btn.Visible = false;

            PerformBothTest = false;
            PerformElectricalSafetyTest = false;
            PerformPerformanceTest = false;
            PerformQAS = true;
            tabMenu.SelectedTab = _QASTab;
            _ElectricalSafetyTestTab.Enabled = false;
            _PerformanceTestTab.Enabled = false;
            _QASTab.Enabled = true;
            
            topPanel.Visible = true;
            topPanel_right.Visible = true;
            _programStatus.Visible = true;
            _programStatus.Text = "Queensland Ambulance Service";
            statusBar.Visible = false;


            if (File.Exists(appRootDir + "/Report Templates/QAS Templates/temp.docx"))
            {
                File.Delete(appRootDir + "/Report Templates/QAS Templates/temp.docx");
            }

            if (File.Exists(appRootDir + "/Report Templates/QAS Templates/temp2.docx"))
            {
                File.Delete(appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            }

            _EquipmentCounter.Clear();
            _PartsCounter.Clear();
            Aspirator.parts.Clear();
            AutomaticExternalDefib.parts.Clear();
            DemandHead.parts.Clear();
            ElectricSuction.parts.Clear();
            Flowmeter.parts.Clear();
            Outlet_Point.parts.Clear();
            OxygenReticulationAlarm.parts.Clear();
            PulseOximeter.parts.Clear();
            RecoilBagResuscitator.parts.Clear();
            Regulator.parts.Clear();
            RecoilBagResuscitator.parts.Clear();
            SphygmoWall.parts.Clear();
            SphygmoHandheld.parts.Clear();
            TwinOVac.parts.Clear();

            File.Copy(appRootDir + "/Report Templates/QAS Template-TEMPLATE.docx", appRootDir + "/Report Templates/QAS Templates/temp.docx");

            askForEquipmentDetails();



        }
        private void espt_btn_Click(object sender, EventArgs e)
        {
            ClearPanelValues();
            //Exit Word First
            ExitWord();

            valuesPanel.Visible = true;
            tabMenu.Visible = true;
            espt_btn.Visible = true;
            est_btn.Visible = false;
            qas_btn.Visible = false;
            pt_btn.Visible = false;

            PerformBothTest = true;
            PerformElectricalSafetyTest = false;
            PerformPerformanceTest = false;
            PerformQAS = false;

            tabMenu.SelectedTab = _ElectricalSafetyTestTab;
            _ElectricalSafetyTestTab.Enabled = true;
            _PerformanceTestTab.Enabled = true;
            _QASTab.Enabled = false;

            topPanel.Visible = true;
            statusBar.Visible = false;
            askForEquipmentDetails();
        }
        private void est_btn_Click(object sender, EventArgs e)
        {
            //Exit Word First
            ExitWord();

            ClearPanelValues();

            valuesPanel.Visible = true;
            espt_btn.Visible = false;
            est_btn.Visible = true;
            qas_btn.Visible = false;
            pt_btn.Visible = false;

            class1testBtn.Enabled = true;
            class2testBtn.Enabled = true;

            tabMenu.Visible = true;
            PerformElectricalSafetyTest = true;
            PerformPerformanceTest = false;
            PerformBothTest = false;
            PerformQAS = false;

            tabMenu.SelectedTab = _ElectricalSafetyTestTab;
            _ElectricalSafetyTestTab.Enabled = true;
            _PerformanceTestTab.Enabled = false;
            _QASTab.Enabled = false;

            topPanel.Visible = true;
            statusBar.Visible = false;


            askForEquipmentDetails();
}
        private void pt_btn_Click(object sender, EventArgs e)
        {

            //Exit Word First
            ExitWord();

            espt_btn.Visible = false;
            est_btn.Visible = false;
            qas_btn.Visible = false;
            pt_btn.Visible = true;
            tabMenu.Visible = true;
            PerformPerformanceTest = true;
            PerformElectricalSafetyTest = false;
            PerformBothTest = false;
            PerformQAS = false;

            tabMenu.SelectedTab = _PerformanceTestTab;
            _PerformanceTestTab.Enabled = true;
            _ElectricalSafetyTestTab.Enabled = false;
            _QASTab.Enabled = false;

            topPanel.Visible = true;
            statusBar.Visible = false;

            askForEquipmentDetails();
        }
        private void askForEquipmentDetails()
        {

            if (PerformQAS == true)
            {
                //ask for information
                QASEquipmentDetails _equipmentdetails = new QASEquipmentDetails();

                DialogResult result = _equipmentdetails.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    navigateToMainMenu();
                }
                else if (result == DialogResult.OK)
                {
                    _QASTab.Focus();
                }
            }
            else
            {
                //ask for information
                EquipmentDetails _equipmentdetails = new EquipmentDetails();

                DialogResult result = _equipmentdetails.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    navigateToMainMenu();
                }
                else if (result == DialogResult.OK)
                {
                    YesNoEquipmentDetails = true;
                    if (PerformElectricalSafetyTest == true || PerformBothTest == true)
                    {
                        ConnectToSerial();
                        _ElectricalSafetyTestTab.Focus();
                    }

                    if (PerformPerformanceTest == true)
                    {
                        _PerformanceTestTab.Focus();
                    }
                    
                }
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

            topPanel_right.Visible = false;
            try
            {
                if (mySerialPort.IsOpen == true)
                {
                    mySerialPort.Close();

                }
            }
            catch (Exception)
            {
            }

        }
        //connect to SerialCOM
        private void ConnectToSerial()
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

                DialogResult noflukeQuestion = MetroFramework.MetroMessageBox.Show(this, "", "Please connect the Fluke on your computer and try again", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

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
        private void createReport() {

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
                MetroFramework.MetroMessageBox.Show(this, "", "Report is done for - " + EquipmentDetails.assetNumber, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (PerformPerformanceTest == true)
            {
                editPerformanceTemplate(appRootDir + "/Report Templates/temp2.docx");
                MetroFramework.MetroMessageBox.Show(this, "", "Report is done for - " + EquipmentDetails.assetNumber, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (PerformElectricalSafetyTest == true)
            {
                editElectricalSafetyTemplate(appRootDir + "/Report Templates/temp.docx");
                MetroFramework.MetroMessageBox.Show(this, "", "Report is done for - " + EquipmentDetails.assetNumber, MessageBoxButtons.OK, MessageBoxIcon.Information);

                class1testBtn.Enabled = false;
                class2testBtn.Enabled = false;
            }


        }
        #region Performance Test Button Click Events:
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
                        DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            yesNoPerformanceTest = false;
                            PTtestIsDone = false;

                            MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                }

            }
        }
        private void ptECG_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
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
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }

                }
            }
            
        }
        private void ptNIBP_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
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
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }

                }
            }
        }
        private void eddanDoppler_btn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
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
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }

                }
            }
        }
        private void sphygmomanometer_btn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
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
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }

                }
            }
        }
        private void genius2_btn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
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
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }

                }
            }
        }
        private void heinent300_btn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    HeineNT300 dg = new HeineNT300();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.nt300Test_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTHeineNT300Completed = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }

                }
            }
        }
        private void philipsMRx_btn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    GenericDefibrillator dg = new GenericDefibrillator();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.philipsMrxTest_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTPhilipsMRxCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void accusonicAP170_btn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    AccusonicAP170 dg = new AccusonicAP170();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.AccusonicAP170Test_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTAccusonicAP170Completed = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void comweldoxygenFM_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    ComweldOxygenFlowmeter dg = new ComweldOxygenFlowmeter();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.ComweldOxygenFlowmeterTest_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTComweldOxygenFMCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void scales_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    Scales dg = new Scales();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.Scales_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTScalesCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void varp_Vue_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    VarpVue dg = new VarpVue();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.VarpVueTest_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTVarpVueCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }

                }
            }
        }
        private void vaccineFridge_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    VaccineFridge dg = new VaccineFridge();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.VaccineFridge_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTVaccineFridgeCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void spirometer_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    Spirometer dg = new Spirometer();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.Spirometer_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTSpirometerCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void pulseOximeter_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    PulseOximeter2 dg = new PulseOximeter2();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.PulseOximeter_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTPulseOximeter2Completed = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }

            }
        }
        private void manifoldBtn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    Manifold dg = new Manifold();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.manifold_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTManifoldCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void regulatorBtn_PT_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    RegulatorPT dg = new RegulatorPT();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.RegulatorTest_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTRegulator2Completed = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void aedBtn_PT_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    AED dg = new AED();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.AEDTest_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTAEDCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void genericVitalsMonitor_btn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    GenericVitalsMonitor dg = new GenericVitalsMonitor();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.genericVitalsTest_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTVitalsMonitorCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void philipsMonitor_btn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    PhilipsMonitors dg = new PhilipsMonitors();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.philipsMonitorTest_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTPhilipsMonitorCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void oxyvivaresusbox_btn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    OxyVivaResusBox dg = new OxyVivaResusBox();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.oxyvivaTest_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTOxyVivaCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void softpackrescue_btn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    SoftPackRescueBag dg = new SoftPackRescueBag();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.softpackrescueTest_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTSoftPackRescueCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void oxylogBtn_Click(object sender, EventArgs e)
        {
            if (PerformPerformanceTest == true || PerformBothTest == true)
            {
                while (PTtestIsDone == false)
                {
                    Oxylog dg = new Oxylog();
                    DialogResult dialog1 = dg.ShowDialog();
                    if (dialog1 == DialogResult.Cancel)
                    {
                        if (dg.oxylogTest_Submit == true)
                        {
                            yesNoPerformanceTest = true;
                            PTtestIsDone = true;
                            PTOxylogCompleted = true;
                            createReport();
                        }
                        else
                        {
                            DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                yesNoPerformanceTest = false;
                                PTtestIsDone = false;

                                MetroFramework.MetroMessageBox.Show(this, "No Report will be generated", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                    }
                }
            }
        }
        #endregion
        // Serial Communication for the FLUKE ESA620 with real-time checker
        #region CommunicationToFluke
        private void patientLeakageCurrent()
        {
            this.Invoke((MethodInvoker)delegate
            {
                _programStatus.Text = "Patient Leakage Current (Normal Condition)...";
                statusBar.Enabled = true;
                statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            });
            //normal condition
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("PAT");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=OFF");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=N");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("EARTH=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("AP=RA,LL,LA,RL,V1,V2,V3,V4,V5,V6//OPEN");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MDUAL=OFF");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _PLC1 = mySerialPort.ReadExisting();
            Match _plc1_m = Regex.Match(_PLC1, @"^-?\d*\.?\d*");
            _PLC1_double= Double.Parse(_plc1_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                if (PatientLeakageCurrentType.typeCF == true)
                {
                    if (_PLC1_double > 10)
                    {
                        patientLeakageCurrentFailed1 = true;
                        Thread.CurrentThread.Interrupt();
                        MetroFramework.MetroMessageBox.Show(this, "", "Patient Leakage Current (Normal Condition) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PLClabel1.Text = _PLC1_double.ToString() + " uA";
                        PLClabel1.ForeColor = Color.Red;
                        //buttonPLC1.Visible = true;
                    }
                    else
                    {
                        patientLeakageCurrentFailed1 = false;
                        PLClabel1.Text = _PLC1_double.ToString() + " uA";
                    }
                }
                if (PatientLeakageCurrentType.typeBF == true || PatientLeakageCurrentType.typeB == true)
                {
                    if (_PLC1_double > 100)
                    {
                        patientLeakageCurrentFailed1 = true;
                        Thread.CurrentThread.Interrupt();
                        MetroFramework.MetroMessageBox.Show(this, "", "Patient Leakage Current (Normal Condition) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PLClabel1.Text = _PLC1_double.ToString() + " uA";
                        PLClabel1.ForeColor = Color.Red;
                        //buttonPLC1.Visible = true;
                    }
                    else
                    {
                        patientLeakageCurrentFailed1 = false;
                        PLClabel1.Text = _PLC1_double.ToString() + " uA";
                    }
                }
                
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);

            this.Invoke((MethodInvoker)delegate
            {
                _programStatus.Text = "Patient Leakage Current (Open Neutral)...";
                statusBar.Enabled = true;
                statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            });
            //neutral
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("PAT");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=OFF");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=N");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("EARTH=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=O");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("AP=RA,LL,LA,RL,V1,V2,V3,V4,V5,V6//OPEN");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MDUAL=OFF");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _PLC2 = mySerialPort.ReadExisting();
            Match _plc2_m = Regex.Match(_PLC2, @"^-?\d*\.?\d*");
            _PLC2_double = Double.Parse(_plc2_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                if (PatientLeakageCurrentType.typeCF == true)
                {
                    if (_PLC2_double > 10)
                    {
                        patientLeakageCurrentFailed2 = true;
                        Thread.CurrentThread.Interrupt();
                        MetroFramework.MetroMessageBox.Show(this, "", "Patient Leakage Current (Open Neutral) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PLClabel2.Text = _PLC2_double.ToString() + " uA";
                        PLClabel2.ForeColor = Color.Red;
                        //buttonPLC2.Visible = true;
                    }
                    else
                    {
                        patientLeakageCurrentFailed2 = false;
                        PLClabel2.Text = _PLC2_double.ToString() + " uA";
                    }
                }
                if (PatientLeakageCurrentType.typeBF == true || PatientLeakageCurrentType.typeB == true)
                {
                    if (_PLC2_double > 100)
                    {
                        patientLeakageCurrentFailed2 = true;
                        Thread.CurrentThread.Interrupt();
                        MetroFramework.MetroMessageBox.Show(this, "", "Patient Leakage Current (Open Neutral) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PLClabel2.Text = _PLC2_double.ToString() + " uA";
                        PLClabel2.ForeColor = Color.Red;
                        //buttonPLC2.Visible = true;
                    }
                    else
                    {
                        patientLeakageCurrentFailed2 = false;
                        PLClabel2.Text = _PLC2_double.ToString() + " uA";
                    }
                }

            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);


            this.Invoke((MethodInvoker)delegate
            {
                _programStatus.Text = "Patient Leakage Current (Open Earth)...";
                statusBar.Enabled = true;
                statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            });

            //protective earthing
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("PAT");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=OFF");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("POL=N");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("EARTH=C");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("NEUT=O");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MODE=ACDC");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("AP=RA,LL,LA,RL,V1,V2,V3,V4,V5,V6//OPEN");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("MDUAL=OFF");
            Thread.Sleep(1500);
            mySerialPort.Close();
            mySerialPort.Open();
            mySerialPort.WriteLine("READ");
            Thread.Sleep(1500);
            _PLC3 = mySerialPort.ReadExisting();
            Match _plc3_m = Regex.Match(_PLC3, @"^-?\d*\.?\d*");
            _PLC3_double = Double.Parse(_plc3_m.Value);
            this.Invoke((MethodInvoker)delegate
            {
                if (PatientLeakageCurrentType.typeCF == true)
                {
                    if (_PLC3_double > 10)
                    {
                        patientLeakageCurrentFailed3 = true;
                        Thread.CurrentThread.Interrupt();
                        MetroFramework.MetroMessageBox.Show(this, "", "Patient Leakage Current (Open Earth) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PLClabel3.Text = _PLC3_double.ToString() + " uA";
                        PLClabel3.ForeColor = Color.Red;
                        //buttonPLC3.Visible = true;
                    }
                    else
                    {
                        patientLeakageCurrentFailed3 = false;
                        PLClabel3.Text = _PLC3_double.ToString() + " uA";
                    }
                }
                if (PatientLeakageCurrentType.typeBF == true || PatientLeakageCurrentType.typeB == true)
                {
                    if (_PLC3_double > 100)
                    {
                        patientLeakageCurrentFailed3 = true;
                        Thread.CurrentThread.Interrupt();
                        MetroFramework.MetroMessageBox.Show(this, "", "Patient Leakage Current (Open Earth) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PLClabel3.Text = _PLC3_double.ToString() + " uA";
                        PLClabel3.ForeColor = Color.Red;
                        //buttonPLC3.Visible = true;
                    }
                    else
                    {
                        patientLeakageCurrentFailed3 = false;
                        PLClabel3.Text = _PLC3_double.ToString() + " uA";
                    }
                }

            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);
        }
        //private void mainsContactCurrent()
        //{
        //    //normal condition
        //    mySerialPort.WriteLine("REMOTE");
        //    Thread.Sleep(1000);
        //    mySerialPort.WriteLine("STD=ASNZ");
        //    Thread.Sleep(1000);
        //    mySerialPort.WriteLine("MAP");
        //    Thread.Sleep(1500);
        //    mySerialPort.WriteLine("MAP=LOW");
        //    Thread.Sleep(1500);
        //    mySerialPort.WriteLine("MAP=NORM");
        //    Thread.Sleep(1500);
        //    mySerialPort.WriteLine("EARTH=C");
        //    Thread.Sleep(1500);
        //    mySerialPort.WriteLine("AP=RA,LL,LA,RL,V1,V2,V3,V4,V5,V6//OPEN");
        //    Thread.Sleep(1500);
        //    mySerialPort.WriteLine("MDUAL=OFF");
        //    Thread.Sleep(1500);
        //    mySerialPort.Close();
        //    mySerialPort.Open();
        //    mySerialPort.WriteLine("READ");
        //    Thread.Sleep(1500);
        //    _MMC = mySerialPort.ReadExisting();
        //    Match _MMC_m = Regex.Match(_MMC, @"^-?\d*\.?\d*");
        //    _MMC_double = Double.Parse(_MMC_m.Value);
        //    this.Invoke((MethodInvoker)delegate
        //    {
        //        if (typeCF == true)
        //        {
        //            if (_MMC_double > 50)
        //            {
        //                patientLeakageCurrentFailed1 = true;
        //                Thread.CurrentThread.Interrupt();
        //                MetroFramework.MetroMessageBox.Show(this, "Manually do the test to try again", "Patient Leakage Current (Normal Condition) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                PLClabel1.Text = _MMC_double.ToString() + " uA";
        //                PLClabel1.ForeColor = Color.Red;
        //                buttonPLC1.Visible = true;
        //            }
        //            else
        //            {
        //                 = false;
        //                PLClabel1.Text = _MMC_double.ToString() + " uA";
        //            }
        //        }
        //        if (typeBF == true || typeB == true)
        //        {
        //            if (_PLC1_double > 100)
        //            {
        //                patientLeakageCurrentFailed1 = true;
        //                Thread.CurrentThread.Interrupt();
        //                MetroFramework.MetroMessageBox.Show(this, "Manually do the test to try again", "Patient Leakage Current (Normal Condition) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                PLClabel1.Text = _PLC1_double.ToString() + " uA";
        //                PLClabel1.ForeColor = Color.Red;
        //                buttonPLC1.Visible = true;
        //            }
        //            else
        //            {
        //                patientLeakageCurrentFailed1 = false;
        //                PLClabel1.Text = _PLC1_double.ToString() + " uA";
        //            }
        //        }

        //    });
        //    mySerialPort.WriteLine("LOCAL");
        //    Thread.Sleep(1000);
        //}
        private void initialisedDevice()
        {
            this.Invoke((MethodInvoker)delegate
            {

                _programStatus.Text = "Initialising...";

            });

            mySerialPort.WriteLine("LOCAL");

            Thread.Sleep(1000);
        }
        private void getVersionNumber()
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

                labelAnsurVersion.Text = _versionNumber.Trim();

            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);
        }
        private void mainsVoltage()
        {

            this.Invoke((MethodInvoker)delegate
            {

                _programStatus.Text = "Mains Voltage Test...";

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
                labelM1.Text = _MV1.Trim();
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
                labelM2.Text = _MV2.Trim();
            });
            mySerialPort.WriteLine("LOCAL");
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
                labelM3.Text = _MV3.Trim();
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);

            this.Invoke((MethodInvoker)delegate
            {
                _programStatus.Text = "Mains Voltage Test Complete";

            });

        }
        private void earthResistance()
        {
            this.Invoke((MethodInvoker)delegate
            {
                _programStatus.Text = "Protective Earth Test...";
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
                if (ProtectiveEarthOptions.withApplianceInletOption == true)
                {
                    if (_earthResistance_double > 0.1)
                    {
                        earthResistanceFailed = true;
                        //buttonPE.Visible = true;
                        Thread.CurrentThread.Interrupt();
                        labelPE.Text = _earthResistance_double.ToString() + " OHMS";
                        labelPE.ForeColor = Color.Red;
                        MetroFramework.MetroMessageBox.Show(this, "", "Earth Resistance Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        earthResistanceFailed = false;
                        labelPE.Text = _earthResistance_double.ToString() + " OHMS";
                        labelPE.ForeColor = Color.Green;
                    }
                }
                else if (ProtectiveEarthOptions.detachablePowerSupplyOption == true || ProtectiveEarthOptions.nonDetachableSupplyOption == true)
                {
                    if (_earthResistance_double > 0.2)
                    {
                        earthResistanceFailed = true;
                        //buttonPE.Visible = true;
                        Thread.CurrentThread.Interrupt();
                        labelPE.Text = _earthResistance_double.ToString() + " OHMS";
                        labelPE.ForeColor = Color.Red;
                        MetroFramework.MetroMessageBox.Show(this, "", "Earth Resistance Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        earthResistanceFailed = false;
                        labelPE.Text = _earthResistance_double.ToString() + " OHMS";
                        labelPE.ForeColor = Color.Green;
                    }
                }


            });

            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);

        }
        private void insulationResistance()
        {
            this.Invoke((MethodInvoker)delegate
            {
                _programStatus.Text = "Insulation Resistance Test...";
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
                insulationResistanceFailed = false;
                _insulationResistance = ">100 MOhms";
                this.Invoke((MethodInvoker)delegate
                {
                    labelIR.Text = _insulationResistance;
                });
            }
            else
            {
                insulationResistanceFailed = true;
                _insulationResistance = "FAILED";
                this.Invoke((MethodInvoker)delegate
                {
                    Thread.CurrentThread.Interrupt();
                    MetroFramework.MetroMessageBox.Show(this, "", "Insulation Resistance Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelIR.ForeColor = Color.Red;
                    labelIR.Text = _insulationResistance;
                    //buttonIR.Visible = true;
                });
            }
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(1000);
        }
        private void earthLeakage()
        {
            this.Invoke((MethodInvoker)delegate
            {
                _programStatus.Text = "Earth Leakage Current Test...";
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
                    earthLeakageFailed1 = true;
                    Thread.CurrentThread.Interrupt();
                    MetroFramework.MetroMessageBox.Show(this, "", "Earth Leakage Current (Normal Condition) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelEL1.Text = _EL1_double.ToString() + " uA";
                    labelEL1.ForeColor = Color.Red;
                    //buttonEL1.Visible = true;
                }
                else
                {
                    earthLeakageFailed1 = false;
                    labelEL1.Text = _EL1_double.ToString() + " uA";
                }
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);

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
                    earthLeakageFailed2 = true;
                    Thread.CurrentThread.Interrupt();
                    MetroFramework.MetroMessageBox.Show(this, "", "Earth Leakage Current (Open Neutral) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelEL2.Text = _EL2_double.ToString() + " uA";
                    labelEL2.ForeColor = Color.Red;
                    //buttonEL2.Visible = true;
                }
                else
                {
                    earthLeakageFailed2 = false;
                    labelEL2.Text = _EL2_double.ToString() + " uA";

                }
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);
        }
        private void touchCurrent()
        {
            this.Invoke((MethodInvoker)delegate
            {
                _programStatus.Text = "Touch Current Test...";
            });

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1500);
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
                    touchCurrentFailed1 = true;
                    Thread.CurrentThread.Interrupt();
                    MetroFramework.MetroMessageBox.Show(this, "", "Touch Current (Normal Condition) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelEnL1.Text = _EnL1_double.ToString() + " uA";
                    labelEnL1.ForeColor = Color.Red;
                    //buttonEnL1.Visible = true;
                }
                else
                {
                    touchCurrentFailed2 = false;
                    labelEnL1.Text = _EnL1_double.ToString() + " uA";

                }
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1500);
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
                    touchCurrentFailed2 = true;

                    Thread.CurrentThread.Interrupt();
                    MetroFramework.MetroMessageBox.Show(this, "", "Touch Current (Open Neutral) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelEnL2.Text = _EnL2_double.ToString() + " uA";
                    labelEnL2.ForeColor = Color.Red;
                    //buttonEnL2.Visible = true;
                }
                else
                {
                    touchCurrentFailed2 = false;
                    labelEnL2.Text = _EnL2_double.ToString() + " uA";

                }
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1500);
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
                    touchCurrentFailed3 = true;

                    Thread.CurrentThread.Interrupt();
                    MetroFramework.MetroMessageBox.Show(this, "", "Touch Current (Open Earth) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelEnL3.Text = _EnL3_double.ToString() + " uA";
                    labelEnL3.ForeColor = Color.Red;
                    //buttonEnL3.Visible = true;
                }
                else
                {
                    labelEnL3.Text = _EnL3_double.ToString() + " uA";
                    touchCurrentFailed3 = false;

                }
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1500);
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
                    touchCurrentFailed4 = true;

                    Thread.CurrentThread.Interrupt();
                    MetroFramework.MetroMessageBox.Show(this, "", "Touch Current (Normal Condition, Reversed Mains) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelEnL4.Text = _EnL4_double.ToString() + " uA";
                    labelEnL4.ForeColor = Color.Red;
                    //buttonEnL4.Visible = true;
                }
                else
                {
                    touchCurrentFailed4 = false;
                    labelEnL4.Text = _EnL4_double.ToString() + " uA";

                }
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1500);
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
                    touchCurrentFailed5 = true;

                    Thread.CurrentThread.Interrupt();
                    MetroFramework.MetroMessageBox.Show(this, "", "Touch Current (Open Neutral, Reversed Mains) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelEnL5.Text = _EnL5_double.ToString() + " uA";
                    labelEnL5.ForeColor = Color.Red;
                    //buttonEnL5.Visible = true;
                }
                else
                {
                    labelEnL5.Text = _EnL5_double.ToString() + " uA";
                    touchCurrentFailed5 = false;

                }
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);

            //send command
            mySerialPort.WriteLine("REMOTE");
            Thread.Sleep(1500);
            mySerialPort.WriteLine("STD=ASNZ");
            Thread.Sleep(1500);
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
                    touchCurrentFailed6 = true;

                    Thread.CurrentThread.Interrupt();
                    MetroFramework.MetroMessageBox.Show(this, "", "Touch Current (Open Earth, Reversed Mains) Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    labelEnL6.Text = _EnL6_double.ToString() + " uA";
                    labelEnL6.ForeColor = Color.Red;
                    //buttonEnL6.Visible = true;
                }
                else
                {
                    touchCurrentFailed6 = false;
                    labelEnL6.Text = _EnL6_double.ToString() + " uA";

                }
            });
            mySerialPort.WriteLine("LOCAL");
            Thread.Sleep(5000);





        }
        #endregion
        //refresh buttons
        #region refresh buttons
        private void buttonEL1_Click(object sender, EventArgs e)
        {
            Thread earthleakage = new Thread(refreshEL);

            earthleakage.Start();
        }
        private void refreshEL()
        {
            earthLeakage();
            testComplete();
        }
        private void buttonEnL1_Click(object sender, EventArgs e)
        {
            Thread touchcurrent = new Thread(refreshTouchCurrent);

            touchcurrent.Start();
        }
        private void refreshTouchCurrent()
        {
            touchCurrent();
            testComplete();
        }
        private void buttonIR_Click(object sender, EventArgs e)
        {
            Thread insulation = new Thread(refreshIR);

            insulation.Start();
        }
        private void refreshIR()
        {
            insulationResistance();
            testComplete();
        }
        private void buttonPE_Click(object sender, EventArgs e)
        {
            Thread earthresistance = new Thread(refreshPE);

            earthresistance.Start();
        }
        private void refreshPE()
        {
            earthResistance();
            testComplete();
        }


        private void buttonPLC1_Click(object sender, EventArgs e)
        {
            Thread patientleakage = new Thread(patientLeakageCurrent);

            patientleakage.Start();
        }
        #endregion
        // Class Test Buttons Click Events:
        #region Class Test Buttons Click Events
        private void class1testBtn_Click(object sender, EventArgs e)
        {

            topPanel_right.Visible = true;
            _programStatus.Visible = true;
            class1ASNZtest = true;
            PLC1.Visible = false;
            PLC2.Visible = false;
            PLC3.Visible = false;
            PLCpanel1.Visible = false;
            PLCpanel2.Visible = false;
            PLCpanel3.Visible = false;
            MCC.Visible = false;
            MCCpanel.Visible = false;


            ProtectiveEarthOptions class1option = new ProtectiveEarthOptions();

            DialogResult dialogResult = class1option.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                //navigateToMainMenu();
            }
            else if (dialogResult == DialogResult.OK)
            {
                statusBar.Show();
                statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
                statusBar.MarqueeAnimationSpeed = 30;

                _kindofElectricalSafetyTest = "AS NZS 3551 – Class 1";
                Thread class1NTest = new Thread(class1NormalTest);

                class1NTest.Start();
            }



        }
        private void class2testBtn_Click(object sender, EventArgs e)
        {
            topPanel_right.Visible = true;
            _programStatus.Visible = true;

            //hide earth tests
            el1.Visible = false;
            el1Panel.Visible = false;
            el2.Visible = false;
            el2Panel.Visible = false;
            _PELabel.Visible = false;
            PEPanel.Visible = false;
            PLC1.Visible = false;
            PLC2.Visible = false;
            PLC3.Visible = false;
            PLCpanel1.Visible = false;
            PLCpanel2.Visible = false;
            PLCpanel3.Visible = false;
            MCC.Visible = false;
            MCCpanel.Visible = false;

            statusBar.Show();
            statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
            statusBar.MarqueeAnimationSpeed = 30;

            _kindofElectricalSafetyTest = "AS NZS 3551 – Class 2";
            class2ASNZtest = true;

            Thread class2NTest = new Thread(class2NormalTest);

            class2NTest.Start();
        }
        private void APClass2_Click(object sender, EventArgs e)
        {
            class2AppliedParts = true;
            PatientLeakageCurrentType plctype = new PatientLeakageCurrentType();

            DialogResult dialogResult = plctype.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                //navigateToMainMenu();
            }
            else if (dialogResult == DialogResult.OK)
            {
                statusBar.Show();
                statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
                statusBar.MarqueeAnimationSpeed = 30;

                _kindofElectricalSafetyTest = "AS NZS 3551 – Class 2 with Applied Parts";
                Thread patientleakage = new Thread(class2withAppliedParts);

                patientleakage.Start();
            }
        }
        private void APClass1_Click(object sender, EventArgs e)
        {
            topPanel_right.Visible = true;
            _programStatus.Visible = true;
            class1ASNZtest = true;
            PLC1.Visible = true;
            PLC2.Visible = true;
            PLC3.Visible = true;
            PLCpanel1.Visible = true;
            PLCpanel2.Visible = true;
            PLCpanel3.Visible = true;
            MCC.Visible = true;
            MCCpanel.Visible = true;
            labelPE.Visible = true;


            class1AppliedParts = true;

            ProtectiveEarthOptions class1option = new ProtectiveEarthOptions();

            DialogResult dialogResult1 = class1option.ShowDialog();
            if (dialogResult1 == DialogResult.Cancel)
            {
                //navigateToMainMenu();
            }
            else if (dialogResult1 == DialogResult.OK)
            {
                PatientLeakageCurrentType plctype = new PatientLeakageCurrentType();

                DialogResult dialogResult2 = plctype.ShowDialog();
                if (dialogResult2 == DialogResult.Cancel)
                {
                    //navigateToMainMenu();
                }
                else if (dialogResult2 == DialogResult.OK)
                {
                    statusBar.Show();
                    statusBar.ProgressBarStyle = ProgressBarStyle.Marquee;
                    statusBar.MarqueeAnimationSpeed = 30;

                    _kindofElectricalSafetyTest = "AS NZS 3551 – Class 1 with Applied Parts";
                    Thread patientleakage = new Thread(class1withAppliedParts);

                    patientleakage.Start();
                }
            }



        }
        private void ecgSimulation_Click(object sender, EventArgs e)
        {

        }
        #endregion
        // Test Functions:
        private void class1NormalTest()
        {
            initialisedDevice();
            getVersionNumber();
            mainsVoltage();
            earthResistance();
            insulationResistance();
            touchCurrent();
            earthLeakage();
            testComplete();
        }
        private void class2NormalTest()
        {
            initialisedDevice();
            getVersionNumber();
            mainsVoltage();
            insulationResistance();
            touchCurrent();
            testComplete();
        }
        private void class1withAppliedParts()
        {
            initialisedDevice();
            getVersionNumber();
            mainsVoltage();
            earthResistance();
            insulationResistance();
            touchCurrent();
            earthLeakage();
            patientLeakageCurrent();
            testComplete();
        }
        private void class2withAppliedParts()
        {
            initialisedDevice();
            getVersionNumber();
            mainsVoltage();
            earthResistance();
            insulationResistance();
            touchCurrent();
            earthLeakage();
            patientLeakageCurrent();
            testComplete();
        }
        private void ecgSimulation()
        {

        }

        // Electrical Test Complete Function
        private void testComplete()
        {
            this.Invoke((MethodInvoker)delegate
            {
                statusBar.Hide();
                //show complete
                _programStatus.Text = "Test Completed";
                if (class1ASNZtest==true)
                {
                    buttonPE.Visible = true;
                    buttonIR.Visible = true;
                    buttonEL1.Visible = true;
                    buttonEL2.Visible = true;
                    buttonEnL1.Visible = true;
                    buttonEnL2.Visible = true;
                    buttonEnL3.Visible = true;
                    buttonEnL4.Visible = true;
                    buttonEnL5.Visible = true;
                    buttonEnL6.Visible = true;
                    if (class1AppliedParts == true)
                    {
                        buttonPLC1.Visible = true;
                        buttonPLC2.Visible = true;
                        buttonPLC3.Visible = true;
                        buttonMCC.Visible = true;
                    }

                    while (earthResistanceFailed == false && insulationResistanceFailed == false && earthLeakageFailed1 == false && earthLeakageFailed2 == false && touchCurrentFailed1 == false && touchCurrentFailed2 == false &&
            touchCurrentFailed3 == false && touchCurrentFailed4 == false && touchCurrentFailed5 == false && touchCurrentFailed6 == false)
                    {
                        if (PerformBothTest == true)
                        {
                            _programStatus.Text = "Please select the equipment";
                            valuesPanel.Visible = false;
                            tabMenu.SelectedTab = _PerformanceTestTab;
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

                        break;
                    }
                
                }
                if (class2ASNZtest==true)
                {

                    buttonIR.Visible = true;
                    buttonEnL1.Visible = true;
                    buttonEnL2.Visible = true;
                    buttonEnL3.Visible = true;
                    buttonEnL4.Visible = true;
                    buttonEnL5.Visible = true;
                    buttonEnL6.Visible = true;
                    if (class2AppliedParts == true)
                    {
                        buttonPLC1.Visible = true;
                        buttonPLC2.Visible = true;
                        buttonPLC3.Visible = true;
                        buttonMCC.Visible = true;
                    }

                    while (insulationResistanceFailed == false  && touchCurrentFailed1 == false && touchCurrentFailed2 == false &&
touchCurrentFailed3 == false && touchCurrentFailed4 == false && touchCurrentFailed5 == false && touchCurrentFailed6 == false)
                    {
                        if (PerformBothTest == true)
                        {
                            _programStatus.Text = "Please select the equipment";
                            valuesPanel.Visible = false;
                            tabMenu.SelectedTab = _PerformanceTestTab;
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

                        break;
                    }
                }


            });
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

            wDoc1.ExportAsFixedFormat(saveDestination + "/" + EquipmentDetails.assetNumber + "-"+ EquipmentDetails.serialNumber+ "-" + EquipmentDetails.model + "-"+ EquipmentDetails.manufacturer + "-"+ "- Electrical Safety Test and Performance Test.pdf", Word.WdExportFormat.wdExportFormatPDF);

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
                //genius2 thermometer
                if (PTHeineNT300Completed == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Heine NT300-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //philips mrx
                if (PTPhilipsMRxCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Philips MRx Defibrillator-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //accusonic ap170
                if (PTAccusonicAP170Completed == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Accusonic AP170-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //comweld oxygen flowmeter
                if (PTComweldOxygenFMCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Comweld Oxygen Flowmeter-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //varp vue
                if (PTVarpVueCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/VAPR VUE Generator-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //Scales
                if (PTScalesCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Scales-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //vaccine Fridge
                if (PTVaccineFridgeCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/VaccineFridge-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //Spirometer
                if (PTSpirometerCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Spirometer-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //PulseOximeter
                if (PTPulseOximeter2Completed == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Pulse Oximeter-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //Manifold
                if (PTManifoldCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Manifold-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //AED
                if (PTAEDCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/AED-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //Regulator PT
                if (PTRegulator2Completed == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Regulator-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //Generic Vitals
                if (PTVitalsMonitorCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/VitalsMonitor-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //Philips Monitors
                if (PTPhilipsMonitorCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/PhilipsPatientMonitor-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //Oxy Viva
                if (PTOxyVivaCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Oxy Viva Resus Box-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //Soft Pack
                if (PTSoftPackRescueCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Soft Pack Rescue Bag-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }
                //Oxylog
                if (PTOxylogCompleted == true)
                {
                    File.Copy(appRootDir + "/Report Templates/Oxylog-TEMPLATE.docx", appRootDir + "/Report Templates/temp2.docx");
                }

            }
            object missing = System.Reflection.Missing.Value;


            //Open the word document
            Word.Document wDoc = wordApp.Documents.Open(appRootDir + "/Report Templates/temp2.docx");

            // Activate the document
            wDoc.Activate();


            // for changing signatures
            wDoc.Bookmarks["image"].Select();
            string pictureName = appRootDir + "/Signatures/" + LogInPage.currentUser + ".png";
            wordApp.Selection.InlineShapes.AddPicture(pictureName);



            ///if statements on what kind of performance test

            //perfusor Space
            if (PTpefusorSpaceCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
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

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = perfusorSpace.testequipment.Last();
                foreach (string item in perfusorSpace.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Generic ECG
            if (PTECGCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", GenericECG.result1);
                this.FindAndReplace(wordApp, "<result2>", GenericECG.result2);
                this.FindAndReplace(wordApp, "<result3>", GenericECG.result3);
                this.FindAndReplace(wordApp, "<result4>", GenericECG.result4);
                this.FindAndReplace(wordApp, "<Comments>", GenericECG.comments);




                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = GenericECG.testequipment.Last();
                foreach (string item in GenericECG.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Generic NIBP
            if (PTNIBPGenericCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", GenericNIBPMonitor.result1);
                this.FindAndReplace(wordApp, "<result2>", GenericNIBPMonitor.result2);
                this.FindAndReplace(wordApp, "<result3>", GenericNIBPMonitor.result3);
                this.FindAndReplace(wordApp, "<result4>", GenericNIBPMonitor.result4);
                this.FindAndReplace(wordApp, "<result5>", GenericNIBPMonitor.result1);
                this.FindAndReplace(wordApp, "<result6>", GenericNIBPMonitor.result2);
                this.FindAndReplace(wordApp, "<result7>", GenericNIBPMonitor.result3);
                this.FindAndReplace(wordApp, "<result8>", GenericNIBPMonitor.result4);
                this.FindAndReplace(wordApp, "<Comments>", GenericNIBPMonitor.comments);
                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = GenericNIBPMonitor.testequipment.Last();
                foreach (string item in GenericNIBPMonitor.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Edan Doppler
            if (PTEdanDopplerCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", EdanDoppler.result1);
                this.FindAndReplace(wordApp, "<result2>", EdanDoppler.result2);
                this.FindAndReplace(wordApp, "<Comments>", EdanDoppler.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = EdanDoppler.testequipment.Last();
                foreach (string item in EdanDoppler.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Generic Sphygmomanometer
            if (PTSphygmomanometerCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", GenericSphygmomanometer.result1);
                this.FindAndReplace(wordApp, "<result2>", GenericSphygmomanometer.result2);
                this.FindAndReplace(wordApp, "<result3>", GenericSphygmomanometer.result3);
                this.FindAndReplace(wordApp, "<result4>", GenericSphygmomanometer.result4);
                this.FindAndReplace(wordApp, "<result5>", GenericSphygmomanometer.result5);
                this.FindAndReplace(wordApp, "<result6>", GenericSphygmomanometer.result6);
                this.FindAndReplace(wordApp, "<result7>", GenericSphygmomanometer.result7);
                this.FindAndReplace(wordApp, "<Comments>", GenericSphygmomanometer.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = GenericSphygmomanometer.testequipment.Last();
                foreach (string item in GenericSphygmomanometer.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Edan Doppler
            if (PTGenius2Completed == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", Genius2Thermometer.result1);
                this.FindAndReplace(wordApp, "<result2>", Genius2Thermometer.result2);
                this.FindAndReplace(wordApp, "<Comments>", Genius2Thermometer.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = Genius2Thermometer.testequipment.Last();
                foreach (string item in Genius2Thermometer.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Heine NT300
            if (PTHeineNT300Completed == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", HeineNT300.result1);
                this.FindAndReplace(wordApp, "<result2>", HeineNT300.result2);
                this.FindAndReplace(wordApp, "<result3>", HeineNT300.result3);
                this.FindAndReplace(wordApp, "<result4>", HeineNT300.result4);
                this.FindAndReplace(wordApp, "<result5>", HeineNT300.result5);
                this.FindAndReplace(wordApp, "<result6>", HeineNT300.result6);
                this.FindAndReplace(wordApp, "<result7>", HeineNT300.result7);
                this.FindAndReplace(wordApp, "<result8>", HeineNT300.result8);
                this.FindAndReplace(wordApp, "<Comments>", HeineNT300.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = HeineNT300.testequipment.Last();
                foreach (string item in HeineNT300.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Generic Defib
            if (PTPhilipsMRxCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", GenericDefibrillator.result1);
                this.FindAndReplace(wordApp, "<result2>", GenericDefibrillator.result2);
                this.FindAndReplace(wordApp, "<result3>", GenericDefibrillator.result3);
                this.FindAndReplace(wordApp, "<result4>", GenericDefibrillator.result4);
                this.FindAndReplace(wordApp, "<result5>", GenericDefibrillator.result5);
                this.FindAndReplace(wordApp, "<result6>", GenericDefibrillator.result6);
                this.FindAndReplace(wordApp, "<result7>", GenericDefibrillator.result7);
                this.FindAndReplace(wordApp, "<result8>", GenericDefibrillator.result8);
                this.FindAndReplace(wordApp, "<result9>", GenericDefibrillator.result9);
                this.FindAndReplace(wordApp, "<result10>", GenericDefibrillator.result10);
                this.FindAndReplace(wordApp, "<result11>", GenericDefibrillator.result11);
                this.FindAndReplace(wordApp, "<result12>", GenericDefibrillator.result12);
                this.FindAndReplace(wordApp, "<result13>", GenericDefibrillator.result13);
                this.FindAndReplace(wordApp, "<result14>", GenericDefibrillator.result14);
                this.FindAndReplace(wordApp, "<result15>", GenericDefibrillator.result15);
                this.FindAndReplace(wordApp, "<result16>", GenericDefibrillator.result16);
                this.FindAndReplace(wordApp, "<result17>", GenericDefibrillator.result17);
                this.FindAndReplace(wordApp, "<result18>", GenericDefibrillator.result18);
                this.FindAndReplace(wordApp, "<result19>", GenericDefibrillator.result19);
                this.FindAndReplace(wordApp, "<result20>", GenericDefibrillator.result20);
                this.FindAndReplace(wordApp, "<result21>", GenericDefibrillator.result21);
                this.FindAndReplace(wordApp, "<result22>", GenericDefibrillator.result22);
                this.FindAndReplace(wordApp, "<result23>", GenericDefibrillator.result23);
                this.FindAndReplace(wordApp, "<Comments>", GenericDefibrillator.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = GenericDefibrillator.testequipment.Last();
                foreach (string item in GenericDefibrillator.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Accusonic AP170
            if (PTAccusonicAP170Completed == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", AccusonicAP170.result1);
                this.FindAndReplace(wordApp, "<result2>", AccusonicAP170.result2);
                this.FindAndReplace(wordApp, "<result3>", AccusonicAP170.result3);
                this.FindAndReplace(wordApp, "<result4>", AccusonicAP170.result4);
                this.FindAndReplace(wordApp, "<result5>", AccusonicAP170.result5);
                this.FindAndReplace(wordApp, "<Comments>", AccusonicAP170.comments);
                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = AccusonicAP170.testequipment.Last();
                foreach (string item in AccusonicAP170.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Comweld Oxygen Flowmeter
            if (PTComweldOxygenFMCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", ComweldOxygenFlowmeter.result1);
                this.FindAndReplace(wordApp, "<result2>", ComweldOxygenFlowmeter.result2);
                this.FindAndReplace(wordApp, "<result3>", ComweldOxygenFlowmeter.result3);
                this.FindAndReplace(wordApp, "<result4>", ComweldOxygenFlowmeter.result4);
                this.FindAndReplace(wordApp, "<result5>", ComweldOxygenFlowmeter.result5);
                this.FindAndReplace(wordApp, "<result6>", ComweldOxygenFlowmeter.result6);
                this.FindAndReplace(wordApp, "<result7>", ComweldOxygenFlowmeter.result7);
                this.FindAndReplace(wordApp, "<result8>", ComweldOxygenFlowmeter.result8);
                this.FindAndReplace(wordApp, "<result9>", ComweldOxygenFlowmeter.result9);
                this.FindAndReplace(wordApp, "<Comments>", ComweldOxygenFlowmeter.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = ComweldOxygenFlowmeter.testequipment.Last();
                foreach (string item in ComweldOxygenFlowmeter.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Varp Vue
            if (PTVarpVueCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", VarpVue.result1);
                this.FindAndReplace(wordApp, "<result2>", VarpVue.result2);
                this.FindAndReplace(wordApp, "<result3>", VarpVue.result3);
                this.FindAndReplace(wordApp, "<result4>", VarpVue.result4);
                this.FindAndReplace(wordApp, "<result5>", VarpVue.result5);
                this.FindAndReplace(wordApp, "<result6>", VarpVue.result6);
                this.FindAndReplace(wordApp, "<result7>", VarpVue.result7);
                this.FindAndReplace(wordApp, "<result8>", VarpVue.result8);
                this.FindAndReplace(wordApp, "<value1>", VarpVue.value1);
                this.FindAndReplace(wordApp, "<value2>", VarpVue.value2);
                this.FindAndReplace(wordApp, "<value3>", VarpVue.value3);
                this.FindAndReplace(wordApp, "<value4>", VarpVue.value4);
                this.FindAndReplace(wordApp, "<value5>", VarpVue.value5);
                this.FindAndReplace(wordApp, "<value6>", VarpVue.value6);
                this.FindAndReplace(wordApp, "<value7>", VarpVue.value7);
                this.FindAndReplace(wordApp, "<value8>", VarpVue.value8);
                this.FindAndReplace(wordApp, "<result9>", VarpVue.result9);
                this.FindAndReplace(wordApp, "<Comments>", VarpVue.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = VarpVue.testequipment.Last();
                foreach (string item in VarpVue.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Scales
            if (PTScalesCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", Scales.result1);
                this.FindAndReplace(wordApp, "<result2>", Scales.result2);
                this.FindAndReplace(wordApp, "<result3>", Scales.result3);
                this.FindAndReplace(wordApp, "<result4>", Scales.result4);
                this.FindAndReplace(wordApp, "<result5>", Scales.result5);
                this.FindAndReplace(wordApp, "<result6>", Scales.result6);
                this.FindAndReplace(wordApp, "<result7>", Scales.result7);
                this.FindAndReplace(wordApp, "<result8>", Scales.result8);
                this.FindAndReplace(wordApp, "<Comments>", Scales.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = Scales.testequipment.Last();
                foreach (string item in Scales.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Vaccine Fridge
            if (PTVaccineFridgeCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", VaccineFridge.result1);
                this.FindAndReplace(wordApp, "<result2>", VaccineFridge.result2);
                this.FindAndReplace(wordApp, "<result3>", VaccineFridge.result3);
                this.FindAndReplace(wordApp, "<result4>", VaccineFridge.result4);
                this.FindAndReplace(wordApp, "<Comments>", VaccineFridge.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = VaccineFridge.testequipment.Last();
                foreach (string item in VaccineFridge.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Spirometer
            if (PTSpirometerCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", Spirometer.result1);
                this.FindAndReplace(wordApp, "<result2>", Spirometer.result2);
                this.FindAndReplace(wordApp, "<result3>", Spirometer.result3);
                this.FindAndReplace(wordApp, "<result4>", Spirometer.result4);
                this.FindAndReplace(wordApp, "<result5>", Spirometer.result5);
                this.FindAndReplace(wordApp, "<Comments>", Spirometer.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = Spirometer.testequipment.Last();
                foreach (string item in Spirometer.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Pulse Oximeter
            if (PTPulseOximeter2Completed == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", PulseOximeter2.result1);
                this.FindAndReplace(wordApp, "<result2>", PulseOximeter2.result2);
                this.FindAndReplace(wordApp, "<result3>", PulseOximeter2.result3);
                this.FindAndReplace(wordApp, "<result4>", PulseOximeter2.result4);
                this.FindAndReplace(wordApp, "<result5>", PulseOximeter2.result5);
                this.FindAndReplace(wordApp, "<result6>", PulseOximeter2.result6);
                this.FindAndReplace(wordApp, "<result7>", PulseOximeter2.result7);
                this.FindAndReplace(wordApp, "<result8>", PulseOximeter2.result8);
                this.FindAndReplace(wordApp, "<Comments>", PulseOximeter2.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = PulseOximeter2.testequipment.Last();
                foreach (string item in PulseOximeter2.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Manifold
            if (PTManifoldCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", Manifold.result1);
                this.FindAndReplace(wordApp, "<result2>", Manifold.result2);
                this.FindAndReplace(wordApp, "<result3>", Manifold.result3);
                this.FindAndReplace(wordApp, "<result4>", Manifold.result4);
                this.FindAndReplace(wordApp, "<result5>", Manifold.result5);
                this.FindAndReplace(wordApp, "<result6>", Manifold.result6);
                this.FindAndReplace(wordApp, "<result7>", Manifold.result7);
                this.FindAndReplace(wordApp, "<result8>", Manifold.result8);
                this.FindAndReplace(wordApp, "<result9>", Manifold.result9);
                this.FindAndReplace(wordApp, "<result10>", Manifold.result10);
                this.FindAndReplace(wordApp, "<result11>", Manifold.result11);
                this.FindAndReplace(wordApp, "<result12>", Manifold.result12);
                this.FindAndReplace(wordApp, "<result13>", Manifold.result13);
                this.FindAndReplace(wordApp, "<result14>", Manifold.result14);
                this.FindAndReplace(wordApp, "<result15>", Manifold.result15);
                this.FindAndReplace(wordApp, "<result16>", Manifold.result16);
                this.FindAndReplace(wordApp, "<typeofManifold>", Manifold.typeofmanifold);
                this.FindAndReplace(wordApp, "<Comments>", Manifold.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = Manifold.testequipment.Last();
                foreach (string item in Manifold.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //AED
            if (PTAEDCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", AED.result1);
                this.FindAndReplace(wordApp, "<result2>", AED.result2);
                this.FindAndReplace(wordApp, "<result3>", AED.result3);
                this.FindAndReplace(wordApp, "<result4>", AED.result4);
                this.FindAndReplace(wordApp, "<Comments>", AED.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = AED.testequipment.Last();
                foreach (string item in AED.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Regulator
            if (PTRegulator2Completed == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", RegulatorPT.result1);
                this.FindAndReplace(wordApp, "<result2>", RegulatorPT.result2);
                this.FindAndReplace(wordApp, "<result3>", RegulatorPT.result3);
                this.FindAndReplace(wordApp, "<result4>", RegulatorPT.result4);
                this.FindAndReplace(wordApp, "<result5>", RegulatorPT.result5);
                this.FindAndReplace(wordApp, "<Comments>", RegulatorPT.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = RegulatorPT.testequipment.Last();
                foreach (string item in RegulatorPT.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Generic Vitals
            if (PTVitalsMonitorCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", GenericVitalsMonitor.result1);
                this.FindAndReplace(wordApp, "<result2>", GenericVitalsMonitor.result2);
                this.FindAndReplace(wordApp, "<result3>", GenericVitalsMonitor.result3);
                this.FindAndReplace(wordApp, "<result4>", GenericVitalsMonitor.result4);
                this.FindAndReplace(wordApp, "<result5>", GenericVitalsMonitor.result5);
                this.FindAndReplace(wordApp, "<result6>", GenericVitalsMonitor.result6);
                this.FindAndReplace(wordApp, "<result7>", GenericVitalsMonitor.result7);
                this.FindAndReplace(wordApp, "<result8>", GenericVitalsMonitor.result8);
                this.FindAndReplace(wordApp, "<result9>", GenericVitalsMonitor.result9);
                this.FindAndReplace(wordApp, "<result10>", GenericVitalsMonitor.result10);
                this.FindAndReplace(wordApp, "<result11>", GenericVitalsMonitor.result11);
                this.FindAndReplace(wordApp, "<result12>", GenericVitalsMonitor.result12);
                this.FindAndReplace(wordApp, "<result13>", GenericVitalsMonitor.result13);
                this.FindAndReplace(wordApp, "<result14>", GenericVitalsMonitor.result14);
                this.FindAndReplace(wordApp, "<Comments>", GenericVitalsMonitor.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = GenericVitalsMonitor.testequipment.Last();
                foreach (string item in GenericVitalsMonitor.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Philips Monitors
            if (PTPhilipsMonitorCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", PhilipsMonitors.result1);
                this.FindAndReplace(wordApp, "<result2>", PhilipsMonitors.result2);
                this.FindAndReplace(wordApp, "<result3>", PhilipsMonitors.result3);
                this.FindAndReplace(wordApp, "<result4>", PhilipsMonitors.result4);
                this.FindAndReplace(wordApp, "<result5>", PhilipsMonitors.result5);
                this.FindAndReplace(wordApp, "<result6>", PhilipsMonitors.result6);
                this.FindAndReplace(wordApp, "<result7>", PhilipsMonitors.result7);
                this.FindAndReplace(wordApp, "<result8>", PhilipsMonitors.result8);
                this.FindAndReplace(wordApp, "<result9>", PhilipsMonitors.result9);
                this.FindAndReplace(wordApp, "<result10>", PhilipsMonitors.result10);
                this.FindAndReplace(wordApp, "<result11>", PhilipsMonitors.result11);
                this.FindAndReplace(wordApp, "<result12>", PhilipsMonitors.result12);
                this.FindAndReplace(wordApp, "<result13>", PhilipsMonitors.result13);
                this.FindAndReplace(wordApp, "<result14>", PhilipsMonitors.result14);
                this.FindAndReplace(wordApp, "<Comments>", PhilipsMonitors.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = PhilipsMonitors.testequipment.Last();
                foreach (string item in PhilipsMonitors.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //OxyViva
            if (PTOxyVivaCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", OxyVivaResusBox.result1);
                this.FindAndReplace(wordApp, "<result2>", OxyVivaResusBox.result2);
                this.FindAndReplace(wordApp, "<result3>", OxyVivaResusBox.result3);
                this.FindAndReplace(wordApp, "<result4>", OxyVivaResusBox.result4);
                this.FindAndReplace(wordApp, "<result5>", OxyVivaResusBox.result5);
                this.FindAndReplace(wordApp, "<result6>", OxyVivaResusBox.result6);
                this.FindAndReplace(wordApp, "<manufacturer1>", OxyVivaResusBox.manu1);
                this.FindAndReplace(wordApp, "<manufacturer2>", OxyVivaResusBox.manu2);
                this.FindAndReplace(wordApp, "<manufacturer3>", OxyVivaResusBox.manu3);
                this.FindAndReplace(wordApp, "<manufacturer4>", OxyVivaResusBox.manu4);
                this.FindAndReplace(wordApp, "<manufacturer5>", OxyVivaResusBox.manu5);
                this.FindAndReplace(wordApp, "<manufacturer6>", OxyVivaResusBox.manu6);
                this.FindAndReplace(wordApp, "<model1>", OxyVivaResusBox.modelbox1);
                this.FindAndReplace(wordApp, "<model2>", OxyVivaResusBox.modelbox2);
                this.FindAndReplace(wordApp, "<model3>", OxyVivaResusBox.modelbox3);
                this.FindAndReplace(wordApp, "<model4>", OxyVivaResusBox.modelbox4);
                this.FindAndReplace(wordApp, "<model5>", OxyVivaResusBox.modelbox5);
                this.FindAndReplace(wordApp, "<model6>", OxyVivaResusBox.modelbox6);
                this.FindAndReplace(wordApp, "<type1>", OxyVivaResusBox.typebox1);
                this.FindAndReplace(wordApp, "<type2>", OxyVivaResusBox.typebox2);
                this.FindAndReplace(wordApp, "<type3>", OxyVivaResusBox.typebox3);
                this.FindAndReplace(wordApp, "<type4>", OxyVivaResusBox.typebox4);
                this.FindAndReplace(wordApp, "<type5>", OxyVivaResusBox.typebox5);
                this.FindAndReplace(wordApp, "<type6>", OxyVivaResusBox.typebox6);
                this.FindAndReplace(wordApp, "<serial1>", OxyVivaResusBox.serialnum1);
                this.FindAndReplace(wordApp, "<serial2>", OxyVivaResusBox.serialnum2);
                this.FindAndReplace(wordApp, "<serial3>", OxyVivaResusBox.serialnum3);
                this.FindAndReplace(wordApp, "<serial4>", OxyVivaResusBox.serialnum4);
                this.FindAndReplace(wordApp, "<serial5>", OxyVivaResusBox.serialnum5);
                this.FindAndReplace(wordApp, "<serial6>", OxyVivaResusBox.serialnum6);
                this.FindAndReplace(wordApp, "<pressure>", OxyVivaResusBox.pressure1);
                this.FindAndReplace(wordApp, "<Comments>", OxyVivaResusBox.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = OxyVivaResusBox.testequipment.Last();
                foreach (string item in OxyVivaResusBox.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Soft Pack
            if (PTSoftPackRescueCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", SoftPackRescueBag.result1);
                this.FindAndReplace(wordApp, "<result2>", SoftPackRescueBag.result2);
                this.FindAndReplace(wordApp, "<result3>", SoftPackRescueBag.result3);
                this.FindAndReplace(wordApp, "<result4>", SoftPackRescueBag.result4);
                this.FindAndReplace(wordApp, "<result5>", SoftPackRescueBag.result5);
                this.FindAndReplace(wordApp, "<manufacturer1>", SoftPackRescueBag.manu1);
                this.FindAndReplace(wordApp, "<manufacturer2>", SoftPackRescueBag.manu2);
                this.FindAndReplace(wordApp, "<manufacturer3>", SoftPackRescueBag.manu3);
                this.FindAndReplace(wordApp, "<manufacturer4>", SoftPackRescueBag.manu4);
                this.FindAndReplace(wordApp, "<manufacturer5>", SoftPackRescueBag.manu5);
                this.FindAndReplace(wordApp, "<model1>", SoftPackRescueBag.modelbox1);
                this.FindAndReplace(wordApp, "<model2>", SoftPackRescueBag.modelbox2);
                this.FindAndReplace(wordApp, "<model3>", SoftPackRescueBag.modelbox3);
                this.FindAndReplace(wordApp, "<model4>", SoftPackRescueBag.modelbox4);
                this.FindAndReplace(wordApp, "<model5>", SoftPackRescueBag.modelbox5);
                this.FindAndReplace(wordApp, "<type1>", SoftPackRescueBag.typebox1);
                this.FindAndReplace(wordApp, "<type2>", SoftPackRescueBag.typebox2);
                this.FindAndReplace(wordApp, "<type3>", SoftPackRescueBag.typebox3);
                this.FindAndReplace(wordApp, "<type4>", SoftPackRescueBag.typebox4);
                this.FindAndReplace(wordApp, "<type5>", SoftPackRescueBag.typebox5);
                this.FindAndReplace(wordApp, "<serial1>", SoftPackRescueBag.serialnum1);
                this.FindAndReplace(wordApp, "<serial2>", SoftPackRescueBag.serialnum2);
                this.FindAndReplace(wordApp, "<serial3>", SoftPackRescueBag.serialnum3);
                this.FindAndReplace(wordApp, "<serial4>", SoftPackRescueBag.serialnum4);
                this.FindAndReplace(wordApp, "<serial5>", SoftPackRescueBag.serialnum5);
                this.FindAndReplace(wordApp, "<pressure>", SoftPackRescueBag.pressure1);
                this.FindAndReplace(wordApp, "<Comments>", SoftPackRescueBag.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = SoftPackRescueBag.testequipment.Last();
                foreach (string item in SoftPackRescueBag.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }
                #endregion
            }
            //Oxylog
            if (PTOxylogCompleted == true)
            {
                #region Find and Replace
                // Find Place Holders and Replace them with Values.
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
                this.FindAndReplace(wordApp, "<PerformanceTestResult>", ESTResults);
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<result1>", Oxylog.result1);
                this.FindAndReplace(wordApp, "<result2>", Oxylog.result2);
                this.FindAndReplace(wordApp, "<result3>", Oxylog.result3);
                this.FindAndReplace(wordApp, "<result4>", Oxylog.result4);
                this.FindAndReplace(wordApp, "<result5>", Oxylog.result5);
                this.FindAndReplace(wordApp, "<result6>", Oxylog.result6);
                this.FindAndReplace(wordApp, "<result7>", Oxylog.result7);
                this.FindAndReplace(wordApp, "<result8>", Oxylog.result8);
                this.FindAndReplace(wordApp, "<result9>", Oxylog.result9);
                this.FindAndReplace(wordApp, "<result10>", Oxylog.result10);
                this.FindAndReplace(wordApp, "<result11>", Oxylog.result11);
                this.FindAndReplace(wordApp, "<result12>", Oxylog.result12);
                this.FindAndReplace(wordApp, "<result13>", Oxylog.result13);
                this.FindAndReplace(wordApp, "<result14>", Oxylog.result14);
                this.FindAndReplace(wordApp, "<text1>", Oxylog.text_result1);
                this.FindAndReplace(wordApp, "<text2>", Oxylog.text_result2);
                this.FindAndReplace(wordApp, "<text3>", Oxylog.text_result3);
                this.FindAndReplace(wordApp, "<text4>", Oxylog.text_result4);
                this.FindAndReplace(wordApp, "<text5>", Oxylog.text_result5);
                this.FindAndReplace(wordApp, "<text6>", Oxylog.text_result6);
                this.FindAndReplace(wordApp, "<Comments>", Oxylog.comments);

                wDoc.Bookmarks["testequipment"].Select();
                object moveUnit = Word.WdUnits.wdCell;
                object moveExend = Word.WdMovementType.wdMove;
                string last = Oxylog.testequipment.Last();
                foreach (string item in Oxylog.testequipment)
                {
                    // do something with each item
                    if (item.Equals(last))
                    {
                        wordApp.Selection.TypeText(item);
                    }
                    else
                    {
                        wordApp.Selection.TypeText(item);
                        wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                    }
                }


                #endregion
            }
            //create PDF
            if (PerformPerformanceTest == true)
            {
                wDoc.ExportAsFixedFormat(saveDestination + "/" + EquipmentDetails.assetNumber + "-" + EquipmentDetails.serialNumber + "-" + EquipmentDetails.model + "-"+ EquipmentDetails.manufacturer + "-"+ EquipmentDetails.location + "- Performance Test Report" + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
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

                    if (ProtectiveEarthOptions.nonDetachableSupplyOption == true || ProtectiveEarthOptions.detachablePowerSupplyOption == true)
                    {
                        File.Copy(appRootDir + "/Report Templates/ASNZCLASS1-TEMPLATE1.docx", appRootDir + "/Report Templates/temp.docx");
                    }
                    else if (ProtectiveEarthOptions.withApplianceInletOption == true)
                    {
                        File.Copy(appRootDir + "/Report Templates/ASNZCLASS1-TEMPLATE2.docx", appRootDir + "/Report Templates/temp.docx");
                    }

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
                    string pictureName = appRootDir + "/Signatures/" + LogInPage.currentUser + ".png";
                    wDoc.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, ref oRange);
                }

                if (class1ASNZtest == true)
                {
                    #region Find and Replace
                    // Find Place Holders and Replace them with Values.
                    this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                    this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                    this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                    this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                    this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                    this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
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
                    this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);
                    this.FindAndReplace(wordApp, "<AssetNumber>", EquipmentDetails.assetNumber);
                    this.FindAndReplace(wordApp, "<SerialNumber>", EquipmentDetails.serialNumber);
                    this.FindAndReplace(wordApp, "<Location>", EquipmentDetails.location);
                    this.FindAndReplace(wordApp, "<Manufacturer>", EquipmentDetails.manufacturer);
                    this.FindAndReplace(wordApp, "<Model>", EquipmentDetails.model);
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
                MetroFramework.MetroMessageBox.Show(this, "", "File does not exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //as where to save the files
            //export to pdf
            if (PerformElectricalSafetyTest == true)
            {
                wDoc.ExportAsFixedFormat(saveDestination + "/" + EquipmentDetails.assetNumber + "-" + EquipmentDetails.serialNumber +"-"+ EquipmentDetails.model + "-" + EquipmentDetails.manufacturer + "-"+ EquipmentDetails.location + "- Electrical Safety Test Report" + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
            }


            //Close the document - you have to do this.
            GC.Collect();
            wDoc.Close();
            wordApp.Quit();

       

        }
        #region QAS Buttons

        private void multiflowRegulator_btn_Click(object sender, EventArgs e)
        {
            MultiflowRegulator dg = new MultiflowRegulator();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.multiflowregulatorTest_Submit == true)
                {
                    //yesNoPerformanceTest = true;
                    counter_multiflowregulator++;

                    QASTestisDone = true;
                    PTMultiFlowRegulatorCompleted = true;

                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void outletPoint_btn_Click(object sender, EventArgs e)
        {
            Outlet_Point dg = new Outlet_Point();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.outletPointTest_Submit == true)
                {
                    //yesNoPerformanceTest = true;
                    counter_outletPoint++;

                    QASTestisDone = true;
                    PTOutletPointCompleted = true;

                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void oxygenReticulation_btn_Click(object sender, EventArgs e)
        {
            OxygenReticulationAlarm dg = new OxygenReticulationAlarm();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.oxygenReticulationTest_Submit == true)
                {
                    counter_oxygenReticulation++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTOxygenReticulationCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void regulator_btn_Click(object sender, EventArgs e)
        {
            Regulator dg = new Regulator();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.regulatorTest_Submit == true)
                {
                    counter_regulator++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTRegulatorCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void flowmeter_btn_Click(object sender, EventArgs e)
        {
            Flowmeter dg = new Flowmeter();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.FlowmeterTest_Submit == true)
                {
                    counter_flowmeter++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTFlowmeterCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void residualCurrent_btn_Click(object sender, EventArgs e)
        {
            ResidualCurrentDevice dg = new ResidualCurrentDevice();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.ResidualCurrentDeviceTest_Submit == true)
                {
                    counter_residualCurrentDevice++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTResidualCurrentDeviceCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void twinovac_btn_Click(object sender, EventArgs e)
        {
            TwinOVac dg = new TwinOVac();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.TwinOVacTest_Submit == true)
                {
                    counter_twinOVac++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTTwinOVacCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void demanHead_btn_Click(object sender, EventArgs e)
        {
            DemandHead dg = new DemandHead();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.DemandHeadTest_Submit == true)
                {
                    counter_demandHead++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTDemanHeadCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }


        private void aedefibrillator_btn_Click(object sender, EventArgs e)
        {
            AutomaticExternalDefib dg = new AutomaticExternalDefib();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.AutomaticExternalDefibTest_Submit == true)
                {
                    counter_aspirator++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTAutomaticExternalDefibCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void aspirator_btn_Click(object sender, EventArgs e)
        {
            Aspirator dg = new Aspirator();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.AspiratorTest_Submit == true)
                {
                    counter_aspirator++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTAspiratorCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void pulseOximeter_btn_Click(object sender, EventArgs e)
        {
            PulseOximeter dg = new PulseOximeter();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.PulseOximeter_Submit == true)
                {
                    counter_pulseOximeter++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTPulseOximeterCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void sphygmo2_btn_Click(object sender, EventArgs e)
        {
            SphygmoWall dg = new SphygmoWall();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.SphygmoWallTest_Submit == true)
                {
                    counter_sphygmoWall++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTSphygmoWallCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void sphygmo1_btn_Click(object sender, EventArgs e)
        {
            SphygmoHandheld dg = new SphygmoHandheld();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.SphygmoHandheldTest_Submit == true)
                {
                    counter_shygmoHHeld++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTSphygmoHHeldCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void recoilBag_btn_Click(object sender, EventArgs e)
        {
            RecoilBagResuscitator dg = new RecoilBagResuscitator();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.RecoilBagResuscitatorTest_Submit == true)
                {
                    counter_recoilBag++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTRecoilBagCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void electricSuction_btn_Click(object sender, EventArgs e)
        {
            ElectricSuction dg = new ElectricSuction();
            DialogResult dialog1 = dg.ShowDialog();
            if (dialog1 == DialogResult.Cancel)
            {
                if (dg.ElectricSuctionTest_Submit == true)
                {
                    counter_electricSuction++;
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTElectricSuctionCompleted = true;
                    QASeditDocument();
                }
                else
                {
                    DialogResult dialogResult = MetroFramework.MetroMessageBox.Show(this, "Continue?", "Performance test is not completed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //yesNoPerformanceTest = false;
                        QASTestisDone = false;

                        MetroFramework.MetroMessageBox.Show(this, "This will not be generated in the report", "Performance Test Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        #endregion
        //QAS edit document
        private void QASeditDocument()
        {
            if (File.Exists(MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx"))
            {
                File.Delete(MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            }

            if (PTOutletPointCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Outlet Point-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTOxygenReticulationCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Oxygen Reticulation Failure Alarm-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTRegulatorCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Regulator-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTFlowmeterCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Flowmeter-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTElectricSuctionCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Electric Suction-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTRecoilBagCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Recoil Bag Resuscitator-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTSphygmoHHeldCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Sphygmo Handheld-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTSphygmoWallCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Sphygmo Wall-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTPulseOximeterCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Pulse Oximeter-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTAspiratorCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Aspirator-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTDemanHeadCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Demand Head-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTTwinOVacCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Twin-O-Vac Suction Device-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTResidualCurrentDeviceCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Residual Current Device-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTAutomaticExternalDefibCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Automatic External Defibrillator-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTMultiFlowRegulatorCompleted == true)
                File.Copy(MainMenu.appRootDir + "/Report Templates/QAS Templates/Multi-Flow Regulator-TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");

            //Setup the Word.Application class.
            Word.Application wordApp =
                new Word.Application();

            //set objects
            object missing = System.Reflection.Missing.Value;
            object what = Word.WdGoToItem.wdGoToLine;
            object which = Word.WdGoToDirection.wdGoToLast;
            object saveAs = MainMenu.appRootDir + "/Report Templates/QAS Templates/temp.docx";
            //Set Word to be not visible.
            wordApp.Visible = false;



            //open temp1 docx - electrical safety
            Word.Document wDoc1 = wordApp.Documents.Open(MainMenu.appRootDir + "/Report Templates/QAS Templates/temp.docx");
            //open temp2 docx - performance test
            Word.Document wDoc2 = wordApp.Documents.Open(MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");

            wDoc2.Activate();

            //find and replace first before copying everything

            //Outlet Point
            if (PTOutletPointCompleted == true)
            {
                OutletPointAssets.Add(Outlet_Point.assetNumberText);

                this.FindAndReplace(wordApp, "<AssetNumber>", Outlet_Point.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", Outlet_Point.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", Outlet_Point.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", Outlet_Point.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", Outlet_Point.result1);
                this.FindAndReplace(wordApp, "<result2>", Outlet_Point.result2);
                this.FindAndReplace(wordApp, "<result3>", Outlet_Point.result3);
                this.FindAndReplace(wordApp, "<result4>", Outlet_Point.result4);
                this.FindAndReplace(wordApp, "<Comments>", Outlet_Point.comments);

                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in Outlet_Point.parts)
                {
                    para.Range.Text = item+"\n";
                    _PartsCounter.Add(item);

                }

            }
            //AED
            if (PTAutomaticExternalDefibCompleted == true)
            {
                AutomaticEDAssets.Add(AutomaticExternalDefib.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", AutomaticExternalDefib.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", AutomaticExternalDefib.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", AutomaticExternalDefib.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", AutomaticExternalDefib.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", AutomaticExternalDefib.result1);
                this.FindAndReplace(wordApp, "<result2>", AutomaticExternalDefib.result2);
                this.FindAndReplace(wordApp, "<result3>", AutomaticExternalDefib.result3);
                this.FindAndReplace(wordApp, "<Comments>", AutomaticExternalDefib.comments);

                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in AutomaticExternalDefib.parts)
                {
                    para.Range.Text = item + "\r";
                    _PartsCounter.Add(item);

                }

            }

            if (PTOxygenReticulationCompleted == true)
            {
                OxygenReticulationAssets.Add(OxygenReticulationAlarm.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", OxygenReticulationAlarm.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", OxygenReticulationAlarm.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", OxygenReticulationAlarm.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", OxygenReticulationAlarm.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", OxygenReticulationAlarm.result1);
                this.FindAndReplace(wordApp, "<result2>", OxygenReticulationAlarm.result2);
                this.FindAndReplace(wordApp, "<result3>", OxygenReticulationAlarm.result3);
                this.FindAndReplace(wordApp, "<result4>", OxygenReticulationAlarm.result4);
                this.FindAndReplace(wordApp, "<Comments>", OxygenReticulationAlarm.comments);

                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in OxygenReticulationAlarm.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }
            if (PTRegulatorCompleted == true)
            {
                RegulatorAssets.Add(Regulator.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", Regulator.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", Regulator.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", Regulator.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", Regulator.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", Regulator.result1);
                this.FindAndReplace(wordApp, "<result2>", Regulator.result2);
                this.FindAndReplace(wordApp, "<result3>", Regulator.result3);
                this.FindAndReplace(wordApp, "<result4>", Regulator.result4);
                this.FindAndReplace(wordApp, "<Comments>", Regulator.comments);

                wDoc2.Bookmarks["listofitems"].Select();

                foreach (string item in Regulator.parts)
                {
                    wordApp.Selection.TypeText(item + "\n");
                    _PartsCounter.Add(item);
                }
            }
            if (PTMultiFlowRegulatorCompleted == true)
            {
                MultiFlowRegulatorAssets.Add(MultiflowRegulator.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", MultiflowRegulator.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", MultiflowRegulator.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", MultiflowRegulator.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", MultiflowRegulator.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", MultiflowRegulator.result1);
                this.FindAndReplace(wordApp, "<result2>", MultiflowRegulator.result2);
                this.FindAndReplace(wordApp, "<result3>", MultiflowRegulator.result3);
                this.FindAndReplace(wordApp, "<result4>", MultiflowRegulator.result4);
                this.FindAndReplace(wordApp, "<Comments>", MultiflowRegulator.comments);

                wDoc2.Bookmarks["listofitems"].Select();

                foreach (string item in MultiflowRegulator.parts)
                {
                    wordApp.Selection.TypeText(item + "\n");
                    _PartsCounter.Add(item);
                }
            }
            if (PTFlowmeterCompleted == true)
            {
                FlowmeterAssets.Add(Flowmeter.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", Flowmeter.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", Flowmeter.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", Flowmeter.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", Flowmeter.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", Flowmeter.result1);
                this.FindAndReplace(wordApp, "<result2>", Flowmeter.result2);
                this.FindAndReplace(wordApp, "<result3>", Flowmeter.result3);
                this.FindAndReplace(wordApp, "<Comments>", Flowmeter.comments);

                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in Flowmeter.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }
            if (PTElectricSuctionCompleted == true)
            {
                ElectricSuctionAssets.Add(ElectricSuction.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", ElectricSuction.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", ElectricSuction.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", ElectricSuction.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", ElectricSuction.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", ElectricSuction.result1);
                this.FindAndReplace(wordApp, "<result2>", ElectricSuction.result2);
                this.FindAndReplace(wordApp, "<result3>", ElectricSuction.result3);
                this.FindAndReplace(wordApp, "<Comments>", ElectricSuction.comments);

                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in ElectricSuction.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }
            if (PTRecoilBagCompleted == true)
            {
                RecoilBagResuscitatorAssets.Add(RecoilBagResuscitator.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", RecoilBagResuscitator.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", RecoilBagResuscitator.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", RecoilBagResuscitator.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", RecoilBagResuscitator.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", RecoilBagResuscitator.result1);
                this.FindAndReplace(wordApp, "<result2>", RecoilBagResuscitator.result2);
                this.FindAndReplace(wordApp, "<result3>", RecoilBagResuscitator.result3);
                this.FindAndReplace(wordApp, "<result4>", RecoilBagResuscitator.result4);
                this.FindAndReplace(wordApp, "<result5>", RecoilBagResuscitator.result5);
                this.FindAndReplace(wordApp, "<Comments>", RecoilBagResuscitator.comments);
                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in RecoilBagResuscitator.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }
            if (PTSphygmoHHeldCompleted == true)
            {
                Spygmo1Assets.Add(SphygmoHandheld.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", SphygmoHandheld.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", SphygmoHandheld.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", SphygmoHandheld.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", SphygmoHandheld.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", SphygmoHandheld.result1);
                this.FindAndReplace(wordApp, "<result2>", SphygmoHandheld.result2);
                this.FindAndReplace(wordApp, "<result3>", SphygmoHandheld.result3);
                this.FindAndReplace(wordApp, "<result4>", SphygmoHandheld.result4);
                this.FindAndReplace(wordApp, "<result5>", SphygmoHandheld.result5);
                this.FindAndReplace(wordApp, "<result6>", SphygmoHandheld.result6);
                this.FindAndReplace(wordApp, "<Comments>", SphygmoHandheld.comments);
                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in SphygmoHandheld.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }
            if (PTSphygmoWallCompleted == true)
            {
                Spygmo2Assets.Add(SphygmoWall.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", SphygmoWall.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", SphygmoWall.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", SphygmoWall.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", SphygmoWall.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", SphygmoWall.result1);
                this.FindAndReplace(wordApp, "<result2>", SphygmoWall.result2);
                this.FindAndReplace(wordApp, "<result3>", SphygmoWall.result3);
                this.FindAndReplace(wordApp, "<result4>", SphygmoWall.result4);
                this.FindAndReplace(wordApp, "<result5>", SphygmoWall.result5);
                this.FindAndReplace(wordApp, "<result6>", SphygmoWall.result6);
                this.FindAndReplace(wordApp, "<Comments>", SphygmoWall.comments);
                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in SphygmoWall.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }
            if (PTPulseOximeterCompleted == true)
            {
                PulseOximeterAssets.Add(PulseOximeter.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", PulseOximeter.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", PulseOximeter.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", PulseOximeter.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", PulseOximeter.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", PulseOximeter.result1);
                this.FindAndReplace(wordApp, "<result2>", PulseOximeter.result2);
                this.FindAndReplace(wordApp, "<result3>", PulseOximeter.result3);
                this.FindAndReplace(wordApp, "<Comments>", PulseOximeter.comments);
                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in PulseOximeter.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }
            if (PTAspiratorCompleted == true)
            {
                AspiratorsAssets.Add(Aspirator.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", Aspirator.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", Aspirator.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", Aspirator.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", Aspirator.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", Aspirator.result1);
                this.FindAndReplace(wordApp, "<result2>", Aspirator.result2);
                this.FindAndReplace(wordApp, "<result3>", Aspirator.result3);
                this.FindAndReplace(wordApp, "<Comments>", Aspirator.comments);
                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in Aspirator.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }
            if (PTDemanHeadCompleted == true)
            {
                DemandHeadAssets.Add(DemandHead.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", DemandHead.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", DemandHead.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", DemandHead.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", DemandHead.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", DemandHead.result1);
                this.FindAndReplace(wordApp, "<result2>", DemandHead.result2);
                this.FindAndReplace(wordApp, "<result3>", DemandHead.result3);
                this.FindAndReplace(wordApp, "<Comments>", DemandHead.comments);
                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in DemandHead.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }
            if (PTTwinOVacCompleted == true)
            {
                TwinOVacAssets.Add(TwinOVac.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", TwinOVac.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", TwinOVac.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", TwinOVac.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", TwinOVac.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", TwinOVac.result1);
                this.FindAndReplace(wordApp, "<result2>", TwinOVac.result2);
                this.FindAndReplace(wordApp, "<result3>", TwinOVac.result3);
                this.FindAndReplace(wordApp, "<result4>", TwinOVac.result4);
                this.FindAndReplace(wordApp, "<result5>", TwinOVac.result5);
                this.FindAndReplace(wordApp, "<result6>", TwinOVac.result6);
                this.FindAndReplace(wordApp, "<Comments>", TwinOVac.comments);
                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in TwinOVac.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }
            if (PTResidualCurrentDeviceCompleted == true)
            {
                RCDAssets.Add(ResidualCurrentDevice.assetNumberText);
                this.FindAndReplace(wordApp, "<AssetNumber>", ResidualCurrentDevice.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", ResidualCurrentDevice.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", ResidualCurrentDevice.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", ResidualCurrentDevice.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", ResidualCurrentDevice.result1);
                this.FindAndReplace(wordApp, "<result2>", ResidualCurrentDevice.result2);
                this.FindAndReplace(wordApp, "<result3>", ResidualCurrentDevice.result3);
                this.FindAndReplace(wordApp, "<result4>", ResidualCurrentDevice.result4);
                this.FindAndReplace(wordApp, "<Comments>", ResidualCurrentDevice.comments);
                object paraRange = wDoc2.Bookmarks[1].Range;
                Word.Paragraph para = wDoc2.Paragraphs.Add(paraRange);
                //para.Range.Font.Name = "Courier New";

                foreach (string item in ResidualCurrentDevice.parts)
                {
                    para.Range.Text = item + "\n";
                    _PartsCounter.Add(item);

                }
            }

            
            Word.Range docRange = wDoc2.Content;

            docRange.Select();
            wordApp.Selection.Copy();

            wDoc1.Activate();
            wordApp.Selection.GoTo(what, which, missing, missing);
            wordApp.Selection.Paste();

            //Save the document as the correct file name.
            wDoc1.SaveAs(ref saveAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);

            GC.Collect();
            wDoc1.Close();
            wDoc2.Close();
            wordApp.Quit();

            MetroFramework.MetroMessageBox.Show(this, "", "Added on the report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (File.Exists(MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx"))
            {
                File.Delete(MainMenu.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            }

            PTMultiFlowRegulatorCompleted = false;
            PTAspiratorCompleted = false;
            PTOutletPointCompleted = false;
            PTOxygenReticulationCompleted = false;
            PTRegulatorCompleted = false;
            PTFlowmeterCompleted = false;
            PTElectricSuctionCompleted = false;
            PTRecoilBagCompleted = false;
            PTSphygmoHHeldCompleted = false;
            PTSphygmoWallCompleted = false;
            PTPulseOximeterCompleted = false;
            PTDemanHeadCompleted = false;
            PTTwinOVacCompleted = false;
            PTResidualCurrentDeviceCompleted = false;
            PTAutomaticExternalDefibCompleted = false;

            Aspirator.parts.Clear();
            AutomaticExternalDefib.parts.Clear();
            DemandHead.parts.Clear();
            ElectricSuction.parts.Clear();
            Flowmeter.parts.Clear();
            Outlet_Point.parts.Clear();
            OxygenReticulationAlarm.parts.Clear();
            PulseOximeter.parts.Clear();
            RecoilBagResuscitator.parts.Clear();
            Regulator.parts.Clear();
            ResidualCurrentDevice.parts.Clear();
            SphygmoHandheld.parts.Clear();
            TwinOVac.parts.Clear();
            MultiflowRegulator.parts.Clear();
        }
        private void qasSubmit_btn_Click(object sender, EventArgs e)
        {
            QASsaveReportPDF();
            Application.Exit();
        }
        private void QASsaveReportPDF()

        {

            //add equipments to the list
            AddEquipmentList();
            bool isEmpty = !_EquipmentCounter.Any();
            if (isEmpty)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "Select from the following list", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                //Setup the Word.Application class.
                Word.Application wordApp =
                    new Word.Application();

                //set objects
                object missing = System.Reflection.Missing.Value;
                //Set Word to be not visible.
                wordApp.Visible = false;

                //open temp1 docx - electrical safety
                Word.Document wDoc1 = wordApp.Documents.Open(appRootDir + "/Report Templates/QAS Templates/temp.docx");

                wDoc1.Activate();

                //find and replace first before copying everything
                this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
                this.FindAndReplace(wordApp, "<Location/Room>", QASEquipmentDetails.location);
                this.FindAndReplace(wordApp, "<Station>", QASEquipmentDetails.station);
                this.FindAndReplace(wordApp, "<VehicleNumber>", QASEquipmentDetails.vehiclenumber);
                this.FindAndReplace(wordApp, "<RegoNumber>", QASEquipmentDetails.registrationnumber);
                this.FindAndReplace(wordApp, "<Name>", LogInPage.currentUser);


                // for changing signatures
                wDoc1.Bookmarks["image"].Select();
                object saveWithDocument = true;
                string pictureName = appRootDir + "/Signatures/" + LogInPage.currentUser + ".png";
                wordApp.Selection.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, missing);

                //for equipment list
                wDoc1.Bookmarks["equipments"].Select();
                foreach (var lvi in _EquipmentCounter)
                {
                    wordApp.Selection.TypeText(lvi + "\n");
                }

                //for parts list
                wDoc1.Bookmarks["parts"].Select();
                var q = from x in _PartsCounter
                        group x by x into g
                        let count = g.Count()
                        orderby count descending
                        select new { Value = g.Key, Count = count };
                foreach (var x in q)
                {
                    wordApp.Selection.TypeText(x.Count + "x - " + x.Value + "\n");
                }


                wDoc1.ExportAsFixedFormat(saveDestination + "/Station " + QASEquipmentDetails.station + "-Vehicle Number " + QASEquipmentDetails.vehiclenumber  + "- QAS Report.pdf", Word.WdExportFormat.wdExportFormatPDF);
                
                GC.Collect();
                wDoc1.Close();
                wordApp.Quit();
                MetroFramework.MetroMessageBox.Show(this, "", "Report is Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(saveDestination + "/Station " + QASEquipmentDetails.station + "-Vehicle Number " + QASEquipmentDetails.vehiclenumber + "- QAS Report.pdf");

            }

        }
        private void AddEquipmentList()
        {

            if (counter_outletPoint != 0)
                _EquipmentCounter.Add(counter_outletPoint.ToString()+"x - Outlet Point: (" + string.Join(", ", OutletPointAssets)+ ")");
            if (counter_oxygenReticulation != 0)
                _EquipmentCounter.Add( counter_oxygenReticulation.ToString()+ "x - Oxygen Reticulation: ( " + string.Join(", ", OxygenReticulationAssets) + ")");
            if (counter_aspirator != 0)
                _EquipmentCounter.Add(counter_aspirator.ToString()+ "x - Aspirator: (" + string.Join(", ", AspiratorsAssets) + ")");
            if (counter_demandHead != 0)
                _EquipmentCounter.Add( counter_demandHead.ToString()+ "x - Demand Head: ("+ string.Join(", ", DemandHeadAssets) + ")");
            if (counter_electricSuction != 0)
                _EquipmentCounter.Add( counter_electricSuction.ToString()+ "x - Electric Suction: (" + string.Join(", ", ElectricSuctionAssets) + ")");
            if (counter_flowmeter != 0)
                _EquipmentCounter.Add( counter_flowmeter.ToString()+ "x - Flowmeter: (" + string.Join(", ", FlowmeterAssets) + ")");
            if (counter_pulseOximeter != 0)
                _EquipmentCounter.Add( counter_pulseOximeter.ToString()+ "x - Pulse Oximeter: (" + string.Join(", ", PulseOximeterAssets) + ")");
            if (counter_recoilBag != 0)
                _EquipmentCounter.Add( counter_recoilBag.ToString()+ "x - Recoil Bag Resuscitator: (" + string.Join(", ", RecoilBagResuscitatorAssets) + ")");
            if (counter_regulator != 0)
                _EquipmentCounter.Add( counter_regulator.ToString()+ "x - Regulator: (" + string.Join(", ", RegulatorAssets) + ")");
            if (counter_residualCurrentDevice != 0)
                _EquipmentCounter.Add( counter_residualCurrentDevice.ToString()+ "x - Residual Current Device: " + string.Join(", ", RCDAssets) + ")");
            if (counter_shygmoHHeld != 0)
                _EquipmentCounter.Add(counter_shygmoHHeld.ToString()+ "x - Sphygmo Handheld: (" + string.Join(", ", Spygmo1Assets) + ")");
            if (counter_sphygmoWall != 0)
                _EquipmentCounter.Add( counter_sphygmoWall.ToString()+ "x - Sphygmo Wall: (" + string.Join(", ", Spygmo2Assets) + ")");
            if (counter_twinOVac != 0)
                _EquipmentCounter.Add(counter_twinOVac.ToString()+ "x - Twin-O-Vac Suction Device: (" + string.Join(", ", TwinOVacAssets) + ")");
            if (counter_automaticExternalDefib != 0)
                _EquipmentCounter.Add(counter_automaticExternalDefib.ToString()+ "x - Automatic External Defibrillator: (" + string.Join(", ", AutomaticEDAssets) + ")");
            if (counter_multiflowregulator != 0)
                _EquipmentCounter.Add(counter_multiflowregulator.ToString() + "x - Multi-Flow Regulator: (" + string.Join(", ", MultiFlowRegulatorAssets) + ")");

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

        //Exit MSWORD
        private void ExitWord()
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("WINWORD"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearPanelValues()
        {
            labelAnsurVersion.Text = "";
            labelM1.Text = "";
            labelM2.Text = "";
            labelM3.Text = "";
            labelIR.Text = "";
            labelPE.Text = "";
            labelEnL1.Text = "";
            labelEnL2.Text = "";
            labelEnL3.Text = "";
            labelEnL4.Text = "";
            labelEnL5.Text = "";
            labelEnL6.Text = "";
            labelEL1.Text = "";
            labelEL2.Text = "";
            PLClabel1.Text = "";
            PLClabel2.Text = "";
            PLClabel3.Text = "";
            MCClabel1.Text = "";
            buttonEnL1.Visible = false;
            buttonEnL2.Visible = false;
            buttonEnL3.Visible = false;
            buttonEnL4.Visible = false;
            buttonEnL5.Visible = false;
            buttonEnL6.Visible = false;
            buttonPE.Visible = false;
            buttonIR.Visible = false;
            buttonEL1.Visible = false;
            buttonEL2.Visible = false;
            buttonPLC1.Visible = false;
            buttonPLC2.Visible = false;
            buttonPLC3.Visible = false;
            buttonMCC.Visible = false;
        }
    }
}
