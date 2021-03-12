using System;

namespace Task3
{
    class Program
    {
        static float CheckFloat()
        {
            float a;
            while (!float.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Invalid data, please try again: ");
            }
            return a;
        }

        static bool CheckTriangle(float a, float b, float c)
        {
            if (a < b + c && b < a + c && c < a + b) return true;
            else return false;
        }

        static float Square(float a, float b, float c)
        {
            float p = Perimetr(a, b, c) / 2;
            return (float)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        
        static float Perimetr(float a, float b, float c) => a + b + c;

        static float RadiusOut(float a, float b, float c) => (a * b * c) / (4 * Square(a, b, c));

        static float RadiusIn(float a, float b, float c) => (Square(a, b, c) / (Perimetr(a, b, c) / 2));

        static void Angles(float a, float b, float c)
        {
            float x = (b * b + c * c - a * a) / (2 * b * c);
            float y = (a * a + c * c - b * b) / (2 * a * c);
            float z = (a * a + b * b - c * c) / (2 * a * b);
            Console.WriteLine("angel 1: " + (Math.Acos(x) * 180 / Math.PI));
            Console.WriteLine("angel 2: " + (Math.Acos(y) * 180 / Math.PI));
            Console.WriteLine("angel 3: " + (Math.Acos(z) * 180 / Math.PI));
        }

        static void Main(string[] args)
        {
            bool value = true;
            while (value)
            {
                Console.Write("Enter side 1: ");
                float a = CheckFloat();
                Console.Write("Enter side 2: ");
                float b = CheckFloat();
                Console.Write("Enter side 3: ");
                float c = CheckFloat();
            
                if (CheckTriangle(a, b, c))
                {
                    Console.WriteLine("\nperimeter: " + (a + b + c));
                    Console.WriteLine("Square: " + Square(a, b, c));
                    Console.WriteLine("R circle: " + RadiusOut(a, b, c));
                    Console.WriteLine("R in circle: " + RadiusIn(a, b, c));
                    Angles(a, b, c);
                    value = false;
                }
                else
                {
                    Console.WriteLine("There is no such triangle");
                }
            }
        }
    }
}