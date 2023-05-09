using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.DTO;
using Ticket_booking_API.Models;

namespace Ticket_booking_API.Repository.IRepository
{
 public interface ITicketRepository
  {
    IEnumerable<TicketDTO> GetAllTickets();
    Ticket GetTicketById(int id);
    void AddTicket(Ticket ticket);
    void UpdateTicket(Ticket ticket);
    void DeleteTicket(int id);
    // Task<Ticket> GetTicketById(int id);
  }
}
