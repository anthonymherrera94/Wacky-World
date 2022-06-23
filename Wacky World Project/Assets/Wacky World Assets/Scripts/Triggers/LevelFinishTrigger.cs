using Managers;
using UnityEngine;

namespace Triggers
{
    public class LevelFinishTrigger : MonoBehaviour {
    
    
        public void OnTriggerEnter(Collider collider) {
            if (collider.tag == "Player") {
                GameManager.Instance.CompleteLevel();
            }
        }
    }
}
