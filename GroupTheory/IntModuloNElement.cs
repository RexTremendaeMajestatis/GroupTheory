using System;
using System.Collections.Generic;
using System.Text;

namespace GroupTheory
{
    class IntModuloNElement
    {
        private int module;
        private int element;

        /// <summary>
        /// Create integer modulo n element
        /// </summary>
        /// <param name="a"></param>
        /// <param name="module"></param>
        public IntModuloNElement(int a)
        {
            this.module = 3;
            element = a % module;
            if (element < 0)
            {
                element += module;
            }
        }
        /// <summary>
        /// Create integer modulo n element
        /// </summary>
        public IntModuloNElement()
        {
            this.module = 3;
            this.element = 0;
        }
        /// <summary>
        /// Integer modulo n string interpretation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return element.ToString();
        }
        /// <summary>
        /// Check object and integer modulo n element equivalence
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return this == (IntModuloNElement) obj;
        }
        /// <summary>
        /// Get integer modulo n element hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.element.GetHashCode() ^ this.module.GetHashCode();
        }
        /// <summary>
        /// Check integer modulo n elements equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(IntModuloNElement a, IntModuloNElement b)
        {
            return a.module.Equals(b.module) && a.element.Equals(b.element);
        }
        /// <summary>
        /// Check integer modulo n elements non-equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(IntModuloNElement a, IntModuloNElement b)
        {
            return !(a.module.Equals(b.module) && a.element.Equals(b.element));
        }
        /// <summary>
        /// Integer module n group operation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IntModuloNElement operator +(IntModuloNElement a, IntModuloNElement b)
        {
            if (a.module == b.module)
            {
                return new IntModuloNElement(a.element + b.element);
            }
            return new IntModuloNElement();
        }
        /// <summary>
        /// Scalar multiply
        /// </summary>
        /// <param name="l"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IntModuloNElement operator *(int l, IntModuloNElement b)
        {
            return new IntModuloNElement(l * b.element);
        }
        /// <summary>
        /// Scalar multiply
        /// </summary>
        /// <param name="b"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public static IntModuloNElement operator *(IntModuloNElement b, int l)
        {
            return new IntModuloNElement(l * b.element);
        }
    }
}

