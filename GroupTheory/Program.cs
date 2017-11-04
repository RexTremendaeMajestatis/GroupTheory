using System;

namespace GroupTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            QuanternionsGroupElement a = new QuanternionsGroupElement("i");
            QuanternionsGroupElement b = new QuanternionsGroupElement("j");
            QuanternionsGroupElement c = new QuanternionsGroupElement("k");
            IntModuloNElement ten = new IntModuloNElement(1);
            Console.WriteLine(ten);
            IntModuloNElement mten = new IntModuloNElement(-1);
            Console.WriteLine(mten);
            Console.WriteLine(ten + mten);

            GroupElement ge = new GroupElement(2, "i");

            GroupElement gee = new GroupElement(1, "j");

            Console.WriteLine(gee * ge);

            Console.ReadKey();
        }
    }
}
