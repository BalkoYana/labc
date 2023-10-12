using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lablinq
{
    internal class Patients
    {
        public string Surname { get; set; }
        public DateTime Birthday {get;set;}
        public string Diagnosis { get; set; }
        public string DoctorsSurname { get; set; }
        public string Department { get; set; }
        public DateTime DateOfReceipt { get; set; }
        public DateTime DateOfDischarge { get; set; }


    }
}
