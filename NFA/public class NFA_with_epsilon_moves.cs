using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFA
{
    public class NFA_with_epsilon_moves : NFA
    {
        public override Tập_Hợp<State> deltaStar(string w)
        {
            return base.deltaStar(w);
        }

        public Func<bool> isEpsilon;
        public Tập_Hợp<State> EpsilonClosure(State b)
        {
            var vertices = new Tập_Hợp<State> { b };
            while (true)
            {
                var previousCount = vertices.Count;

                if (vertices.Count == previousCount)
                    break;
            }
            return vertices;
        }
    }
}
