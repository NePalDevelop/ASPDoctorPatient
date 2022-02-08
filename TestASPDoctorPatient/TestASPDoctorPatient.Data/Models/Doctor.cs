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

        public int IDCabinet { get; set; }

        public int? IDArea { get; set; }

        public int IDSpec { get; set; } 

    }
}
