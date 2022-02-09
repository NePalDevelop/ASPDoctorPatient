using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestASPDoctorPatient.Data.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public int? CabinetID { get; set; }
        public Cabinet Cabinet { get; set; }

        public int? AreaID { get; set; }
        public ServiceArea Area { get; set; }

        public int SpecID { get; set; } 
        public Specialization Spec { get; set; }

    }
}
