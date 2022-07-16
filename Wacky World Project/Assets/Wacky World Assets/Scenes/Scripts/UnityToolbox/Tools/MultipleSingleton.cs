using System;

namespace UnityToolbox.Tools
{
    public class MultipleSingleton : Exception
    {
        public MultipleSingleton()
        {
        }

        public MultipleSingleton(string message) : base(message)
        {
        }
    }
}