using System.ComponentModel.DataAnnotations;

namespace TestASPDoctorPatient.Models
{
    public class Doctor
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public Cabinet Cabinet { get; set; }

        public ServiceArea Area { get; set; }

        [Required]
        public Specialization SpecializationID { get; set; }

    }
}
