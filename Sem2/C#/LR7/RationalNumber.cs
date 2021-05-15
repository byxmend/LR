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
            this.Numerator = 0;
            this.Denominator = 0;
        }

        public RationalNumber(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public static RationalNumber operator +(RationalNumber num1, RationalNumber num2)
        {
            int numeratorChisel;
            int denominatorChisel;
            numeratorChisel = (num1.Numerator * num2.Denominator) + (num2.Numerator * num1.Denominator);
            denominatorChisel = num1.Denominator * num2.Denominator;
            return new RationalNumber { Numerator = numeratorChisel, Denominator = denominatorChisel };
        }

        public static RationalNumber operator -(RationalNumber num1, RationalNumber num2)
        {
            int numeratorChisel;
            int denominatorChisel;
            numeratorChisel = (num1.Numerator * num2.Denominator) - (num2.Numerator * num1.Denominator);
            denominatorChisel = num1.Denominator * num2.Denominator;
            return new RationalNumber { Numerator = numeratorChisel, Denominator = denominatorChisel };
        }

        public static RationalNumber operator *(RationalNumber num1, RationalNumber num2)
        {
            return new RationalNumber { Numerator = num1.Numerator * num2.Numerator, Denominator = num1.Denominator * num2.Denominator };
        }

        public static RationalNumber operator /(RationalNumber num1, RationalNumber num2)
        {
            return new RationalNumber { Numerator = num1.Numerator * num2.Denominator, Denominator = num1.Denominator * num2.Numerator };
        }

        public static RationalNumber operator ++(RationalNumber num1)
        {
            return new RationalNumber { Numerator = num1.Numerator + num1.Denominator, Denominator = num1.Denominator };
        }

        public static RationalNumber operator --(RationalNumber num1)
        {
            return new RationalNumber { Numerator = num1.Numerator - num1.Denominator, Denominator = num1.Denominator };
        }

        public static RationalNumber operator +(RationalNumber num1, int val)
        {
            return new RationalNumber { Numerator = num1.Numerator + (val * num1.Denominator), Denominator = num1.Denominator };
        }

        public static bool operator <(RationalNumber num1, RationalNumber num2)
        {
            int numeratorChisla1 = num1.Numerator * num2.Denominator;
            int numeratorChisla2 = num2.Numerator * num1.Denominator;
            return numeratorChisla1 < numeratorChisla2;
        }

        public static bool operator >(RationalNumber num1, RationalNumber num2)
        {
            int numeratorChisla1 = num1.Numerator * num2.Denominator;
            int numeratorChisla2 = num2.Numerator * num1.Denominator;
            return numeratorChisla1 > numeratorChisla2;
        }

        public static bool operator ==(RationalNumber num1, RationalNumber num2)
        {
            int numeratorChisla1 = num1.Numerator * num2.Denominator;
            int numeratorChisla2 = num2.Numerator * num1.Denominator;
            return numeratorChisla1 == numeratorChisla2;
        }

        public static bool operator !=(RationalNumber num1, RationalNumber num2)
        {
            int numeratorChisla1 = num1.Numerator * num2.Denominator;
            int numeratorChisla2 = num2.Numerator * num1.Denominator;
            return numeratorChisla1 != numeratorChisla2;
        }

        public static void processStr(string[] str, List<RationalNumber> numbers)
        {
            char buf;
            StringBuilder buf2 = new StringBuilder();
            StringBuilder buf1 = new StringBuilder();
            foreach (string c in str)
            {
                if (c.Contains("/"))
                {
                    for (int i = 0; i < c.Length; i++)
                    {
                        buf = c[i];
                        if (buf == '/')
                        {
                            for (int j = i + 1; j < c.Length; j++)
                            {
                                buf1.Append(c[j]);
                            }

                            numbers.Add(new RationalNumber
                            {
                                Denominator = Convert.ToInt32(buf1.ToString()),
                                Numerator = Convert.ToInt32(buf2.ToString()),
                            });
                            break;
                        }
                        else
                        {
                            buf2.Append(c[i]);
                        }
                    }

                    buf2.Clear();
                    buf1.Clear();
                }

                if (c.Contains("."))
                {
                    for (int i = 0; i < c.Length; i++)
                    {
                        buf = c[i];
                        if (buf == '.')
                        {
                            numbers.Add(new RationalNumber
                            {
                                Denominator = Convert.ToInt32(Math.Pow(10, c.Length - i - 1)),
                                Numerator = Convert.ToInt32(Convert.ToDouble(c) * Convert.ToDouble(Math.Pow(10, c.Length - i - 1))),
                            });
                            buf1.Clear();
                            break;
                        }
                        else
                        {
                            buf1.Append(c[i]);
                        }
                    }
                }
            }
        }

        public static void reduceFraction(RationalNumber num1)
        {
            int minChislo = 0;
            if (Math.Abs(num1.Numerator) > Math.Abs(num1.Denominator))
            {
                minChislo = Math.Abs(num1.Denominator);
            }
            else
            {
                minChislo = Math.Abs(num1.Numerator);
            }

            int i = 2;
            while (i <= minChislo)
            {
                if ((num1.Denominator % i == 0) & (num1.Numerator % i == 0))
                {
                    num1.Denominator /= i;
                    num1.Numerator /= i;
                    i = 1;
                }

                i++;
            }
        }

        public static void getType(RationalNumber num1, string format)
        {
            if (format == "in decimal")
            {
                Console.WriteLine(Convert.ToDouble(num1.Numerator) / Convert.ToDouble(num1.Denominator));
            }
            else if (format == "with fractions")
            {
                Console.WriteLine(num1.Numerator + "\n-\n" + num1.Denominator);
            }
        }

        public override string ToString()
        {
            return (Convert.ToDouble(this.Numerator) / Convert.ToDouble(this.Denominator)).ToString();
        }

        public string ToString(string format)
        {
            if (format == "in decimal")
            {
                return (Convert.ToDouble(this.Numerator) / Convert.ToDouble(this.Denominator)).ToString();
            }
            else if (format == "with fractions")
            {
                return this.Numerator.ToString() + "\n-\n" + this.Denominator.ToString();
            }

            return string.Empty;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            RationalNumber p = (RationalNumber)obj;
            int cheсk = this.CompareTo(p);
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

        public static explicit operator RationalNumber(string c)
        {
            char buf;
            StringBuilder buf1 = new StringBuilder();
            StringBuilder buf2 = new StringBuilder();
            if (c.Contains("/"))
            {
                for (int i = 0; i < c.Length; i++)
                {
                    buf = c[i];
                    if (buf == '/')
                    {
                        for (int j = i + 1; j < c.Length; j++)
                        {
                            buf1.Append(c[j]);
                        }

                        return new RationalNumber
                        {
                            Denominator = Convert.ToInt32(buf1.ToString()),
                            Numerator = Convert.ToInt32(buf2.ToString()),
                        };
                    }
                    else
                    {
                        buf2.Append(c[i]);
                    }
                }
            }

            if (c.Contains("."))
            {
                for (int i = 0; i < c.Length; i++)
                {
                    buf = c[i];
                    if (buf == '.')
                    {
                        return new RationalNumber
                        {
                            Denominator = Convert.ToInt32(Math.Pow(10, c.Length - i - 1)),
                            Numerator = Convert.ToInt32(Convert.ToDouble(c) * Convert.ToDouble(Math.Pow(10, c.Length - i - 1))),
                        };
                    }
                    else
                    {
                        buf1.Append(c[i]);
                    }
                }
            }

            return null;
        }

        public int CompareTo(RationalNumber num)
        {
            if (num > this)
            {
                return 1;
            }

            if (num < this)
            {
                return -1;
            }

            if (num == this)
            {
                return 0;
            }

            return 0;
        }
    }
}