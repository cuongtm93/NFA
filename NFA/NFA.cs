using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFA
{

    public class NFA
    {

        /// <summary>
        ///  Hàm chuyển trạng thái (q,char) --> {Tập các trạng thái }
        /// </summary>
        public Func<State, char, TapHop<State>> delta;

        /// <summary>
        ///  Trạng thái bắt đầu
        /// </summary>
        public virtual State q0 { get; set; }

        /// <summary>
        ///  Tập trạng thái kết thúc
        /// </summary>
        public virtual TapHop<State> F { get; set; }

        /// <summary>
        ///  Hàm chuyển trạng thái mở rộng
        /// </summary>
        /// <param name="w"> Chuỗi nhập vào </param>
        /// <returns></returns>
        public virtual TapHop<State> deltaStar(string w)
        {
            var Q = new TapHop<State>();
            var q = this.q0;
            foreach (var c in w)
            {
                if (!Q.Any())
                    Q += delta(q, c);
                else
                {
                    var @new = new TapHop<State>();
                    foreach (var r in Q)
                        @new = @new + delta(r, c);

                    Q = @new;
                }
            }
            return Q;
        }

        /// <summary>
        ///  NFA có đoán nhận chuỗi w không?
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        public virtual bool Accept(string w)
        {
            Console.WriteLine($"End at [{string.Join(",", deltaStar(w))}]");
            return deltaStar(w).Where(q => this.F.Contains(q)).Any();
        }


    }
}
