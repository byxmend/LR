using System;
using System.Collections.Generic;

namespace LR7
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber first = new RationalNumber(15, 30);
            RationalNumber second = new RationalNumber(10, 8);
            RationalNumber third = new RationalNumber(8, 4);
            RationalNumber fourth = new RationalNumber(34, 17);
            RationalNumber[] rationalNumbers = new RationalNumber[] { first, second, third, fourth };

            foreach (RationalNumber index in rationalNumbers)
                RationalNumber.reduceFraction(index);

            Array.Sort(rationalNumbers);

            foreach (RationalNumber index in rationalNumbers)
                RationalNumber.getType(index, "in decimal");

            Console.WriteLine();

            Console.WriteLine(first > second);
            Console.WriteLine(fourth < third);
            Console.WriteLine(fourth == third);
            Console.WriteLine(second.Equals(fourth));
            Console.WriteLine(fourth.Equals(third));
            Console.WriteLine();

            RationalNumber rationalNumber = new RationalNumber();
            rationalNumber = first + second;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(rationalNumber, "with fractions");
            Console.WriteLine();
            rationalNumber = first - second;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(rationalNumber, "with fractions");
            Console.WriteLine();
            rationalNumber = first * second;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(rationalNumber, "with fractions");
            Console.WriteLine();
            rationalNumber = first / second;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(rationalNumber, "with fractions");
            Console.WriteLine();
            first++;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(first, "with fractions");
            Console.WriteLine();
            first--;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(first, "with fractions");
            Console.WriteLine();
            rationalNumber = first + 10;
            RationalNumber.reduceFraction(rationalNumber);
            RationalNumber.getType(rationalNumber, "with fractions");
            Console.WriteLine();

            int buf1;
            double buf2;
            buf1 = first;
            Console.WriteLine(buf1);
            buf2 = (double)first;
            Console.WriteLine(buf2 + "\n");

            Console.WriteLine(first.ToString("in decimal"));
            Console.WriteLine(first.ToString("with fractions"));
            Console.WriteLine();

            RationalNumber num = new RationalNumber();
            string str = "99/17";
            num = (RationalNumber)str;
            RationalNumber.getType(num, "with fractions");
            Console.WriteLine();

            string inputStr = Console.ReadLine();
            string[] rationalNumbers1 = inputStr.Split(' ');
            List<RationalNumber> listNumbers = new List<RationalNumber>();
            RationalNumber.processStr(rationalNumbers1, listNumbers);
            foreach (RationalNumber i in listNumbers)
            {
                Console.WriteLine(i.ToString("in decimal"));
            }
        }
    }
}