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
            if (inputLetter.Text == "N")
            {
                year = 2013;
            }
            if (inputLetter.Text == "K")
            {
                year = 2010;
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
