using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTheory
{
    class Group
    {
        /// <summary>
        /// List of group elements
        /// </summary>
        public readonly List<GroupElement> Elements;

        protected int order;
        protected int Order => order;

        /// <summary>
        /// Create empty group
        /// </summary>
        public Group()
        {
            Elements = new List<GroupElement>();
            order = 0;
        }
        /// <summary>
        /// Create group
        /// </summary>
        /// <param name="elements"></param>
        public Group(List<GroupElement> elements)
        {
            this.Elements = elements;
            order = elements.Count;
        }

        /// <summary>
        /// Show group elements
        /// </summary>
        public void Show()
        {
            foreach (var e in Elements)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Group string interpretation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order: " + order + "\n");
            sb.Append("{ ");
            foreach (var e in Elements)
            {
                sb.Append(e + ", ");
            }
            sb.Append("} \n");
            return sb.ToString();
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
            return this == (Group) obj;
        }

        /// <summary>
        /// Get hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int result = 0;
            foreach (var g in Elements)
            {
                result += g.GetHashCode();
            }
            return result;
        }
        /// <summary>
        /// Check groups equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Group a, Group b) => new HashSet<GroupElement>(a.Elements).SetEquals(b.Elements);
        /// <summary>
        /// Check group non-equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Group a, Group b) => !(a == b);


    }
}
