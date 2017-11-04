using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Coset string interprepation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{ ");
            foreach (var e in Elements)
            {
                sb.Append(e + ", ");
            }
            sb.Append("} \n");

            return sb.ToString();
        }
        /// <summary>
        /// Check coset and object equivalence
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.ToString().Equals((string) obj);
        }
        /// <summary>
        /// Get hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int res = 0;
            foreach (var a in Elements)
            {
                res += a.GetHashCode();
            }
            return res;
        }

        /// <summary>
        /// Check cosets equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Coset a, Coset b)
        {
            return new HashSet<GroupElement>(a.Elements).SetEquals(b.Elements);
        }
        /// <summary>
        /// Check cosets non-equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Coset a, Coset b)
        {
            return !(a == b);
        }
    }
}
