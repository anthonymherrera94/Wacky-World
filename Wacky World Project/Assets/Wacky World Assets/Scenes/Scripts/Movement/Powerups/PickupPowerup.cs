using UnityEngine;
using UnityEngine.Events;

namespace Movement.Powerups
{
    public class PickupPowerup : MonoBehaviour
    {
        public PowerupVisitor slow;
        public float speedFactor;

        public float duation;
        [SerializeField] public UnityEvent onCollect
            = new UnityEvent();

        private void Start()
        {
            slow = new Slow(speedFactor, duation);
        }

        private void OnTriggerEnter(Collider other)
        {
            PowerupVisitable vistable = other.gameObject.GetComponentInChildren<PowerupVisitable>() ??
                                        other.gameObject.GetComponentInParent<PowerupVisitable>() ??
                                        other.gameObject.GetComponent<PowerupVisitable>();
            if (vistable == null)
            {
                Debug.Log("No visitable to receive" + slow);
                return;
            }

            onCollect?.Invoke();
            vistable.Accept(slow);
            gameObject.SetActive(false);
        }
    }
}