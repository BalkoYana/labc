using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> nameOfComp = new SortedList<int, string>();
            nameOfComp.Add(1, "Asus");
            nameOfComp.Add(2, "Apple");
            nameOfComp.Add(3, "Lenovo");
            nameOfComp.Add(4, "Sony");
            nameOfComp.Add(5, "Samsung");
            nameOfComp.Add(6, "Microsoft");
            nameOfComp.Add(7, "Acer");
            nameOfComp.Add(8, "Sony");
            Console.WriteLine("Виводимо в прямому порядку");
            foreach (var i in nameOfComp)
            {
                Console.WriteLine(i.Value);
            }
            Console.WriteLine("Виводимо в зворотньому порядку");
            for (int j = nameOfComp.Count - 1; j >= 0; j--)
            {
                Console.WriteLine(nameOfComp.Values[j]);
            }
            Console.WriteLine($"\n кількість елементів:{nameOfComp.Count}");
            nameOfComp.Clear();
            

        }
    }
}
