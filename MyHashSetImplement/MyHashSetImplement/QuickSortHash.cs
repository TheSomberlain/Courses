using System;
using System.Collections.Generic;
using System.Text;

namespace MyHashSetImplement
{
    public static class QuickSortHash
    {
        public static void sort<T>(this MyHashset<T> source, Func<T, T, bool> compare, Func<T, T, bool> equals)
        {
            List<T> tmp = new List<T>();
            foreach (T item in source)
            {
                tmp.Add(item);
            }
            source.Clear();
            qsort(tmp, 0, tmp.Count - 1, compare, equals);
            foreach (T item in tmp)
            {
                source.add(item);
            }
        }
        public static void qsort<T>(List<T> sourceList, int left, int right, Func<T,T,bool> compare, Func<T, T, bool> equals)
        {
            int i;
            if (left < right)
            {
                i = Partition(sourceList, left, right, compare, equals);

                qsort(sourceList, left, i - 1, compare, equals);
                qsort(sourceList, i + 1, right, compare, equals);
            }
        }
        public static int Partition<T>(List<T> sourceList, int left, int right, Func<T, T, bool> compare, Func<T, T, bool> equals)
        {
            T temp;
            T p = sourceList[right];
            int i = left - 1;

            for (int j = left; j <= right - 1; j++)
            {
                if (compare(p,sourceList[j]) && equals(sourceList[j],p))
                {
                    i++;
                    temp = sourceList[i];
                    sourceList[i] = sourceList[j];
                    sourceList[j] = temp;
                }
            }

            temp = sourceList[i + 1];
            sourceList[i + 1] = sourceList[right];
            sourceList[right] = temp;
            return i + 1;

        }
    }
}
