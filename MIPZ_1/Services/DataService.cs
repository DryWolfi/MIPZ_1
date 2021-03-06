using MIPZ_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPZ_1.Services
{
    public class Data
    {
        public const int ThousandD = 1000;
        private readonly Dictionary<(int x, int y), City> _cities;

        public Data(List<Country> countries)
        {
            if (countries.Count == 0 && countries.Count > 20)
            {
                throw new ArgumentException(nameof(countries));
            }

            Countries = countries;
            _cities = countries
                .SelectMany(country => country.Cities)
                .ToDictionary(city => (city.X, city.Y));
        }

        public List<Country> Countries { get; init; }

        public static Data Parse(IEnumerable<string> parse)
        {
            return new Data(parse.Select(p => Country.Parse(p)).ToList());
        }

        public ResultData Execute()
        {
            var results = new Dictionary<string, int>();

            for (var days = 0; true; days++)
            {
                foreach (var r in CompletedCountries())
                {
                    results.TryAdd(r, days);
                }

                if (results.Count == Countries.Count)
                {
                    break;
                }

                if (CheckCountriesMono() && days == ThousandD)
                {
                    Console.WriteLine("Looks like we have a disconected Country");
                    break;
                }

                foreach (var ((x, y), city) in _cities)
                {
                    SendMoney(x, y + 1, city);
                    SendMoney(x - 1, y, city);
                    SendMoney(x, y - 1, city);
                    SendMoney(x + 1, y, city);
                }

                foreach (var (_, city) in _cities)
                {
                    city.ApplyIncoming();
                }
            }

            return new ResultData
            {
                Results = results
            };
        }
        private bool CheckCountriesMono()
        {
            for (int i = 0; i < Countries.Count; i++)
            {
                int citiesCount = Countries[i].Cities.Count;
                int monoCities = 0;
                foreach (var city in Countries[i].Cities)
                {
                    if (city.CheckIfMono())
                        monoCities++;
                }
                if (citiesCount == monoCities)
                    return true;
            }
            return false;
        }
        private IEnumerable<string> CompletedCountries() =>
            _cities
                .GroupBy(x => x.Value.Country)
                .Select(g => (g.Key, g.All(x => Countries.All(y => x.Value.Coins.TryGetValue(y.Name, out var amount) && amount > 0))))
                .Where(x => x.Item2)
                .Select(x => x.Key);

        private void SendMoney(int x, int y, City city)
        {
            if (_cities.TryGetValue((x, y), out var incoming))
            {
                city.AddIncoming(incoming.GetOutcoming());
            }
        }
    }
}
