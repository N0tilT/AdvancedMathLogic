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
            //clauses.Add(new Clause(query.Literals.Select(x => Negate(x)).ToList()));
            HashSet<Clause> newClauses = new HashSet<Clause>(clauses);
            Queue<Clause> clausesToTest = new Queue<Clause>(clauses);

            if (newClauses.Any(x=> x.IsContradictory(query))) return true;

            while (clausesToTest.Count > 0)
            {
                Console.WriteLine("DISJUNCTORS");
                Console.WriteLine(string.Join("\n", newClauses.ToList().Select(x => string.Join(" | ", x.Literals))));

                var current = clausesToTest.Dequeue();

                List<Clause> resolvents = new List<Clause>();

                foreach (var other in newClauses)
                {
                    var newResolvents = ResolveClauses(current, other);
                    resolvents.AddRange(newResolvents);
                }

                foreach (var resolvent in resolvents)
                {
                    if(newClauses.Add(resolvent))
                        clausesToTest.Enqueue(resolvent);
                }

                if (newClauses.Any(x => x.IsContradictory(query))) return true;

                Console.WriteLine("RESOLVENTS");
                Console.WriteLine(string.Join("\n", resolvents.ToList().Select(x => string.Join(" | ", x.Literals))));
            }

            Console.WriteLine("DISJUNCTORS");
            Console.WriteLine(string.Join("\n",newClauses.ToList().Select(x=>string.Join(" | ",x.Literals))));

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

        public static string Negate(string literal)
        {
            return literal.StartsWith("!") ? literal.Substring(1) : "!" + literal;
        }
    }
}
