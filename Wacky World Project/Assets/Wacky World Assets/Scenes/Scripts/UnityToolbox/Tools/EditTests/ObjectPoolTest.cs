using System;
using NUnit.Framework;
using UnityEngine;

namespace UnityToolbox.Tools.EditTests
{
    public class ObjectPoolTest
    {
        private const int InitialPoolLength = 10;
        private ObjectPool<GameObject> objectPool;


        [SetUp]
        public void Build()
        {
            objectPool = new ObjectPool<GameObject>(InitialPoolLength);
        }

        [TearDown]
        public void DestroyObject()
        {
            objectPool = null;
        }

        [Test]
        public void ObjectsShouldNotBeInstantiatedInitially()
        {
            for (int i = 0; i < objectPool.PoolSize; i++) Assert.Null(objectPool.GetItem(i));
        }

        [Test]
        public void SetThenGetAllShouldBeTheSame()
        {
            GameObject[] gameObjects = new GameObject[objectPool.PoolSize];
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i] = new GameObject();
                objectPool.SetItem(i, gameObjects[i]);
            }

            for (int i = 0; i < objectPool.PoolSize; i++)
            {
                GameObject got = objectPool.GetItem(i);

                Assert.AreSame(gameObjects[i], got);
            }
        }

        [Test]
        public void SetAll()
        {
            for (int i = 0; i < objectPool.PoolSize; i++)
                try
                {
                    objectPool.SetItem(i, new GameObject());
                }
                catch (Exception)
                {
                    Assert.Fail("should not be an error when setting");
                }
        }


        [Test]
        public void GetLength()
        {
            Assert.AreEqual(objectPool.PoolSize, InitialPoolLength);
        }

        [Test]
        public void SetOutOfBoundShouldThrowAnError()
        {
            Assert.Throws<PoolOutOfBoundException>(() => objectPool.SetItem(10, new GameObject()));
        }

        [Test]
        public void GetOutOfBoundShouldThrowAnError()
        {
            Assert.Throws<PoolOutOfBoundException>(() => objectPool.GetItem(10));
        }
    }
}