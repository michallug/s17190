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

        [HttpPost]
        public IActionResult Create(Zamowienie newZamowienie)
        {
            _context.Zamowienie.Add(newZamowienie);
            _context.SaveChanges();

            return StatusCode(201, newZamowienie);
        }

        [HttpPut("{IdZamowienie:int}")]
        public IActionResult Update(int IdZamowienie, Zamowienie updatedZamowienie)
        {
            if (_context.Zamowienie.Count(e => e.IdZamowienie == IdZamowienie) == 0)
            {
                return NotFound();
            }

            _context.Zamowienie.Attach(updatedZamowienie);
            _context.Entry(updatedZamowienie).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(updatedZamowienie);
        }

        [HttpDelete("{IdZamowienie:int}")]
        public IActionResult Delete(int IdZamowienie)
        {
            var order = _context.Zamowienie.FirstOrDefault(e => e.IdZamowienie == IdZamowienie);
            if (order == null)
            {
                return NotFound();
            }

            _context.Zamowienie.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }
    }
}