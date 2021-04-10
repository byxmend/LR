using System;

namespace WoT
{
    static class Program
    {
        static void SwitchAddEquip(int chooseNewTank)
        {
            HeavyTank heavyTank = new HeavyTank();
            LightTank lightTank = new LightTank();
            Tank tank = new Tank();

            switch (chooseNewTank)
            {
                case 0:
                    heavyTank.AddEquip();
                    break;
                case 1:
                    lightTank.AddEquip();
                    break;
                case 2:
                    tank.AddEquip();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        
        static void SwitchRemoveEquip(int chooseNewTank)
        {
            HeavyTank heavyTank = new HeavyTank();
            LightTank lightTank = new LightTank();
            Tank tank = new Tank();

            switch (chooseNewTank)
            {
                case 0:
                    heavyTank.RemoveEquip();
                    break;
                case 1:
                    lightTank.RemoveEquip();
                    break;
                case 2:
                    tank.RemoveEquip();
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
            HeavyTank heavyTank = new HeavyTank();
            LightTank lightTank = new LightTank();
            Imba imba = new Imba();

            heavyTank.FillTanksSet(0);
            lightTank.FillTanksSet(1);
            imba.FillTanksSet(2);
            
            heavyTank.ShowTanksSet(0);
            lightTank.ShowTanksSet(1);
            imba.ShowTanksSet(2);
            
            int[] array = new int[3];
            int firstChooseTank;
            int secondChooseTank;

            while (true)
            {
                tanks.Menu();

                switch (tanks.CheckInt())
                {
                    case 1:
                        heavyTank.FillTanksSet(0);
                        lightTank.FillTanksSet(1);
                        imba.FillTanksSet(2);
                        break;
                    case 2:
                        heavyTank.ShowTanksSet(0);
                        lightTank.ShowTanksSet(1);
                        imba.ShowTanksSet(2);
                        break;
                    case 3:
                        SwitchAddEquip(tanks.ChooseTank());
                        break;
                    case 4:
                        SwitchRemoveEquip(tanks.ChooseTank());
                        break;
                    case 5:
                        tanks.MenuEquipment(array);
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