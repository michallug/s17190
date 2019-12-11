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

        [HttpPost]
        public IActionResult Create(Napoj newNapoj)
        {
            _context.Napoj.Add(newNapoj);
            _context.SaveChanges();

            return StatusCode(201, newNapoj);
        }

        [HttpPut("{IdNapoj:int}")]
        public IActionResult Update(int IdNapoj, Napoj updatedNapoj)
        {
            if (_context.Napoj.Count(e => e.IdNapoj == IdNapoj) == 0)
            {
                return NotFound();
            }

            _context.Napoj.Attach(updatedNapoj);
            _context.Entry(updatedNapoj).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedNapoj);
        }

        [HttpDelete("{idNapoj:int}")]
        public IActionResult Delete(int IdNapoj)
        {
            var drink = _context.Napoj.FirstOrDefault(e => e.IdNapoj == IdNapoj);
            if (drink == null)
            {
                return NotFound();
            }

            _context.Napoj.Remove(drink);
            _context.SaveChanges();

            return Ok(drink);
        }
    }
}