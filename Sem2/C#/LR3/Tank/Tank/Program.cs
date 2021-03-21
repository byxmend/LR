using System;

namespace Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People();
            people[0] = new Person { Name = "Tom" };
            people[1] = new Person { Name = "Bob" };
 
            Person tom = people[0];
            Console.WriteLine(tom?.Name);
 
            Console.ReadKey();
        }
    }
}