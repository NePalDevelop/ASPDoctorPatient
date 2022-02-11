using System;
using System.ComponentModel.DataAnnotations;
using TestASPDoctorPatient.Data.Enums;

namespace TestASPDoctorPatient.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Address { get; set; }

        public DateTime? Birthdate { get; set; }

        public Gender? Gender { get; set; }

        [Required]
        public ServiceArea Area { get; set; }
    }
}
