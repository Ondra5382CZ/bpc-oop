using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cvicenie2
{
    class Program
    {
        static void Main(string[] args)
        {
            TestComplex.Test("Testicek +", new Complex(1, 1)+ new Complex(2, 2), new Complex(3, 3));
            TestComplex.Test("Testicek -", new Complex(2, 2) - new Complex(1, 1), new Complex(1, 1));

            TestComplex.Test("Testicek *", new Complex(2, 1) * new Complex(2, 1), new Complex(3, 4));
            TestComplex.Test("Testicek /", new Complex(6, 8) / new Complex(5, 1), new Complex(7, 1));
            TestComplex.Test("Testicek -u", - new Complex(1, 1), new Complex(-1, -1));



            var a = new Complex(5, 6);

            double modul;
            double argument;

            a.ToModArg(out modul, out argument);

        }
    }
}
