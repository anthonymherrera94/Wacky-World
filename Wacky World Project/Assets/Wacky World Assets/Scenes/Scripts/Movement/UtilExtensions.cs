using UnityEngine;

namespace Movement
{
    public static class UtilExtensions {

        public static float ToDegrees(this float a)
            => (a / Mathf.PI) * 180;

    }
}
