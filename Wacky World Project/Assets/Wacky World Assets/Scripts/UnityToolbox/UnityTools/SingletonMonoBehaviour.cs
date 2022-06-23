using UnityEngine;

namespace UnityToolbox.UnityTools
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T:SingletonMonoBehaviour<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Trying to instance a second instance of singleton");
                //TODO: This should throw exception, not logerror

                // throw new MultipleSingleton("");
            }
            else
            {
                Instance = (T) this;
            }
        }

        protected virtual void OnDestroy()
        {
            if (Instance == null) Instance = null;
        }

    
    }
}
