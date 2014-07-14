using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BetterThanNull.Tests
{
    [TestClass]
    public class Definitely
    {
        [TestMethod]
        public void ConstructorThrowsOnNull()
        {
            try
            {
                var definitely = new Definitely<object>(null);
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Creating Definitely with a null object should throw an ArgumentNullException.");
        }

        [TestMethod]
        public void ImplicitCastThrowsOnNull()
        {
            try
            {
                Definitely<object> unpacked = null;
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Implicitly casting a null to Definitely should throw an ArgumentNullException.");
        }

        [TestMethod]
        public void StoresValue()
        {
            object obj = new object();
            var definitely = new Definitely<object>(obj);
            Assert.AreEqual(obj, definitely.Value);
        }

        [TestMethod]
        public void ThrowsOnDefaultConstructor()
        {
            try
            {
                var definitely = new Definitely<object>();
            }
            catch (NotSupportedException)
            {
                return;
            }

            Assert.Fail("Creating Definitely with the default constructor should throw a NotSupportedException.");
        }
    }
}