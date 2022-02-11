using System;
using TestASPDoctorPatient.Data.Enums;
using System.Linq;
using TestASPDoctorPatient.Data.Models;


namespace TestASPDoctorPatient.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HospitalContext context)
        {
            context.Database.EnsureCreated();

            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }

            var cabinets = new Cabinet[]
            {
                new Cabinet {Number = "1"},
                new Cabinet {Number = "2"},
                new Cabinet {Number = "2A"},
                new Cabinet {Number = "3"},
                new Cabinet {Number = "4"}
            };
            foreach (var c in cabinets)
            {
                context.Cabinets.Add(c); 
            }
            context.SaveChanges();

            var areas = new ServiceArea[]
            {
                new ServiceArea {Number = "A"},
                new ServiceArea {Number = "B"},
                new ServiceArea {Number = "C"},
                new ServiceArea {Number = "D"},
                new ServiceArea {Number = "E"}
            };
            foreach (var a in areas)
            {
                context.Areas.Add(a);
            }
            context.SaveChanges();

            var specs = new Specialization[]
            {
                new Specialization {Name = "Терапевт"},
                new Specialization {Name = "Окулист"},
                new Specialization {Name = "Хирург"},
                new Specialization {Name = "Отоларинголог"},
                new Specialization {Name = "Невролог"}
            };
            foreach (var s in specs)
            {
                context.Specializations.Add(s);
            }
            context.SaveChanges();

            var doctors = new Doctor[] 
            { 
                new Doctor {LastName = "Иванов", FirstName = "Сергей", Patronymic = "Петрович",AreaId = 1, CabinetId = 1, SpecializationId = 1},
                new Doctor {LastName = "Скворцова", FirstName = "Ирина", Patronymic = "Ивановна",AreaId = 2, CabinetId = 2, SpecializationId = 1},
                new Doctor {LastName = "Сидоров", FirstName = "Петр", Patronymic = "Ильич",AreaId = 3, CabinetId = 1, SpecializationId = 1},
                new Doctor {LastName = "Чернов", FirstName = "Иван", Patronymic = "Петрович",AreaId = 4, CabinetId = 2, SpecializationId = 1},
                new Doctor {LastName = "Котова", FirstName = "Полина", Patronymic = "Павловна",AreaId = 5, CabinetId = 1, SpecializationId = 1},
                new Doctor {LastName = "Мальцева", FirstName = "Антонина", Patronymic = "Ивановна", CabinetId = 3, SpecializationId = 2},
                new Doctor {LastName = "Дронов", FirstName = "Илья", Patronymic = "Семенович", CabinetId = 3, SpecializationId = 2},
                new Doctor {LastName = "Дронова", FirstName = "Мария", Patronymic = "Федоровна", CabinetId = 4, SpecializationId = 3},
                new Doctor {LastName = "Кулик", FirstName = "Федор", Patronymic = "Степанович", CabinetId = 4, SpecializationId = 3},
                new Doctor {LastName = "Ступак", FirstName = "Татьяна", Patronymic = "Александровна", CabinetId = 5, SpecializationId = 4},
                new Doctor {LastName = "Стоянова", FirstName = "Вера", Patronymic = "Ивановна", CabinetId = 5, SpecializationId = 5}
            };
            
            foreach (var d in doctors)
            {
                context.Doctors.Add(d);
            }
            context.SaveChanges();

            var patients = new Patient[]
            {
            new Patient{LastName="Крутов",FirstName="Владимир",Patronymic = "Сидорович", Address ="Москва", Birthdate=DateTime.Parse("1982-09-01"), Gender = Gender.Man, AreaId = 1},
            new Patient{LastName="Крутова",FirstName="Елена",Patronymic = "Павловна", Address ="Москва", Birthdate=DateTime.Parse("1985-08-12"), Gender = Gender.Woman, AreaId = 1},
            new Patient{LastName="Васильев",FirstName="Иван",Patronymic = "Иванович", Address ="Москва", Birthdate=DateTime.Parse("2005-09-01"), Gender = Gender.Man, AreaId = 2},
            new Patient{LastName="Голов",FirstName="Сергей",Patronymic = "Ильич", Address ="Москва", Birthdate=DateTime.Parse("2001-06-22"), Gender = Gender.Man, AreaId = 2},
            new Patient{LastName="Крюков",FirstName="Александр",Patronymic = "Петрович", Address ="Москва", Birthdate=DateTime.Parse("1955-11-08"), Gender = Gender.Man, AreaId = 3},
            new Patient{LastName="Машкова",FirstName="Виктория",Patronymic = "Владимировна", Address ="Москва", Birthdate=DateTime.Parse("2001-08-08"), Gender = Gender.Woman, AreaId = 3},
            new Patient{LastName="Смолова",FirstName="Зинаида",Patronymic = "Сидоровна", Address ="Москва", Birthdate=DateTime.Parse("1965-07-07"), Gender = Gender.Woman, AreaId = 4},
            new Patient{LastName="Валиева",FirstName="Камилла",Patronymic = "Ринатовна", Address ="Москва", Birthdate=DateTime.Parse("2007-04-08"), Gender = Gender.Woman, AreaId = 4},
            new Patient{LastName="Медведева",FirstName="Наталья",Patronymic = "Ивановна", Address ="Москва", Birthdate=DateTime.Parse("1959-01-15"), Gender = Gender.Woman, AreaId = 5},
            new Patient{LastName="Загитов",FirstName="Дамир",Patronymic = "Радикович", Address ="Москва", Birthdate=DateTime.Parse("2011-09-13"), Gender = Gender.Man, AreaId = 5}
            };

            foreach (var p in patients)
            {
                context.Patients.Add(p);
            }
            context.SaveChanges();
        }
    }
}
