using System;

namespace My_List
{
    class Program
    {
        private static void Display(string m) => Console.WriteLine("Written from main " + m);
        static void Main(string[] args)
        {
            void send(int num)
            {
                Console.WriteLine($"Removed at {num}");
            }
            MyList<int> list = new MyList<int>();
            list.log += Display;
            list.log += s => Console.WriteLine("Written after displayed");
            list.send += send;
            list.add(1);
            list.add(2);
            list.add(3);
            list.add(4);
            list.add(5);
            list.removeAt(0);
            list.send -= send;
            list.removeAt(1);
            foreach (int number in list)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("----------------");
            Predicate<int> pred = num => num % 2 == 0;
            foreach(int num in list.Filter(pred))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------------");
            pred = num => num % 2 != 0;
            foreach (int num in list.Filter(pred))
            {
                Console.WriteLine(num);
            }

            Console.ReadKey();
        }
    }
}
