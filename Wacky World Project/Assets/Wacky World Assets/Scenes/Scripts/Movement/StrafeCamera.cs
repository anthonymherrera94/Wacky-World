using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class StrafeCamera : MonoBehaviour {
    
        private Rigidbody _rb;
        public float Accel;
        public float DistanceFromPlayer;
        public Transform Cam;

        private void Start() {
            _rb = GetComponent<Rigidbody>();
            Cam.parent = null;
        }

        private Vector3 _targetPosition;
        private Vector3 _actualPosition;
        public void Update() {

            // float x = Mathf.Pow(_rb.velocity.x * SwayFactor, 2) * -Mathf.Sign(_rb.velocity.x);
            // float z = Mathf.Pow(_rb.velocity.z * SwayFactor, 2) * -Mathf.Sign(_rb.velocity.z);

            Cam.rotation = Quaternion.Euler(60, 0, 0);
        
            // Cam.Rotate(new Vector3(z, 0, 0), Space.Self);
            // Cam.Rotate(new Vector3(0, -x, 0), Space.Self);
            // Cam.Rotate(new Vector3(-30, 0, 0));

            _targetPosition = transform.position + (-Cam.forward * DistanceFromPlayer);

            Vector3 delta = (_targetPosition - _actualPosition);// * Mathf.Clamp(Accel * Time.deltaTime, 0, 1);
            _actualPosition += delta;
            Cam.position = _actualPosition;
        }

    }
}
