using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyHashSetImplement
{
    class Bucket<T> : IEnumerable<T>
    {
        public List<T> _buckets;
        public int hashcode;
        public Bucket(int hash)
        {
            _buckets = new List<T>();
            this.hashcode = hash;
        }
        public void add(T element)
        {
            _buckets.Add(element);
        }
        public void remove(T element)
        {
            _buckets.Remove(element);
        }
        public bool contains(T element)
        {
            foreach(T elem in _buckets)
            {
                if (elem.Equals(element)) return true;
            }
            return false;
        }
        public void printBucket()
        {
            Console.Write($"{hashcode}: ");
            foreach (T bucket in _buckets)
            {
                Console.Write(bucket + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator GetEnumerator()
        {
            return _buckets.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _buckets.GetEnumerator();
        }
    }
}
