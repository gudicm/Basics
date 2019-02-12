using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XML.Tests
{
    [TestClass]
    public class XmlValidateTests
    {
        private string currtPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

        


        [TestMethod]
        public void CurrentPathTest()
        {
            var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Debug.Print(path);
        }

        [TestMethod]
        public void ReadXMLTests()
        {

            var xmlPath = Path.Combine(currtPath, "data");
            xmlPath = Path.Combine(xmlPath, "GolfCountryClub");
            xmlPath = Path.Combine(xmlPath, "GolfCountryClub.xml");

            if (File.Exists(xmlPath))
            {
                var xDoc = XDocument.Load(xmlPath);
                Debug.Print(xDoc.ToString()); ;
            }



        }

        [TestMethod]
        public void XmlWellFormedTest()
        {
           
            var xmlPath = Path.Combine(currtPath, "data");
            xmlPath = Path.Combine(xmlPath, "GolfCountryClub");
            xmlPath = Path.Combine(xmlPath, "GolfCountryClub.xml");

            try
            {
                var xDoc = XDocument.Load(xmlPath);
                Debug.Print("XMLdata well formed!!!"); ;

            }
            catch (XmlException ex)
            {
                
                Debug.Print("Line:"+ex.LineNumber + "," +ex.LinePosition + ":Message:" + ex.Message);
            }
            
        }

        [TestMethod]
        public void XmlWellFormedInvalidTest()
        {

            var xmlPath = Path.Combine(currtPath, "data");
            xmlPath = Path.Combine(xmlPath, "GolfCountryClub");
            xmlPath = Path.Combine(xmlPath, "GolfCountryClubInvalid.xml");

            try
            {
                var xDoc = XDocument.Load(xmlPath);
                Debug.Print("XMLdata well formed!!!"); ;

            }
            catch (XmlException ex)
            {

                Debug.Print("Line:" + ex.LineNumber + "," + ex.LinePosition + ":Message:" + ex.Message);
            }

        }
    }
}
