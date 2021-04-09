using System;

namespace WoT
{
    public readonly struct Camo
    {
        private readonly string _color;
        private readonly string _season;
        private readonly int _disguise;

        public Camo(string color, string season, int disguise)
        {
            _color = color;
            _season = season;
            _disguise = disguise;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Color: {_color}, Season: {_season}, Disguise: {_disguise}");
        }
    }
}