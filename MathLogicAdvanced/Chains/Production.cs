using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLogicAdvanced.Chains
{
    public class Production
    {
        private List<Fact> _facts = new List<Fact>();
        private List<Rule> _rules = new List<Rule>();

        public void AddFact(Fact fact)
        {
            _facts.Add(fact);
        }

        public void AddRule(Rule rule)
        {
            _rules.Add(rule);
        }

        public void ForwardChain()
        {
            bool hasChanged;
            do
            {
                hasChanged = false;

                foreach (var rule in _rules)
                {
                    if (rule.Condition(_facts.ToArray()))
                    {
                        rule.Action(_facts.ToArray());
                        hasChanged = true;
                    }
                }
            } while (hasChanged);
        }

        public bool BackwardChain(string goal)
        {
            var fact = _facts.Find(f => f.Name == goal);
            if (fact != null && fact.Value)
            {
                return true;
            }

            foreach (var rule in _rules)
            {
                if (rule.Action.Method.Name == goal)
                {
                    var factsToCheck = new List<string>();
                    foreach (var f in _facts)
                    {
                        if (rule.Condition(new[] { f }))
                        {
                            factsToCheck.Add(f.Name);
                        }
                    }
                    foreach (var f in factsToCheck)
                    {
                        if (!BackwardChain(f))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }

            return false;
        }

        public void DisplayFacts()
        {
            foreach (var fact in _facts)
            {
                System.Console.WriteLine($"{fact.Name}: {fact.Value}");
            }
        }
    }
}
