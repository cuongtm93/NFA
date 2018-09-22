using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFA
{
    public class Tập_Hợp<T> : List<T>
    {
        public  static Tập_Hợp<T> Rỗng()
        {
            return new Tập_Hợp<T>();
        }
        public new void Add(T element)
        {
            if (this.Contains(element))
                return;

            this.Insert(0, element);
        }
              

        /// <summary>
        /// Toán tử A con B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool operator <(Tập_Hợp<T> A, Tập_Hợp<T> B)
        {
            foreach (var x in A)
            {
                if (B.Contains(x) == false)
                    return false;
            }

            return true;
        }

        /// <summary>
        ///  Toán tử A chứa B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool operator >(Tập_Hợp<T> A, Tập_Hợp<T> B)
        {
            return B < A;
        }
        public static bool operator ==(Tập_Hợp<T> A, Tập_Hợp<T> B)
        {
            if (A.Count != B.Count)
                return false;

            foreach (var x in A)
            {
                if (B.Contains(x) == false)
                    return false;
            }

            return true;
        }
        public static bool operator !=(Tập_Hợp<T> A, Tập_Hợp<T> B)
        {
            return !(A == B);
        }

        /// <summary>
        ///  A hợp B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Tập_Hợp<T> operator +(Tập_Hợp<T> A, Tập_Hợp<T> B)
        {
            var C = new Tập_Hợp<T>();
            C.AddRange(A);
            C.AddRange(B);

            return C;
        }

        /// <summary>
        ///  A giao B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Tập_Hợp<T> operator ^(Tập_Hợp<T> A, Tập_Hợp<T> B)
        {
            var C = new Tập_Hợp<T>();
            foreach (var x in A)
            {
                if (B.Contains(x))
                    C.Add(x);
            }
            return C;
        }
    }
}
