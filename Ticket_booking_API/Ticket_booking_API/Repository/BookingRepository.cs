using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.Data;
using Ticket_booking_API.Models;
using Ticket_booking_API.Repository.IRepository;

namespace Ticket_booking_API.Repository
{
  public class BookingRepository : IBookingRepository
  {
    private readonly ApplicationDbContext _context;
    public void AddBooking(Booking booking)
    {
      _context.Add(booking);
      _context.SaveChanges();
    }
  }
}
