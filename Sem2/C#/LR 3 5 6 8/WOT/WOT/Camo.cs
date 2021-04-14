using System;

namespace WOT
{
    public struct Camo
    {
        private readonly string _color;
        private readonly string _season;
        public int Disguise;

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