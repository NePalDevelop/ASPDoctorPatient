using System;
using TestASPDoctorPatient.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASPDoctorPatient.Helper
{
    public static class Mapper
    {
        public static Doctor MapFromData(Data.Models.Doctor doctor)
        {
            return new Doctor { 
                ID = doctor.ID,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Patronymic = doctor.Patronymic,
                CabinetNumber = doctor.Cabinet?.Number,
                AreaNumber = doctor.Area?.Number,
                SpecializationName = doctor.Spec?.Name
            };
        }


    }
}
