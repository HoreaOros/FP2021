using Microsoft.VisualStudio.TestTools.UnitTesting;
using _11_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_03.Tests
{
    [TestClass()]
    public class IntExtensionTests
    {
        [TestMethod()]
        public void IsPalindromeTest()
        {
            // arrange
            int n = 1231;
            bool expected = false;
            bool actual;

            // act 
            actual = n.IsPalindrome();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}