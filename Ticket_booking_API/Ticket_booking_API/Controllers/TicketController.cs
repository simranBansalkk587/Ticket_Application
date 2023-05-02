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
    ////[AllowAnonymous]
    ////[Route("get")]
    //public IEnumerable<Ticket> GetTickets()
    //{
    // return _ticketRepository.GetAllTickets();
    //  //return _context.Tickets.AsEnumerable();
    //public IActionResult GetAllTickets()
    //{
    //  var tickets = _ticketRepository.GetAllTickets();

    //  var ticketDTOs = _mapper.Map<IEnumerable<Ticket>, IEnumerable<TicketDTO>>(tickets);

    //  return Ok(ticketDTOs);
    ////}
    public IEnumerable<Ticket> GetTickets()
    {
      return _ticketRepository.GetAllTickets();
      //return _context.Tickets.AsEnumerable();
    }
    [HttpPost]
    //public IActionResult SaveTicket([FromBody] TicketDTO ticketDTO)
    //{
    //  if (ticketDTO == null)
    //    return BadRequest(ModelState);

    //  // map TicketDTO to Ticket entity
    //  var Ticket = _mapper.Map<TicketDTO, Ticket>(ticketDTO);

    //  // check if ticket count is already at maximum
    //  if (_ticketRepository.GetTicketCount() >= MaxTickets)
    //  {
    //    return BadRequest("Maximum ticket count reached.");
    //  }

    //  // add the new ticket to the repository
    //  _ticketRepository.AddTicket(Ticket);

    //  // increment the ticket count
    //  int ticketCount = _ticketRepository.GetTicketCount() + 1;

    //  return Ok($"Ticket saved. Total tickets: {ticketCount}");
    //}
    
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
