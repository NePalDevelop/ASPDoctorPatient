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
                ID = doctor.ID,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Patronymic = doctor.Patronymic,
                Cabinet = doctor.Cabinet == null ? null : new Cabinet { ID = doctor.Cabinet.ID, Number = doctor.Cabinet.Number },
                Area = doctor.Area == null ? null : new ServiceArea { ID = doctor.Area.ID, Number = doctor.Area.Number },
                SpecializationID = doctor.Specialization == null ? null : new Specialization { ID = doctor.SpecializationID, Name = doctor.Specialization.Name }
            };
        }

        public static Data.Models.Doctor MapDoctorToData(Doctor doctor)
        {
            if (doctor == null) return null;

            return new Data.Models.Doctor
            {
                ID = doctor.ID ?? default,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Patronymic = doctor.Patronymic,
                CabinetID = doctor.Cabinet?.ID,
                AreaID = doctor.Area?.ID,
                SpecializationID = doctor.SpecializationID.ID
            };
        }

        public static Patient MapPatientFromData(Data.Models.Patient patient)
        {
            if (patient == null) return null;

            return new Patient
            {
                ID = patient.ID,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Patronymic = patient.Patronymic,
                Address = patient.Address,
                Birthdate = patient.Birthdate,
                Gender = patient.Gender,
                Area = patient.Area == null ? null : new ServiceArea { ID = patient.Area.ID, Number = patient.Area.Number },
            };
        }

        public static Data.Models.Patient MapPatientToData(Patient patient)
        {
            if (patient == null) return null;

            return new Data.Models.Patient
            {
                ID = patient.ID ?? default,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Patronymic = patient.Patronymic,
                Address = patient.Address,
                Birthdate = patient.Birthdate,
                Gender = patient.Gender,
                AreaID = patient.Area?.ID
            };
        }
    }
}


