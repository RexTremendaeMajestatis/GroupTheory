using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupTheory
{
    class Commutant
    {
        private readonly HashSet<Commutator> commutators;
        private readonly Group g;

        /// <summary>
        /// Create commutant
        /// </summary>
        /// <param name="g"></param>
        public Commutant(Group g)
        {
            commutators = new HashSet<Commutator>();
            this.g = g;
            for (int i = 0; i < g.Elements.Count; i++)
            {
                for (int j = 0; j < g.Elements.Count; j++)
                {
                    commutators.Add(new Commutator(g, g.Elements[i], g.Elements[j]));
                }
            }
        }

        /// <summary>
        /// Commutant string interpretation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (var a in commutators)
            {
                sb.Append(i + " " + a.ToString() + "\n");
            }
            return sb.ToString();
        }
    }
}
