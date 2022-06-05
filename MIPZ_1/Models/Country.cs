using System;
using System.Collections.Generic;

namespace MIPZ_1.Models
{
    public class Country
    {
        public string Name { get; }
        public int Xl { get; }
        public int Yl { get; }
        public int Xh { get; }
        public int Yh { get; }
        public List<City> Cities
        {
            get
            {
                var cities = new List<City>();

                for (var i = Xl; i <= Xh; i++)
                {
                    for (var j = Yl; j <= Yh; j++)
                    {
                        cities.Add(new City(Name, i, j));
                    }
                }

                return cities;
            }
        }

        public Country(string name, int xl, int yl, int xh, int yh)
        {
            Name = name;
            Xl = xl;
            Yl = yl;
            Xh = xh;
            Yh = yh;
        }

        public static Country Parse(string parse)
        {
            var splited = parse?.Split(' ');

            if (splited == null
                || splited.Length != 5
                || splited[0].Length > 25
                || !int.TryParse(splited[1], out var Xl)
                || !int.TryParse(splited[2], out var Yl)
                || !int.TryParse(splited[3], out var Xh)
                || !int.TryParse(splited[4], out var Yh))
            {
                throw new Exception();
            }

            return new Country(splited[0], Xl, Yl, Xh, Yh);
        }
    }
}
