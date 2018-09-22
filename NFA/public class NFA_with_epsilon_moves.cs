using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFA
{
    public class NFA_with_epsilon_moves : NFA
    {
        public override TapHop<State> deltaStar(string w)
        {
            return base.deltaStar(w);
        }

        public Func<bool> isEpsilon;
        public TapHop<State> EpsilonClosure(State b)
        {
            var vertices = new TapHop<State> { b };
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
