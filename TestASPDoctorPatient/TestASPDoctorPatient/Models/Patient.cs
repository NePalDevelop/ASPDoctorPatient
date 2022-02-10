using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPDoctorPatient.Data.Enums;

namespace TestASPDoctorPatient.Models
{
    public class Patient
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }

        public Gender? Gender { get; set; }

        public ServiceArea Area { get; set; }

    }
}
