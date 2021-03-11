using System;

namespace Task1
{
    class Program
    {
        static void Counter(string str, char a)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == a) count++;
            }
            Console.WriteLine("Numbers " + a + ": " + count);
        }
            
        static void Date(string str)
        {
            for (char i = '0'; i < '9'; i++)
            {
                Counter(str, i);
            }
        }
        
        static void Main(string[] args)
        {
            string fullFormat = DateTime.Now.ToString("F");
            string shortFormat = DateTime.Now.ToString("g");
            Console.WriteLine("Full format: " + fullFormat);
            Date(fullFormat);
            Console.WriteLine("\nShort format: " + shortFormat);
            Date(shortFormat);
        }
    }
}