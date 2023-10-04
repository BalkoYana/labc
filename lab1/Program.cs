using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    //    Дано структуру даних(колекцію) відповідно до варіанта.Додати
    //зазначену кількість елементів, які описують відповідну предметну
    //область.Вивести всі елементи на консоль в прямому та зворотному
    //порядку.Вивести кількість елементів у колекції.Очистити колекцію.Назви виробників комп’ютерної

    //техніки
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<int, string> nameOfComp = new SortedList<int, string>();
            nameOfComp.Add(1, "Asus");
            nameOfComp.Add(3, "Lenovo");
            nameOfComp.Add(2, "Apple");
            nameOfComp.Add(6, "Microsoft");
            nameOfComp.Add(4, "Sony");
            nameOfComp.Add(5, "Samsung");
            
            nameOfComp.Add(7, "Acer");
            nameOfComp.Add(8, "Sony");
            Console.WriteLine("Виводимо в прямому порядку");
           
            foreach (var i in nameOfComp)
            {
                Console.WriteLine(i.Value);
            }
            
            foreach (var j in nameOfComp.Reverse())
            {
                Console.WriteLine(j.Value);
            }
            Console.WriteLine($"\n кількість елементів:{nameOfComp.Count}");
            nameOfComp.Clear();
            

        }
    }
}
