using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.DTO;
using Ticket_booking_API.Models;

namespace Ticket_booking_API.DTOMapping
{
  public class MappingProfile: Profile
  {
    public MappingProfile()
    {
      CreateMap<UserDTO, User>().ReverseMap();
      CreateMap<TicketDTO, Ticket>().ReverseMap();
    }

  }
}
