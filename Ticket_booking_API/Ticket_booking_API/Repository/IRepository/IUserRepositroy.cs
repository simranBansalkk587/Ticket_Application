using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.DTO;
using Ticket_booking_API.Models;

namespace Ticket_booking_API.Repository.IRepository
{
  public interface IUserRepositroy
  {

    bool IsUniqueUser(string UserName);
    User Authenticate(string UserName, string password);
    User Register(UserDTO userDTO);

  }
}
