using System;
using System.Collections.Generic;
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
        //https://msdn.microsoft.com/en-us/library/system.numerics.complex(v=vs.110).aspx
    
    public static Complex operator +(Complex left, Complex right) {
        left.real += right.real;
        left.img += right.img;
        return left;
    }
    public static Complex operator -(Complex left, Complex right)
    {
        left.real -= right.real;
        left.img -= right.img;
        return left;
    }
    public static Complex operator *(Complex left, Complex right)
    {
        //(ac - bd) + (ad + bc)i
        var real = (left.real * right.real - left.img * right.img);
        var imag = (left.real * right.img + left.img * right.real);
        return new Complex(real,imag);
    }
    public static Complex operator /(Complex left, Complex right)
    {
        //((ac + bd) / (c2 + d2)) + ((bc - ad) / (c2 + d2)i
        var real = ((left.real * right.real + left.img * right.img) / (right.real * right.real + right.img * right.img));
        var imag = (left.img * right.real - left.real * right.img) / (right.real* right.real+right.img*right.img);
        return new Complex(real, imag);
    }
    public static Complex operator -(Complex num)
    {
        return new Complex(-num.real, -num.img);
    }
    public static bool operator ==(Complex left, Complex right)
    {
        if(left.real==right.real && left.img==right.img) return true;
        return false;
    }
    public static bool operator !=(Complex left, Complex right)
    {
        if (left.real != right.real || left.img != right.img) return true;
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