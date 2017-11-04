using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTheory
{
    class CycleGroup : Group
    {
        private readonly GroupElement generatrix;

        /// <summary>
        /// Create cycle group
        /// </summary>
        /// <param name="a"></param>
        public CycleGroup(GroupElement a)
        {
            generatrix = a;
            GroupElement e = new GroupElement(0, "1");
            GroupElement temp = a;
            Elements.Add(a);
            while (temp != e)
            {
                temp *= a;
                Elements.Add(temp);
            }
            order = Elements.Count;
        }

        /// <summary>
        /// Cycle group string interpretation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "<" + generatrix + ">" + " = " + base.ToString();
        }
        /// <summary>
        /// Check group and object equivalence
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this == (CycleGroup) obj;
        }
        /// <summary>
        /// Get cycle group hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Check cycle groups equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(CycleGroup a, CycleGroup b) => new HashSet<GroupElement>(a.Elements).SetEquals(b.Elements);
        /// <summary>
        /// Check groups non-equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(CycleGroup a, CycleGroup b)
        {
            return !(a == b);
        }
    }
}
