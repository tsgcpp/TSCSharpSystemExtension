using System;

namespace System.Extension
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Extension method for null check
        /// </summary>
        /// <remarks>
        /// Support UnityEngine.Object destruction check.
        /// </remarks>
        /// <param name="obj">Target object</param>
        /// <returns>false: obj is not null, true: obj is null</returns>
        public static bool IsNull(this object obj)
        {
            if (obj == null)
            {
                return true;
            }

            return obj.Equals(null);
        }
    }
}
