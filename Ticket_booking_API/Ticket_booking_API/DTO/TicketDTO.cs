using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_booking_API.DTO
{
  public class TicketDTO

  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Count { get; set; }
    public string Image { get; set; }
    public bool IsDeleted { get; set; }
  }
}
