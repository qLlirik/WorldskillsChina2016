using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldskillsChina2016.cs
{
    public static class PageInitialize
    {
        public static string GetDayPath()
        {
            DateTime Date = DateTime.Now;
            if ((Date.Hour >= 6) && (Date.Hour < 12))
                return "Morning";
            else if ((Date.Hour >= 12) && (Date.Hour < 18))
                return "Afternoon";
            else
                return "Evening";
        }

        public static bool CanAuth = true;
    }
}
