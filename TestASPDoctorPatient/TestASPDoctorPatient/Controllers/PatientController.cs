using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        // GET: api/<PatientController>
        public async Task<ActionResult<IEnumerable<Patient>>> Get()
        {
            var patients = await _patientStore.GetPatients();

            List<Patient> pats = new();

            foreach (var p in patients)
            {
                pats.Add(Mapper.MapPatientFromData(p));
            }

            return pats;
        }

        // GET api/<PatientController>/5
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


        // GET api/<PatientController>/5/5
        // Возвращает постранично список докторов
        // Список упорядочен по фамилии - SecondName
        // Входные параметры pageIndex - номер запрашиваемой страницы
        // pageSize - количество строк на странице

        [HttpGet("{pageIndex}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<Patient>>> PaginatedGetPatient(int pageIndex, int pageSize)
        {

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 5 : pageSize;

            var patients = await _patientStore.GetPatients((pageIndex - 1) * pageSize, pageSize);

            if (patients == null)
            {
                return NotFound();
            }

            List<Patient> pats = new();

            foreach (var p in patients)
            {
                pats.Add(Mapper.MapPatientFromData(p));
            }

            return pats;
        }



        // POST api/<PatientController>
        [HttpPost]

        public async Task<ActionResult<Patient>> CreatePatient([FromBody] Patient patient)
        {

            if (ModelState.IsValid)
            {
                Data.Models.Patient _patient = Mapper.MapPatientToData(patient);
                _patient = await _patientStore.AddPatient(_patient);
                return Mapper.MapPatientFromData(_patient);
            }
            return ValidationProblem();
        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public async Task<ActionResult<Patient>> PutPatient([FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                Data.Models.Patient _patient = Mapper.MapPatientToData(patient);

                _patient = await _patientStore.PutPatient(_patient);

                if (_patient == null)
                {
                    return NotFound();
                }

                return Mapper.MapPatientFromData(_patient);
            }
            
            return ValidationProblem();

        }

        // DELETE api/<PatientController>/5
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

