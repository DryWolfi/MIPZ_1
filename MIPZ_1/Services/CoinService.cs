using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPZ_1.Services
{
    public static class CoinService
    {
        public static void AddCoins(this Dictionary<string, int> dict, string country, int amount)
        {
            if (dict.ContainsKey(country))
            {
                dict[country] += amount;
            }
            else
            {
                dict.Add(country, amount);
            }
        }
    }
}
