using System;

namespace Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            Tank x = new Tank();
            Console.WriteLine($"averageSpeed: {x.AverageSpeed}");
            x.AddEquipment();
            Console.WriteLine(x.AverageSpeed);
            x.RemoveEquipment();
            Console.WriteLine(x.AverageSpeed);
        }
    }
}






// add static
// add outputs
// add a menu for working with fields
//add methods (1-2) (for example: )
// add field crew and some methods with this field
// maybe delete second constructor

