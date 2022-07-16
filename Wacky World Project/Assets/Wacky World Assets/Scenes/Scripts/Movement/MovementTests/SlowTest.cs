using System.Collections;
using Movement.Powerups;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Movement.MovementTests
{
    public class SlowTest
    {
        Translator translator;
        GameObject gameObject;

        private GameObject powerup;
        private float initialSpeed;
        public IEnumerator Setup()
        {
            yield return CreateTranslator();
        }

        [UnityTearDown]
        public IEnumerator DestoryAll()
        {
            foreach (GameObject o in GameObject.FindObjectsOfType<GameObject>())
            {
                GameObject.Destroy(o);
            }

            yield return null;
        }

        [UnityTest]
        public IEnumerator SlowTestWithEnumeratorPasses()
        {
            yield return CreateTranslator();
            Assert.IsTrue(translator.currentSpeed != 0);
            yield return null;
        }

        [UnityTest]
        public IEnumerator CreatePowerUpOkay()
        {
            yield return CreatePowerUp();
        }
        [UnityTest]
        public IEnumerator SpeedChangesOnCollision()
        {
            yield return CreateTranslator();
            yield return CreatePowerUp();
            gameObject.transform.position = Vector3.one;
            powerup.transform.position = Vector3.one;
            yield return null;
            yield return null;
            // Assert.IsFalse(powerup.activeInHierarchy);
            Assert.AreNotEqual(initialSpeed, translator.currentSpeed);
            yield return null;
        }

        private IEnumerator CreatePowerUp()
        {
            powerup = GameObject.Instantiate(new GameObject());
            var pickupPowerup = powerup.AddComponent<PickupPowerup>();
            pickupPowerup.slow = new Slow(3, 2);
            powerup.AddComponent<BoxCollider>().isTrigger = true;
            yield return null;
            pickupPowerup.slow = new Slow(3, 2);
            yield return null;
        }

        private IEnumerator CreateTranslator()
        {
            gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            translator = gameObject.AddComponent<Translator>();
            yield return null;
            initialSpeed = translator.currentSpeed;
            yield return null;
        }
    }
}