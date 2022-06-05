using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPZ_1.Services
{
    public class ResultData
    {
        public Dictionary<string, int> Results { get; init; } = new Dictionary<string, int>();

        public override string ToString()
        {
            var str = new StringBuilder();

            foreach (var result in Results.OrderBy(r => r.Value).ThenBy(r => r.Key))
            {
                str.AppendLine($"{result.Key} {result.Value}");
            }

            return str.ToString();
        }
    }
}
