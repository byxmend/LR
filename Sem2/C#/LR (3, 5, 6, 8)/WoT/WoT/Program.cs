using System;

namespace WoT
{
    static class Program
    {
        private static readonly Tanks Tanks = new Tanks();
        private static readonly Tank Tank = new Tank();
        private static readonly Battle Battle = new Battle();
        private static readonly HeavyTank HeavyTank = new HeavyTank();
        private static readonly LightTank LightTank = new LightTank();
        private static readonly Imba Imba = new Imba();
        
        static void SwitchAddEquip(Tanks tanks, int chooseNewTank)
        {
            switch (chooseNewTank)
            {
                case 0:
                    HeavyTank.AddEquip(tanks, chooseNewTank);
                    break;
                case 1:
                    LightTank.AddEquip(tanks, chooseNewTank);
                    break;
                case 2:
                    Tank.AddEquip(tanks, chooseNewTank);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        
        static void SwitchRemoveEquip(Tanks tanks, int chooseNewTank)
        {
            switch (chooseNewTank)
            {
                case 0:
                    HeavyTank.RemoveEquip(tanks, chooseNewTank);
                    break;
                case 1:
                    LightTank.RemoveEquip(tanks, chooseNewTank);
                    break;
                case 2:
                    Tank.RemoveEquip(tanks, chooseNewTank);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        
        static void Main()
        {
            Tanks tanks = new Tanks();
            
            HeavyTank.FillTanksSet(tanks, 0);
            LightTank.FillTanksSet(tanks, 1);
            Imba.FillTanksSet(tanks, 2);
            
            HeavyTank.ShowTanksSet(tanks, 0);
            LightTank.ShowTanksSet(tanks, 1);
            Imba.ShowTanksSet(tanks, 2);
            
            int[] array = new int[3];
            int firstChooseTank;
            int secondChooseTank;
            int newChooseTank;

            while (true)
            {
                Tanks.Menu();

                switch (Tanks.CheckInt())
                {
                    case 1:
                        HeavyTank.FillTanksSet(tanks, 0);
                        LightTank.FillTanksSet(tanks, 1);
                        Imba.FillTanksSet(tanks, 2);
                        break;
                    case 2:
                        HeavyTank.ShowTanksSet(tanks, 0);
                        LightTank.ShowTanksSet(tanks, 1);
                        Imba.ShowTanksSet(tanks, 2);
                        break;
                    case 3:
                        newChooseTank = Tanks.ChooseTank();
                        SwitchAddEquip(tanks, newChooseTank);
                        break;
                    case 4:
                        newChooseTank = Tanks.ChooseTank();
                        SwitchRemoveEquip(tanks, newChooseTank);
                        break;
                    case 5:
                        Tanks.MenuEquipment(tanks, array);
                        break;
                    case 6:
                        firstChooseTank = Tanks.ChooseTank();
                        secondChooseTank = Tanks.ChooseTank();
                        Battle.BattleBetweenTanks(tanks, firstChooseTank, secondChooseTank);
                        break;
                    case 7:
                        Console.Clear();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}