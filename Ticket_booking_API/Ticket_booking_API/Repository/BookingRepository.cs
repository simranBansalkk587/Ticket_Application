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
  public class BookingRepository : IBookingRepository

  {
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public BookingRepository(ApplicationDbContext context,IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }


    public BookingDTO BookTicket(BookingDTO bookingDTO)
    {
     
      var existingBooking = _context.Bookings
                      .FirstOrDefault(b => b.UserId == bookingDTO.UserId && b.TicketId == bookingDTO.TicketId);
      if (existingBooking != null)
      {
        existingBooking.Count += bookingDTO.Count;

        _context.SaveChanges();
        var updatedBookingDTO = _mapper.Map<BookingDTO>(existingBooking);
        return updatedBookingDTO;
      }
      else
      {
        var booking = _mapper.Map<BookingDTO, Booking>(bookingDTO);
        _context.Bookings.Add(booking);
        _context.SaveChanges();
        var newBookingDTO = _mapper.Map<BookingDTO>(booking);
        return newBookingDTO;
      }
    }
  }
}
