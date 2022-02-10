using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IEnumerable<Doctor>> GetDoctors() => await GetDoctors(-1, -1);

        //{

        //    //var query = _context.Doctors
        //    //    .Include(d => d.Cabinet)
        //    //    .Include(a => a.Area)
        //    //    .Include(s => s.Spec)
        //    //    .OrderBy(d => d.LastName);

        //    //return await query.ToListAsync();
        //    //return await GetDoctors(-1, -1);

        //}


        // Возвращает список врачей начиная с позции idStart
        // количество записей = number, список упорядочен по фамилии
        public async Task<IEnumerable<Doctor>> GetDoctors(int idStart, int number)
        {

            var query = _context.Doctors
                .Include(c => c.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Spec)
                .OrderBy(d => d.LastName);

            var count = await query.CountAsync();
            var doctors = await query.Skip((idStart <= 0 ? 1 : idStart) - 1).Take(number <= 0 ? count : number).ToListAsync();

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
                .Include(d => d.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Spec)
                .FirstOrDefaultAsync(m => m.ID == id);

            return doctor;
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {

            _context.Add(doctor);
            await _context.SaveChangesAsync();

            doctor = await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Spec)
                .FirstOrDefaultAsync(m => m.ID == doctor.ID);

            return doctor;
        }

        public async Task<Doctor> PutDoctor(Doctor doctor)
        {

            _context.Update(doctor);
            await _context.SaveChangesAsync();

            doctor = await _context.Doctors
                .Include(d => d.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Spec)
                .FirstOrDefaultAsync(m => m.ID == doctor.ID);

            return doctor;
        }

        public async Task DeleteDoctor(Doctor doctor)
        {

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return ;
        }

    }
}
