using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1._2
{//Дано чергу цілих чисел, яка складається з n елементів.
   // Визначити різницю між максимальним та мінімальним
    //елементами.
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
            int d = numbers.Max() - numbers.Min();
            for (int i = 0; i < n; i++)
            {


                Console.WriteLine(numbers.Dequeue());


            }
            
            
           
            Console.WriteLine($"Різниця між максимальним і мінімальним елементами:{d}");
        }
    }
}
