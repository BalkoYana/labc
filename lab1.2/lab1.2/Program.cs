using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть кількість чисел");
            int n = int.Parse(Console.ReadLine());
            Queue<int> numbers = new Queue<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            for(int i = 0; i < n; i++)
            {
                numbers.Enqueue(rand.Next(1,100));
               
               
            }
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            int max = numbers.Max();
            int min = numbers.Min();
            int dif = max - min;
            Console.WriteLine($"Різниця між максимальним і мінімальним елементами:{dif}");
        }
    }
}
