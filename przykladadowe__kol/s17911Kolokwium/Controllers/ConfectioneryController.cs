using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s17911Kolokwium.DTOs;
using s17911Kolokwium.Services;


namespace s17911Kolokwium.Controllers
{
    [Route("api")]
    [ApiController]
    public class ConfectioneryController : ControllerBase
    {
        private readonly ICukierniaDbServices _dbService;

        public ConfectioneryController(ICukierniaDbServices dbService)
        {
            _dbService = dbService;
        }

        // GET: api/orders
        [HttpGet("orders/")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_dbService.GetZamowienia());
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }

        // GET: api/orders/surname
        [HttpGet("orders/{surname}")]
        public IActionResult Get(String surname)
        {
            try
            {
                return Ok(_dbService.GetZamowienie(surname));
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }

        // POST: api/orders
        [HttpPost("clients/{idClient}/orders")]
        public IActionResult Post([FromBody] NoweZamowienieDto newOrderDto, int idClient)
        {
            try
            {
                return Ok(_dbService.DodajZamowienie(newOrderDto, idClient));
            }
            catch (Exception e)
            {
                return BadRequest("Exception: " + e.Message + "\n" + e.StackTrace);
            }
        }
    }
}