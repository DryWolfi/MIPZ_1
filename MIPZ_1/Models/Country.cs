using System;
using System.Collections.Generic;

namespace MIPZ_1.Models
{
    public class Country
    {
        public const int MaxValue = 10;
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
            try
            {
                if (name == null)
                {
                    Console.WriteLine("Name is null");
                    throw new ArgumentNullException();
                }

                if (name.Length > 25)
                {
                    Console.WriteLine("Name is to long");
                    throw new ArgumentException();
                }

                if (xl < 0 || xl > MaxValue)
                {
                    Console.WriteLine("xl is less than 0");
                    throw new ArgumentOutOfRangeException();
                }

                if (xh < xl || xh > MaxValue)
                {
                    Console.WriteLine("xl is less than xh");
                    throw new ArgumentOutOfRangeException();
                }

                if (yl < 0 || yl > MaxValue)
                {
                    Console.WriteLine("yl is less than 0");
                    throw new ArgumentOutOfRangeException();
                }

                if (yh < yl || yh > MaxValue)
                {
                    Console.WriteLine("yh is less than yl");
                    throw new ArgumentOutOfRangeException();
                }
                Name = name;
                Xl = xl;
                Yl = yl;
                Xh = xh;
                Yh = yh;
            } catch (Exception ex)
            {
                Console.WriteLine("One or more error occured while procesing County data, please redo it");
            }
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
