using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTheory
{
    class RightCoset : Coset
    {
        private readonly GroupElement generatrix;

        /// <summary>
        /// Create right coset
        /// </summary>
        /// <param name="generatrix"></param>
        /// <param name="h"></param>
        public RightCoset(GroupElement generatrix, Group h)
        {
            this.generatrix = generatrix;
            Elements = new List<GroupElement>();
            foreach (var x in h.Elements)
            {
                Elements.Add(x * generatrix);
            }
        }

        /// <summary>
        /// Right coset string interpretation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("h" + generatrix.ToString() + " = ");
            sb.Append("{ ");
            foreach (var a in Elements)
            {
                sb.Append(a + ", ");
            }
            sb.Append("}");

            return sb.ToString();
        }
        /// <summary>
        /// Check right coset and object equivalence
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this.ToString().Equals((string)obj);
        }
        /// <summary>
        /// Get hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

