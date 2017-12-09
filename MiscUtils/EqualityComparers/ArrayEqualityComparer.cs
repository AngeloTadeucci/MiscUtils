using System.Collections.Generic;

namespace MiscUtils
{
    public class ArrayEqualityComparer<T> : IEqualityComparer<T[]>
    {
        public bool Equals(T[] x, T[] y)
        {
            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            if (x.Length != y.Length)
            {
                return false;
            }

            for (int i = 0; i < x.Length; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(x[i], y[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode(T[] obj)
        {
            unchecked
            {
                int hashCode = 599672073;

                for (int i = 0; i < obj.Length; i++)
                {
                    hashCode *= -1521134295 + i.GetHashCode();
                    hashCode *= -1521134295 + EqualityComparer<T>.Default.GetHashCode(obj[i]);
                }

                return hashCode;
            }
        }
    }
}
