using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.Data;
using Ticket_booking_API.Models;
using Ticket_booking_API.Repository.IRepository;

namespace Ticket_booking_API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class BookingController : ControllerBase
  {
    private readonly IBookingRepository _bookingRepositroy;
    private readonly ITicketRepository _ticketRepository;
    private readonly ApplicationDbContext _context;
    public BookingController(IBookingRepository bookingRepository,ITicketRepository ticketRepository,ApplicationDbContext context)
    {
      _bookingRepositroy = bookingRepository;
      _ticketRepository = ticketRepository;
      _context = context;
    }
    ////[HttpPost]
    ////public async Task<IActionResult> BookTicket([FromBody]Booking booking)
    ////{
    ////  // Get the currently authenticated user's ID
    ////   booking.UserId = booking.UserId; 

    ////  // Retrieve the ticket from the database
    ////  Ticket ticket =  _ticketRepository.GetTicketById(ticket.);

    ////  // If the ticket doesn't exist, return a 404 error
    ////  if (ticket == null)
    ////  {
    ////    return NotFound();
    ////  }

    ////  // If the ticket is sold out, return a 400 error
    ////  if (ticket.Count < count)
    ////  {
    ////    return BadRequest("Not enough tickets available.");
    ////  }

    ////  // Create a new booking entity and save it to the database
    ////  Booking booking1 = new Booking
    ////  {
    ////    UserId = userId,
    ////    TicketId = ticket.Id,
    ////    Count = count,
    ////  };
    ////   _bookingRepositroy.AddBooking(booking);

    ////  // Update the ticket's available count
    ////  ticket.Count -= count;
    ////  _ticketRepository.UpdateTicket(ticket);


    ////  return Ok();
    ////}

    ////// POST api/bookings
    //[HttpPost]
    //public IActionResult BookTicket([FromBody] Booking booking)
    //{

    //  try
    //  {
    //    var ticket = _context.Tickets.FirstOrDefault(s => s.Id == booking.TicketId);
    //    if (ticket == null)
    //    {
    //      return BadRequest("Invalid ticket id");
    //    }

    //    if (ticket.Count < booking.Count)
    //    {
    //      return BadRequest("Not enough tickets available");
    //    }

    //    var existingBooking = _context.Bookings.FirstOrDefault(s => s.UserId == booking.UserId && s.TicketId == booking.TicketId);
    //    if (existingBooking != null)
    //    {
    //      // Update existing booking
    //      existingBooking.Count += booking.Count;
    //    }
    //    else
    //    {
    //      // Create new booking
    //      _context.Bookings.Add(booking);
    //    }

    //    // Update the ticket count
    //    ticket.Count -= booking.Count;

    //    // Save the changes to the database
    //    _context.SaveChanges();


    //    return Ok();
    //  }
    //  catch (Exception ex)
    //  {

    //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
    //  }
    //}

    //{
    //  try
    //  {
    //    var bookinticket = _context.Tickets.FirstOrDefault(s => s.Id == booking.TicketId);
    //    if (bookinticket.Count < booking.Count)
    //    {
    //      return BadRequest("Not enough tickets available");
    //    }
    //    var existingBooking = _context.Bookings.FirstOrDefault(s => s.UserId == booking.UserId && s.TicketId == booking.TicketId);
    //    if (existingBooking != null)
    //    {
    //      // Update existing booking
    //      existingBooking.Count += booking.Count;
    //    }
    //    else
    //    {
    //      // Create new booking
    //      _context.Bookings.Add(booking);
    //    }
    //    bookinticket.Count -= booking.Count;
    //    _context.SaveChanges();
    //    return Ok();
    //  }
    //  catch (Exception ex)
    //  {
    //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
    //  }
    //}
    [HttpPost]
    public IActionResult BookTicket([FromBody] Booking booking)
    {
      //var bookticketDb = _context.Bookings.Include(u => u.User).Include(u => u.Ticket).FirstOrDefault();
      //if (bookticketDb != null && ModelState.IsValid)
      //{
      //  _context.Bookings.Add(booking);
      //  _context.SaveChanges();
      //  return Ok();
      //}
      //return BadRequest();
      try
      {
        var bookinticket = _context.Tickets.FirstOrDefault(s => s.Id == booking.TicketId);
        if (bookinticket.Count <= booking.Count)
        {
          return BadRequest("Not Enough tickets available");
        }
        var ticket = _context.Bookings.FirstOrDefault(s => s.UserId == booking.UserId && s.TicketId == booking.TicketId);
        if (ticket != null)
        {
          var booktic = ticket.Count += booking.Count;
          booking.Count = booktic;
        }
        bookinticket.Count -= booking.Count;
        _context.Entry(ticket).State = EntityState.Modified;
        _context.Bookings.Add(booking);
        _context.SaveChanges();
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

      }
    }
    [HttpGet]
    public IActionResult GetBooking()
    {
      return Ok(_context.Bookings.Include(u => u.Ticket).Include(u => u.User).ToList());
      //return Ok(_context.Employees.ToList());
      //var empInDb = _context.Tickets.Where(n => !n.IsDeleted);
      //return Ok(empInDb);
    }
    [HttpPut]
    public IActionResult BookingUpdate([FromBody] Booking booking)
    {
      
      var bookticketDb = _context.Bookings.Include(u => u.User).Include(u => u.Ticket).FirstOrDefault();
      if (bookticketDb != null && ModelState.IsValid)
      {
        _context.Bookings.Update(booking);
        _context.SaveChanges();
        return Ok();
      }
      return BadRequest();
    }
    //[HttpDelete]
    //public void Delete(int id)
    //{
    //  var bookInDb = _context.Bookings.FirstOrDefault(s => s.Id == id && !s.IsDeleted);
    //  if (bookInDb != null)
    //    _context.Remove(bookInDb);
    //  _context.SaveChanges();

    //}
    // Create a new booking objects
    //  var booki = new Booking
    //  {
    //    TicketId = booking.TicketId,
    //    UserId = booking.UserId,
    //    Count = booking.Count
    //  };
    //  _context.Bookings.Add(booking1);
    //  _context.SaveChanges();

    //  // Save the booking to your database
    //  //_context.Bookings.Add(booking);
    //  //_context.SaveChanges();
    // // _context.SaveChanges(booking);

    //  // Return a success response
    //  return Ok(booking);
  }

  }


