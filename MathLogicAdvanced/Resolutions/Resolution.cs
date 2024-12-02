using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLogicAdvanced.Resolutions
{
    public class Resolution
    {
        public bool Resolve(List<Clause> clauses, Clause query)
        {
            HashSet<Clause> newClauses = new HashSet<Clause>(clauses);
            Queue<Clause> clausesToTest = new Queue<Clause>(clauses);

            while (clausesToTest.Count > 0)
            {
                var current = clausesToTest.Dequeue();

                if (current.IsContradictory(query))
                {
                    return true;
                }

                foreach (var other in newClauses)
                {
                    var resolvents = ResolveClauses(current, other);

                    foreach (var resolvent in resolvents)
                    {
                        if (!newClauses.Contains(resolvent))
                        {
                            newClauses.Add(resolvent);
                            clausesToTest.Enqueue(resolvent); 
                        }
                    }
                }
            }

            return false;
        }

        public IEnumerable<Clause> ResolveClauses(Clause c1, Clause c2)
        {
            List<Clause> resolvents = new List<Clause>();

            foreach (var literal in c1.Literals)
            {
                if (c2.Literals.Contains(Negate(literal)))
                {
                    var newLiterals = c1.Literals.Except(new[] { literal })
                        .Union(c2.Literals.Except(new[] { Negate(literal) }))
                        .ToList();
                    resolvents.Add(new Clause(newLiterals));
                }
            }

            return resolvents;
        }

        public string Negate(string literal)
        {
            return literal.StartsWith("¬") ? literal.Substring(1) : "¬" + literal;
        }
    }
}
}
