using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestASPDoctorPatient.Data.Models;

namespace TestASPDoctorPatient.Data.Stores
{
    public class PatientStore
    {
        private readonly DPContext _context;

        public PatientStore(DPContext context)
        {
            _context = context;
        }

        // Возвращает список всех пациентов 
        // список упорядочен по фамилии

        public async Task<IEnumerable<Patient>> GetPatients()
        {

            var query = _context.Patients
                .Include(a => a.Area)
                .OrderBy(d => d.LastName);

            return await query.ToListAsync();

        }

        // Возвращает список пациентов пропуская skipID позиций
        // количество записей = number, список упорядочен по фамилии
        public async Task<IEnumerable<Patient>> GetPatients(int skipID, int number)
        {

            var query = _context.Patients
                .Include(a => a.Area)
                .OrderBy(d => d.LastName);

            var patients = await query.Skip(skipID)
                                .Take(number)
                                .ToListAsync();

            return patients;

        }


        // Возвращает пациента по id

        public async Task<Patient> GetPatient(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var patient = await _context.Patients
                .Include(a => a.Area)
                .FirstOrDefaultAsync(p => p.ID == id);

            return patient;
        }

        // Добавление нового пациента

        public async Task<Patient> AddPatient(Patient patient)
        {

            _context.Add(patient);
            await _context.SaveChangesAsync();

            patient = await _context.Patients
                .Include(a => a.Area)
                .FirstOrDefaultAsync(p => p.ID == patient.ID);

            return patient;
        }

        // Изменение данных у пациента

        public async Task<Patient> PutPatient(Patient patient)
        {

            if ( !PatientExists(patient.ID) )
            {
                return null;
            }


            _context.Update(patient);
            await _context.SaveChangesAsync();

            patient = await _context.Patients
                .Include(a => a.Area)
                .FirstOrDefaultAsync(p => p.ID == patient.ID);

            return patient;
        }

        // Удаление пациента 

        public async Task DeletePatient(Patient patient)
        {

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return;
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.ID == id);
        }

    }
}




//=============================================================================
/*


    }
}
*/