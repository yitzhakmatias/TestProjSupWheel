using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportWheel.App.Helper
{
    /// <summary>
    /// Get day's name based on the number 
    /// </summary>
    public static class DayHelper
    {
        /// <summary>
        /// The day by number
        /// </summary>
        private static string _dayByNumber;
        /// <summary>
        /// The week
        /// </summary>
        private static string _week;

        /// <summary>
        /// Gets or sets the day by number.
        /// </summary>
        /// <value>
        /// The day by number.
        /// </value>
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

        /// <summary>
        /// Gets or sets the week.
        /// </summary>
        /// <value>
        /// The week.
        /// </value>
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