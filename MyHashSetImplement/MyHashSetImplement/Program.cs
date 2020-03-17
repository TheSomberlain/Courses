using System;
using System.Collections.Generic;

namespace MyHashSetImplement
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashset<int> hashset = new MyHashset<int>();
            hashset.add(1);
            hashset.add(3);
            hashset.add(5);
            hashset.add(2);
            hashset.add(4);
            hashset.printHashSet();
            Console.WriteLine("------------------");
            hashset.ForEach(num => num *= 2);
            hashset.printHashSet();
            Console.WriteLine("------------------");
            hashset.Map(num => num *= num);
            hashset.printHashSet();
            Console.WriteLine("------------------");
            QuickSortHash.sort(hashset);
            hashset.printHashSet();

            Console.ReadKey();
        }
    }
}
