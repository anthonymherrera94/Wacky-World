using UnityEngine;

namespace Triggers
{
    public class ResetTrigger : MonoBehaviour {
    
        public Transform spawnPoint;
    
        public void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                var parent = other.transform.parent;
                parent.position = spawnPoint.position;
                parent.rotation = spawnPoint.rotation;
                var rb = parent.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
