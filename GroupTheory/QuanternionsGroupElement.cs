using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GroupTheory
{
    public class QuanternionsGroupElement
    {
        private static readonly string[,] cayleyTable = new string[8, 8]
        {
            {"1", "-1", "i", "-i", "j", "-j", "k", "-k"},
            {"-1", "1", "-i", "i", "-j", "j", "-k", "k"},
            {"i", "-i", "-1", "1", "k", "-k", "-j", "j"},
            {"-i", "i", "1", "-1", "-k", "k", "j", "-j"},
            {"j", "-j", "-k", "k", "-1", "1", "i", "-i"},
            {"-j", "j", "k", "-k", "1", "-1", "-i", "i"},
            {"k", "-k", "j", "-j", "-i", "i", "-1", "1"},
            {"-k", "k", "-j", "j", "i", "-i", "1", "-1"},
        };
        private readonly int index;
        /// <summary>
        /// Create quaternion object
        /// </summary>
        /// <param name="a"></param>
        public QuanternionsGroupElement(string a)
        {
            try
            {
                switch (a)
                {
                    case "1":
                        index = 0;
                        break;
                    case "-1":
                        index = 1;
                        break;
                    case "i":
                        index = 2;
                        break;
                    case "-i":
                        index = 3;
                        break;
                    case "j":
                        index = 4;
                        break;
                    case "-j":
                        index = 5;
                        break;
                    case "k":
                        index = 6;
                        break;
                    case "-k":
                        index = 7;
                        break;
                }
            }
            catch
            {
                throw new Exception(message: "Wrong letter");
            }
        }
        /// <summary>
        /// Create quaternion object
        /// </summary>
        /// <param name="a"></param>
        public QuanternionsGroupElement(int a)
        {
            try
            {
                switch (a)
                {
                    default:
                        index = 0;
                        break;
                    case 1:
                        index = 0;
                        break;
                    case -1:
                        index = 1;
                        break;
                }
            }
            catch
            {
                throw new Exception(message: "Wrong letter");
            }
        }
        /// <summary>
        /// String interpretation of quaternion
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch (index)
            {
                default:
                    return "";
                case 0:
                    return "1";
                case 1:
                    return "-1";
                case 2:
                    return "i";
                case 3:
                    return "-i";
                case 4:
                    return "j";
                case 5:
                    return "-j";
                case 6:
                    return "k";
                case 7:
                    return "-k";
            }
        }
        /// <summary>
        /// Check quaternion and object equivalence
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
            return index.GetHashCode();
        }
        /// <summary>
        /// Quaternion group orepation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static QuanternionsGroupElement operator *(QuanternionsGroupElement a, QuanternionsGroupElement b)
        {
            return new QuanternionsGroupElement(cayleyTable[a.index, b.index]);
        }
        /// <summary>
        /// Check quaternion equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(QuanternionsGroupElement a, QuanternionsGroupElement b)
        {
            return a.ToString().Equals(b.ToString());
        }
        /// <summary>
        /// Check quaternions non-equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(QuanternionsGroupElement a, QuanternionsGroupElement b)
        {
            return !(a == b);
        }
    }
}
