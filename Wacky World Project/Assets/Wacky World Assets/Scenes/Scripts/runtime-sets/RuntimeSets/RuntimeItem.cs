using UnityEngine;

namespace RuntimeSets
{
    public class RuntimeItem : MonoBehaviour
    {
        [SerializeField] private RuntimeSet set;

        private void OnEnable()
        {
            set.Register(gameObject);
        }

        private void OnDisable()
        {
            set.Deregister(gameObject);
        }
    }
}