using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldskillsChina2016.md
{
    partial class Championship
    {
        public string Duration
        {
                get
            {
                return DateFinish + " - " + DateStart;
            }
        }

        public string YearEvent
        {
            get
            {
                return DateStart.Value.Year + " - " + Name;
            }
        }
    }
}
