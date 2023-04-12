﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_booking_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ExprieDate { get; set; }
        public DateTime RegreshDates { get; set; }
        public int RoleId { get; set; }

        public Roles Roles { get; set; }

    }
}
