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
    public partial class AlarisSoftwareManagementForm : MetroForm
    {
        public bool fileIsSelected;
        public int counter1, counter2, counter3;

        public List<string> serialNumbers = new List<string>();
        public List<string> model = new List<string>();
        public List<string> serviceDates = new List<string>();


        public static string saveDestination;
        public bool YesNoSaveDestination;


        public AlarisSoftwareManagementForm()
        {
            InitializeComponent();
            saveDestination = MainMenu.saveDestination;
            YesNoSaveDestination = true;
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //magic happens here
            //use for each loop
            if (YesNoSaveDestination)
            {
                if (counter1 == counter2 && counter1 == counter3)
                {

                    foreach (string item in serialNumberBox.Lines)
                    {
                        serialNumbers.Add(item);
                    }
                    foreach (string item in modelBox.Lines)
                    {
                        model.Add(item);
                    }
                    foreach (string item in serviceDateBox.Lines)
                    {
                        serviceDates.Add(item);
                    }

                    if (File.Exists(MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8015.docx"))
                    {
                        File.Delete(MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8015.docx");
                    }
                    if (File.Exists(MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8100.docx"))
                    {
                        File.Delete(MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8100.docx");
                    }
                    if (File.Exists(MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8110.docx"))
                    {
                        File.Delete(MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8110.docx");
                    }

                    File.Copy(MainMenu.appRootDir + "/Report Templates/ASM Templates/ALARIS 8015 TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8015.docx");
                    File.Copy(MainMenu.appRootDir + "/Report Templates/ASM Templates/ALARIS 8100 TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8100.docx");
                    File.Copy(MainMenu.appRootDir + "/Report Templates/ASM Templates/ALARIS 8110 TEMPLATE.docx", MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8110.docx");


                    for (int i = 0; i < serialNumbers.Count; i++)
                    {
                        if (model[i] == "8015")
                        {
                            //use template for 8100
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
                            Word.Document wDoc = wordApp.Documents.Open(MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8015.docx");


                            //serial first
                            this.FindAndReplace(wordApp, "<serialnumber>", serialNumbers[i]);

                            //service date
                            this.FindAndReplace(wordApp, "<date>", serviceDates[i]);



                            //signature
                            wDoc.Bookmarks["electricsignature"].Select();
                            string pictureName = MainMenu.appRootDir + "/Signatures/" + LogInPage.currentUser + ".png";
                            wordApp.Selection.InlineShapes.AddPicture(pictureName);

                            wDoc.ExportAsFixedFormat(saveDestination + "/" + serialNumbers[i] + " - Alaris "+ model[i]+ ".pdf", Word.WdExportFormat.wdExportFormatPDF);

                            //Close the document - you have to do this.
                            GC.Collect();
                            wDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                            wordApp.Quit();
                            ExitWord();

                        }


                        if (model[i] == "8100")
                        {
                            //use template for 8015
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
                            Word.Document wDoc = wordApp.Documents.Open(MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8100.docx");

                            //serial first
                            this.FindAndReplace(wordApp, "<serialnumber>", serialNumbers[i]);

                            //service date
                            this.FindAndReplace(wordApp, "<date>", serviceDates[i]);

                            //signature
                            wDoc.Bookmarks["electricsignature"].Select();
                            string pictureName = MainMenu.appRootDir + "/Signatures/" + LogInPage.currentUser + ".png";
                            wordApp.Selection.InlineShapes.AddPicture(pictureName);

                            wDoc.ExportAsFixedFormat(saveDestination + "/" + serialNumbers[i] + " - Alaris " + model[i] + ".pdf", Word.WdExportFormat.wdExportFormatPDF);

                            //Close the document - you have to do this.
                            GC.Collect();
                            wDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                            wordApp.Quit();
                            ExitWord();




                        }


                        if (model[i] == "8110")
                        {
                            //use template for 8110
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
                            Word.Document wDoc = wordApp.Documents.Open(MainMenu.appRootDir + "/Report Templates/ASM Templates/temp8110.docx");


                            //serial first
                            this.FindAndReplace(wordApp, "<serialnumber>", serialNumbers[i]);

                            //service date
                            this.FindAndReplace(wordApp, "<date>", serviceDates[i]);

                            //signature
                            wDoc.Bookmarks["electricsignature"].Select();
                            string pictureName = MainMenu.appRootDir + "/Signatures/" + LogInPage.currentUser + ".png";
                            wordApp.Selection.InlineShapes.AddPicture(pictureName);

                            wDoc.ExportAsFixedFormat(saveDestination + "/" + serialNumbers[i] + " - Alaris " + model[i] + ".pdf", Word.WdExportFormat.wdExportFormatPDF);

                            //Close the document - you have to do this.
                            GC.Collect();
                            wDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                            wordApp.Quit();
                            ExitWord();



                        }
                    }

                    YesNoSaveDestination = false;
                    serialNumbers.Clear();
                    model.Clear();
                    serviceDates.Clear();
                }
                else
                {
                    MessageBox.Show("All three fields should be equal number of items");
                }
            }
            else
            {
                MessageBox.Show("Select the folder destination of the reports");

            }

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void serialNumberBox_TextChanged(object sender, EventArgs e)
        {
            var lines = serialNumberBox.Lines.Where(line => !String.IsNullOrWhiteSpace(line)).Count();
            serialCounter.Text = lines.ToString() +" items";
            counter1 = lines;
        }

        private void modelBox_TextChanged(object sender, EventArgs e)
        {
            var lines = modelBox.Lines.Where(line => !String.IsNullOrWhiteSpace(line)).Count();
            modelCounter.Text = lines.ToString() + " items";
            counter2 = lines;
        }

        private void serviceDateBox_TextChanged(object sender, EventArgs e)
        {
            var lines = serviceDateBox.Lines.Where(line => !String.IsNullOrWhiteSpace(line)).Count();
            serviceCounter.Text = lines.ToString() + " items";
            counter3 = lines;
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
