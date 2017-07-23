using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outsurance
{
    public static class Processor
    {
        public static List<dynamic> GetFirstNameFrequency(List<Person> data)
        {
            return (from person in data
                    group person by person.FirstName into personGroup
                    select new
                    {
                        Name = personGroup.Key,
                        General = personGroup.Count()
                    }).OrderByDescending(x => x.General).ThenBy(x => x.Name).ToList<dynamic>();
        }

        public static List<dynamic> GetLastNameFrequency(List<Person> data)
        {
            return (from person in data
                    group person by person.LastName into personGroup
                    select new
                    {
                        Name = personGroup.Key,
                        General = personGroup.Count()
                    }).OrderByDescending(x => x.General).ThenBy(x => x.Name).ToList<dynamic>();
        }

        public static List<dynamic> GetFullName(List<Person> data)
        {
            return (from person in data
                    group person by new { person.FirstName, person.LastName } into personGroup
                    select new
                    {
                        Name = personGroup.Key.FirstName,
                        General = personGroup.Key.LastName
                    }).OrderBy(x => x.Name).ThenBy(x => x.General).ToList<dynamic>();
        }

        public static List<string> GetSortedAddresses(List<Person> data)
        {
            List<string> addresses = new List<string>();
            data.Sort((o, c) => new string(o.Address.Where(x => char.IsLetter(x)).ToArray()).CompareTo(new string(c.Address.Where(x => char.IsLetter(x)).ToArray())));
            data.ForEach(x =>
            {
                addresses.Add(x.Address);
            });

            return addresses;
        }
    }
}
