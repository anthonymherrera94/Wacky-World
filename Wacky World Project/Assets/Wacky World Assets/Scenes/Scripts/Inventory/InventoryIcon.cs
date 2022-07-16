using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    [RequireComponent(typeof(Image))]
    public class InventoryIcon : MonoBehaviour
    {
        private Image image;
        [SerializeField] public Sprite enabledIcon,DisabledIcon;
        public bool ImageIsActive { get; set; }

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void SetActiveImage()
        {
            ImageIsActive = true;
            image.sprite = enabledIcon;
        }

        public void SetInactiveImage()
        {
            ImageIsActive = false;
            image.sprite = DisabledIcon;
        }

    }
}
