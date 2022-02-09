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
            //var query = from d in _context.Doctors
            //            join c in _context.Cabinets
            //                on d.CabinetID equals c.ID
            //            select d

            //            new Doctor
            //            {
            //                ID = d.ID,
            //                FirstName = d.FirstName,
            //                LastName = d.LastName,
            //                Patronymic = d.Patronymic,
            //                CabinetID = d.CabinetID,
            //                Cabinet = new Cabinet { ID = c.ID, Number = c.Number },
            //                AreaID = d.AreaID,
            //                SpecID = d.SpecID
            //            };
            //var doctors =  _context.Doctors
            //    .Include(d => d.Cabinet)
            //    .Where();



            //  return await query.ToListAsync();
            var query = _context.Doctors.Include(d => d.Cabinet);
            return await query.ToListAsync();
//            return doctors;
        }

    }
}
