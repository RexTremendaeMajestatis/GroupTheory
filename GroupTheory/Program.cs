using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GroupTheory
{
    class Program
    {

        public static bool IsNormal(Group G, Group H)
        {
            List<LeftCoset> leftClasses = new List<LeftCoset>();
            List<RightCoset> rightClasses = new List<RightCoset>();

            foreach (var a in G.Elements)
            {
                leftClasses.Add(new LeftCoset(a, H));
            }

            foreach (var a in G.Elements)
            {
                rightClasses.Add(new RightCoset(a, H));
            }

            for (int i = 0; i < G.Elements.Count; i++)
            {
                if (rightClasses[i] != leftClasses[i])
                {
                    Console.WriteLine("************************");
                    Console.WriteLine(rightClasses[i].ToString());
                    Console.WriteLine(leftClasses[i].ToString());
                    Console.WriteLine("************************");
                    return false;
                }
            }
            return true;
        }
        public static List<GroupElement> GenerategGroup()
        {
            int[] mod = new int[3] { 0, 1, 2 };
            string[] qua = new string[8] { "1", "-1", "i", "-i", "j", "-j", "k", "-k" };
            List<GroupElement> group = new List<GroupElement>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    group.Add(new GroupElement(mod[i], qua[j]));
                }
            }
            return group;
        }


        public static void ShowSubgroup(GroupElement g)
        {
            GroupElement e = new GroupElement(0, "1");
            GroupElement temp = g;
            while (temp != e)
            {
                temp *= g;
                Console.WriteLine("  " + temp);
            }
            Console.WriteLine();
        }

        public static List<GroupElement> Subgroup(GroupElement g)
        {
            GroupElement e = new GroupElement(0, "1");
            List<GroupElement> res = new List<GroupElement>();
            res.Add(e);
            GroupElement temp = g;
            while (temp != e)
            {
                temp *= g;
                res.Add(temp);
            }
            return res;
        }
        static void Main(string[] args)
        {

            string path = @"C:\Users\pavel\Desktop\out.txt";
            StringBuilder sb = new StringBuilder();
            GroupElement e = new GroupElement(0, "1");
            GroupElement me = new GroupElement(0, "-1");
            List<GroupElement> group = GenerategGroup();
            Group G = new Group(group);



            Commutant commutantG = new Commutant(G);

            Console.WriteLine(commutantG);

            foreach (var a in G.Elements)
            {
                Console.WriteLine(a + " " + Commutator.ReverseElement(a, G));
            }
            List<int> commutatorInts = new List<int>();
            int k = 1;
            for (int i = 0; i < G.Elements.Count; i++)
            {
                for (int j = 0; j < G.Elements.Count; j++)
                {
                    /*if (i == j || G.Elements[i] == e || G.Elements[j] == e || G.Elements[i] == me || G.Elements[j] == me)
                        commutatorInts.Add(k);*/
                    if (Commutator.ReverseElement(G.Elements[i], G) == G.Elements[j] || Commutator.ReverseElement(G.Elements[j], G) == G.Elements[i])
                        commutatorInts.Add(k);
                    Console.WriteLine(k + new Commutator(G, G.Elements[i], G.Elements[j]).ToString() + "\n");
                    k++;
                }
            }

            foreach (var a in commutatorInts)
            {
                Console.WriteLine(a.ToString() + " ");
            }

            GroupElement zerok = new GroupElement(0, "k");
            GroupElement twok = new GroupElement(2, "k");

            Console.WriteLine(zerok * twok);


            Console.ReadKey();

        }
    }
}
