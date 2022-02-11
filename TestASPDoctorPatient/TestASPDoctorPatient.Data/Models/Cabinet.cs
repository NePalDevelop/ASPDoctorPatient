﻿using System.Collections.Generic;

namespace TestASPDoctorPatient.Data.Models

{
    public class Cabinet
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public ICollection<Doctor> Doctors { get; set; }

    }
}
