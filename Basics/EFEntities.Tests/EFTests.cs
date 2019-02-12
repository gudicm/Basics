using System;
using System.Linq;
using EFEntities.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFEntities.Tests
{
    [TestClass]
    public class EFTests
    {
        private AwPersonDbContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            _context = new AwPersonDbContext();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public void TestSimple1()
        {
            using (_context)
            {
                Assert.AreEqual(87,_context.Person.Count(p => p.LastName == "Miller"));
                Assert.AreEqual("Abigal", _context.Person.First(p => p.LastName == "Miller").FirstName.ToString());
                         }
        }
    }
}
