using System;

namespace Tools
{
    public static class Validators
    {
        public static void IsNotNull(Object obj)
        {
            if (obj == null)
            {
                throw new Exception($"{nameof(obj)} - should not be null");
            }
        }
        public static void IsNotNull(Object obj, string message)
        {
            if (obj == null)
            {
                throw new Exception(message);
            }
        }
        
        public static void IsNotNull(Object obj, Exception exception)
        {
            if (obj == null)
            {
                throw exception;
            }
        }

        public static void IsFalse(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
        
        public static void IsFalse(bool condition, Exception exception)
        {
            if (condition)
            {
                throw exception;
            }
        }
    }
}