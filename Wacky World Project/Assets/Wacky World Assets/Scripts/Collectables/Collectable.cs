using System.Linq;
using PlayerManagement;
using UnityEngine;

namespace Collectables {
    // MARK: Not sure we really need the collectable system for nuggets. Maybe for objective items in the near future though
    [RequireComponent(typeof(Collider))]
    public class Collectable : MonoBehaviour {
        
        public string CollectableName;
        public int CollectableCount;

        public void OnTriggerEnter(Collider collider) {
            if (collider.tag == "Player") {
                Collector c = collider.GetComponent<Collector>();
                if (c.ItemMask.Contains(CollectableName))
                {
                    c.Add(CollectableName, CollectableCount);


                    GameObject.Destroy(gameObject); // TODO: Do a collection animation or something

                    PlayerManager.Instance.Score += 20;
                }
            }
        }

    }
}
