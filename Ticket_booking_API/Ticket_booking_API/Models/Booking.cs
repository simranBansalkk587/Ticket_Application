﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_booking_API.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int Count { get; set; }


    }
}
