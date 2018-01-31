using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldskillsChina2016.md
{
    partial class User
    {
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string GenderString
        {
            get
            {
                return IsMale == true ? "Male" : "Female";
            }
        }

        public string SkillsofService
        {
            get
            {
                return Participation.Select(w => w.Competition.NameEnglish).FirstOrDefault();
            }
        }
    }
}
