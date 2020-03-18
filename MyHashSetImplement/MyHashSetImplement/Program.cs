using System;
using System.Collections.Generic;

namespace MyHashSetImplement
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("=============TASK 1==============");
            MyHashset<int> nums = new MyHashset<int>();
            OnAddObserver observer1 = new OnAddObserver(20, "Kto-to", nums);
            OnClearObserver observer2 = new OnClearObserver(19, "Kto-to esche", nums);
            observer1.Subscribe();
            observer2.Subscribe();
            nums.put(32);
            nums.put(12);
            nums.put(42);
            nums.put(52);
            nums.put(82);
            observer1.printLog();
            nums.Clear();
            observer2.printLog();
            observer1.Unsubscribe();
            nums.put(45);
            Console.WriteLine("=============TASK 2==============");
            MyHashset<int> hashset = new MyHashset<int>()
            {
                1,3,5,4,2
            };
            hashset.printHashSet();
            Console.WriteLine("------------------");
            hashset.ForEach(num => Console.Write($"{num *= 2} "));
            Console.WriteLine();
            hashset.printHashSet();
            Console.WriteLine("------------------");
            hashset.Map(num => num *= num);
            hashset.printHashSet();
            Console.WriteLine("=============TASK 3==============");
            QuickSortHash.sort(hashset,(num1,num2) => num1>num2);
            hashset.printHashSet();
            Console.WriteLine("------------------");
            MyHashset<Person> persons = new MyHashset<Person>()
            {
                new Person(40, "Petro"),
                new Person(12, "Dasha"),
                new Person(15, "Ivan"),
                new Person(19, "Katya"),
                new Person(10, "Vasilisa"),
                new Person(20, "Petro")
            };
            
            QuickSortHash.sort(persons, (num1, num2) => num1.Age > num2.Age);
            foreach(Person person in persons)
            {
                person.printPerson();
            }
            char getFirstChar(string s)
            {
                char[] chars = s.ToCharArray();
                return chars[0];
            }
            Console.WriteLine("------------------");
            QuickSortHash.sort(persons, (num1, num2) => (int)getFirstChar(num1.Name) > (int)getFirstChar(num2.Name));
            foreach (Person person in persons)
             {
                person.printPerson();
             }
            Console.ReadKey();
        }
    }
}
