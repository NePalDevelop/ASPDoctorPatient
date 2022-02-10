
namespace TestASPDoctorPatient.Models
{
    public class Doctor
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public Cabinet Cabinet { get; set; }

        public ServiceArea Area { get; set; }

        public Specialization Spec { get; set; }

    }
}
