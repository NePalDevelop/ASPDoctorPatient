using TestASPDoctorPatient.Models;


namespace TestASPDoctorPatient.Helper
{
    public static class Mapper
    {
        public static Doctor MapFromData(Data.Models.Doctor doctor)
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
                Spec = doctor.Spec == null ? null : new Specialization { ID = doctor.SpecID, Name = doctor.Spec.Name }
            };
        }

        public static Data.Models.Doctor MapToData(Doctor doctor)
        {
            if (doctor == null) return null;

            return new Data.Models.Doctor
            {
                ID = doctor.ID ?? default,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Patronymic = doctor.Patronymic,
                CabinetID = doctor.Cabinet.ID,
                AreaID = doctor.Area.ID,
                SpecID = doctor.Spec.ID
            };
        }


    }
}
