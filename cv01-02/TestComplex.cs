using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TestComplex
{
    public static void Test(String Testname, Complex a, Complex b)
    {
        Console.Write($"{Testname} ");
        var epsilon = 0.000001;
        if (Math.Abs(a.real - b.real) < epsilon &&
            Math.Abs(a.img - b.img) < epsilon && a == b)
        {
            Console.WriteLine("OK");
        }
        else
        {
            Console.WriteLine("Error \n");
            Console.WriteLine($"Real val:: {a}");
            Console.WriteLine($"Expected val: {b}");
        }
    }
}
