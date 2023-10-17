using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
//Сформувати файл “Zavod.json”, що містить інформацію про дані з полями; номер цеху; посада;
//стаж роботи; заробітна плата.
// Переглянути файл на консолі;
// Вивести номер цеху, посаду, стаж роботи та заробітну плату за заданим прізвищем.
// Обчислити середню заробітну плату в цеху Х.
namespace filejson
{
    public class Worker
    {
        [JsonProperty(PropertyName ="number")]
        public int Number { get; set; }
        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }
        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }
        [JsonProperty(PropertyName = "experience")]
        public int Experience { get; set; }
        [JsonProperty(PropertyName = "salary")]
        public double Salary { get; set; }

    }
    public class WorkerList
    {
        public List<Worker> workerList { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var stringJson = @"{
                 'workerList':[{
                  'surname':'Petrenko',
                  'number': 1,
                  'position':'position1',
                  'experience':5,
                  'salary':80000},
                   {
                  'surname':'Semenko',
                  'number': 1,
                  'position':'position2',
                  'experience':9,
                  'salary':8000},
                   {
                  'surname':'Smith',
                  'number': 2,
                  'position':'position3',
                  'experience':1,
                  'salary':800}]
        
           }";

            var workers=JsonConvert.DeserializeObject<WorkerList>(stringJson);

            ////
            foreach(var worker in workers.workerList) {
            Console.WriteLine("{0},{1},{2},{3},{4}", worker.Number, worker.Surname,worker.Position, worker.Experience,worker.Salary);
            }
            /////
            string surname = "Smith";
            foreach (var worker in workers.workerList)
            {
                if (worker.Surname.Trim().ToLower().Equals(surname.Trim().ToLower()))
                {
                    Console.WriteLine("{0} ось всі дані знайдені за цим прізвищем{1},{2},{3},{4}", worker.Surname, worker.Number, worker.Position, worker.Experience, worker.Salary);
                }
            }
            //////
            int number1 = 1;
            double totalSalary = 0;
            int counter = 0;
            foreach (var worker in workers.workerList)
            {
                if (worker.Number == number1)
                {
                    totalSalary += worker.Salary;
                    counter++;
                }
            }
            double average = totalSalary / counter;
            Console.WriteLine($"Середня заробітня плата в цеху {number1} становить {average}");

          ////
            var serializedOcject = JsonConvert.SerializeObject(workers);
            Console.WriteLine(serializedOcject);

        
            File.WriteAllText(@"C:\Users\ASUS\Desktop\Zavod.json", serializedOcject);



            Console.ReadKey();

        }
    }
}
