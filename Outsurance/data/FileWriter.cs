using System;
using System.Collections.Generic;
using System.IO;

namespace Outsurance
{
    public class FileWriter
    {
        public static void WriteToFile(List<dynamic> data, string fileName)
        {
            StreamWriter writer = null;
            string path = string.Concat(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"\output\", fileName, ".txt");
            if (File.Exists(path))
            {
                writer = File.AppendText(path);
            }
            else
            {
                writer = File.CreateText(path);
            }

            data.ForEach(x =>
            {
                writer.WriteLine(string.Format("{0}{1} {2}", x.Name, IsNumeric(x.General) ? "," : "", x.General));
            });

            writer.WriteLine();
            writer.Close();
            writer.Dispose();
            Console.WriteLine("Text file {0} created successfully.", fileName);
        }

        public static void WriteToFile(List<string> data, string fileName)
        {
            StreamWriter writer = new StreamWriter(string.Concat(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"\output\", fileName, ".txt"));
            data.ForEach(x =>
            {
                writer.WriteLine(string.Format("{0}", x));
            });

            writer.Close();
            writer.Dispose();
            Console.WriteLine("Text file {0} created successfully.", fileName);
        }

        private static bool IsNumeric(dynamic param)
        {
            int num;
            return int.TryParse(param.ToString(), out num);
        }
    }
}
