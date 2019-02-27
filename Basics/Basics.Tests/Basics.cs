using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Tests
{
    /// <summary>
    /// Summary description for Basics
    /// </summary>
    [TestClass]
    public class Basics
    {
        [TestMethod]
        public void ConvertionTest()
        {
            char c = Convert.ToChar(64);
            Debug.Print(c.ToString());
            Assert.AreEqual("@",c.ToString());
            Assert.AreEqual('@', c);

            Assert.AreEqual("64",Convert.ToString(64));
            Assert.AreEqual((decimal)(64.1), Convert.ToDecimal("64,1"));
            Assert.AreEqual((double)(64.1), Convert.ToDouble("64,1"));

            // to decimal string with dot
            //value.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
             Assert.AreEqual("64.20",(64.20).ToString("0.00", CultureInfo.InvariantCulture));
            
            //check if string is nber
            int n;
            bool isNumeric = int.TryParse("10", out n);
            Assert.IsTrue(isNumeric);
            isNumeric = int.TryParse("10.2", out n);
            Assert.IsFalse(isNumeric);

   
            double nd;
            bool isDouble = double.TryParse("10.10", out nd);
            Assert.IsTrue(isDouble);
            isNumeric = double.TryParse("zz", out nd);
            Assert.IsFalse(isDouble);

        }
    }
}
