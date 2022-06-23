using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Color = UnityEngine.Color;

namespace RuntimeSets
{
    public class RuntimeSetManager : MonoBehaviour
    {
        public int Size => set.Length;

        [SerializeField] private RuntimeSet set;
        [SerializeField] private Color lineColor = Color.white;

        [FormerlySerializedAs("OnChange")] [SerializeField]
        private UnityEvent<int> OnSizeChange;

        [SerializeField] private UnityEvent onZero;

        private void Start()
        {
            set.OnChange.AddListener(() => OnSizeChange?.Invoke(Size));
            set.OnChange.AddListener(() =>
            {
                if (set.Length < 1)
                {
                    onZero?.Invoke();
                }
            });
            OnSizeChange?.Invoke(Size);
        }

        private void OnDrawGizmosSelected()
        {
            foreach (GameObject entry in set.GetSet()) DrawLineTo(entry);
        }

        private void DrawLineTo(GameObject entry)
        {
            Vector3 managerPosition = transform.position;
            Vector3 otherPosition = entry.transform.position;
            Gizmos.DrawLine(managerPosition, otherPosition);
            // float midHeight = (managerPosition.y - otherPosition.y) * 0.5f;
            // Vector3 offset = Vector3.up * midHeight;
            // Handles.DrawBezier(managerPosition,
            //     otherPosition,
            //     managerPosition - offset,
            //     otherPosition + offset,
            //     lineColor,
            //     Texture2D.whiteTexture,
            //     1.0f);
        }
    }
}