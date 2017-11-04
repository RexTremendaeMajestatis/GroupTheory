namespace GroupTheory
{
    class Commutator
    {
        private static readonly GroupElement neutral = new GroupElement(0, "1");
        private readonly GroupElement commutatorValue;
        private readonly GroupElement firstElement;
        private readonly GroupElement secondElement;
        private readonly Group g;

        /// <summary>
        /// Create ommutator
        /// </summary>
        /// <param name="G"></param>
        /// <param name="firstElement"></param>
        /// <param name="secondElement"></param>
        public Commutator(Group G, GroupElement firstElement, GroupElement secondElement)
        {
            this.firstElement = firstElement;
            this.secondElement = secondElement;
            this.g = G;
            commutatorValue = firstElement * secondElement 
                * ReverseElement(firstElement, G) * ReverseElement(secondElement, G);
        }

        /// <summary>
        /// Commutator string interpretation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "[" + firstElement.ToString() + secondElement.ToString() + "] = "
                   + firstElement.ToString() + " * " + secondElement.ToString() 
                   + " * " + ReverseElement(firstElement, g) + " * " 
                   + ReverseElement(secondElement, g) + " = "
                   + commutatorValue.ToString();
        }
        /// <summary>
        /// Check commutator and object equivalence
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
            return this.commutatorValue.GetHashCode();
        }

        /// <summary>
        /// Check commutator equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Commutator a, Commutator b)
        {
            return a != null && a.commutatorValue == b.commutatorValue;
        }
        /// <summary>
        /// Check commutators non-equivalence
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Commutator a, Commutator b)
        {
            return !(a == b);
        }
        /// <summary>
        /// For g find a: g * a = a * g  = e
        /// </summary>
        /// <param name="g"></param>
        /// <param name="G"></param>
        /// <returns></returns>
        public static GroupElement ReverseElement(GroupElement g, Group G)
        {
            GroupElement temp = new GroupElement(0, "1");

            foreach (var a in G.Elements)
            {
                if (a * g == neutral)
                {
                    temp = a;

                }
            }

            return temp;
        }
    }


}
