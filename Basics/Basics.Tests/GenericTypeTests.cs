using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Tests
{
    /// <summary>
    /// Summary description for GenericTypeTests
    /// </summary>
    [TestClass]
    public class GenericTypeTests
    {
        public GenericTypeTests()
        {

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
        public void TestGenericVariable()
        {
            dynamic variable = "foo";

            variable = 15;


        }

        [TestMethod]
        public void TestGenericTypeReturnTest()
        {
            Person p = (Person)GetGenericPerson(1, "John", "Smith", "No name street 13", 27);
            Assert.AreEqual(1, p.Id);
            Assert.AreEqual("John", p.FirstName);

            p = GetGenericPerson2(2, "Bob", "Doe", "No name street 13", 29);
            Assert.AreEqual(2, p.Id);
            Assert.AreEqual("Bob", p.FirstName);

        }

        public object GetGenericPerson(int id, string first, string last, string addr,int age)
        {
            return new Person()
            {
                FirstName = first,LastName = last,Id = id,Address = addr,Age = age
            };
        }

        [TestMethod]
        public void TestGenericClassWtihGenericMembers()
        {
            var str = new GenericStructure();
            str.Item1 = "foo";
            str.Item2 = 2;
            Assert.AreEqual("foo", str.Item1);

            str.Item1 = 3;
            str.Item2 = "blah";
            Assert.AreEqual(3, str.Item1);
        }

        public dynamic GetGenericPerson2(int id, string first, string last, string addr, int age)
        {
            return new Person()
            {
                FirstName = first,
                LastName = last,
                Id = id,
                Address = addr,
                Age = age
            };
        }
        internal class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public int Age { get; set; }
        }

        internal class GenericStructure
        {
            public object Item1{ get; set; }
            public object Item2 { get; set; }
            
        }
    }
}
