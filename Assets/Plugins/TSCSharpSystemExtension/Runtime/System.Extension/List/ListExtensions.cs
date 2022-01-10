using System.Collections.Generic;

namespace System.Extension
{
    public static class ListExtensions
    {
        public static bool Remove<T>(this List<T> items, T item, IEqualityComparer<T> comparer)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                if (comparer.Equals(item, items[i]))
                {
                    items.RemoveAt(index: i);
                    return true;
                }
            }

            return false;
        }

        public static int RemoveAll<T>(this List<T> items, T item, IEqualityComparer<T> comparer)
        {
            int removedCount = 0;
            for (int i = items.Count - 1; i >= 0; --i)
            {
                if (comparer.Equals(item, items[i]))
                {
                    items.RemoveAt(index: i);
                    removedCount += 1;
                }
            }

            return removedCount;
        }
    }
}
