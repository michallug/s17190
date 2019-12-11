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
    public class OrderDetailsController : ControllerBase
    {
        private s17190Context _context;
        public OrderDetailsController(s17190Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetOrderDetails()
        {
            return Ok(_context.Zamowienie.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrderDetails(int id)
        {
            var order = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}