using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Complex
{
    public double real;
    public double img;
    public Complex(double real,double imag) {
        this.real = real;
        this.img = imag;
    }
    
    public static Complex operator +(Complex a, Complex b) {
        a.real += b.real;
        a.img += b.img;
        return a;
    }
    public static Complex operator -(Complex a, Complex b)
    {
        a.real -= b.real;
        a.img -= b.img;
        return a;
    }
    public static Complex operator *(Complex a, Complex b)
    {
        var real = (a.real * b.real - a.img * b.img);
        var imag = (a.real * b.img + a.img * b.real);
        return new Complex(real,imag);
    }
    public static Complex operator /(Complex a, Complex b)
    {
        var denum = b.real * b.real + b.img * b.img;
        var Re = (a.real * b.real + a.img * b.img) / denum;
        var Im = (a.img * b.real - a.real *b.img)/denum;
        return new Complex(Re, Im);
    }
    public static Complex operator -(Complex num)
    {
        return new Complex(-num.real, -num.img);
    }
    public static bool operator ==(Complex a, Complex b)
    {
        if(a.real==b.real && a.img==b.img) return true;
        return false;
    }
    public static bool operator !=(Complex a, Complex b)
    {
        if (a.real != b.real || a.img != b.img) return true;
        return false;
    }
    public override String ToString()
    {
        if (img < 0) return $"{real}{img}i";
        return $"{real}+{img}i";
    }
    public void ToModArg(out double modul, out double argument) {
        modul = Math.Sqrt(real * real + img * img);
        argument = Math.Atan2(img, real);
    }
}