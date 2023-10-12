using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Завдання мають бути виконані з використанням методів LINQ. Цикли можна використовувати лише
//при виведенні результатів запитів. Допускається виконання завдань лабораторної роботи у проекті
//консольного типу. Базові типи елементів колекцій та самі колекції (списки чи масиви) мають бути
//описані та ініціалізовані у окремому класі. Розв’язок кожного завдання має міститися у окремому
//методі (TaskA, TaskB, TaskC).
//Параметри методів мають визначатися, виходячи з умови завдань. Кожна
//з колекцій має містити не менше 20 елементів
//
//
//Елементи колекції «Лікарі» мають наступну структуру: прізвище, спеціалізація.Елементи колекції «Пацієнти» містять прізвище пацієнта, дата народження, діагноз, прізвище лікаря, відділення, дата надходження, дата виписки.
//а) Вивести сумарну кількість пацієнтів пенсійного віку у заданих відділеннях.
//b) Вивести кількості різних діагнозів, які поставили лікарі із заданою спеціалізацією.
//с) Вивести ті діагнози, кількість різних пацієнтів з якими протягом заданого терміну є найбільшою.
namespace lablinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> dep = new List<string> { "Відділення неврології", "Дерматологічне відділення" };
           int b= A(Patients,dep);
            Console.WriteLine(b);
            var c = B(Patients);
            Console.WriteLine(c);
            var a = C(Patients, new DateTime(2023, 1, 1), new DateTime(2023, 10, 1));
            Console.WriteLine(c);
        }
        public static List<Doctor> Doctor = new List<Doctor>()
            {
                new Doctor(){
                    Surname="Ivanova",
                    Specialization="Кардіолог"
                },
                 new Doctor(){
                    Surname="Smith",
                    Specialization="Кардіолог"
                },
                  new Doctor(){
                    Surname="Johnson",
                    Specialization="Педіатр"
                }, new Doctor(){
                    Surname="Williams",
                    Specialization="Педіатр"
                }, new Doctor(){
                    Surname="Brown",
                    Specialization="Дерматолог"
                }, new Doctor(){
                    Surname="Jones",
                    Specialization="Дерматолог"
                }, new Doctor(){
                    Surname="Miller",
                    Specialization="Хірург"
                }, new Doctor(){
                    Surname="Davis",
                    Specialization="Хірург"
                }, new Doctor(){
                    Surname="Garcia",
                    Specialization="Педіатр"
                }, new Doctor(){
                    Surname="Rodriguez",
                    Specialization="Педіатр"
                }, new Doctor(){
                    Surname="Wilson",
                    Specialization="Кардіолог"
                }, new Doctor(){
                    Surname="Martinez",
                    Specialization="Кардіолог"
                }, new Doctor(){
                    Surname="Anderson",
                    Specialization="Хірург"
                }, new Doctor(){
                    Surname="Taylor",
                    Specialization="Хірург"
                }, new Doctor(){
                    Surname="Thomas",
                    Specialization="Дерматолог"
                }, new Doctor(){
                    Surname="Hernandez",
                    Specialization="Дерматолог"
                }, new Doctor(){
                    Surname="Moore",
                    Specialization="Невролог"
                }, new Doctor(){
                    Surname="Martin",
                    Specialization="Невролог"
                }, new Doctor(){
                    Surname="Jackson",
                    Specialization="Невролог"
                }, new Doctor(){
                    Surname="Thompson",
                    Specialization="Невролог"
                },
            };
        public static List<Patients> Patients = new List<Patients>
    {
        new Patients
        {
            Surname = "Allen",
            Birthday = new DateTime(1980, 5,30 ),
            Diagnosis = "Мігрень",
            DoctorsSurname = "Thompson",
            Department = "Відділення неврології",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 1, 10)
        },
        new Patients
        {
            Surname = "Young",
            Birthday = new DateTime(1999, 2,13 ),
            Diagnosis = "Епілепсія",
            DoctorsSurname = "Jackson",
            Department = "Відділення неврології",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 2, 10)
        },
        new Patients
        {
            Surname = "Hernandez",
            Birthday = new DateTime(1987, 7,30 ),
            Diagnosis = "Епілепсія",
            DoctorsSurname = "Thompson",
            Department = "Відділення неврології",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 3, 10)
        },

        new Patients
        {
            Surname = "King",
            Birthday = new DateTime(1950, 9,20 ),
            Diagnosis = "Акне",
            DoctorsSurname = "Hernandez",
            Department = "Дерматологічне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 6, 10)
        },
        new Patients
        {
            Surname = "Wright",
            Birthday = new DateTime(1978, 7,30 ),
            Diagnosis = "Акне",
            DoctorsSurname = "Thomas",
            Department = "Дерматологічне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 4, 10)
        },
        new Patients
        {
            Surname = "Lopez",
            Birthday = new DateTime(1945, 7,30 ),
            Diagnosis = "Герпес",
            DoctorsSurname = "Jones",
            Department = "Дерматологічне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 2, 10)
        },
        //
         new Patients
        {
            Surname = "Hill",
            Birthday = new DateTime(1959, 5,30 ),
            Diagnosis = "Апендицит",
            DoctorsSurname = "Davis",
            Department = "Хірургічне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 1, 10)
        },
        new Patients
        {
            Surname = "Scott",
            Birthday = new DateTime(1999, 2,19 ),
            Diagnosis = "Грижа",
            DoctorsSurname = "Davis",
            Department = "Хірургічне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 3, 11)
        },
        new Patients
        {
            Surname = "Green",
            Birthday = new DateTime(1967, 7,24),
            Diagnosis = "Грижа",
            DoctorsSurname = "Miller",
            Department = "Хірургічне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 3, 10)
        },

        new Patients
        {
            Surname = "Adams",
            Birthday = new DateTime(1950, 9,29 ),
            Diagnosis = "Грижа",
            DoctorsSurname = "Miller",
            Department = "Хірургічне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 4, 10)
        },
        new Patients
        {
            Surname = "Baker",
            Birthday = new DateTime(2008, 7,30 ),
            Diagnosis = "Перелом кістки",
            DoctorsSurname = "Miller",
            Department = "Хірургічне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 1, 4)
        },
        new Patients
        {
            Surname = "Gonzalez",
            Birthday = new DateTime(1950, 6,2 ),
            Diagnosis = "Перелом кістки",
            DoctorsSurname = "Anderson",
            Department = "Хірургічне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 2, 10)
        },
        ///
         new Patients
        {
            Surname = "Nelson",
            Birthday = new DateTime(1960, 4,3 ),
            Diagnosis = "Отит",
            DoctorsSurname = "Rodriguez",
            Department = "Педіатричне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 4, 18)
        },
        new Patients
        {
            Surname = "Carter",
            Birthday = new DateTime(1998, 2,13 ),
            Diagnosis = "Отит",
            DoctorsSurname = "Rodriguez",
            Department = "Педіатричне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 1, 10)
        },
        new Patients
        {
            Surname = "Mitchell",
            Birthday = new DateTime(1987, 7,30 ),
            Diagnosis = "Гастроентерит",
            DoctorsSurname = "Rodriguez",
            Department = "Педіатричне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 3, 10)
        },

        new Patients
        {
            Surname = "Perez",
            Birthday = new DateTime(1951, 9,20 ),
            Diagnosis = "Гастроентерит",
            DoctorsSurname = "Williams",
            Department = "Педіатричне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 7, 10)
        },
        new Patients
        {
            Surname = "Turner",
            Birthday = new DateTime(1978, 7,6 ),
            Diagnosis = "Гострий бронхіт",
            DoctorsSurname = "Williams",
            Department = "Педіатричне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 4, 19)
        },
        new Patients
        {
            Surname = "Roberts",
            Birthday = new DateTime(1945, 7,30 ),
            Diagnosis = "Гострий бронхіт",
            DoctorsSurname = "Williams",
            Department = "Педіатричне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 9, 10)
        },
        new Patients
        {
            Surname = "Phillips",
            Birthday = new DateTime(1978, 7,30 ),
            Diagnosis = "Вітряна віспа",
            DoctorsSurname = "Johnson",
            Department = "Педіатричне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 4, 10)
        },
        new Patients
        {
            Surname = "Campbell",
            Birthday = new DateTime(1956, 7,30 ),
            Diagnosis = "Вітряна віспа",
            DoctorsSurname = "Garcia",
            Department = "Педіатричне відділення",
            DateOfReceipt = new DateTime(2023, 1, 1),
            DateOfDischarge = new DateTime(2023, 2, 10)
        },

        };
        //а) Вивести сумарну кількість пацієнтів пенсійного віку у заданих відділеннях.
        public static int A (List <Patients> Patients, List<string> departments)
        {
            int pensionAge = DateTime.Now.Year - 65;
            var filteredPatients = Patients.Where(p => departments.Contains(p.Department));
            var patients = filteredPatients.GroupBy(
                patient => new
                {
                    patient.Department,
                    patient.Birthday.Year,
                });
            var filtered = patients.Where(patient => patient.Key.Year <= pensionAge).ToList().Count;

           


            return filtered ;
        }
        //b) Вивести кількості різних діагнозів, які поставили лікарі із заданою спеціалізацією.
        public static List<Patients> B(List<Patients> Patients)
        {
            string specialization = "Дерматолог";
            var filtered = Doctor.Where(doctor => doctor.Specialization == specialization);
            var joined = filtered.Join(Patients, d => d.Surname, p => p.DoctorsSurname, (d, p) => p);
            var dep = joined.GroupBy(patient => patient.Diagnosis).Select(g => new { Diagnosis = g.Key, Count = g.Count() });
            foreach (var item in dep)
            {
                Console.WriteLine($"Для спецiалiзацiї {specialization} дiагноз {item.Diagnosis} поставлено {item.Count} разiв");
            }

            return Patients;
        }
//с) Вивести ті діагнози, кількість різних пацієнтів з якими протягом заданого терміну є найбільшою.

  public static List<Patients> C(List<Patients> patients, DateTime startDate, DateTime endDate)
        {

            var filtered = patients.Where(p => p.DateOfReceipt >= startDate && p.DateOfDischarge <= endDate);

            var grouped = filtered.GroupBy(p => p.Diagnosis).Select(g => new { Diagnosis = g.Key, Count = g.Select(p => p.Surname).Distinct().Count() });

            var maxCount = grouped.Max(g => g.Count);

            var result = grouped.Where(g => g.Count == maxCount).Select(g => g.Diagnosis);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            return patients;

           
}

    }
}
 
