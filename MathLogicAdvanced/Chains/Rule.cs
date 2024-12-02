using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLogicAdvanced.Chains
{
    public class Rule
    {
        public string Name { get; }
        public Func<Fact[], bool> Condition { get; }
        public Action<Fact[]> Action { get; }

        public Rule(string name, Func<Fact[], bool> condition, Action<Fact[]> action)
        {
            Name = name;
            Condition = condition;
            Action = action;
        }
    }
}
