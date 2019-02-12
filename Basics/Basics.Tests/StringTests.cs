using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Tests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void TestsProperties()
        {
           Assert.AreEqual(5, "hello".Length);
           Assert.AreEqual(3, "foo".Length);

            string s = "hello";
            Assert.AreEqual('h', s[0]);
            Assert.AreEqual('e', s[1]);
            Assert.AreEqual('l', s[2]);
            Assert.AreEqual('l', s[3]);
            Assert.AreEqual('o', s[4]);

        }

        [TestMethod]
        public void TestsMethods()
        {
            var clone = "hello".Clone();
            Assert.AreEqual("hello",clone);

            
            // contains substring
            Assert.IsTrue("foo".Contains("foo"));
            Assert.IsTrue("testing".Contains("tin"));
            Assert.IsFalse("foo".Contains("ao"));

            // Substring
            Assert.AreEqual("ing","testing".Substring(4));
            Assert.AreEqual("la", "hulahula".Substring(6));
            
            // Equals compare values of string with another string value
            string s1 = "foo";
            string s2 = "foo";
            string s3 = "fao";
            Assert.IsTrue(s1.Equals(s2)); 
            Assert.IsFalse(s1.Equals(s3));

            //substring returns substring defined by range
            Assert.AreEqual("Twoo", "OneTwooThree".Substring(3,4));
            // Split(Parse) splits string by delimiter characters defined
            char[] delimiterChars = { ';', ',', '.', ':' };
            var arrayString = "One;Twoo:Three,Four".Split(delimiterChars);
            Assert.AreEqual("One",arrayString.ElementAt(0));
            Assert.AreEqual("Three", arrayString.ElementAt(2));

            // IndexOf check is substring or character within string
            s1 = "Your dog is cute.";
            Assert.IsTrue(s1.IndexOf("dog")!=-1);
            s1 = "Your dog is cute.";
            Assert.IsTrue(s1.IndexOfAny(new char[] {'d','Y'}) != -1);

        }

        // LINQ methos on string simple data type 
        [TestMethod]
        public void TestsMethodExtensions()
        {
            string s = "testing";
            var enumerable = "hello".ToCharArray().Where(c => c == 'l');
            Assert.IsTrue(enumerable.Any());
            Assert.AreEqual(2,enumerable.Count());

            Assert.IsTrue("testing".Any());
            Assert.IsTrue("eeeeeeee".All(c => c == 'e')) ;
            // reverse string
            Assert.AreEqual("olleh", String.Concat("hello".Reverse()));
            // sorting string by linq
            Assert.AreEqual("ehllo", String.Concat("hello".OrderBy(c=>c)));
            Assert.AreEqual("ollhe", String.Concat("hello".OrderByDescending(c => c)));
            // index with LINQ
            Assert.AreEqual('e',s.ElementAt(1));
            
        }

        [TestMethod]
        public void TestsRegex()
        {
            //Regex.Match(InputStr, Pattern, RegexOptions)
            //RegexOptions.Compiled 
            //RegexOptions.IgnoreCase 
            //RegexOptions.Multiline
            //RegexOptions.RightToLeft
            //RegexOptions.Singleline
            // date pattern
            string pattern = @"([a-zA-Z]+) (\d+)";
            Assert.IsTrue(Regex.IsMatch("June 24",pattern));
            // ip address
            pattern = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
            Assert.IsTrue(Regex.IsMatch("0.0.0.0", pattern));
            Assert.IsTrue(Regex.IsMatch("255.255.255.0", pattern));
            Assert.IsTrue(Regex.IsMatch("192.168.0.136", pattern));

            Assert.IsFalse(Regex.IsMatch("256.1.3.4", pattern));
            Assert.IsFalse(Regex.IsMatch("023.44.33.22", pattern));
            Assert.IsTrue(Regex.IsMatch("10.57.98.23", pattern));

            Assert.IsTrue(Regex.IsMatch("Testing", "ING", RegexOptions.IgnoreCase));


        }
    }
}
