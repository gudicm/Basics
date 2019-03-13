using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Tests
{
    /// <summary>
    /// Summary description for CollectionTests
    /// </summary>
    [TestClass]
    public class CollectionTests
    {
        public IList<Person> Persons { get; set; }
        public IList<Employee> EmployeesData { get; set; }

        [TestInitialize]
        public void Init()
        {
            Persons = new List<Person>()
            {
                new Person() {Id = 1, Age = 30, FirstName = "John", LastName = "Doe", Gender = 'M'},
                new Person() {Id = 2, Age = 55, FirstName = "Mary", LastName = "Smith", Gender = 'F'},
                new Person() {Id = 3, Age = 33, FirstName = "Lucky", LastName = "Luck", Gender = 'M'},
                new Person() {Id = 4, Age = 30, FirstName = "Mia", LastName = "Vega", Gender = 'F'},
                new Person() {Id = 5, Age = 45, FirstName = "Bob", LastName = "Jones", Gender = 'M'}
            };

            EmployeesData = new List<Employee>()
            {
                new Employee() {Id = 1, JobRole = "CTO", OrganizationUnit = "HQ", PersonId = 1},
                new Employee() {Id = 2, JobRole = "CFO", OrganizationUnit = "HQ", PersonId = 2},
                new Employee() {Id = 3, JobRole = "Worker", OrganizationUnit = "Industry", PersonId = 3},
                new Employee() {Id = 2, JobRole = "Worker", OrganizationUnit = "Industry", PersonId = 4},
                new Employee() {Id = 3, JobRole = "Worker", OrganizationUnit = "Industry", PersonId = 3},
            };
        }

        [TestCleanup]
        public void Dispose()
        {
            Persons = null;
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestCollectionList()
        {

            IList<String> l = new List<string>();
            l.Add("foo1");
            l.Add("foo2");
            Assert.AreEqual(2,l.Count);
            Assert.AreEqual("foo2",l[1]);

            // enumerable to list
            IEnumerable<string> eStr = new List<string>() {"one", "two","three"};
            var lStr =  eStr.ToList();
            lStr.Add("four");
            Assert.AreEqual(4, lStr.Count());
            Assert.AreEqual("four", lStr.Last());

        }

        [TestMethod]
        public void TestSortOrderBySelect()
        {
            Assert.IsNotNull(Persons);
            Assert.IsTrue(Persons.Count == 5);
            Persons.Add(new Person() { Id = 6, Age = 45, FirstName = "Little", LastName = "John", Gender = 'M' });
            Assert.IsTrue(Persons.Count == 6);

            // querying a list
            var qList = Persons.AsEnumerable().Where(p => p.FirstName == "John").ToList();
            Assert.AreEqual("Doe", qList.First().LastName);

            // sorting a list
            Persons = Persons.OrderBy(p=>p.Age).ThenByDescending(p=>p.Id).ToList();
            Assert.AreEqual("Mia",Persons.First().FirstName);
            
            // selecting specific rows from list
            var lAges =  Persons.Select(p => new {p.Id, p.Age, p.Gender}).ToList();
            Assert.AreEqual(30,lAges.First().Age);

        }

        [TestMethod]
        public void TestJoinList()
        {
            var query = from p in Persons join e in EmployeesData on p.Id equals e.PersonId 
                select new { p.FirstName, p.LastName,e.JobRole,e.OrganizationUnit};

            Console.WriteLine(String.Format("{0}:{1}",query.First().LastName, query.First().OrganizationUnit));
        }
    }
    
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string JobRole { get; set; }
        public string OrganizationUnit { get; set; }
    }
}
