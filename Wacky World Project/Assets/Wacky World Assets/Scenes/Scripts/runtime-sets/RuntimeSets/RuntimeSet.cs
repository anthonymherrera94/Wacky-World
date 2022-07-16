using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RuntimeSets
{
    [CreateAssetMenu]
    public class RuntimeSet : ScriptableObject
    {
        [SerializeField] private List<GameObject> myset = new List<GameObject>();
        public Texture2D PreviewIcon;
        public UnityEvent OnRegister, OnDeregister, OnChange;
        public int Length => myset.Count;

        public void Register(GameObject addition)
        {
            myset.Add(addition);
            OnRegister?.Invoke();
            OnChange?.Invoke();
        }

        public List<GameObject> GetSet()
        {
            return myset;
        }

        public void Deregister(GameObject gameObject)
        {
            myset.Remove(gameObject);
            OnDeregister?.Invoke();
            OnChange?.Invoke();
        }
    }
}