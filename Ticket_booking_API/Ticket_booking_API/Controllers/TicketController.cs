using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.Data;
using Ticket_booking_API.Models;

namespace Ticket_booking_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetTicket()
        {
            var ticketIndb = _context.Tickets.Where(n => !n.IsDeleted);
            return Ok(ticketIndb);
        }
        [HttpGet("{id}")]
        public IActionResult GetTicket(int id)
        {
            var ticketIndb = _context.Tickets.Find(id);
            if (ticketIndb == null) return NotFound();
            return Ok(ticketIndb);
        }
        [HttpPost]
        public IActionResult SaveTicket([FromBody] Ticket ticket)
        {
            if (ticket != null && ModelState.IsValid)
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateTicket([FromBody] Ticket ticket)
        {
            if (ticket != null && ModelState.IsValid)
            {
                _context.Tickets.Update(ticket);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public void Delete(int id)
        {
            var ticketInDb = _context.Tickets.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
            if (ticketInDb != null)
                _context.Remove(ticketInDb);
            _context.SaveChanges();

        }

    } 
}
