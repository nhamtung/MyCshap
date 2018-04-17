using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual
{
    class DerivedClass : BaseClass
    {
        private string name;
        public override string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value != String.Empty)
                    name = value;
                else
                    name = "Unknown";
            }
        }
    }
}
