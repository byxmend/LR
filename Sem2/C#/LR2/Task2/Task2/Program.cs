using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string linst = "abcdefghijklmnopqrstuvwxyz";
            string total;
            int sign;
            Random x = new Random();

            for (int i = 0; i < 4; i++)
            {
                sign = x.Next(0, 26);
                total = string.Concat(linst[sign]);
                Console.Write(total);
            }
        }
    }
}