using System;
using System.Collections.Generic;

namespace LR7
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber a = new RationalNumber(15, 30);
            RationalNumber b = new RationalNumber(10, 8);
            RationalNumber c = new RationalNumber(8, 4);
            RationalNumber d = new RationalNumber(34, 17);
            RationalNumber[] rationalNumbers = new RationalNumber[] { a, b, c, d };

            foreach (RationalNumber i in rationalNumbers)
            {
                RationalNumber.reduceFraction(i);
            }

            Array.Sort(rationalNumbers);
            foreach (RationalNumber i in rationalNumbers)
            {
                RationalNumber.getType(i, "in decimal");
            }

            Console.WriteLine();

            Console.WriteLine(a > b);
            Console.WriteLine(d < c);
            Console.WriteLine(d == c);
            Console.WriteLine(b.Equals(d));
            Console.WriteLine(d.Equals(c));
            Console.WriteLine();

            RationalNumber rationalNumber = new RationalNumber();
            rationalNumber = a + b;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(rationalNumber, "with fractions");
            Console.WriteLine();
            rationalNumber = a - b;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(rationalNumber, "with fractions");
            Console.WriteLine();
            rationalNumber = a * b;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(rationalNumber, "with fractions");
            Console.WriteLine();
            rationalNumber = a / b;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(rationalNumber, "with fractions");
            Console.WriteLine();
            a++;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(a, "with fractions");
            Console.WriteLine();
            a--;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(a, "with fractions");
            Console.WriteLine();
            rationalNumber = a + 10;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(rationalNumber, "with fractions");
            Console.WriteLine();

            int buf1;
            double buf2;
            buf1 = a;
            Console.WriteLine(buf1);
            buf2 = (double)a;
            Console.WriteLine(buf2 + "\n");

            Console.WriteLine(a.ToString("in decimal"));
            Console.WriteLine(a.ToString("with fractions"));
            Console.WriteLine();

            RationalNumber num = new RationalNumber();
            string str = "99/17";
            num = (RationalNumber)str;
            RationalNumber.getType(num, "with fractions");
            Console.WriteLine();

            string inputStr = Console.ReadLine();
            string[] rationalNumbers1 = inputStr.Split(' ');
            List<RationalNumber> listNumbers = new List<RationalNumber>();
            RationalNumber.processString(rationalNumbers1, listNumbers);
            foreach (RationalNumber i in listNumbers)
            {
                Console.WriteLine(i.ToString("in decimal"));
            }
        }
    }
}