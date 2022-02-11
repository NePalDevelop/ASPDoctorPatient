using TestASPDoctorPatient.Models;

namespace TestASPDoctorPatient.Helpers
{
    public static class Mapper
    {
        public static Doctor MapDoctorFromData(Data.Models.Doctor doctor)
        {
            if (doctor == null) return null;

            return new Doctor
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Patronymic = doctor.Patronymic,
                Cabinet = doctor.Cabinet == null ? null : new Cabinet { Id = doctor.Cabinet.Id, Number = doctor.Cabinet.Number },
                Area = doctor.Area == null ? null : new ServiceArea { Id = doctor.Area.Id, Number = doctor.Area.Number },
                Specialization = doctor.Specialization == null ? null : new Specialization { Id = doctor.SpecializationId, Name = doctor.Specialization.Name }
            };
        }

        public static Data.Models.Doctor MapDoctorToData(Doctor doctor)
        {
            if (doctor == null) return null;

            return new Data.Models.Doctor
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Patronymic = doctor.Patronymic,
                CabinetId = doctor.Cabinet?.Id,
                AreaId = doctor.Area?.Id,
                SpecializationId = doctor.Specialization.Id
            };
        }

        public static Patient MapPatientFromData(Data.Models.Patient patient)
        {
            if (patient == null) return null;

            return new Patient
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Patronymic = patient.Patronymic,
                Address = patient.Address,
                Birthdate = patient.Birthdate,
                Gender = patient.Gender,
                Area = patient.Area == null ? null : new ServiceArea { Id = patient.Area.Id, Number = patient.Area.Number },
            };
        }

        public static Data.Models.Patient MapPatientToData(Patient patient)
        {
            if (patient == null) return null;

            return new Data.Models.Patient
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Patronymic = patient.Patronymic,
                Address = patient.Address,
                Birthdate = patient.Birthdate,
                Gender = patient.Gender,
                AreaId = patient.Area?.Id
            };
        }
    }
}


