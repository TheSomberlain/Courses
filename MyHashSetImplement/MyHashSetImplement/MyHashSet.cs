using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MyHashSetImplement
{
    class MyHashset<T> : IEnumerable
    {
        private List<Bucket<T>> _buckets;
        public MyHashset()
        {
            _buckets = new List<Bucket<T>>();
        }
        public void add(T element)
        {
            int hash = element.GetHashCode();
            foreach (Bucket<T> bucket in _buckets)
            {
                if(bucket.hashcode == hash)
                {
                    if (bucket.contains(element)) return;
                    else
                    {
                        bucket.add(element);
                        return;
                    }
                    
                }
            }
            {
                Bucket<T> bucket = new Bucket<T>(hash);
                bucket.add(element);
                _buckets.Add(bucket);
            }
        }
        public bool contains(T element)
        {
            foreach(Bucket<T> bucket in _buckets)
            {
                if(bucket.hashcode == element.GetHashCode())
                {
                    return bucket.contains(element);
                }
            }
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return _buckets.GetEnumerator();
        }

        public void printHashSet()
        {
            foreach (Bucket<T> bucket in _buckets)
            {
                Console.Write($"{bucket.hashcode}: ");
                foreach (T item in bucket._buckets)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
