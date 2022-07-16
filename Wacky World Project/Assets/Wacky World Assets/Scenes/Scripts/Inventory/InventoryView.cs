using UnityEngine;

namespace Inventory
{
    [RequireComponent(typeof(GUILayout))]
    public class InventoryView : MonoBehaviour
    {
        public int Size = 3;
        private GameObject[] items;
        private InventoryIcon[] icons;
        private int previousCount;
        [SerializeField] public Sprite disabledIcon,enabledIcon;
    

        // Start is called before the first frame update
        void Awake()
        {
            items = new GameObject[Size];
            CreateInventoryItems();
            icons = GetComponentsInChildren<InventoryIcon>();
            Collected(0);
        }


        private void CreateInventoryItems()
        {
            for (int i = 0; i < Size; i++)
            {
                items[i] = Create(transform);
            }
        }

        private GameObject Create( Transform parent)
        {
            var go = Instantiate(new GameObject(), parent);
            var icon = go.AddComponent<InventoryIcon>();
            icon.enabledIcon = enabledIcon;
            icon.DisabledIcon = disabledIcon;
            return go;
        }

        public void Increment()
        {
            Collected(previousCount + 1);
        }

        public void Collected(int n)
        {
            previousCount = n;
            for (int i = 0; i < Size; i++)
            {
                if (i < n)
                {
                    icons[i].SetActiveImage();
                    continue;
                }

                icons[i].SetInactiveImage();
            }
        }
    }
}