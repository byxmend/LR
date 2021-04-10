using System;

namespace WoT
{
    public class Imba : Tank
    {
        private Camo _camo;

        private void FillCamo()
        {
            Console.Write("Fill camo:\nColor: ");
            string color = Console.ReadLine();
            Console.Write("Season: ");
            string season = Console.ReadLine();
            Console.Write("Disguise (1 - 10): ");
            int disguise = CheckInt();

            _camo = new Camo(color, season, disguise);
        }
        
        public override void FillTanksSet(int i)
        {
            Console.WriteLine("Imba tank:");
            FillCamo();
            base.FillTanksSet(i);
        }

        public override void ShowTanksSet(int i)
        {
            base.ShowTanksSet(i);
            _camo.DisplayInfo();
        }

        public int Aiming()
        {
            int value;
            
            while (true)
            {
                if (_camo.Disguise > 0 && _camo.Disguise < 6)
                {
                    value = _camo.Disguise / 2;
                    return value;
                }
                
                if (_camo.Disguise > 5 && _camo.Disguise < 11)
                {
                    value = _camo.Disguise / 3;
                    return value;
                }

                Console.WriteLine("Range: 1 - 10, try again");
                _camo.Disguise = CheckInt();
            }
        }
    }
}