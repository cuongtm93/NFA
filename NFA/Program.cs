using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFA
{
    public enum State
    {
        q0,
        q1,
        q2,
        q3,
        q4
    };

    class Program
    {
        static void Main(string[] args)
        {
            BinaryMachine();
        }

        static void BinaryMachine()
        {
            var binaryMachine = new NFA()
            {
                q0 = State.q0,
                F = new Tập_Hợp<State>() { State.q2, State.q4 },
            };

            binaryMachine.delta = (q, c) =>
            {
                var Q = new Tập_Hợp<State>();
                switch (q)
                {
                    case State.q0:
                        if (c == '0')
                            return new Tập_Hợp<State> { State.q0, State.q3 };
                        else
                            return new Tập_Hợp<State>() { State.q0, State.q1 };
                    case State.q1:
                        if (c == '0')
                            return new Tập_Hợp<State> { };
                        else
                            return new Tập_Hợp<State> { State.q2 };
                    case State.q2:
                        if (c == '0')
                            return new Tập_Hợp<State> { State.q2 };
                        else
                            return new Tập_Hợp<State> { State.q2 };
                    case State.q3:
                        if (c == '0')
                            return new Tập_Hợp<State> { State.q4 };
                        else
                            return new Tập_Hợp<State> { };
                    case State.q4:
                        if (c == '0')
                            return new Tập_Hợp<State> { State.q4 };
                        else
                            return new Tập_Hợp<State> { State.q4 };
                    default:
                        break;
                }
                return Q;
            };

            var s1 = "01";
            var s2 = "01001";
            Console.WriteLine("Accept : " + s1 + " --> " + binaryMachine.Accept(s1));
            Console.WriteLine("--------------");
            Console.WriteLine("Accept : " + s2 + " --> " + binaryMachine.Accept(s2));
            Console.ReadKey();
        }

        static void NFA_with_empty_moves()
        {
            var NFA_with_empty = new NFA_with_epsilon_moves();
            NFA_with_empty.EpsilonClosure(State.q0);
        }

    }
}
