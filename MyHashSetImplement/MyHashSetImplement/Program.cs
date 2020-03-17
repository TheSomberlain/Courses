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
            QuickSortHash.sort(hashset,(num1,num2) => num1>num2, (num1, num2) => num1 == num2);
            hashset.printHashSet();
            Console.WriteLine("------------------");
            MyHashset<Person> persons = new MyHashset<Person>();
            persons.add(new Person(40, "Petro"));
            persons.add(new Person(12, "Dasha"));
            persons.add(new Person(15, "Ivan"));
            persons.add(new Person(19, "Katya"));
            persons.add(new Person(10, "Vasilisa"));
            QuickSortHash.sort(persons, (num1, num2) => num1.Age > num2.Age, (num1, num2) => num1 == num2);
            foreach(Person person in persons)
            {
                person.printPerson();
            }
            /*char getFirstChar(string s)
            {
                char[] chars = s.ToCharArray();
                return chars[0];
            }
            Console.WriteLine("------------------");
            QuickSortHash.sort(persons, (num1, num2) => (int)getFirstChar(num1.Name) > (int)getFirstChar(num2.Name), (num1, num2) => num1 == num2);
            foreach (Person person in persons)
             {
                person.printPerson();
             }*/
            Console.ReadKey();
        }
    }
}
