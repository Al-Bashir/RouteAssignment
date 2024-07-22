using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05.Duration
{
    internal class Duration
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Duration(int seconds)
        {
            int[] CovertedFromSeconds = ConvertSecond(seconds);
            Hours = CovertedFromSeconds[0];
            Minutes = CovertedFromSeconds[1];
            Seconds = CovertedFromSeconds[2];
        }

        //public Duration(int seconds)
        //{
        //    if (seconds < 60)
        //    {
        //        Seconds = seconds;
        //        Minutes = 0;
        //        Hours = 0;
        //    }
        //    else if (seconds >= 60 && seconds < 3600)
        //    {
        //        if (seconds == 60)
        //        {
        //            Seconds = 0;
        //            Minutes = 1;
        //            Hours = 0;
        //        }
        //        else if (seconds % 60 == 0)
        //        {
        //            Seconds = 0;
        //            Minutes = seconds / 60;
        //            Hours = 0;
        //        }
        //        else
        //        {
        //            Seconds = seconds % 60;
        //            Minutes = seconds / 60;
        //            Hours = 0;
        //        }
        //    }
        //    else
        //    {
        //        if ((seconds % 3600) == 0)
        //        {
        //            Seconds = 0;
        //            Minutes = 0;
        //            Hours = Seconds / 3600;
        //        }
        //    }
        //}

        private static int[] ConvertSecond(int seconds)
        {
            int ConvertedHours;
            int ConvertedMinutes;
            int ConvertedSeconds;
            if (seconds % 3600 == 0)
            {
                ConvertedHours = seconds / 3600;
                ConvertedMinutes = 0;
                ConvertedSeconds = 0;
            }
            else if (seconds % 60 == 0)
            {
                ConvertedHours = seconds / 3600;
                ConvertedMinutes = seconds / 60 - ((seconds / 3600) * 60);
                ConvertedSeconds = 0;
            }
            else
            {
                ConvertedHours = seconds / 3600;
                ConvertedMinutes = seconds / 60 - ((seconds / 3600) * 60);
                ConvertedSeconds = seconds % 60;
            }
            return new int[] { ConvertedHours, ConvertedMinutes, ConvertedSeconds };  
        }

        public override string ToString()
        {
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        }

        public override int GetHashCode()
        {
            return -1 ;
        }

        public override bool Equals(object? obj)
        {
            return false;
        }

        public static Duration operator + (Duration a, Duration b)
        { 
            int DurationASeconds = a.Seconds + a.Minutes * 60 + a.Hours * 60 * 60;
            int DurationBSeconds = b.Seconds + b.Minutes * 60 + b.Hours * 60 * 60;
            int[] CovertedFromSeconds = ConvertSecond(DurationASeconds + DurationBSeconds);
            return new Duration(CovertedFromSeconds[0], CovertedFromSeconds[1], CovertedFromSeconds[2]);
        }        
        public static Duration operator + (Duration a, int b)
        { 
            int DurationASeconds = a.Seconds + a.Minutes * 60 + a.Hours * 60 * 60;
            int DurationBSeconds = b;
            int[] CovertedFromSeconds = ConvertSecond(DurationASeconds + DurationBSeconds);
            return new Duration(CovertedFromSeconds[0], CovertedFromSeconds[1], CovertedFromSeconds[2]);
        }        
        public static Duration operator + (int a, Duration b)
        { 
            int DurationASeconds = a;
            int DurationBSeconds = b.Seconds + b.Minutes * 60 + b.Hours * 60 * 60;
            int[] CovertedFromSeconds = ConvertSecond(DurationASeconds + DurationBSeconds);
            return new Duration(CovertedFromSeconds[0], CovertedFromSeconds[1], CovertedFromSeconds[2]);
        }  
        
        public static Duration operator ++ (Duration a)
        {
            int DurationASeconds = a.Seconds + a.Minutes * 60 + a.Hours * 60 * 60;
            DurationASeconds += 60;
            int[] CovertedFromSeconds = ConvertSecond(DurationASeconds);
            return new Duration(CovertedFromSeconds[0], CovertedFromSeconds[1], CovertedFromSeconds[2]);
        }        
        public static Duration operator -- (Duration a)
        {
            int DurationASeconds = a.Seconds + a.Minutes * 60 + a.Hours * 60 * 60;
            DurationASeconds = DurationASeconds > 60 ? (DurationASeconds - 60) : 0;
            int[] CovertedFromSeconds = ConvertSecond(DurationASeconds);
            return new Duration(CovertedFromSeconds[0], CovertedFromSeconds[1], CovertedFromSeconds[2]);
        }        

        public static bool operator > (Duration a, Duration b)
        {
            int DurationASeconds = a.Seconds + a.Minutes * 60 + a.Hours * 60 * 60;
            int DurationBSeconds = b.Seconds + b.Minutes * 60 + b.Hours * 60 * 60;
            return DurationASeconds > DurationBSeconds;
        }
        public static bool operator < (Duration a, Duration b)
        {
            int DurationASeconds = a.Seconds + a.Minutes * 60 + a.Hours * 60 * 60;
            int DurationBSeconds = b.Seconds + b.Minutes * 60 + b.Hours * 60 * 60;
            return DurationASeconds < DurationBSeconds;
        }

        public static bool operator >= (Duration a, Duration b)
        {
            int DurationASeconds = a.Seconds + a.Minutes * 60 + a.Hours * 60 * 60;
            int DurationBSeconds = b.Seconds + b.Minutes * 60 + b.Hours * 60 * 60;
            return DurationASeconds >= DurationBSeconds;
        }
        public static bool operator <= (Duration a, Duration b)
        {
            int DurationASeconds = a.Seconds + a.Minutes * 60 + a.Hours * 60 * 60;
            int DurationBSeconds = b.Seconds + b.Minutes * 60 + b.Hours * 60 * 60;
            return DurationASeconds <= DurationBSeconds;
        }

        public static implicit operator bool(Duration a)
        { 
            return a is not null;
        }        
        public static implicit operator DateTime(Duration a)
        { 
            return new DateTime(1, 1, 1, a.Hours, a.Minutes, a.Seconds);
        }
    }
}
