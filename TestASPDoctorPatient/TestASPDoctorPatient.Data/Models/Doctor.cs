using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestASPDoctorPatient.Data.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public int? CabinetId { get; set; }
        public Cabinet Cabinet { get; set; }

        public int? AreaId { get; set; }
        public ServiceArea Area { get; set; }

        public int SpecializationId { get; set; } 
        public Specialization Specialization { get; set; }

    }
}
