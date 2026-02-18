using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie2
{
    public class TestComplex
    {
        public static void Test(String Testname, Complex a, Complex b)
        {
            Console.Write($"{Testname} ");
            var epsilon = 0.000001;
            if (Math.Abs(a.Realna - b.Realna) < epsilon &&
                Math.Abs(a.Imaginarna - b.Imaginarna) < epsilon)
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("Chyba \n");
                Console.WriteLine($"Skutocna hodnota:{a}");
                Console.WriteLine($"Ocakavana hodnota:{b}");
            }
        }
    }
}
