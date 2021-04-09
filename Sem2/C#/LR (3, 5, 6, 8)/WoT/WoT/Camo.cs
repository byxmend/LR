using System;

namespace WoT
{
    public struct Camo
    {
        private readonly string _color;
        private readonly string _season;
        internal int Disguise;

        public Camo(string color, string season, int disguise)
        {
            _color = color;
            _season = season;
            Disguise = disguise;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Color: {_color}\nSeason: {_season}\nDisguise: {Disguise}");
        }
    }
}