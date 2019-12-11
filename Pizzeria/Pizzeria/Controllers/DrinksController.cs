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
    public class DrinksController : ControllerBase
    {
        private s17190Context _context;
        public DrinksController(s17190Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetDrinks()
        {
            return Ok(_context.Napoj.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDrinks(int id)
        {
            var drink = _context.Napoj.FirstOrDefault(e => e.IdNapoj == id);
            if (drink == null)
            {
                return NotFound();
            }

            return Ok(drink);
        }
    }
}