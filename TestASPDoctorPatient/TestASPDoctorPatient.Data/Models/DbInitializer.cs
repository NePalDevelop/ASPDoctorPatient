using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestASPDoctorPatient.Data.Models
{
    public static class DbInitializer
    {
        public static void Initialize(DPContext context)
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
            foreach (Cabinet c in cabinets)
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
            foreach (ServiceArea a in areas)
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
            foreach (Specialization s in specs)
            {
                context.Specializations.Add(s);
            }
            context.SaveChanges();

            var doctors = new Doctor[] 
            { 
                new Doctor {LastName = "Иванов", FirstName = "Сергей", Patronymic = "Петрович",IDArea = 1, IDCabinet = 1, IDSpec = 1},
                new Doctor {LastName = "Скворцова", FirstName = "Ирина", Patronymic = "Ивановна",IDArea = 2, IDCabinet = 2, IDSpec = 1},
                new Doctor {LastName = "Сидоров", FirstName = "Петр", Patronymic = "Ильич",IDArea = 3, IDCabinet = 1, IDSpec = 1},
                new Doctor {LastName = "Чернов", FirstName = "Иван", Patronymic = "Петрович",IDArea = 4, IDCabinet = 2, IDSpec = 1},
                new Doctor {LastName = "Котова", FirstName = "Полина", Patronymic = "Павловна",IDArea = 5, IDCabinet = 1, IDSpec = 1},
                new Doctor {LastName = "Мальцева", FirstName = "Антонина", Patronymic = "Ивановна", IDCabinet = 3, IDSpec = 2},
                new Doctor {LastName = "Дронов", FirstName = "Илья", Patronymic = "Семенович", IDCabinet = 3, IDSpec = 2},
                new Doctor {LastName = "Дронова", FirstName = "Мария", Patronymic = "Федоровна", IDCabinet = 4, IDSpec = 3},
                new Doctor {LastName = "Кулик", FirstName = "Федор", Patronymic = "Степанович", IDCabinet = 4, IDSpec = 3},
                new Doctor {LastName = "Ступак", FirstName = "Татьяна", Patronymic = "Александровна", IDCabinet = 5, IDSpec = 4},
                new Doctor {LastName = "Стоянова", FirstName = "Вера", Patronymic = "Ивановна", IDCabinet = 5, IDSpec = 5}
            };
            
            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }
            context.SaveChanges();



            var patietns = new Patient[]
            {
            new Patient{LastName="Крутов",FirstName="Владимир",Patronymic = "Сидорович", Address ="Москва", Birthdate=DateTime.Parse("1982-09-01"), Gender = Gender.Man, IDArea = 1},
            new Patient{LastName="Крутова",FirstName="Елена",Patronymic = "Павловна", Address ="Москва", Birthdate=DateTime.Parse("1985-08-12"), Gender = Gender.Woman, IDArea = 1},
            new Patient{LastName="Васильев",FirstName="Иван",Patronymic = "Иванович", Address ="Москва", Birthdate=DateTime.Parse("2005-09-01"), Gender = Gender.Man, IDArea = 2},
            new Patient{LastName="Голов",FirstName="Сергей",Patronymic = "Ильич", Address ="Москва", Birthdate=DateTime.Parse("2001-06-22"), Gender = Gender.Man, IDArea = 2},
            new Patient{LastName="Крюков",FirstName="Александр",Patronymic = "Петрович", Address ="Москва", Birthdate=DateTime.Parse("1955-11-08"), Gender = Gender.Man, IDArea = 3},
            new Patient{LastName="Машкова",FirstName="Виктория",Patronymic = "Владимировна", Address ="Москва", Birthdate=DateTime.Parse("2001-08-08"), Gender = Gender.Woman, IDArea = 3},
            new Patient{LastName="Смолова",FirstName="Зинаида",Patronymic = "Сидоровна", Address ="Москва", Birthdate=DateTime.Parse("1965-07-07"), Gender = Gender.Woman, IDArea = 4},
            new Patient{LastName="Валиева",FirstName="Камилла",Patronymic = "Ринатовна", Address ="Москва", Birthdate=DateTime.Parse("2007-04-08"), Gender = Gender.Woman, IDArea = 4},
            new Patient{LastName="Медведева",FirstName="Наталья",Patronymic = "Ивановна", Address ="Москва", Birthdate=DateTime.Parse("1959-01-15"), Gender = Gender.Woman, IDArea = 5},
            new Patient{LastName="Загитов",FirstName="Дамир",Patronymic = "Радикович", Address ="Москва", Birthdate=DateTime.Parse("2011-09-13"), Gender = Gender.Man, IDArea = 5}
            };

            foreach (Patient p in patietns)
            {
                context.Patients.Add(p);
            }
            context.SaveChanges();
        }
    }
}
