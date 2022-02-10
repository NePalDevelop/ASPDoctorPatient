using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestASPDoctorPatient.Data.Stores;
using TestASPDoctorPatient.Helper;
using TestASPDoctorPatient.Models;




namespace TestASPDoctorPatient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
 
        private readonly DoctorStore _doctorStore;

        public DoctorController(DoctorStore doctor)
        {
            _doctorStore = doctor;
         }

        // GET: api/<DoctorController>
        public async Task<ActionResult<IEnumerable<Doctor>>> Get()
        {
            var doctors = await _doctorStore.GetDoctors();

            List<Doctor> docs = new();

            foreach (var d in doctors)
            {
                docs.Add(Mapper.MapFromData(d));
            }

            return docs;
        }


        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> Get(int id)
        {

            var doctor = await _doctorStore.GetDoctor(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Mapper.MapFromData(doctor);
        }

        // GET api/<DoctorController>/5/5
        [HttpGet("{startid}/{number}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> Get(int startid, int number)
        {

            var doctors = await _doctorStore.GetDoctors(startid, number);

            if (doctors == null)
            {
                return NotFound();
            }

            List<Doctor> docs = new();

            foreach (var d in doctors)
            {
                docs.Add(Mapper.MapFromData(d));
            }

            return docs;
        }



        // POST api/<DoctorController>
        [HttpPost]

        public async Task<ActionResult<Doctor>> Create([FromBody] Doctor doctor)
        {

            if (ModelState.IsValid)
            {
                Data.Models.Doctor _doctor = Mapper.MapToData(doctor);
                _doctor = await _doctorStore.AddDoctor(_doctor);
                return Mapper.MapFromData(_doctor);
            }
            return doctor;
        }


        // PUT api/<DoctorController>/5
        [HttpPut]
        public async Task<ActionResult<Doctor>> Put([FromBody] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                Data.Models.Doctor _doctor = Mapper.MapToData(doctor);
                _doctor = await _doctorStore.PutDoctor(_doctor);
                return Mapper.MapFromData(_doctor);
            }
            return doctor;

        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var doctor = await _doctorStore.GetDoctor(id);

            if (doctor == null)
                return NotFound();
            await _doctorStore.DeleteDoctor(doctor);

            return Ok();
        }

        
    }
}
