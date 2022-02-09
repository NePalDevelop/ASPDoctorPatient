using System;
using System.Collections.Generic;

namespace TestASPDoctorPatient.Data.Models
{
    public enum Gender
    {
        Man,
        Woman
    }

    public class Patient
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Address { get; set; }
        public DateTime? Birthdate { get; set; }
        
        public Gender? Gender { get; set; }

        public int? AreaID { get; set; }
        

    }
}
