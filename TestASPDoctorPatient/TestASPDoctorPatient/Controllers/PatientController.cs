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
    public class PatientController : ControllerBase
    {
        private readonly PatientStore _patientStore;

        public PatientController(PatientStore patient)
        {
            _patientStore = patient;
        }

        // GET: api/Patient
        public async Task<ActionResult<IEnumerable<Patient>>> Get()
        {
            var patients = await _patientStore.GetPatients();

            return patients.Select(Mapper.MapPatientFromData).ToList();
        }

        // GET api/Patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            var patient = await _patientStore.GetPatient(id);

            if (patient == null)
            {
                return NotFound();
            }
            return Mapper.MapPatientFromData(patient);
        }

        // GET api/Patient/5/5
        // Возвращает постранично список пациентов
        // Список упорядочен по фамилии - SecondName
        // Входные параметры pageIndex - номер запрашиваемой страницы
        // pageSize - количество строк на странице

        [HttpGet("{pageIndex}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<Patient>>> PaginatedGetPatient(int pageIndex, int pageSize)
        {
            if (pageIndex < 1 || pageSize < 1)
            {
                return BadRequest("Некорректно заданы параметры страницы");
            }

            var patients = await _patientStore.GetPatients((pageIndex - 1) * pageSize, pageSize);

            if (patients == null)
            {
                return NotFound();
            }
            return patients.Select(Mapper.MapPatientFromData).ToList();
        }

        // POST api/Patient
        [HttpPost]
        public async Task<ActionResult<Patient>> CreatePatient([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            var createdPatient = await _patientStore.AddPatient(Mapper.MapPatientToData(patient));

            return Mapper.MapPatientFromData(createdPatient);
        }

        // PUT api/Patient/5
        [HttpPut]
        public async Task<ActionResult<Patient>> UpdatePatient([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            var createdPatient = await _patientStore.UpdatePatient(Mapper.MapPatientToData(patient));

            if (createdPatient == null)
            {
                return NotFound();
            }
            return Mapper.MapPatientFromData(createdPatient);
        }

        // DELETE api/Patient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var patient = await _patientStore.GetPatient(id);

            if (patient == null)
            {
                return NotFound();
            }

            await _patientStore.DeletePatient(patient);

            return Ok();
        }

    }
}

