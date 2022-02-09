using System.Collections.Generic;

namespace TestASPDoctorPatient.Data.Models
{
    public class ServiceArea
    {
        public int ID { get; set; }
        public string Number { get; set; }

        public ICollection<Doctor> Doctors { get; set; }

        public ICollection<Patient> Patients { get; set; }

    }
}
