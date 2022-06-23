using UnityEngine;
using UnityEngine.Events;

namespace General_Events
{
    public class OnCollisionWithTag : MonoBehaviour
    {
        [SerializeField] private string otherTag = "Player";
        public UnityEvent onCollision;

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag(otherTag))
            {
                onCollision?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(otherTag))
            {
                onCollision?.Invoke();
            }
        }
    }
}

