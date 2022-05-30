using MIPZ_1.Services;
using System.Collections.Generic;

namespace MIPZ_1.Models
{
    public class City
    {
        private readonly Dictionary<string, int> _dict = new Dictionary<string, int>();
        public string Country { get; }
        public int X { get; }
        public int Y { get; }
        public Dictionary<string, int> Coins { get; }

        public City(string country, int x, int y)
        {
            Country = country;
            X = x;
            Y = y;

            Coins = new Dictionary<string, int>{
                { country, 1000000 }
            };
        }
        public void AddIncoming(Dictionary<string, int> incoming)
        {
            foreach (var pair in incoming)
            {
                _dict.AddCoins(pair.Key, pair.Value);
            }
        }

        public Dictionary<string, int> GetOutcoming()
        {
            var dict = new Dictionary<string, int>();

            foreach (var pair in Coins)
            {
                dict.Add(pair.Key, pair.Value / 1000);

                _dict.AddCoins(pair.Key, -dict[pair.Key]);
            }

            return dict;
        }

        public void ApplyIncoming()
        {
            foreach (var pair in _dict)
            {
                Coins.AddCoins(pair.Key, pair.Value);
            }

            _dict.Clear();
        }
    }
}
