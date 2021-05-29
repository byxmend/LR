using System;
using System.Collections.Generic;

namespace LR7
{
    class Program
    {
        static void Main(string[] args)
        {
            RationalNumber firstNumber = new RationalNumber(30, 60);
            RationalNumber secondNumber = new RationalNumber(20, 16);
            RationalNumber thirdNumber = new RationalNumber(16, 8);
            RationalNumber fourthNumber = new RationalNumber(68, 34);
            RationalNumber firstRationalNumber = new RationalNumber();
            RationalNumber secondRationalBumber = new RationalNumber();

            RationalNumber[] rationalNumbers = new RationalNumber[] 
            { 
                firstNumber,
                secondNumber,
                thirdNumber,
                fourthNumber
            };


            foreach (RationalNumber index in rationalNumbers)
            {
                RationalNumber.reduceFraction(index);
            }

            Array.Sort(rationalNumbers);

            foreach (RationalNumber index in rationalNumbers)
            {
                RationalNumber.getType(index, "in decimal");
            }

            Console.WriteLine($"\n{firstNumber > secondNumber}\n" +
                $"{fourthNumber < thirdNumber}\n" +
                $"{fourthNumber == thirdNumber}\n" +
                $"{secondNumber.Equals(fourthNumber)}\n" +
                $"{fourthNumber.Equals(thirdNumber)}\n");

            firstRationalNumber = firstNumber + secondNumber;

            RationalNumber.reduceFraction(firstRationalNumber);
            RationalNumber.getType(firstRationalNumber, "with fractions");
            Console.WriteLine();

            firstRationalNumber = firstNumber - secondNumber;

            RationalNumber.reduceFraction(firstRationalNumber);
            RationalNumber.getType(firstRationalNumber, "with fractions");
            Console.WriteLine();
            
            firstRationalNumber = firstNumber * secondNumber;
            
            RationalNumber.reduceFraction(firstRationalNumber);
            RationalNumber.getType(firstRationalNumber, "with fractions");
            Console.WriteLine();
            
            firstRationalNumber = firstNumber / secondNumber;
            
            RationalNumber.reduceFraction(firstRationalNumber);
            RationalNumber.getType(firstRationalNumber, "with fractions");
            Console.WriteLine();
            
            firstNumber++;
            
            RationalNumber.reduceFraction(firstRationalNumber);
            RationalNumber.getType(firstNumber, "with fractions");
            Console.WriteLine();
            
            firstNumber--;
            
            RationalNumber.reduceFraction(firstRationalNumber);
            RationalNumber.getType(firstNumber, "with fractions");
            Console.WriteLine();
            
            firstRationalNumber = firstNumber + 10;
            
            RationalNumber.reduceFraction(firstRationalNumber);
            RationalNumber.getType(firstRationalNumber, "with fractions");
            Console.WriteLine();

            int firstBuffer;
            double secondBuffer;
            string str = "99/17";

            firstBuffer = firstNumber;
            Console.WriteLine(firstBuffer);

            secondBuffer = (double)firstNumber;
            Console.WriteLine(secondBuffer + "\n");

            Console.WriteLine(firstNumber.ToString("in decimal"));
            Console.WriteLine(firstNumber.ToString("with fractions"));
            Console.WriteLine();

            secondRationalBumber = (RationalNumber)str;
            RationalNumber.getType(secondRationalBumber, "with fractions");
            Console.WriteLine();

            string inputStr = Console.ReadLine();
            string[] ratNum = inputStr.Split(' ');
            List<RationalNumber> listNumbers = new List<RationalNumber>();
            RationalNumber.processString(ratNum, listNumbers);

            foreach (RationalNumber index in listNumbers)
            {
                Console.WriteLine(index.ToString("in decimal"));
            }
        }
    }
}