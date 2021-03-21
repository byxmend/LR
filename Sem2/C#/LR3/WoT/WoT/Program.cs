using System;

namespace WoT
{
    static class Program
    {
        static void Main(string[] args)
        {
            Tanks x = new Tanks();
            
            x.FillTanksSet();
            x.ShowTanksSet();
        }
    }
}