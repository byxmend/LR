using System;

namespace Tank
{
    class Program
    {
        private static void Meny()
        {
            Console.WriteLine("\n1 - add equipment\n2 - remove equipment\n3 - output all fields\n4 - turn off");
        }
        
        static void Main(string[] args)
        {
            int a;
            
            Tank x = new Tank();
            x.Output();
            
            while (true)
            {
                Meny();
                a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        x.AddEquipment();
                        break;
                    case 2:
                        x.RemoveEquipment();
                        break;
                    case 3:
                        x.Output();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("You entered an invalid value, you can try again");
                        break;
                }
            }
        }
    }
}

// change Convert to TryParse