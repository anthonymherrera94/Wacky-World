using UnityEngine;
using UnityEngine.Events;

namespace Movement
{
    public class Groundable : MonoBehaviour
    {
//TODO: Remove this, since Jumper.Groundtrigger replaced it
        public bool grounded;
        public UnityEvent onGround;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                onGround?.Invoke();
                grounded = true;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                grounded = false;
            }
        }
    }
}