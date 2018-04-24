using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOtE
{
    class Equipment
    {
        private String name = "";


        public String CurrentFrame
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


    }
}
