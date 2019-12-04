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
    public class DipsController : ControllerBase
    {
        private s17190Context _context;
        public DipsController(s17190Context context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetDips()
        {
            return Ok(_context.Sos.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDips(int id)
        {
            var dip = _context.Sos.FirstOrDefault(e => e.IdSos == id);
            if (dip == null)
            {
                return NotFound();
            }

            return Ok(dip);
        }
    }
}