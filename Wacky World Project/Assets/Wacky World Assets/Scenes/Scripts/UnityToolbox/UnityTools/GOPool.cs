using UnityEngine;
using UnityToolbox.Tools;

namespace UnityToolbox.UnityTools
{
    public class GOPool : MonoBehaviour
    {
        public GameObject[] types;
        public int poolSize = 50;
        protected ObjectPool<GameObject> pool;

        protected virtual void Awake()
        {
            pool = new ObjectPool<GameObject>(poolSize);
        }

        protected virtual void Start()
        {
            CreatePool();
        }

        public GameObject PopDeactivatedObjectOrReturnNull()
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject item = pool.GetItem(i);
                if (!item.activeInHierarchy)
                {
                    return item;
                }
            }

            return null;
        }

        private void CreatePool()
        {
            int numberOfTypes = types.Length;
            for (int i = 0; i < poolSize; i++)
            {
                GameObject currentPrefab = types[i % numberOfTypes];
                GameObject item = Instantiate(currentPrefab);
                item.SetActive(false);
                pool.SetItem(i, item);
            }
        }
    }
}