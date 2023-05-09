using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.Data;
using Ticket_booking_API.DTO;
using Ticket_booking_API.Models;
using Ticket_booking_API.Repository.IRepository;

namespace Ticket_booking_API.Repository
{
  public class TicketRepository:ITicketRepository
  {
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TicketRepository(ApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;

    }
    public void AddTicket(Ticket ticket)
    {
      _context.Add(ticket);
      _context.SaveChanges();
    }

    public void DeleteTicket(int id)
    {
      var Ticketindb = _context.Tickets.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
      if (Ticketindb != null)
        _context.Remove(Ticketindb);
      _context.SaveChanges();
    }

    public IEnumerable<TicketDTO> GetAllTickets()
    {
      var tickets = _context.Tickets.Where(n => !n.IsDeleted);
      var ticketDTOs = _mapper.Map<IEnumerable<TicketDTO>>(tickets);
      foreach (var ticketDTO in ticketDTOs)
      {
        var bookingTicket = _context.Bookings.Where(h => h.TicketId == ticketDTO.Id).Sum(h => h.Count);
        ticketDTO.Count = ticketDTO.Count - bookingTicket;

      }
      return ticketDTOs;
      // return _context.Tickets.Where(s => !s.IsDeleted);
    }

    public Ticket GetTicketById(int id)
    {
      return _context.Tickets.FirstOrDefault(e => e.Id == id);
    }

    public int GetTicketCount()
    {
      return _context.Tickets.Count();
    }

    public void UpdateTicket(Ticket ticket)
    {
      var updateticket = _context.Tickets.FirstOrDefault(e => e.Id == ticket.Id);
      if (updateticket != null)
      {
        updateticket.Name = ticket.Name;
        updateticket.Count = ticket.Count;
        updateticket.Image = ticket.Image;
      }
      _context.SaveChanges();
    }
  }
}

