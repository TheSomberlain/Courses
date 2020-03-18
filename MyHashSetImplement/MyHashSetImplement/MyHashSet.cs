using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MyHashSetImplement
{
    public class MyHashset<T> : IEnumerable<T>
    {
        private List<Bucket<T>> _buckets;
        public event EventHandler onAdded;
        public event EventHandler onClear;
        public MyHashset()
        {
            _buckets = new List<Bucket<T>>();
        }
        public void put(T element)
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
                onAdded?.Invoke(this,EventArgs.Empty);
            }
        }
        public void Add(T item)
        {
            put(item);
        }
        public void Clear()
        {
            _buckets.Clear();
            onClear?.Invoke(this,EventArgs.Empty);
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
            //return _buckets.GetEnumerator();
            foreach(Bucket<T> bucket in _buckets)
            {
                foreach(T item in bucket._buckets)
                {
                    yield return item;
                }
            }
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

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
        public void ForEach(Action<T> action)
        {
            foreach (Bucket<T> bucket in _buckets)
            {
                bucket._buckets.ForEach(action);
            }
        }
        public void Map(Func<T,T> func)
        {
            foreach (Bucket<T> bucket in _buckets)
            {
                for (int i = 0; i < bucket._buckets.Count; i++)
                {
                    bucket._buckets[i] = func(bucket._buckets[i]);
                }
            }
        }
        
    }
}
