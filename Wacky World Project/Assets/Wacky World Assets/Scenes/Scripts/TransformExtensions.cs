using UnityEngine;

    public static class TransformExtensions
    {
        public static void MoveToPosition(this Transform transform,  Transform destination)
        {
            transform.position = destination.position;
            return;
        }
    }

