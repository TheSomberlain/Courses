using System;


namespace MyHashSetImplement
{
    class Program
    {
        static void Main(string[] args)
        {
             MyHashset<int> hashset = new MyHashset<int>();
            hashset.add(1);
            hashset.add(2);
            hashset.add(3);
            hashset.add(4);
            hashset.add(5);
            hashset.printHashSet();

            foreach(Bucket<int> item in hashset)
            {
                item.printBucket();
            }
            Console.ReadKey();
        }
    }
}
