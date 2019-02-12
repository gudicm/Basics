using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exam.Tests
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Remove Alternate Duplicate characters from a char array you have to do it in Place.Like keeping only the odd occurences of each character.
        /// </summary>
        [TestMethod]
        public void KeppOddinCharacterStreamTest()
        {
            string test = "fooboohhhaaaa";
            foreach (var character in test.ToCharArray())
            {
                Console.Write(character);
            }

        }

        public string RemoveAlternateDuplicateCharacters(string inp)
        {
            string alternate = String.Copy(inp);

            return alternate;
        }
    }

}
