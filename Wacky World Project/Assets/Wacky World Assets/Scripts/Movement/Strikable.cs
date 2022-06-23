using UnityEngine;
using UnityEngine.Events;

namespace Movement
{
    public class Strikable : MonoBehaviour
    {
        [SerializeField] private UnityEvent onStruck;

        public void Struck()
        {
            onStruck?.Invoke();
        }
    }
}