using UnityEngine;

namespace Movement
{
    public class GroundedTrigger : MonoBehaviour {
    
        public bool IsGrounded {
            get => accum > 0;
        }

        private int accum = 0;
        public void OnTriggerEnter(Collider collider) {
            if (collider.tag == "Ground")
                accum++;
        }
        public void OnTriggerExit(Collider collider) {
            if (collider.tag == "Ground")
                accum--;
        }

        // private void Update() {
        //     Debug.Log($"{accum}");
        // }

    }
}
