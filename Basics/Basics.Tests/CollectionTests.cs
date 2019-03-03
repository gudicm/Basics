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
    }
}
