using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Linq
{
    [TestClass]
    public class StringLinqTests
    {
        [TestMethod]
        public void CharOccurenceinString()
        {
            Assert.AreEqual(3, "foohaaabooo".ToCharArray().Where(c => c == 'a').Count());
            Assert.AreEqual(5,CharOccurInString("foohaaabooo", 'o'));
            Assert.AreEqual(3, CharOccurInString("foohaaabooo", 'a'));
            Assert.AreEqual(0, CharOccurInString("foohaaabooo", 'k'));

            Assert.AreEqual(1, IndexesOfCharInstring("foohaaabooo",'f').Count);
            Assert.AreEqual(5, IndexesOfCharInstring("foohaaabooo", 'o').Count);

            
        }


        public int CharOccurInString(string inp, char character)
        {
            if (inp != null) return inp.ToCharArray().Where(c => c == character).Count();
            return 0;
        }

        public List<int> IndexesOfCharInstring(string inp, char character)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < inp.ToCharArray().Length; i++)
            {
                if(character == inp.ToCharArray()[i])
                    indexes.Add(i);    
            }
            
            return indexes;
        }
    }
}
