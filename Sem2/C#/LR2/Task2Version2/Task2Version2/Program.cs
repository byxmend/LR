using System;

namespace Task2Version2
{
    class Program
    {
        static void Main(string[] args)
        {
            string linst = "abcdefghijklmnopqrstuvwxyz";
            string total;
            int sign, length;
            Random x = new Random();
            length = x.Next(1, 4); // If 4 inclusive, then change the string to (length = x.Next(1, 5);)
            
            for (int i = 0; i < length; i++)
            {
                sign = x.Next(0, 26);
                total = string.Concat(linst[sign]);
                Console.Write(total);
            }
        }
    }
}
