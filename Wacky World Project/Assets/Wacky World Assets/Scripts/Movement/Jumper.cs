using System;
using UnityEngine;
using UnityEngine.Events;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody), typeof(Groundable))]
    public class Jumper : MonoBehaviour
    {
        [SerializeField] public GroundedTrigger Trigger;
        private Rigidbody rb;

        [Range(1, 20)] public float jumpForce = 5;

        // private bool grounded => groundable.grounded;
        // private Groundable groundable;
        public UnityEvent onJump;

        public float Tolerance = 0.1f;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            // groundable = GetComponent<Groundable>();
        }

        private float _lastJump = 0.0f;

        public void Jump()
        {
            if (Trigger.IsGrounded && Time.realtimeSinceStartup - _lastJump > Tolerance)
            {
                onJump?.Invoke();
                _lastJump = Time.realtimeSinceStartup;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}