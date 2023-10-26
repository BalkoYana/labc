using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace labxml
{
    //    Сформувати файл “Zavod.xml”, що містить інформацію про дані з полями; номер цеху; посада;
    //стаж роботи; заробітна плата.
    //Переглянути файл на консолі;
    //Вивести номер цеху, посаду, стаж роботи та заробітну плату за заданим прізвищем.
    //Обчислити середню заробітну плату в цеху Х.
    internal class Program
    {
        static string xmlFile = @"C:\Users\ASUS\Desktop\Zavod.xml";
        static void Main(string[] args)
        {
            CreateXmlFile();
            var workerList = ReadFile();
            Print(workerList);
            PrintBySurname(workerList, "Smith");
            AverageSalary(workerList, 1);
        } static void CreateXmlFile()
        {
            using (XmlTextWriter writer = new XmlTextWriter(xmlFile, null))
            {
                var workerList = new WorkerList();
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;

                writer.WriteStartDocument(true);
                writer.WriteStartElement("workerList");
                AddWorker(writer, "Petrenko", "1", "position1", "6", "30000");
                AddWorker(writer, "Smith", "1", "position2", "8", "300000");
                AddWorker(writer, "Semenko", "3", "position3", "1", "20000");
                WorkerList workerList1 = new WorkerList();
                Worker w = new Worker(1, "Petrenko", "position1", "6", 30000);
                Worker w2 = new Worker(2, "Smith", "position2", "8", 300000);
                Worker w3 = new Worker(3, "Semenko", "position3", "1", 20000);
                workerList1.AddWorker(w);
                workerList1.AddWorker(w2);
                workerList1.AddWorker(w3);

                writer.WriteEndDocument();
               

            }
        }static void AddWorker(XmlTextWriter writer, string surname, string number, string position, string experience, string salary)
        {
            writer.WriteStartElement("worker");
            writer.WriteAttributeString("surname", surname);
            writer.WriteAttributeString("number", number);
            writer.WriteAttributeString("position", position);
            writer.WriteAttributeString("experience", experience);
            writer.WriteAttributeString("salary", salary);
            writer.WriteEndElement();
        }
        static List<Worker> ReadFile() { 
            var workerList = new List<Worker>();

            using (XmlTextReader reader = new XmlTextReader(xmlFile))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "worker")
                    {
                        var number = reader.GetAttribute("number");
                        var surname = reader.GetAttribute("surname");
                        var position = reader.GetAttribute("position");
                        var experience = reader.GetAttribute("experience");
                        var salary = reader.GetAttribute("salary");
                        reader.ReadStartElement("worker");

                        workerList.Add(new Worker(Convert.ToInt32(number) ,surname,position,experience,Convert.ToDouble(salary)));
                    }
                }
            }
            return workerList;
        }
            static void Print(List<Worker> workerList) {
                foreach (var worker in workerList)
                {
                    Console.WriteLine("{0},{1},{2},{3},{4}", worker.Number, worker.Surname, worker.Position, worker.Experience, worker.Salary);
                }
            }
        static void PrintBySurname(List<Worker> workerList, string surname)
        {
            foreach (var worker in workerList)
            {
                if (worker.Surname.Trim().ToLower().Equals(surname.Trim().ToLower()))
                {
                    Console.WriteLine("{0} ось всі дані знайдені за цим прізвищем{1},{2},{3},{4}", worker.Surname, worker.Number, worker.Position, worker.Experience, worker.Salary);
                }
            }
        }
        static void AverageSalary(List<Worker> workerList, int number)
        {
            int number1 = 1;
            double totalSalary = 0;
            int counter = 0;
            foreach (var worker in workerList)
            {
                if (worker.Number == number1)
                {
                    totalSalary += worker.Salary;
                    counter++;
                }
            }
            double average = totalSalary / counter;
            Console.WriteLine($"Середня заробітня плата в цеху {number1} становить {average}");
         }
    }
}
