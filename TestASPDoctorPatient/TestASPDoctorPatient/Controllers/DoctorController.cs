using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestASPDoctorPatient.Data.Stores;
using TestASPDoctorPatient.Helpers;
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

            return doctors.Select(Mapper.MapDoctorFromData).ToList();
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

            return Mapper.MapDoctorFromData(doctor);
        }


        // GET api/<DoctorController>/5/5
        // Возвращает постранично список докторов
        // Список упорядочен по фамилии - SecondName
        // Входные параметры pageIndex - номер запрашиваемой страницы
        // pageSize - количество строк на странице
        [HttpGet("{pageIndex}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> PaginatedGetDoctor(int pageIndex, int pageSize)
        {
            if (pageIndex < 1 || pageSize < 1)
            {
                return BadRequest("Некорректно заданы параметры страницы");
            }

            var doctors = await _doctorStore.GetDoctors((pageIndex - 1) * pageSize, pageSize);

            if (doctors == null)
            {
                return NotFound();
            }

            return doctors.Select(Mapper.MapDoctorFromData).ToList();
        }

        // POST api/<DoctorController>
        [HttpPost]

        public async Task<ActionResult<Doctor>> CreateDoctor([FromBody] Doctor doctor)
        {

            if (ModelState.IsValid)
            {
                Data.Models.Doctor _doctor = Mapper.MapDoctorToData(doctor);
                _doctor = await _doctorStore.AddDoctor(_doctor);
                return Mapper.MapDoctorFromData(_doctor);
            }
            return ValidationProblem();
        }

        // PUT api/<DoctorController>/5
        [HttpPut]
        public async Task<ActionResult<Doctor>> PutDoctor([FromBody] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                Data.Models.Doctor _doctor = Mapper.MapDoctorToData(doctor);
                
                _doctor = await _doctorStore.PutDoctor(_doctor);

                if (_doctor == null)
                {
                    return NotFound();
                }

                return Mapper.MapDoctorFromData(_doctor);
            }
            return ValidationProblem();

        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorStore.GetDoctor(id);

            if (doctor == null)
            {
                return NotFound();
            }

            await _doctorStore.DeleteDoctor(doctor);

            return Ok();
        }

    }
}
