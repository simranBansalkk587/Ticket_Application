using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.Data;
using Ticket_booking_API.Models;
using Ticket_booking_API.Repository.IRepository;

namespace Ticket_booking_API.Repository
{
  public class TicketRepository:ITicketRepository
  {
    private readonly ApplicationDbContext _context;
    public TicketRepository(ApplicationDbContext context)
    {
      _context = context;
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

    public IEnumerable<Ticket> GetAllTickets()
    {
      return _context.Tickets.Where(s => !s.IsDeleted);
    }

    public Ticket GetTicketById(int id)
    {
      return _context.Tickets.FirstOrDefault(e => e.Id == id);
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

