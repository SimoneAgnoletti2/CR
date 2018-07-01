using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Class
{
    public class Parameter
    {
        public string key;
        public string value;

        public Parameter(string k, string v)
        {
            key = k;
            value = v;
        }

        public string Key
        {
            get { return this.key; }
            set { this.key = value; }
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
