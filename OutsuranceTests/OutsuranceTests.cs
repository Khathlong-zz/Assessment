using Microsoft.VisualStudio.TestTools.UnitTesting;
using Outsurance;
using System;
using System.Collections.Generic;
using System.IO;

namespace OutsuranceTests
{
    [TestClass]
    public class OutsuranceTests
    {
        public string Source { get; set; } 
        public Person Person { get; set; }
        public List<Person> People { get; set;}
        public List<string> Addresses { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            Source = string.Concat(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), @"\output\data.csv").Replace("OutsuranceTests", "Outsurance");
            People = FileReader.ReadFile(Source);
            Person = new Person();
            Addresses = new List<string>();
        }

        [TestMethod]
        public void CheckPersonType()
        {
            Type expected = typeof(Person);
            Assert.IsInstanceOfType(Person, expected);
        }

        [TestMethod]
        public void CheckPeopleType()
        {
            Type expected = typeof(List<Person>);
            Assert.IsInstanceOfType(People, expected);
        }

        [TestMethod]
        public void CheckAddressType()
        {
            Type expected = typeof(List<string>);
            Assert.IsInstanceOfType(Addresses, expected);
        }

        [TestMethod]
        public void ReadFileTest()
        {
            CollectionAssert.AllItemsAreNotNull(People);
        }
        
        [TestMethod]
        public void GetFirstNameFrequencyTest()
        {
            CollectionAssert.AllItemsAreUnique(Processor.GetFirstNameFrequency(People));
        }

        [TestMethod]
        public void GetLastNameFrequencyTest()
        {
            CollectionAssert.AllItemsAreUnique(Processor.GetLastNameFrequency(People));
        }

        [TestMethod]
        public void GetFullNameTest()
        {
            CollectionAssert.AllItemsAreNotNull(Processor.GetFullName(People));
        }

        [TestMethod]
        public void GetSortedAddressesTest()
        {
            CollectionAssert.AllItemsAreNotNull(Processor.GetSortedAddresses(People));
        }
    }
}
