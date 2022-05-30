using MIPZ_1.Services;
using System;
using System.IO;
using System.Reflection;

namespace MIPZ_1
{
    class Program
    {
        static void Main(string[] args)
            //C:\Users\dvovc\source\repos\MIPZ_1\MIPZ_1\Data\input.txt
        {
            //string currentDirectory = Directory.GetCurrentDirectory();
            //string inputPath = Path.Combine(Environment.CurrentDirectory, @"Data\", "input.txt");
            //string inputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\input.txt");
            var lines = File.ReadAllLines("C:/Users/dvovc/source/repos/MIPZ_1/MIPZ_1/Data/input.txt");

            var set = DataSet.Parse(lines);

            set.Execute();
            //string outputPath = Path.Combine(Environment.CurrentDirectory, @"Data\", "output.txt");
            //string outputPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\output.txt");
            File.WriteAllText("C:/Users/dvovc/source/repos/MIPZ_1/MIPZ_1/Data/output.txt", set.ToString());
        }
    }
}
