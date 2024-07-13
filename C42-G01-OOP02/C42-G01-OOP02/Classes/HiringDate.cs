using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP02.Classes
{
    internal class HiringDate
    {
        #region Properties
        private int day;

        public int Day
        {
            get { return day; }
            set 
            {
                if (value > 0 && value <= 31) 
                    day = value; 
                else 
                    throw new Exception("Day value is not valid");

            }
        }

        private int month;

        public int Month
        {
            get { return month; }
            set
            {
                if (value > 0 && value <= 12)
                    month = value;
                else
                    throw new Exception("Month value is not valid");

            }
        }

        private int year;
        public int Year
        {
            get { return year; }
            set
            {
                if (value > 1980 && value <= DateTime.Now.Year)
                    year = value;
                else
                    throw new Exception("Year value is not valid");

            }
        }

        private DateTime fullDate;
        public DateTime FullDate
        {
            get { return new DateTime(Year, Month, Day); }
        }
        #endregion

        #region Constructor
        public HiringDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        #endregion
    }
}
