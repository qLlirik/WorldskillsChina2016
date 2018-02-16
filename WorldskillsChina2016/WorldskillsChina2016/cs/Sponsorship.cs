using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldskillsChina2016.md
{
    partial class Sponsorship
    {
        public dynamic IMG
        {
            get
            {
                if (Picture == null)
                    return "/WorldskillsChina2016;component/im/NonImage.png";
                else
                    return Picture;
            }
        }
    }
}
