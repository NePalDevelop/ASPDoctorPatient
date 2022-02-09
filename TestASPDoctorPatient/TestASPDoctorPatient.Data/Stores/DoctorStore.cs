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

        // GET: Doctors
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {

            var query = _context.Doctors
                .Include(d => d.Cabinet)
                .Include(a => a.Area)
                .Include(s => s.Spec);

            return await query.ToListAsync();

        }
        // GET: Doctor (ID)
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
            if (doctor == null)
            {
                return null;
            }

            return doctor;
        }

    }
}
