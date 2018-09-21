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

    public class NFA1
    {

        /// <summary>
        ///  Hàm chuyển trạng thái (q,char) --> {Tập các trạng thái }
        /// </summary>
        public Func<State, char, List<State>> delta;

        /// <summary>
        ///  Trạng thái bắt đầu
        /// </summary>
        public State q0 { get; set; }

        /// <summary>
        ///  Tập trạng thái kết thúc
        /// </summary>
        public List<State> F { get; set; }

        /// <summary>
        ///  Hàm chuyển trạng thái mở rộng
        /// </summary>
        /// <param name="w"> Chuỗi nhập vào </param>
        /// <returns></returns>
        public List<State> deltaStar(string w)
        {
            var Q = new List<State>();
            var q = this.q0;
            foreach (var c in w)
            {
                if (!Q.Any())
                {
                    var R = delta(q, c);
                    Q.AddRange(R);

                }
                else
                {
                    var @new = new List<State>();
                    foreach (var r in Q)
                    {
                        var R = delta(r, c);
                        @new.AddRange(R);
                    }
                    Q = @new;
                }

                // Đảm bảo Q là tập hợp
                Q = Q.Distinct().ToList();
            }
            return Q;
        }

        /// <summary>
        ///  NFA có đoán nhận chuỗi w không?
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public bool Accept(string w)
        {
            Console.WriteLine($"End at [{string.Join(",", deltaStar(w))}]");
            return deltaStar(w).Where(q => this.F.Contains(q)).Any();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var NFA = new NFA1()
            {
                q0 = State.q0,
                F = new List<State>() { State.q2, State.q4 },
            };

            NFA.delta = (q, c) =>
            {
                var Q = new List<State>();
                switch (q)
                {
                    case State.q0:
                        if (c == '0')
                            return new List<State> { State.q0, State.q3 };
                        else
                            return new List<State>() { State.q0, State.q1 };
                    case State.q1:
                        if (c == '0')
                            return new List<State> { };
                        else
                            return new List<State> { State.q2 };
                    case State.q2:
                        if (c == '0')
                            return new List<State> { State.q2 };
                        else
                            return new List<State> { State.q2 };
                    case State.q3:
                        if (c == '0')
                            return new List<State> { State.q4 };
                        else
                            return new List<State> { };
                    case State.q4:
                        if (c == '0')
                            return new List<State> { State.q4 };
                        else
                            return new List<State> { State.q4 };
                    default:
                        break;
                }
                return Q;
            };

            var s1 = "01";
            var s2 = "01001";
            Console.WriteLine("Accept : " + s1 + " --> " + NFA.Accept(s1));
            Console.WriteLine("--------------");
            Console.WriteLine("Accept : " + s2 + " --> " + NFA.Accept(s2));
            Console.ReadKey();
        }
    }
}
