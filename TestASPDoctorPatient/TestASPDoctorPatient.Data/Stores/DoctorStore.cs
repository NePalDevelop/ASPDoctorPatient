using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestASPDoctorPatient.Data.Models;

namespace TestASPDoctorPatient.Data.Stores
{
    public class DoctorStore
    {
        private readonly DPContext _context;

        public DoctorStore(DPContext context)
        {
            _context = context;
        }

        // Возвращает список всех врачей 
        // список упорядочен по фамилии

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {

            var query = _context.Doctors
                .Include(c => c.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Specialization)
                .OrderBy(d => d.LastName);

            return await query.ToListAsync();

        }




        // Возвращает список врачей пропуская skipID позиций
        // количество записей = number, список упорядочен по фамилии
        public async Task<IEnumerable<Doctor>> GetDoctors(int skipID, int number)
        {

            var query = _context.Doctors
                .Include(c => c.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Specialization)
                .OrderBy(d => d.LastName);

            var doctors = await query.Skip(skipID).Take(number).ToListAsync();

            return doctors;

        }

        // Возвращает врача по id

        public async Task<Doctor> GetDoctor(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var doctor = await _context.Doctors
                .Include(c => c.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Specialization)
                .FirstOrDefaultAsync(d => d.ID == id);

            return doctor;
        }
        
        // Добавление нового врача

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {

            _context.Add(doctor);
            await _context.SaveChangesAsync();

            doctor = await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Specialization)
                .FirstOrDefaultAsync(m => m.ID == doctor.ID);

            return doctor;
        }

        // Изменение данных у врача

        public async Task<Doctor> PutDoctor(Doctor doctor)
        {
            if (!DoctorExists(doctor.ID))
            {
                return null;
            }

            _context.Update(doctor);
            await _context.SaveChangesAsync();

            doctor = await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Specialization)
                .FirstOrDefaultAsync(m => m.ID == doctor.ID);

            return doctor;
        }

        // Удаление врача 

        public async Task DeleteDoctor(Doctor doctor)
        {

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return ;
        }
        
        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.ID == id);
        }
    }
}
