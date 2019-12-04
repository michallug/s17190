using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Models;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private s17190Context _context;
        public PaymentsController(s17190Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetPayments()
        {
            return Ok(_context.SposobPlatnosci.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetPayments(int id)
        {
            var payment = _context.SposobPlatnosci.FirstOrDefault(e => e.IdPlatnoscTyp == id);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }
    }
}