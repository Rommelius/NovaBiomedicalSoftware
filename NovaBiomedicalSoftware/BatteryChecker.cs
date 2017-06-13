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
using System.Globalization;

namespace NovaBiomedicalSoftware
{
    public partial class BatteryChecker : MetroForm
    {

        
        
        public int digits, year;
        public char letterchar;


        public BatteryChecker()
        {
            InitializeComponent();

        }

        private void checkBattery_btn_Click(object sender, EventArgs e)
        {
            //continue working on the letters
            if (inputLetter.Text == "I")
            {
                year = 2009;
            }
            if (inputLetter.Text == "H")
            {
                year = 2008;
            }
            if (inputLetter.Text == "G")
            {
                year = 2007;
            }
            if (inputLetter.Text == "F")
            {
                year = 2006;
            }
            if (inputLetter.Text == "E")
            {
                year = 2005;
            }
            if (inputLetter.Text == "D")
            {
                year = 2004;
            }
            if (inputLetter.Text == "C")
            {
                year = 2003;
            }
            if (inputLetter.Text == "B")
            {
                year = 2002;
            }
            if (inputLetter.Text == "A")
            {
                year = 2001;
            }
            if (inputLetter.Text == "L")
            {
                year = 2011;
            }
            if (inputLetter.Text == "M")
            {
                year = 2012;
            }
            if (inputLetter.Text == "N")
            {
                year = 2013;
            }
            if (inputLetter.Text == "K")
            {
                year = 2010;
            }
            if (inputLetter.Text == "O")
            {
                year = 2014;
            }
            if (inputLetter.Text == "P")
            {
                year = 2015;
            }
            if (inputLetter.Text == "Q")
            {
                year = 2016;
            }
            if (inputLetter.Text == "R")
            {
                year = 2017;
            }
            if (inputLetter.Text == "S")
            {
                year = 2018;
            }
            if (inputLetter.Text == "T")
            {
                year = 2019;
            }
            if (inputLetter.Text == "U")
            {
                year = 2020;
            }
            if (inputLetter.Text == "V")
            {
                year = 2021;
            }
            if (inputLetter.Text == "W")
            {
                year = 2022;
            }
            if (inputLetter.Text == "X")
            {
                year = 2023;
            }
            if (inputLetter.Text == "Y")
            {
                year = 2024;
            }
            if (inputLetter.Text == "Z")
            {
                year = 2025;
            }
            Int32.TryParse(inputDigits.Text, out digits);

            resultsAge.Text = FirstDateOfWeekISO8601(year, digits).ToLongDateString();




        }

        public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }
    }
}
