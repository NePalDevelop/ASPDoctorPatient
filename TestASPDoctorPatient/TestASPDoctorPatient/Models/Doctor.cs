using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASPDoctorPatient.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public string CabinetNumber { get; set; }

        public string AreaNumber { get; set; }

        public string SpecializationName { get; set; }

    }
}
