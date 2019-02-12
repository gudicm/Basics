using System;
using System.Data.Entity;
using System.Linq;
using EFEntities.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFEntities.Tests
{
    [TestClass]
    public class LinQTests
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
        public void TestFilter()
        {
            Assert.IsTrue(_context.Person.Any()); 
            Assert.AreEqual("Ken", _context.Person.First().FirstName);
            Assert.AreEqual("Terri", _context.Person.Where(p => p.BusinessEntityID == 2).First().FirstName);
            Assert.AreEqual("Michael", _context.Person.Where(p => p.PersonType == "EM" && p.LastName == "Sullivan").FirstOrDefault().FirstName); ;
            Assert.AreEqual("Erickson", _context.Person.Find(5).LastName);
            Assert.AreEqual("5", _context.Person.Take(5).Count()); // Take(5) as TOP 5
            Assert.AreEqual("5", _context.Person.Take(5).Count()); // Take(5) as TOP 5

            Assert.AreEqual("Alexandria",
                _context.Person.Where(p => p.EmailPromotion == 1).Where(p => p.LastName == "Bradley").First().FirstName);
        }

        [TestMethod]
        public void TestFilterAndOrder()
        {
            var firstName = _context.Person.Where(p => p.LastName == "Bradley")
                .Where(p => p.PersonType == "IN")
                .OrderByDescending(p => p.BusinessEntityID).First().FirstName;
            Assert.AreEqual("Chloe", firstName);


        }

        [TestMethod]
        public void TestSelect()
        {
            // select method is used to filter attribs in list
            // select with anonymous
             var personView = _context.Person.Where(p=>p.BusinessEntityID==10).Select(i=>new {i.FirstName, i.LastName, i.PersonType});
             Assert.AreEqual("Michael",personView.First().FirstName);
             Assert.AreEqual("Raheem", personView.First().LastName);
             Assert.AreEqual("EM", personView.First().PersonType);


            // select with anonymous SelectListItem
           var pView =  _context.Person.Where(p => p.BusinessEntityID == 10).Select(p => new {Ime = p.FirstName, Prezime = p.LastName, Tip = p.PersonType});
           Assert.AreEqual("Michael", pView.First().Ime);
           Assert.AreEqual("Raheem", pView.First().Prezime);
           Assert.AreEqual("EM", pView.First().Tip);

        }

        [TestMethod]
        public void TestInnerJoin()
        {
            var vEmails = _context.Person.Join(_context.EmailAddress, p => p.BusinessEntityID, e => e.BusinessEntityID,
                (p, e) => new {p.FirstName, p.LastName, e.EmailAddress1, e.BusinessEntityID}).Where(p=>p.BusinessEntityID == 293);

            Assert.AreEqual(1, vEmails.Count());
            Assert.AreEqual("Abel",vEmails.First().LastName);
        }
    

    }
}
