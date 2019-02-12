using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assesment
{
    [TestClass]
    public class FibonnaciTests
    {
        [TestMethod]
        public void RecursiveTest()
        {
            for (int i = 1; i <= 100; i++)
            {
                Debug.Print(RecursiveFib(i).ToString());
            }
         Assert.IsTrue(true);
        }

        [TestMethod]
        public void FibonaciTest()
        {
            int fib = 0;
            int n1 = 0;
            int n2 = 0;
            for (int i = 1; i <= 100; i++)
            {
                if (fib == 0)
                {
                    n2 = 0;
                    fib = 0;

                }else if (fib == 1)
                {
                    n1 = 1;
                    fib = 1;
                }
                else
                {
                    fib = n2 + n2;
                    n1 = n2;
                    n2 = fib;
                }

                Debug.Print("["+ i + "] : fib: " + fib);

            }    
        }

        private int RecursiveFib(int n)
        {
            if (n < 2)
                return n;
            else
                return RecursiveFib(n-1)+ RecursiveFib(n - 2);
        }
   }

}
