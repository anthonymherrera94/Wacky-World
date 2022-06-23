using UnityEngine;

namespace PlayerManagement
{
    public struct MeterSegment {
        public Vector2 InitalMax, InitalMin;
        public RectTransform Rect;

        public MeterSegment(RectTransform rect) {
            Rect = rect;
            InitalMax = Rect.offsetMax;
            InitalMin = Rect.offsetMin;
        }

        public void UpdateHealthMeter(float percent) {
            // MARK: Idk if we are making it so health could be like super charged or some shit but
            // if we do we can take it into account and make the color start to flash or pulse or something.

            // For Vertical
            // Rect.offsetMax = new Vector2(InitalMax.x, InitalMin.y + ((InitalMax.y - InitalMin.y) * percent));

            // For Horizontal
            Rect.anchorMin = new Vector2(1.0f - Mathf.Clamp(percent, 0, 1), 0);
            // Rect.offsetMin = new Vector2(InitalMax.x + ((InitalMin.x - InitalMax.x) * percent), InitalMin.y);
        }
    }
}