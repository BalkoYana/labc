using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labxml
{
    public class Worker
    {
        public int Number { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Experience { get; set; }
        public double Salary { get; set; }
        public Worker() { }
        public Worker(int number, string surname, string position, string experience, double salary)
        {
            Number = number;
            Surname = surname;
            Position = position;
            Experience = experience;
            Salary = salary;
        }
    }

}
