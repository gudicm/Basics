using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Tests
{
    [TestClass]
    public class AttributesTests
    {
        //public int OnInitValue1 { get; set; }
        //public int OnInitValue2 { get; set; }
        private int _value1 = 0;
        private int _value2 = 0;


        public AttributesTests()
        {
            _value1 = 5;

        }

        [TestInitialize]
        private void Init()
        {
            _value2 = 6;
        }

        [TestCleanup]
        private void Clean()
        {
         }

        [TestMethod]
        public void SimpleOutput()
        {
            Debug.WriteLine("foo");
        }

        [TestMethod]
        public void OnInitValues()
        {
            Console.WriteLine("with constructor _value1 =   " + _value1);
            Console.Write("with TestInit _value2 = " + _value2);
        }


    }
}
