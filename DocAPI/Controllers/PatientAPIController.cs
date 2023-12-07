using DoctorsAppointments.Data;
using DoctorsAppointments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        private readonly AppointmentDbContext _cxt;

        public PatientAPIController(AppointmentDbContext cxt)
        {
            _cxt = cxt;
        }


        //PATIENT END POINTS
        [HttpGet("Patient")]
        public IActionResult GetPatients()
        {
            var patients = _cxt.Patients.Include(p => p.Parish).ToList();
            if (patients == null)
            {
                return BadRequest();
            }
            return Ok(patients);
                
                
        }


        //Find individual record by id
        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _cxt.Patients.Include(p => p.Parish).FirstOrDefault(x => x.Id == id);

            if(patient == null)
            {
                return NotFound();
            }
            return Ok(patient);

        }


        //create record
        [HttpPost("PatientPost")]

        public IActionResult CreatePatient([FromBody] Patient values)
        {
            _cxt.Patients.Add(values);
            _cxt.SaveChanges();
            return CreatedAtAction(nameof(GetPatientById), new {id = values.Id}, values);
        }


        //update record
        [HttpPut("PatientPut")]
        public IActionResult UpdatePatient([FromBody] Patient values)
        {
            if (values.Id == null)
            {
                return NotFound();
            }
            _cxt.Patients.Update(values);
            _cxt.SaveChanges();
            return CreatedAtAction(nameof(GetPatientById), new {id = values.Id}, values);
        }



        //delete individual record by id
        [HttpDelete("{id}")]
        public IActionResult DeletePatientById(int id)
        {
            var patient = _cxt.Patients.Include(p => p.Parish).FirstOrDefault(x => x.Id == id);

            if (patient == null)
            {
                return NotFound();
            }
            _cxt.Patients.Remove(patient);
            _cxt.SaveChanges();
            return Ok(patient);
        }





        //=========================================================================================================================//
        //PARISH END POINTS


        //-----------------------
        [HttpGet]
        [Route("Parish")]
        public IActionResult GetParishes()
        {
            var parItem = _cxt.Parishes.ToList();
            if (parItem == null)
            {
                return BadRequest();
            }
            return Ok(parItem);
        }



        //-----------------------
        //Finds Record where id is = to the result of the firstOrDefault query
        [HttpGet]
        [Route("Parish/{Id}")]
        public IActionResult GetParishById(int id)
        {
            var parItem = _cxt.Parishes.FirstOrDefault(x => x.Id == id); //gets individual parish by Id
            if (parItem == null)
            {
                return NotFound();
            }
            return Ok(parItem);
        }



        //-----------------------
        [HttpPost]
        [Route("ParishPost")]
        public IActionResult CreateParish([FromBody] Parish values)
        {
            _cxt.Parishes.Add(values);
            _cxt.SaveChanges();
            return CreatedAtAction(nameof(GetParishById), new { id = values.Id }, values);
        }



        //-----------------------
        [HttpPut]
        [Route("ParishPut")]
        public IActionResult UpdateParish(int id, [FromBody] Parish values)
        {
            var parItem = _cxt.Parishes.FirstOrDefault(x => x.Id == id);
            if (parItem == null)
            {
                return NotFound();
            }
            _cxt.Parishes.Update(values);
            _cxt.SaveChanges();
            return CreatedAtAction(nameof(GetParishById), new { id = values.Id }, values);
        }




    }
}
