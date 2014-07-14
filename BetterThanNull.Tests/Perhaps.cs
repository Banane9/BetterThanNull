using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BetterThanNull.Tests
{
    [TestClass]
    public class Perhaps
    {
        [TestMethod]
        public void ImplicitCastFromNullProducesEmptyPerhaps()
        {
            Perhaps<object> perhaps = null;
            Assert.IsFalse(perhaps.HasValue);
        }

        [TestMethod]
        public void ImplicitlyCasts()
        {
            Perhaps<object> perhaps = new object();
            Assert.AreEqual(typeof(Perhaps<object>), perhaps.GetType());
        }

        [TestMethod]
        public void SelectWorks()
        {
            TestObject obj = new TestObject();
            Perhaps<TestObject> filledPerhaps = obj;
            obj.TestField = 15;
            Assert.AreEqual(obj.TestField, filledPerhaps.Select(testObj => testObj.TestField).Value);

            Perhaps<TestObject> emptyPerhaps = new Perhaps<TestObject>();
            Assert.IsFalse(emptyPerhaps.Select(testObj => testObj.TestField).HasValue);
        }

        [TestMethod]
        public void ThrowsOnCastOfEmpty()
        {
            try
            {
                Perhaps testPerhaps = (Perhaps)new Perhaps<Perhaps>();
            }
            catch (InvalidCastException)
            {
                return;
            }

            Assert.Fail("Cast of empty Perhaps to the Value should throw an InvalidCastException.");
        }

        private class TestObject
        {
            public int TestField;
        }
    }
}