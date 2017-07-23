using System.Collections.Generic;
using System.IO;

namespace Outsurance
{
    public class FileReader
    {
        public static List<Person> ReadFile(string path)
        {
            List<Person> people = new List<Person>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    Person person = new Person();
                    string[] data = reader.ReadLine().Split(',');
                    person.FirstName = data[0];
                    person.LastName = data[1];
                    person.Address = data[2];
                    person.PhoneNumber = data[3];

                    people.Add(person);
                }

                people.RemoveAt(0);
            }

            return people;
        }
    }
}
