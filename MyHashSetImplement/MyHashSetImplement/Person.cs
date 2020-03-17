using System;
using System.Collections.Generic;
using System.Text;

namespace MyHashSetImplement
{
    class Person
    {
        private int _age;
        private string _name;
        public Person(int age, string name)
        {
            _age = age;
            _name = name;
        }
        public int Age => _age;
        public string Name => _name;
        public void printPerson()
        {
            Console.WriteLine($"Age:  {_age}\nName: {_name}");
        }
        public static bool operator ==(Person p1, Person p2)
        {
            return (p1._age == p2._age) && (p1._name == p2._name);
        }
        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }
    }
}
