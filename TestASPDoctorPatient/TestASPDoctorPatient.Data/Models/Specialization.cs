using System.Collections.Generic;

namespace TestASPDoctorPatient.Data.Models
{
    public class Specialization
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }

    }
}
