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
    public class PizzaController : ControllerBase
    {

        private s17190Context _context;
        public PizzaController(s17190Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetPizzas()
        {
            return Ok(_context.Pizza.ToList());
        }

        [HttpGet("(id:int)")]
        public IActionResult GetPizzas(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        // GET: api/Pizza
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pizza/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pizza
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Pizza/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}