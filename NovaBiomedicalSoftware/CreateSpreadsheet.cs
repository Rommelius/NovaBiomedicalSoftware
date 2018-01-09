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
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;

namespace NovaBiomedicalSoftware
{
    public partial class CreateSpreadsheet : MetroForm
    {
        public static string folderLocationPDFFilesNames;
        public static string saveDestination;
        public static string PDFFolderLocation;


        public bool YesNoSaveDestination;
        public bool YesNoReportFolder;
        public string[] fullFileName;


        public static List<string> pdfFileNames = new List<string>();

        public static List<string> AssetNumber = new List<string>();
        public static List<string> SerialNumber = new List<string>();
        public static List<string> Model = new List<string>();
        public static List<string> Manufacturer = new List<string>();
        public static List<string> LocationList = new List<string>();



        public int numberOfrows;

        public CreateSpreadsheet()
        {
            InitializeComponent();
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.CustomFormat = "MM/yyyy";
        }

        private void changeFolderDestination_btn_Click(object sender, EventArgs e)
        {
            DialogResult drbox = MetroFramework.MetroMessageBox.Show(this, "", "Please select the folder to save your files", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (drbox == DialogResult.OK)
            {

                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;

                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    YesNoSaveDestination = true;
                    saveDestination = folderDlg.SelectedPath;
                    folderDestination.Text = saveDestination;
                }
            }
        }

        private void changeEquipmentFolder_btn_Click(object sender, EventArgs e)
        {
            DialogResult drbox = MetroFramework.MetroMessageBox.Show(this, "", "Please select the folder where the service reports are", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (drbox == DialogResult.OK)
            {

                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;

                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    YesNoReportFolder = true;
                    folderLocationPDFFilesNames = folderDlg.SelectedPath;
                    equipmentFolder.Text = folderLocationPDFFilesNames;
                }
            }
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {

            if (YesNoReportFolder != true && YesNoSaveDestination !=true)
            {
                MetroFramework.MetroMessageBox.Show(this, "", "Please select all the necessary folders needed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (clientName.Text != "" || YesNoSaveDestination != true || YesNoReportFolder != true)
                {
                    GetCSVFileName();
                    SplitCSVtoArray();
                    AddtoWordDocument();
                }
            }
           

        }

        public void SplitCSVtoArray()
        {
            foreach (string item in pdfFileNames)
            {
                fullFileName = item.Split(',');
                Console.WriteLine(fullFileName[0] + fullFileName[1] + fullFileName[2] + fullFileName[3] + fullFileName[4]);
                AssetNumber.Add(fullFileName[0]);
                SerialNumber.Add(fullFileName[1]);
                Model.Add(fullFileName[2]);
                Manufacturer.Add(fullFileName[3]);
                LocationList.Add(fullFileName[4]);
            }

            numberOfrows = AssetNumber.Count;
        }

        public void AddtoWordDocument()
        {
            if (File.Exists(MainMenu.appRootDir + "/Report Templates/Excel Templates/temp.docx"))
            {
                File.Delete(MainMenu.appRootDir + "/Report Templates/Excel Templates/temp.docx");
            }

            File.Copy(MainMenu.appRootDir + "/Report Templates/Excel Templates/Listofequipment.docx", MainMenu.appRootDir + "/Report Templates/Excel Templates/temp.docx");

            //Setup the Word.Application class.
            Word.Application wordApp =
                new Word.Application();

            //set objects
            object missing = System.Reflection.Missing.Value;
            object what = Word.WdGoToItem.wdGoToLine;
            object which = Word.WdGoToDirection.wdGoToLast;
            object saveAs = MainMenu.appRootDir + "/Report Templates/Excel Templates/temp.docx";
            //Set Word to be not visible.
            wordApp.Visible = false;
            
            //open temp1 docx - electrical safety
            Word.Document wDoc = wordApp.Documents.Open(MainMenu.appRootDir + "/Report Templates/Excel Templates/temp.docx");


            this.FindAndReplace(wordApp, "<CLIENTNAME>", clientName.Text);
            this.FindAndReplace(wordApp, "<MONTHYEAR>", datePicker.Value.ToString("MMMM yyyy"));

            wDoc.Bookmarks["equipment"].Select();
            object moveUnit = Word.WdUnits.wdCell;
            object moveExend = Word.WdMovementType.wdMove;

            for (int i = 0; i < numberOfrows; i++)
            {
                wordApp.Selection.TypeText(AssetNumber[i]);
                wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                wordApp.Selection.TypeText(SerialNumber[i]);
                wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                wordApp.Selection.TypeText(Model[i]);
                wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                wordApp.Selection.TypeText(Manufacturer[i]);
                wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                wordApp.Selection.TypeText(LocationList[i]);
                if (i!=numberOfrows-1)
                {
                    wordApp.Selection.MoveRight(moveUnit, 1, moveExend);
                }
            }

            wDoc.ExportAsFixedFormat(saveDestination + "/" + clientName.Text+ " - " + datePicker.Value.ToString("MMMM yyyy") + ".pdf", Word.WdExportFormat.wdExportFormatPDF);

            MetroFramework.MetroMessageBox.Show(this, "", "Report Created at "+ saveDestination, MessageBoxButtons.OK, MessageBoxIcon.Information);


            //Close the document - you have to do this.
            GC.Collect();
            wDoc.Close(Word.WdSaveOptions.wdSaveChanges);
            wordApp.Quit();
            ExitWord();
            YesNoSaveDestination = false;
            YesNoReportFolder = false;
            pdfFileNames.Clear();
            AssetNumber.Clear();
            SerialNumber.Clear();
            Model.Clear();
            Manufacturer.Clear();
            LocationList.Clear();
        }
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
        public void GetCSVFileName()
        {
            DirectoryInfo d = new DirectoryInfo(folderLocationPDFFilesNames);
            FileInfo[] Files = d.GetFiles("*.pdf");
            string str = "";
     
            foreach (FileInfo file in Files)
            {
                if (file.Name.Contains("Electrical Safety Test and Performance Test.pdf") ||
                    file.Name.Contains("Electrical Safety Test Report.pdf") ||
                    file.Name.Contains("Performance Test Report.pdf"))
                {
                    str = file.Name;
                    str = str.Replace('~', ',');
                    str = str.Replace("Electrical Safety Test and Performance Test.pdf", "");
                    str = str.Replace("Electrical Safety Test Report.pdf", "");
                    str = str.Replace("Performance Test Report.pdf", "");
                    str = str.Remove(str.Length - 1);
                    pdfFileNames.Add(str);
                }
            }

        }

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

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
