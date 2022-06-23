using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace UnityToolbox.UnityTools.ToolboxPlayTests
{
    public class SingletonMonoTest
    {
        GameObject gameObject;
        private TestSingletonMono singleton;

        [UnitySetUp]
        public IEnumerator CreateStuff()
        {
            gameObject = Object.Instantiate(new GameObject());
            singleton = gameObject.AddComponent<TestSingletonMono>();
            yield return null;
        }

        [UnityTearDown]
        public IEnumerator TearStuffUp()
        {
            Object.Destroy(gameObject);
            yield return null;
        }

        [UnityTest]
        public IEnumerator ShouldNotBeNull()
        {
            Assert.IsNotNull(singleton);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TwoSingletonShouldThrowException()
        {
            try
            {
                gameObject.AddComponent<TestSingletonMono>();
                // LogAssert.Expect(LogType.Exception, "");
                LogAssert.Expect(LogType.Error, "Trying to instance a second instance of singleton");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            yield return null;
        }

        public class TestSingletonMono : SingletonMonoBehaviour<TestSingletonMono>
        {
        }
    }
}