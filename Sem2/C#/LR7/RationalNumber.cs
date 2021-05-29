using System;
using System.Collections.Generic;
using System.Text;

namespace LR7
{
    class RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public RationalNumber()
        {
            Numerator = 0;
            Denominator = 0;
        }

        public RationalNumber(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public static RationalNumber operator + (RationalNumber firstNumber, RationalNumber secondNumber)
        {
            int numbersNumerator;
            int numbersDenominator;
            numbersNumerator = (firstNumber.Numerator * secondNumber.Denominator) + 
                (secondNumber.Numerator * firstNumber.Denominator);
            numbersDenominator = firstNumber.Denominator * secondNumber.Denominator;

            return new RationalNumber 
            {
                Numerator = numbersNumerator, 
                Denominator = numbersDenominator 
            };
        }

        public static RationalNumber operator - (RationalNumber firstNumber, RationalNumber secondNumber)
        {
            int numbersNumerator;
            int numbersDenominator;
            numbersNumerator = (firstNumber.Numerator * secondNumber.Denominator) - 
                (secondNumber.Numerator * firstNumber.Denominator);
            numbersDenominator = firstNumber.Denominator * secondNumber.Denominator;
            
            return new RationalNumber 
            { 
                Numerator = numbersNumerator, 
                Denominator = numbersDenominator 
            };
        }

        public static RationalNumber operator * (RationalNumber firstNumber, RationalNumber secondNumber)
        {
            return new RationalNumber 
            { 
                Numerator = firstNumber.Numerator * secondNumber.Numerator, 
                Denominator = firstNumber.Denominator * secondNumber.Denominator 
            };
        }

        public static RationalNumber operator / (RationalNumber firstNumber, RationalNumber secondNumber)
        {
            return new RationalNumber 
            { 
                Numerator = firstNumber.Numerator * secondNumber.Denominator, 
                Denominator = firstNumber.Denominator * secondNumber.Numerator 
            };
        }

        public static RationalNumber operator + (RationalNumber firstNumber, int value)
        {
            return new RationalNumber
            {
                Numerator = firstNumber.Numerator + (value * firstNumber.Denominator),
                Denominator = firstNumber.Denominator
            };
        }

        public static RationalNumber operator ++ (RationalNumber firstNumber)
        {
            return new RationalNumber 
            {
                Numerator = firstNumber.Numerator + firstNumber.Denominator, 
                Denominator = firstNumber.Denominator 
            };
        }

        public static RationalNumber operator -- (RationalNumber firstNumber)
        {
            return new RationalNumber 
            { 
                Numerator = firstNumber.Numerator - firstNumber.Denominator, 
                Denominator = firstNumber.Denominator 
            };
        }

        public static bool operator == (RationalNumber firstNumber, RationalNumber secondNumber)
        {
            int firstNumberNumerator = firstNumber.Numerator * secondNumber.Denominator;
            int secondNumberNumerator = firstNumber.Denominator * secondNumber.Numerator;

            return firstNumberNumerator == secondNumberNumerator;
        }

        public static bool operator != (RationalNumber firstNumber, RationalNumber secondNumber)
        {
            int firstNumberNumerator = firstNumber.Numerator * secondNumber.Denominator;
            int secondNumberNumerator = firstNumber.Denominator * secondNumber.Numerator;

            return firstNumberNumerator != secondNumberNumerator;
        }

        public static bool operator > (RationalNumber firstNumber, RationalNumber secondNumber)
        {
            int firstNumberNumerator = firstNumber.Numerator * secondNumber.Denominator;
            int secondNumberNumerator = firstNumber.Denominator * secondNumber.Numerator;

            return firstNumberNumerator > secondNumberNumerator;
        }

        public static bool operator < (RationalNumber firstNumber, RationalNumber secondNumber)
        {
            int firstNumberNumerator = firstNumber.Numerator * secondNumber.Denominator;
            int secondNumberNumerator = firstNumber.Denominator * secondNumber.Numerator;

            return firstNumberNumerator < secondNumberNumerator;
        }

        public static void processString(string[] str, List<RationalNumber> numbers)
        {
            char operation;

            StringBuilder firstBuffer = new StringBuilder();
            StringBuilder secondBuffer = new StringBuilder();

            foreach (string index in str)
            {
                if (index.Contains("/"))
                {
                    for (int i = 0; i < index.Length; i++)
                    {
                        operation = index[i];

                        if (operation == '/')
                        {
                            for (int j = i + 1; j < index.Length; j++)
                            {
                                firstBuffer.Append(index[j]);
                            }

                            numbers.Add(new RationalNumber
                            {
                                Denominator = Convert.ToInt32(firstBuffer.ToString()),
                                Numerator = Convert.ToInt32(secondBuffer.ToString()),
                            });

                            break;
                        }
                        else
                        {
                            secondBuffer.Append(index[i]);
                        }
                    }
                    firstBuffer.Clear();
                    secondBuffer.Clear();
                }

                if (index.Contains("."))
                {
                    for (int i = 0; i < index.Length; i++)
                    {
                        operation = index[i];

                        if (operation == '.')
                        {
                            numbers.Add(new RationalNumber
                            {
                                Denominator = Convert.ToInt32(Math.Pow(10, index.Length - i - 1)),
                                Numerator = Convert.ToInt32(Convert.ToDouble(index) * 
                                Convert.ToDouble(Math.Pow(10, index.Length - i - 1))),
                            });

                            firstBuffer.Clear();
                            
                            break;
                        }
                        else
                        {
                            firstBuffer.Append(index[i]);
                        }
                    }
                }
            }
        }

        public static explicit operator RationalNumber(string str)
        {
            char operation;

            StringBuilder firstBuffer = new StringBuilder();
            StringBuilder secondBuffer = new StringBuilder();
            
            if (str.Contains("/"))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    operation = str[i];

                    if (operation == '/')
                    {
                        for (int j = i + 1; j < str.Length; j++)
                        {
                            firstBuffer.Append(str[j]);
                        }

                        return new RationalNumber
                        {
                            Denominator = Convert.ToInt32(firstBuffer.ToString()),
                            Numerator = Convert.ToInt32(secondBuffer.ToString()),
                        };
                    }
                    else
                    {
                        secondBuffer.Append(str[i]);
                    }
                }
            }

            if (str.Contains("."))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    operation = str[i];

                    if (operation == '.')
                    {
                        return new RationalNumber
                        {
                            Denominator = Convert.ToInt32(Math.Pow(10, str.Length - i - 1)),
                            Numerator = Convert.ToInt32(Convert.ToDouble(str) * 
                            Convert.ToDouble(Math.Pow(10, str.Length - i - 1))),
                        };
                    }
                    else
                    {
                        firstBuffer.Append(str[i]);
                    }
                }
            }

            return null;
        }

        public static void reduceFraction(RationalNumber firstNumber)
        {
            int minChislo, i = 2;

            if (Math.Abs(firstNumber.Numerator) > Math.Abs(firstNumber.Denominator))
            {
                minChislo = Math.Abs(firstNumber.Denominator);
            }
            else
            {
                minChislo = Math.Abs(firstNumber.Numerator);
            }

            while (i <= minChislo)
            {
                if ((firstNumber.Numerator % i == 0) && (firstNumber.Denominator % i == 0))
                {
                    firstNumber.Denominator /= i;
                    firstNumber.Numerator /= i;
                    i = 1;
                }

                i++;
            }
        }

        public static void getType(RationalNumber firstNumber, string format)
        {
            if (format == "in decimal")
            {
                Console.WriteLine(Convert.ToDouble(firstNumber.Numerator) / Convert.ToDouble(firstNumber.Denominator));
            }
            else if (format == "with fractions")
            {
                Console.WriteLine(firstNumber.Numerator + "\n-\n" + firstNumber.Denominator);
            }
        }

        public override string ToString()
        {
            return (Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator)).ToString();
        }

        public string ToString(string format)
        {
            if (format == "in decimal")
            {
                return (Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator)).ToString();
            }
            else if (format == "with fractions")
            {
                return Numerator.ToString() + "\n-\n" + Denominator.ToString();
            }

            return string.Empty;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            RationalNumber rationalNumber = (RationalNumber)obj;

            int cheсk = CompareTo(rationalNumber);
            
            if (cheсk == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static implicit operator int(RationalNumber rationalNumber)
        {
            string str = rationalNumber.ToString("in decimal");

            return Convert.ToInt32(Convert.ToDouble(str));
        }

        public static explicit operator double(RationalNumber rationalNumber)
        {
            string str = rationalNumber.ToString("in decimal");

            return Convert.ToDouble(str);
        }

        public int CompareTo(RationalNumber number)
        {
            if (number > this)
            {
                return 1;
            }
            else if (number < this)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}