using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFA
{
    public class TapHop<T> : List<T>
    {
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
        public static bool operator <(TapHop<T> A, TapHop<T> B)
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
        public static bool operator >(TapHop<T> A, TapHop<T> B)
        {
            return B < A;
        }
        public static bool operator ==(TapHop<T> A, TapHop<T> B)
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
        public static bool operator !=(TapHop<T> A, TapHop<T> B)
        {
            return !(A == B);
        }

        /// <summary>
        ///  A hợp B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static TapHop<T> operator +(TapHop<T> A, TapHop<T> B)
        {
            var C = new TapHop<T>();
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
        public static TapHop<T> operator ^(TapHop<T> A, TapHop<T> B)
        {
            var C = new TapHop<T>();
            foreach (var x in A)
            {
                if (B.Contains(x))
                    C.Add(x);
            }
            return C;
        }
    }
}
