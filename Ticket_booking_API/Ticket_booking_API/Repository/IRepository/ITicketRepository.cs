using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.Models;

namespace Ticket_booking_API.Repository.IRepository
{
 public interface ITicketRepository
  {
    ICollection<Ticket> GetTicket();
    Ticket GetTicket(int ticket);
    bool TicketExists(int ticketId);
    bool TicketExists(string ticketName);
    bool CreateTicket(Ticket ticket);
    bool UpdateTicket(Ticket ticket);
    bool DeleteTicket(Ticket ticket);
    bool save();
  }
}
