using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using lab5.Models;

namespace lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\lab5\lab5\Flat.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var rep = new FlatRepository(connection);


                //вибрати всіх у кого вартість квартири

                Console.WriteLine("Enter price");
                int price = int.Parse(Console.ReadLine());
                var flatA = rep.A(price);
                foreach (Flat flat in flatA)
                {
                    Console.WriteLine($"Ті, у кого  кого вартість квартири {price}: {flat.Square},{flat.Id}");
                };

                //вибрати ті квартири де нема інформації про власника
                var flatB = rep.B();
                foreach (Flat flat in flatB)
                {
                    Console.WriteLine($"ті квартири де нема інформації про власника :{flat.Square},{flat.Id}");
                };

                //вибрати квартири які знаходяться на  поверсі і ціна більша 
                Console.WriteLine("Enter price");
                int price1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter floor");
                int floor = int.Parse(Console.ReadLine());
                var flatC = rep.C(price1,floor);
                foreach (Flat flat in flatC)
                {
                    Console.WriteLine($"вибрати квартири які знаходяться на {floor} поверсі і ціна більша за {price1} :{flat.Price},{flat.Floor}");
                };
                //вивести всі ціни
                var flatD = rep.D();
                foreach (Flat flat in flatD)
                {
                    Console.WriteLine($"ціна:{flat.Price}");
                };
                //порахувати кількість квартир з однаковою вартістю
                var flatE = rep.E();
                foreach (Flat flat in flatE)
                {
                    Console.WriteLine($"ціна:{flat.Data},{flat.Price}");
                };
                //кількість квартир з однаковою ціною в одному районі ,яка перевищує 3 
                Console.WriteLine("Enter number");
                int number = int.Parse(Console.ReadLine());
                var flatF = rep.F(number);
                foreach (Flat flat in flatF)
                {
                    Console.WriteLine($"{flat.Area} {flat.Price}");
                };
                //посортувати у порядку зростання ціни на квартиру
                var flatG = rep.G();
                foreach (Flat flat in flatG)
                {
                    Console.WriteLine($"{flat.Area} {flat.Price}");
                };
                //всі квартири ,у яких ціна дорівнює  змінити на 
                Console.WriteLine("Enter from");
                int from = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter to");
                int to = int.Parse(Console.ReadLine());
                var flatH = rep.H(from, to);
                Console.WriteLine(flatH);


               


               



             


            }

        }
    }
}
