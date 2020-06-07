using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw6.DTOs;
using cw6.Model;
using cw6.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw6.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsDbService _dbService;

        public DoctorsController(IDoctorsDbService dbService)
        {
            _dbService = dbService;
        }

       
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_dbService.GetDoctors());
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }

       
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_dbService.GetDoctor(id));
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }

       
        [HttpPost]
        public IActionResult Post([FromBody] NewDoctorDto doctor)
        {
            try
            {
                return Ok(_dbService.AddDoctor(doctor));
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }

       
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NewDoctorDto doctor)
        {
            try
            {
                if (_dbService.GetDoctor(id) == null)
                {
                    return NotFound("Selected doctor doesn't exist");
                }
                return Ok(_dbService.UpdateDoctor(id, doctor));
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_dbService.GetDoctor(id) == null)
                {
                    return NotFound("Selected doctor doesn't exist");
                }
                return Ok(_dbService.DeleteDoctors(id));
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
