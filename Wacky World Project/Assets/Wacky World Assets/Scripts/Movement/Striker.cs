using UnityEngine;
using UnityEngine.Events;

namespace Movement
{
    public class Striker : MonoBehaviour
    {
        [SerializeField] private Transform strikePoint;
        [SerializeField] private float distance = 1;
        [SerializeField] private UnityEvent onStrike;
        public float radius = 0.5f;

        public void Strike()
        {
            RaycastHit hit = new RaycastHit();
            // if (Physics.SphereCast(strikePoint.transform.position, radius, transform.forward, out hit, distance)
            // )
            if (Physics.Raycast(strikePoint.transform.position, transform.forward, out hit, distance)
               )
            {
                onStrike?.Invoke();
                var strikable = hit.collider.GetComponent<Strikable>();
                strikable?.Struck();
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (strikePoint == null)
            {
                return;
            }

            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(strikePoint.position + transform.forward * distance, radius);
            // Gizmos.DrawLine(strikePoint.position, strikePoint.position + transform.forward * distance);
        }
    }
}