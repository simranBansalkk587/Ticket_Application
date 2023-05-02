using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_booking_API.Models
{
  public class UserVM
  {
    //public string Name { get; set; }
    public string Email { get; set; }
    public string PassWord { get; set; }
    //public int UserId { get; set; }
    //public int TicketId { get; set; }
    //public int Count { get; set; }

    public string Token { get; set; }
  }
}
