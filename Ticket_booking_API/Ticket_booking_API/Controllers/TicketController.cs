using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.Data;
using Ticket_booking_API.DTO;
using Ticket_booking_API.Models;
using Ticket_booking_API.Repository.IRepository;

namespace Ticket_booking_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private ITicketRepository _ticketRepository;
    public TicketController(ApplicationDbContext context, IMapper mapper, ITicketRepository ticketRepository)
        {
            _context = context;
            _mapper = mapper;
            _ticketRepository = ticketRepository;

    }
    [HttpGet]
    
    public IEnumerable<TicketDTO> GetTickets()
    {
      return _ticketRepository.GetAllTickets();
    }
    [HttpPost]
    
      public IActionResult SaveTicket([FromBody] TicketDTO ticketDTO)
      {
        if (ticketDTO == null)
          return BadRequest(ModelState);

        var Ticket = _mapper.Map<TicketDTO, Ticket>(ticketDTO);

        _ticketRepository.AddTicket(Ticket);

        return Ok(Ticket);
      }

    

    [HttpPut]
    public IActionResult UpdateTicket([FromBody] TicketDTO ticketDTO)
    {
      if (ticketDTO == null) return BadRequest(ModelState);
      var Ticket = _mapper.Map<TicketDTO, Ticket>(ticketDTO);

      _ticketRepository.UpdateTicket(Ticket);

      return Ok(Ticket);
    }
    [HttpDelete]
    public void DeleteTicket(int id)
    {
      _ticketRepository.DeleteTicket(id);
    }
    

 } 
}
