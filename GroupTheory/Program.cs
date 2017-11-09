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

            List<GroupElement> group = GenerategGroup();
            Group G = new Group(group);

            Console.WriteLine(group[1].Order);


            Console.ReadKey();

        }
    }
}
