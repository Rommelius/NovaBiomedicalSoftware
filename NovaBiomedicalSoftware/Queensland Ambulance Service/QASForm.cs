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
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace NovaBiomedicalSoftware.Queensland_Ambulance_Service
{
    public partial class QASForm : MetroForm
    {
        DateTime date = DateTime.Today;

        public bool QASTestisDone;

        public bool PTOutletPointCompleted, PTOxygenReticulationCompleted, PTRegulatorCompleted,
            PTFlowmeterCompleted, PTElectricSuctionCompleted, PTRecoilBagCompleted, PTSphygmoHHeldCompleted,
            PTSphygmoWallCompleted, PTPulseOximeterCompleted, PTAspiratorCompleted, PTDemanHeadCompleted,
            PTTwinOVacCompleted, PTResidualCurrentDeviceCompleted;

        public QASForm()
        {
            InitializeComponent();

            if (File.Exists(Main.appRootDir + "/Report Templates/QAS Templates/temp.docx"))
            {
                File.Delete(Main.appRootDir + "/Report Templates/QAS Templates/temp.docx");
            }

            File.Copy(Main.appRootDir + "/Report Templates/QAS Template-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp.docx");

        }
        private void saveReportPDF()
        {
            //Setup the Word.Application class.
            Word.Application wordApp =
                new Word.Application();

            //set objects
            object missing = System.Reflection.Missing.Value;
            //Set Word to be not visible.
            wordApp.Visible = false;

            //open temp1 docx - electrical safety
            Word.Document wDoc1 = wordApp.Documents.Open(Main.appRootDir + "/Report Templates/QAS Templates/temp.docx");

            wDoc1.Activate();

            //find and replace first before copying everything
            this.FindAndReplace(wordApp, "<Date>", date.ToShortDateString());
            this.FindAndReplace(wordApp, "<Location/Room>", locationTextbox.Text);
            this.FindAndReplace(wordApp, "<Station>", stationTextbox.Text);
            this.FindAndReplace(wordApp, "<VehicleNumber>", vehicleTextBox.Text);
            this.FindAndReplace(wordApp, "<RegoNumber>", registrationTextBox.Text);
            this.FindAndReplace(wordApp, "<Name>", Main.currentUser);

            // for changing signatures
            int count = wDoc1.Bookmarks.Count;
            for (int i = 1; i < count + 1; i++)
            {
                object oRange = wDoc1.Bookmarks[i].Range;
                object saveWithDocument = true;
                string pictureName = Main.appRootDir + "/Signatures/" + Main.currentUser+ ".png";
                wDoc1.InlineShapes.AddPicture(pictureName, ref missing, ref saveWithDocument, ref oRange);
            }
            
            wDoc1.ExportAsFixedFormat(Main.saveDestination + "/" + stationTextbox.Text + "-" + vehicleTextBox.Text + "-" + registrationTextBox.Text + "- QAS Report.pdf", Word.WdExportFormat.wdExportFormatPDF);
            
            GC.Collect();
            wDoc1.Close();
            wordApp.Quit();

            MetroFramework.MetroMessageBox.Show(this, "", "Report is Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Exit();

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
                        QASTestisDone = true;
                        PTOutletPointCompleted = true;
                        editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTOxygenReticulationCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTRegulatorCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTFlowmeterCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTResidualCurrentDeviceCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTTwinOVacCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTDemanHeadCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTAspiratorCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTPulseOximeterCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTSphygmoWallCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTSphygmoHHeldCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTRecoilBagCompleted = true;
                    editDocument();
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
                    //yesNoPerformanceTest = true;
                    QASTestisDone = true;
                    PTElectricSuctionCompleted = true;
                    editDocument();
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


        //create Outlet Point document
        private void editDocument()
        {
            if (File.Exists(Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx"))
            {
                File.Delete(Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            }

            if (PTOutletPointCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Outlet Point-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTOxygenReticulationCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Oxygen Reticulation Failure Alarm-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTRegulatorCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Regulator-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if(PTFlowmeterCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Flowmeter-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTElectricSuctionCompleted==true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Electric Suction-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTRecoilBagCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Recoil Bag Resuscitator-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTSphygmoHHeldCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Sphygmo Handheld-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTSphygmoWallCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Sphygmo Wall-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTPulseOximeterCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Pulse Oximeter-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTAspiratorCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Aspirator-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTDemanHeadCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Demand Head-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTTwinOVacCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Twin-O-Vac Suction Device-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            if (PTResidualCurrentDeviceCompleted == true)
                File.Copy(Main.appRootDir + "/Report Templates/QAS Templates/Residual Current Device-TEMPLATE.docx", Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");


            //Setup the Word.Application class.
            Word.Application wordApp =
                new Word.Application();

            //set objects
            object missing = System.Reflection.Missing.Value;
            object what = Word.WdGoToItem.wdGoToLine;
            object which = Word.WdGoToDirection.wdGoToLast;
            object saveAs = Main.appRootDir + "/Report Templates/QAS Templates/temp.docx";
            //Set Word to be not visible.
            wordApp.Visible = false;

            //open temp1 docx - electrical safety
            Word.Document wDoc1 = wordApp.Documents.Open(Main.appRootDir + "/Report Templates/QAS Templates/temp.docx");
            //open temp2 docx - performance test
            Word.Document wDoc2 = wordApp.Documents.Open(Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");

            wDoc2.Activate();

            //find and replace first before copying everything
            
            //Outlet Point
            if (PTOutletPointCompleted == true)
            {
                this.FindAndReplace(wordApp, "<AssetNumber>", Outlet_Point.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", Outlet_Point.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", Outlet_Point.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", Outlet_Point.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", Outlet_Point.result1);
                this.FindAndReplace(wordApp, "<result2>", Outlet_Point.result2);
                this.FindAndReplace(wordApp, "<result3>", Outlet_Point.result3);
                this.FindAndReplace(wordApp, "<result4>", Outlet_Point.result4);
                this.FindAndReplace(wordApp, "<Comments>", Outlet_Point.comments);
            }
            if (PTOxygenReticulationCompleted == true)
            {
                this.FindAndReplace(wordApp, "<AssetNumber>", OxygenReticulationAlarm.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", OxygenReticulationAlarm.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", OxygenReticulationAlarm.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", OxygenReticulationAlarm.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", OxygenReticulationAlarm.result1);
                this.FindAndReplace(wordApp, "<result2>", OxygenReticulationAlarm.result2);
                this.FindAndReplace(wordApp, "<result3>", OxygenReticulationAlarm.result3);
                this.FindAndReplace(wordApp, "<result4>", OxygenReticulationAlarm.result4);
                this.FindAndReplace(wordApp, "<Comments>", OxygenReticulationAlarm.comments);
            }
            if (PTRegulatorCompleted == true)
            {
                this.FindAndReplace(wordApp, "<AssetNumber>", Regulator.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", Regulator.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", Regulator.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", Regulator.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", Regulator.result1);
                this.FindAndReplace(wordApp, "<result2>", Regulator.result2);
                this.FindAndReplace(wordApp, "<result3>", Regulator.result3);
                this.FindAndReplace(wordApp, "<result4>", Regulator.result4);
                this.FindAndReplace(wordApp, "<Comments>", Regulator.comments);
            }
            if (PTFlowmeterCompleted == true)
            {
                this.FindAndReplace(wordApp, "<AssetNumber>", Flowmeter.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", Flowmeter.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", Flowmeter.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", Flowmeter.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", Flowmeter.result1);
                this.FindAndReplace(wordApp, "<result2>", Flowmeter.result2);
                this.FindAndReplace(wordApp, "<result3>", Flowmeter.result3);
                this.FindAndReplace(wordApp, "<Comments>", Flowmeter.comments);
            }
            if (PTElectricSuctionCompleted == true)
            {
                this.FindAndReplace(wordApp, "<AssetNumber>", ElectricSuction.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", ElectricSuction.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", ElectricSuction.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", ElectricSuction.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", ElectricSuction.result1);
                this.FindAndReplace(wordApp, "<result2>", ElectricSuction.result2);
                this.FindAndReplace(wordApp, "<result3>", ElectricSuction.result3);
                this.FindAndReplace(wordApp, "<Comments>", ElectricSuction.comments);
            }
            if (PTRecoilBagCompleted == true)
            {
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
            }
            if (PTSphygmoHHeldCompleted == true)
            {
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
            }
            if (PTSphygmoWallCompleted == true)
            {
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
            }
            if (PTPulseOximeterCompleted == true)
            {
                this.FindAndReplace(wordApp, "<AssetNumber>", PulseOximeter.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", PulseOximeter.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", PulseOximeter.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", PulseOximeter.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", PulseOximeter.result1);
                this.FindAndReplace(wordApp, "<result2>", PulseOximeter.result2);
                this.FindAndReplace(wordApp, "<result3>", PulseOximeter.result3);
                this.FindAndReplace(wordApp, "<Comments>", PulseOximeter.comments);
            }
            if (PTAspiratorCompleted == true)
            {
                this.FindAndReplace(wordApp, "<AssetNumber>", Aspirator.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", Aspirator.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", Aspirator.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", Aspirator.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", Aspirator.result1);
                this.FindAndReplace(wordApp, "<result2>", Aspirator.result2);
                this.FindAndReplace(wordApp, "<result3>", Aspirator.result3);
                this.FindAndReplace(wordApp, "<Comments>", Aspirator.comments);
            }
            if (PTDemanHeadCompleted == true)
            {
                this.FindAndReplace(wordApp, "<AssetNumber>", DemandHead.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", DemandHead.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", DemandHead.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", DemandHead.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", DemandHead.result1);
                this.FindAndReplace(wordApp, "<result2>", DemandHead.result2);
                this.FindAndReplace(wordApp, "<result3>", DemandHead.result3);
                this.FindAndReplace(wordApp, "<Comments>", DemandHead.comments);
            }
            if (PTTwinOVacCompleted == true)
            {
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
            }
            if (PTResidualCurrentDeviceCompleted == true)
            {
                this.FindAndReplace(wordApp, "<AssetNumber>", ResidualCurrentDevice.assetNumberText);
                this.FindAndReplace(wordApp, "<SerialNumber>", ResidualCurrentDevice.serialNumberText);
                this.FindAndReplace(wordApp, "<Make>", ResidualCurrentDevice.makeBoxText);
                this.FindAndReplace(wordApp, "<Model>", ResidualCurrentDevice.modelBoxText);
                this.FindAndReplace(wordApp, "<result1>", ResidualCurrentDevice.result1);
                this.FindAndReplace(wordApp, "<result2>", ResidualCurrentDevice.result2);
                this.FindAndReplace(wordApp, "<result3>", ResidualCurrentDevice.result3);
                this.FindAndReplace(wordApp, "<result4>", ResidualCurrentDevice.result4);
                this.FindAndReplace(wordApp, "<Comments>", ResidualCurrentDevice.comments);
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
            if (File.Exists(Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx"))
            {
                File.Delete(Main.appRootDir + "/Report Templates/QAS Templates/temp2.docx");
            }



            PTOutletPointCompleted= false;
            PTOxygenReticulationCompleted = false;
            PTRegulatorCompleted = false;
            PTFlowmeterCompleted= false;
            PTElectricSuctionCompleted = false;
            PTRecoilBagCompleted = false;
            PTSphygmoHHeldCompleted = false;
            PTSphygmoWallCompleted= false;
            PTPulseOximeterCompleted = false;
            PTAspiratorCompleted = false;
            PTDemanHeadCompleted = false;
            PTTwinOVacCompleted= false;
            PTResidualCurrentDeviceCompleted = false;


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

        private void submit_btn_Click(object sender, EventArgs e)
        {
            saveReportPDF();
        }

    }
}
