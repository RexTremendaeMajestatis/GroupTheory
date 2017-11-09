using System;
using System.Collections.Generic;
using System.Text;

namespace GroupTheory
{
    class FullCommutant: Commutant
    {
        private readonly List<Commutator> allCommutators;

        public FullCommutant(Group g) 
            : base(g)
        {
            allCommutators = new List<Commutator>();
            for (int i = 0; i < g.Elements.Count; i++)
            {
                for (int j = 0; j < g.Elements.Count; j++)
                {
                    allCommutators.Add(new Commutator(g, g.Elements[i], g.Elements[j]));
                }
            }
        }

        public string ShowAll()
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (var a in allCommutators)
            {
                sb.Append(i + " " + a.ToString() + "\n");
                i++;
            }
            return sb.ToString();
        }
    }
}
