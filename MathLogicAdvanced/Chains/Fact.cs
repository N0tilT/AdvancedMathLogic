using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLogicAdvanced.Chains
{
    public class Fact
    {
        public string Name { get; }
        public bool Value { get; set; }

        public Fact(string name, bool value)
        {
            Name = name;
            Value = value;
        }
    }
}
