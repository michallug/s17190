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
    public class PizzasController : ControllerBase
    {
        private s17190Context _context;
        public PizzasController(s17190Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("{IdPizza:int}")]
        public IActionResult GetPizzas(int IdPizza)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == IdPizza);
            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }
    }
}