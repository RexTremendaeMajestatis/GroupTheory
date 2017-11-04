using System.Collections.Generic;

namespace GroupTheory
{
    class Coset
    {
        /// <summary>
        /// List of coset elements
        /// </summary>
        public List<GroupElement> Elements;

        /// <summary>
        /// Create coset 
        /// </summary>
        /// <param name="elements"></param>
        public Coset(List<GroupElement> elements)
        {
            Elements = elements;
        }
        /// <summary>
        /// Create empty coset
        /// </summary>
        public Coset()
        {
            Elements = null;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this == (Coset)obj;
        }

        public override int GetHashCode()
        {
            int res = 0;
            foreach (var a in Elements)
            {
                res += a.GetHashCode();
            }
            return res;
        }

        public static bool operator ==(Coset a, Coset b)
        {
            return new HashSet<GroupElement>(a.Elements).SetEquals(b.Elements);
        }

        public static bool operator !=(Coset a, Coset b)
        {
            return !(a == b);
        }
    }
}
