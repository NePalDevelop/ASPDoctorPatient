using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestASPDoctorPatient.Data.Models;

namespace TestASPDoctorPatient.Data.Stores
{
    public class DoctorStore
    {
        private readonly HospitalContext _context;

        public DoctorStore(HospitalContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает список всех врачей 
        /// список упорядочен по фамилии
        /// </summary>
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var query = _context.Doctors
                .Include(c => c.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Specialization)
                .OrderBy(d => d.LastName);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Возвращает список врачей пропуская skipID позиций
        /// количество записей = number, список упорядочен по фамилии
        /// </summary>
        public async Task<IEnumerable<Doctor>> GetDoctors(int skip, int number)
        {
            var query = _context.Doctors
                .Include(c => c.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Specialization)
                .OrderBy(d => d.LastName);

            var doctors = await query.Skip(skip).Take(number).ToListAsync();

            return doctors;
        }

        /// <summary>
        /// Возвращает врача по id
        /// </summary>
        public async Task<Doctor> GetDoctor(int id)
        {
            return await _context.Doctors
                .Include(c => c.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Specialization)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        /// <summary>
        /// Добавление нового врача
        /// </summary>
        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            _context.Add(doctor);
            await _context.SaveChangesAsync();

            return await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Specialization)
                .FirstOrDefaultAsync(m => m.Id == doctor.Id);
        }

        /// <summary>
        /// Изменение данных у врача
        /// </summary>
        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            if (!await DoctorExists(doctor.Id))
            {
                return null;
            }

            _context.Update(doctor);
            await _context.SaveChangesAsync();

            return await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Specialization)
                .FirstOrDefaultAsync(m => m.Id == doctor.Id);
        }

        /// <summary>
        /// Удаление врача 
        /// </summary>
        public async Task DeleteDoctor(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
        
        private async Task<bool> DoctorExists(int id)
        {
            return await _context.Doctors.AnyAsync(e => e.Id == id);
        }
    }
}
