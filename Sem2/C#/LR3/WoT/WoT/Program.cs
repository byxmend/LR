using System;

namespace WoT
{
    static class Program
    {
        static void FillTanksSet(Tanks tanks)
        {
            int hitPoints;
            int averageSpeed;
            int damagePerMinute;
            string name;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter the hit points:");
                hitPoints = tanks.CheckInt();
                Console.WriteLine("Enter the average speed:");
                averageSpeed = tanks.CheckInt();
                Console.WriteLine("Enter the damage per minute:");
                damagePerMinute = tanks.CheckInt();
                Console.WriteLine("Enter the name:");
                name = Console.ReadLine();
                
                tanks[i] = new Tank(hitPoints, averageSpeed, damagePerMinute, name);
                Console.Clear();
            }
        }

        static void ShowTanksSet(Tanks tanks)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\nHitPoints: {tanks[i].HitPoints}\nAverageSpeed: {tanks[i].AverageSpeed}\n" +
                                  $"DamagePerMinute: {tanks[i].DamagePerMinute}\nName: {tanks[i].Name}\nId: {tanks[i].Id}");
            }
        }
        
        static void Main(string[] args)
        {
            Tanks tanks = new Tanks();
            FillTanksSet(tanks);
            ShowTanksSet(tanks);
        }
    }
}