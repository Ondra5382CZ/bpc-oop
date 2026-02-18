using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        TestComplex.Test("Test +", new Complex(1, 1) + new Complex(2, 2), new Complex(3, 3));
        TestComplex.Test("Test -", new Complex(2, 2) - new Complex(1, 1), new Complex(1, 1));
        TestComplex.Test("Test *", new Complex(2, 1) * new Complex(2, 1), new Complex(3, 4));
        TestComplex.Test("Test /", new Complex(2, 2) / new Complex(1, 1), new Complex(2, 0));
        TestComplex.Test("Test -u", - new Complex(1, 1), new Complex(-1, -1));

        var a = new Complex(5, 6);

        double modul;
        double argument;

        a.ToModArg(out modul, out argument);

    }
}

