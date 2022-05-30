using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPZ_1.Services
{
    public class DataSet
    {
        public List<Data> Datas { get; set; } = new List<Data>();

        public List<ResultData> Results { get; private set; }

        public static DataSet Parse(string[] parse)
        {
            var dataSet = new DataSet();

            while (true)
            {
                int size;
                int.TryParse(parse[0], out size);
                if (parse.FirstOrDefault() == null
                    || size == 0)
                {
                    break;
                }

                var data = Data.Parse(parse
                    .Skip(1)
                    .Take(size)
                    .ToArray());

                dataSet.Datas.Add(data);

                parse = parse
                    .Skip(size + 1)
                    .ToArray();
            }

            return dataSet;
        }

        public static DataSet InputFromConsole()
        {
            var dataSet = new DataSet();

            Data data;

            do
            {
                data = Data.InputFromConsole();

                dataSet.Datas.Add(data);
            } while (data != null);

            return dataSet;
        }

        public void Execute()
        {
            Results = Datas
                .Select(x => x.Execute())
                .ToList();
        }

        public override string ToString()
        {
            var str = new StringBuilder();

            for (var i = 0; i < Results.Count; i++)
            {
                str.AppendLine($"Case Number {i + 1}");

                str.Append(Results[i].ToString());
            }

            return str.ToString();
        }
    }
}
