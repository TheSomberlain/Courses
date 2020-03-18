using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Enumerable.Range(0, 100).Where(num => num % 2 == 0)
                                    .ToList()
                                    .ForEach(e => Console.Write(e + " "));
            Console.WriteLine();
            
            Enumerable.Range(1, 10).Select(num => $"{num} : {num * num}")
                                   .ToList().ForEach(Console.WriteLine);
            
            Enumerable.Range(1, 6).Cast<DayOfWeek>()
                                  .Concat(new DayOfWeek[1])
                                  .Select(a => a.ToString()).ToList()
                                  .ForEach(e => Console.Write(e + " "));
            Console.WriteLine();
            Enumerable.Repeat(1, 5).Concat(Enumerable.Repeat(2, 10))
                                   .ToList()
                                   .ForEach( e => Console.Write(e + " "));
            Console.WriteLine();
            List<string> strings = new List<string>();
            bool flag = true;
            while (flag)
            {
                string str = Console.ReadLine();
                if (str.Equals("s")) flag = false;
                else strings.Add(str);
            }
            strings.Select(x => $"{x}: {x.Length}")
                   .ToList().ForEach(Console.WriteLine);

            var items = new[]
            {
                (10,20),
                (40, 50),
                (50, 100)
            };
            Console.WriteLine(items.Aggregate((v1,v2) => (v1.Item1 +v2.Item1, v1.Item2 + v2.Item2)));
            Console.ReadKey();
        }
    }
}
