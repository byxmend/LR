using System;

namespace WoT
{
    public readonly struct Camo
    {
        private readonly string _color;
        private readonly string _season;
        private readonly string _logo;
        private readonly int _disguise;

        public Camo(string color, string season, string logo, int disguise)
        {
            _color = color;
            _season = season;
            _logo = logo;
            _disguise = disguise;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Color: {_color}, Season: {_season}, Logo: {_logo}, Disguise: {_disguise}");
        }
    }
}