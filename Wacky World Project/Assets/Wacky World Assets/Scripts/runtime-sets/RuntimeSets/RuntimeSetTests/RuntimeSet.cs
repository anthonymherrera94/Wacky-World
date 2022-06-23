using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RuntimeSets.RuntimeSetTests
{
    [CreateAssetMenu]
    public class RuntimeSet : ScriptableObject
    {
        [SerializeField] private List<GameObject> myset = new List<GameObject>();
        public Texture2D previewIcon;
        public UnityEvent onRegister, onDeregister, onChange;
        public int Length => myset.Count;

        public void Register(GameObject addition)
        {
            myset.Add(addition);
            onRegister?.Invoke();
            onChange?.Invoke();
        }

        public List<GameObject> GetSet()
        {
            return myset;
        }

        public void Deregister(GameObject gameObject)
        {
            myset.Remove(gameObject);
            onDeregister?.Invoke();
            onChange?.Invoke();
        }
    }
}