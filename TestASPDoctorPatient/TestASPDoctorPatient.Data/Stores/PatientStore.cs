using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestASPDoctorPatient.Data.Models;

namespace TestASPDoctorPatient.Data.Stores
{
    public class PatientStore
    {
        private readonly HospitalContext _context;

        public PatientStore(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает список всех пациентов 
        /// список упорядочен по фамилии
        /// </summary>
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var query = _context.Patients
                .Include(a => a.Area)
                .OrderBy(d => d.LastName);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Возвращает список пациентов пропуская skip позиций
        /// количество записей = number, список упорядочен по фамилии
        /// </summary>
        public async Task<IEnumerable<Patient>> GetPatients(int skip, int number)
        {
            var query = _context.Patients
                .Include(a => a.Area)
                .OrderBy(d => d.LastName);

            return await query.Skip(skip)
                                .Take(number)
                                .ToListAsync();
        }

        /// <summary>
        /// Возвращает пациента по id
        /// </summary>
        public async Task<Patient> GetPatient(int id)
        {
            return await _context.Patients
                .Include(a => a.Area)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Добавление нового пациента
        /// </summary>
        public async Task<Patient> AddPatient(Patient patient)
        {
            _context.Add(patient);
            await _context.SaveChangesAsync();

            return await _context.Patients
                .Include(a => a.Area)
                .FirstOrDefaultAsync(p => p.Id == patient.Id);
        }

        /// <summary>
        /// Изменение данных у пациента
        /// </summary>
        public async Task<Patient> UpdatePatient(Patient patient)
        {
            if (!await PatientExists(patient.Id))
            {
                return null;
            }

            _context.Update(patient);
            await _context.SaveChangesAsync();

            return await _context.Patients
                .Include(a => a.Area)
                .FirstOrDefaultAsync(p => p.Id == patient.Id);
        }

        /// <summary>
        /// Удаление пациента 
        /// </summary>
        public async Task DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Проверка существования пациента по Id
        /// </summary>
        private async Task<bool> PatientExists(int id)
        {
            return await _context.Patients.AnyAsync(e => e.Id == id);
        }
    }
}
