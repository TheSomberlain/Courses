using System;

namespace My_List
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.add(1);
            list.add(2);
            list.add(3);
            list.add(4);
            list.add(5);
            foreach (int number in list)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------------");
            list.removeAt(4);
            list.removeAt(1);
            foreach (int number in list)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("------------------");
            Console.WriteLine(list.indexOf(4));
            Console.ReadKey();
        }
    }
}
