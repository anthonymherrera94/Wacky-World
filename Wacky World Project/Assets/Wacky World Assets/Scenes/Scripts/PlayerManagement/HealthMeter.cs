using UnityEngine;

namespace PlayerManagement {
    public class HealthMeter : MonoBehaviour {
        
        public float Accel;
        [SerializeField] private RectTransform Rect1, Rect2, Rect3;

        private MeterSegment Segment1, Segment2, Segment3;

        private float ActualHealth = 3;
        private float TargetHealth = 3;

        public void Start() {
            Segment1 = new MeterSegment(Rect1);
            Segment2 = new MeterSegment(Rect2);
            Segment3 = new MeterSegment(Rect3);
            PlayerManager.Instance.OnHealthChanged += x => TargetHealth = x;
        }
        
        private void FixedUpdate() {
            ActualHealth = ActualHealth + (TargetHealth - ActualHealth) * Time.fixedDeltaTime * Accel;
            SetHealthMeter(ActualHealth);
        }

        private void SetHealthMeter(float health) {
            Segment3.UpdateHealthMeter(Mathf.Clamp(health, 0, 1));
            health -= 1.0f;
            Segment2.UpdateHealthMeter(Mathf.Clamp(health, 0, 1));
            health -= 1.0f;
            Segment1.UpdateHealthMeter(Mathf.Clamp(health, 0, 1));
        }

    }
}
