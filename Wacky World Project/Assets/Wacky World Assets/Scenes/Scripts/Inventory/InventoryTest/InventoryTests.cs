using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Inventory.InventoryTest
{
    public class InventoryTests
    {
        GameObject go;
        InventoryView view;
        InventoryIcon[] icons;

        [UnitySetUp]
        public IEnumerator Start()
        {
            yield return CreateUI();
            yield return null;
        }

        private IEnumerator ExepectIconsActive(int active)
        {
            Assert.AreEqual(active, icons.Where(icon => icon.ImageIsActive).Count());
            yield return null;
        }

        [UnityTearDown]
        public IEnumerator Destroy()
        {
            foreach (var go in GameObject.FindObjectsOfType<GameObject>())
            {
                GameObject.Destroy(go);
            }
            yield return null;
        }

        [UnityTest]
        public IEnumerator SetupWorksCorrectly()
        {
            Assert.IsNotNull(icons);
            yield return null;
        }

        [UnityTest]
        public IEnumerator CreatesIcons()
        {
            Assert.AreEqual(3, icons.Length);
            yield return null;
        }

        [UnityTest]
        public IEnumerator IconsEqualsSize()
        {
            Assert.AreEqual(icons.Length, view.Size);
            yield return null;
        }

        [UnityTest]
        public IEnumerator NoneActiveAtStart()
        {
            Assert.AreEqual(0, icons.Where(icon => icon.ImageIsActive).Count());
            yield return null;
        }

        [UnityTest]
        public IEnumerator NoneActiveAtZero()
        {
            view.Collected(0);
            yield return ExepectIconsActive(0);
        }

        [UnityTest]
        public IEnumerator SetOneActive()
        {
            view.Collected(1);
            ExepectIconsActive(1);
            yield return null;
        }

        [UnityTest]
        public IEnumerator SetTwoActive()
        {
            view.Collected(2);
            ExepectIconsActive(2);
            yield return null;
        }

        [UnityTest]
        public IEnumerator SetThreeActive()
        {
            view.Collected(2);
            yield return ExepectIconsActive(2);
        }


        [UnityTest]
        public IEnumerator IncrementZero()
        {
            view.Increment();
            ExepectIconsActive(1);
            yield return null;
        }

        [UnityTest]
        public IEnumerator DoubleIncrementActivatesTwo()
        {
            view.Increment();
            view.Increment();
            ExepectIconsActive(2);
            yield return null;
        }

        private IEnumerator CreateUI()
        {
            go = GameObject.Instantiate(new GameObject());
            yield return null;
            go.AddComponent<HorizontalLayoutGroup>();
            view = go.AddComponent<InventoryView>();
            yield return null;
            yield return null;
            icons = go.GetComponentsInChildren<InventoryIcon>();
            yield return null;
        }
    }
}