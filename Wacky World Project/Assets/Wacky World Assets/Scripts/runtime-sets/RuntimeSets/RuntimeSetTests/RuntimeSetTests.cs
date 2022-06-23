using NUnit.Framework;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

namespace RuntimeSets.RuntimeSetTests
{
    public class RuntimeSetTests
    {
        private GameObject first;

        [SetUp]
        public void CreateStuff()
        {
            first = new GameObject();
        }

        [Test]
        public void AddToSet()
        {
            RuntimeSet gos = new RuntimeSet();
            gos.Register(first);
            Assert.IsTrue(gos.Length > 0);
        }

        [Test]
        public void RemoveFromSet()
        {
            RuntimeSet gos = new RuntimeSet();
            gos.Register(first);
            gos.Deregister(first);
            Assert.AreEqual(0, gos.Length);
        }
    }
}