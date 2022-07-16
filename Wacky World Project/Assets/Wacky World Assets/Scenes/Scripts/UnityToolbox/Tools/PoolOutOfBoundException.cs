using System;

namespace UnityToolbox.Tools
{
    public class PoolOutOfBoundException : Exception
    {
        public PoolOutOfBoundException()
        {
        }

        public PoolOutOfBoundException(string message) : base(message)
        {
        }

        public PoolOutOfBoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}