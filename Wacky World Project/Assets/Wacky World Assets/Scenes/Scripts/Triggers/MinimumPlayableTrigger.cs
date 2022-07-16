using UnityEngine;

namespace Triggers
{
    public class MinimumPlayableTrigger : MonoBehaviour {

        public Transform Player;
        public Transform SpawnPoint;

        private void FixedUpdate() {
            // TODO: Create a better way for getting the players data
            if (Player.position.y < transform.position.y) {
                Player.position = SpawnPoint.position;
                Player.rotation = SpawnPoint.rotation;
                var rb = Player.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
