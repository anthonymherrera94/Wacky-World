namespace UnityToolbox.Tools
{
    public class Singleton<T> where T : new()
    {
        private static T instance;

        private bool instanceAlreadyExists => instance != null;

        public static T Instance()
        {
            if (instance == null) instance = new T();
            return instance;
        }

        public Singleton()
        {
            if (instanceAlreadyExists)
            {
                throw new MultipleSingleton();
            }
        }

    }
}