using System;
using System.Collections.Generic;
using System.IO;

namespace Outsurance
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = string.Concat(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"\output\data.csv");
            List<Person> people = FileReader.ReadFile(source);
            Person person = new Person();

            FileWriter.WriteToFile(Processor.GetFirstNameFrequency(people), "Names");
            FileWriter.WriteToFile(Processor.GetLastNameFrequency(people), "Names");
            FileWriter.WriteToFile(Processor.GetFullName(people), "Names");
            FileWriter.WriteToFile(Processor.GetSortedAddresses(people), "Addresses");

            Console.ReadLine();
        }
    }
}
