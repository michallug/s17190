using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Metoda zwraca dane 
        /// </summary>
        /// <returns>
        ///     Lista obiektów...
        /// </returns>
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

        [HttpPost]
        public IActionResult Create(Pizza newPizza)
        {
            _context.Pizza.Add(newPizza);
            _context.SaveChanges();

            return StatusCode(201, newPizza);
        }

        [HttpPut("{idPizza:int}")]
        public IActionResult Update(int idPizza, Pizza updatedPizza)
        {
            if (_context.Pizza.Count(e => e.IdPizza == idPizza) == 0)
            {
                return NotFound();
            }

            _context.Pizza.Attach(updatedPizza);
            _context.Entry(updatedPizza).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedPizza);
        }

        [HttpDelete("{idPizza:int}")]
        public IActionResult Delete(int idPizza)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.IdPizza == idPizza);
            if(pizza == null)
            {
                return NotFound();
            }

            _context.Pizza.Remove(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }
    }
}