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
            if(Literals.Count != 2) return false;
            int firstIndex = Literals.FindIndex(x => x == query.Literals[0]);
            if (firstIndex != -1)
                if (Literals[firstIndex == 0 ? 1 : 0] == Resolution.Negate(query.Literals[1]))
                    return true; 
            
            return false;
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
