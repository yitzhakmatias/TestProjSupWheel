using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportWheel.App.Helper
{
    public static class DayHelper
    {
        private static string _dayByNumber;
        private static string _week;

        public static String DayByNumber
        {
            get
            {
                switch (_dayByNumber)
                {
                    case "1": return "Monday";
                    case "2": return "Tuesday";
                    case "3": return "Wednesday";
                    case "4": return "Thursday";
                    case "5": return "Friday";
                    case "6": return "Monday";
                    case "7": return "Tuesday";
                    case "8": return "Wednesday";
                    case "9": return "Thursday";
                    case "10": return "Friday";
                    default: return "";

                }
            }
            set { _dayByNumber = value; }
        }

        public static string Week
        {
            get
            {
                switch (_week)
                {
                    case "1": return "First Week ";
                    case "2": return "Second Week ";
                   
                    default: return "";

                }
            }
            set { _week = value; }
        }
    }
}