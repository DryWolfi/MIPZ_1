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
            var lines = File.ReadAllLines("C:/Users/dvovc/source/repos/MIPZ_1/MIPZ_1/Data/input.txt");

            var set = DataSet.Parse(lines);

            set.Execute();
            File.WriteAllText("C:/Users/dvovc/source/repos/MIPZ_1/MIPZ_1/Data/output.txt", set.ToString());
        }
    }
}
