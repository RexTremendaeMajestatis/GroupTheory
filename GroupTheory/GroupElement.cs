using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTheory
{
    class GroupElement
    {
        private readonly IntModuloNElement b;
        private readonly QuanternionsGroupElement s;

        /// <summary>
        /// Create group element using quanternion & modring objects
        /// </summary>
        /// <param name="b"></param>
        /// <param name="s"></param>
        public GroupElement(IntModuloNElement b, QuanternionsGroupElement s)
        {
            this.b = b;
            this.s = s;
        }
        /// <summary>
        /// Create group element using integer & string
        /// </summary>
        /// <param name="b"></param>
        /// <param name="s"></param>
        public GroupElement(int b, string s)
        {
            this.b = new IntModuloNElement(b);
            this.s = new QuanternionsGroupElement(s);
        }

        /// <summary>
        /// Order of group element
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static int Order(GroupElement g)
        {
            GroupElement e = new GroupElement(0, "1");
            GroupElement temp = g;
            int i = 1;
            while (temp != e)
            {
                temp *= g;
                i++;
            }
            return i;
        }
       
       
        /// <summary>
        /// String interpretation of group element
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + this.b.ToString() + ";" + this.s.ToString() + ")";
        }
        /// <summary>
        /// Equivalence with other object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this == (GroupElement) obj;
        }
        /// <summary>
        /// Hash code of group element
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => b.GetHashCode() ^ s.GetHashCode();

        /// <summary>
        /// Operator of equivalence
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool operator ==(GroupElement m, GroupElement n)
        {
            return (m.b == n.b) && (m.s == n.s);
        }
        /// <summary>
        /// Operator of non-equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(GroupElement a, GroupElement b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Group operation
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static GroupElement operator *(GroupElement m, GroupElement n)
        {
            return new GroupElement(m.b + Function(m.s) * n.b, m.s * n.s);
        }

        private static int Function(QuanternionsGroupElement s)
        {
            switch (s.ToString())
            {
                case "1":
                    return 1;
                case "-1":
                    return 1;
                case "i":
                    return 1;
                case "-i":
                    return 1;
                case "j":
                    return -1;
                case "-j":
                    return -1;
                case "k":
                    return -1;
                case "-k":
                    return -1;
            }
            return 0;
        }
    }
}
