using System;

namespace WoT
{
    static class Program
    {
        private static readonly HeavyTank HeavyTank = new HeavyTank();
        private static readonly LightTank LightTank = new LightTank();
        private static readonly Imba Imba = new Imba();
        
        static void SwitchAddEquip(int chooseNewTank)
        {
            switch (chooseNewTank)
            {
                case 1:
                    HeavyTank.AddEquip();
                    break;
                case 2:
                    LightTank.AddEquip();
                    break;
                case 3:
                    Imba.AddEquip();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        
        static void SwitchRemoveEquip(int chooseNewTank)
        {
            switch (chooseNewTank)
            {
                case 1:
                    HeavyTank.RemoveEquip(0);
                    break;
                case 2:
                    LightTank.RemoveEquip(1);
                    break;
                case 3:
                    Imba.RemoveEquip(2);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        
        static void Main()
        {
            Tanks tanks = new Tanks();
            Battle battle = new Battle();

            HeavyTank.FillTanksSet(0);
            LightTank.FillTanksSet(1);
            Imba.FillTanksSet(2);
            
            HeavyTank.ShowTanksSet(0);
            LightTank.ShowTanksSet(1);
            Imba.ShowTanksSet(2);
            
            int[] array = new int[3];
            int firstChooseTank;
            int secondChooseTank;

            while (true)
            {
                tanks.Menu();
                
                switch (tanks.CheckInt())
                {
                    case 1:
                        HeavyTank.FillTanksSet(0);
                        LightTank.FillTanksSet(1);
                        Imba.FillTanksSet(2);
                        break;
                    case 2:
                        HeavyTank.ShowTanksSet(0);
                        LightTank.ShowTanksSet(1);
                        Imba.ShowTanksSet(2);
                        break;
                    case 3:
                        SwitchAddEquip(tanks.ChooseTank());
                        break;
                    case 4:
                        SwitchRemoveEquip(tanks.ChooseTank());
                        break;
                    case 5:
                        tanks.MenuEquipment(array);
                        Imba.AddFeatures(array[0], array[1], array[2]);
                        break;
                    case 6:
                        firstChooseTank = tanks.ChooseTank();
                        secondChooseTank = tanks.ChooseTank();
                        battle.BattleBetweenTanks(tanks[firstChooseTank], tanks[secondChooseTank], firstChooseTank, secondChooseTank);
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