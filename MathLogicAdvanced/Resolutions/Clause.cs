using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLogicAdvanced.Resolutions
{
    public class Clause(List<string >literals)
    {
        public List<string> Literals { get; set; } = literals;
        public bool IsContradictory(Clause query)
        {
            return Literals.Any(l=>query.Literals.Contains(l));
        }
        public override bool Equals(object? obj)
        {
            return obj is Clause clause && Literals.OrderBy(x => x).SequenceEqual(clause.Literals.OrderBy(x => x));
        }
        public override int GetHashCode()
        {
            return Literals.OrderBy(x => x).Aggregate(0, (current, literal) => current ^ literal.GetHashCode());
        }
    }
}
