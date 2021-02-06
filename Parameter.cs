using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBDesk
{
    public class Parameter
    {
        public Parameter()
        {
            this.Name = "";
            this.Value = "";
        }

        public Parameter(in String name, in String value)
        {
            this.Name = name;
            this.Value = value;
        }

        public String Name { get; set; }
        public String Value { get; set; }
    }
}
