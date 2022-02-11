using System;
using TestASPDoctorPatient.Data.Enums;

namespace TestASPDoctorPatient.Data.Models
{

    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }
        
        public Gender? Gender { get; set; }

        public int? AreaId { get; set; }
        public ServiceArea Area { get; set; }

    }
}
