using MIPZ_1.Services;
using System;
using System.IO;
using System.Reflection;

namespace MIPZ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Data/input.txt");

            var set = DataSet.Parse(lines);

            set.Execute();
            File.WriteAllText("Data/output.txt", set.ToString());
        }
    }
}
