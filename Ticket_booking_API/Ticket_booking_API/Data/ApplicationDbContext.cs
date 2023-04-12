
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticket_booking_API.Models;

namespace Ticket_booking_API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet <User>Users { get; set; }
        public DbSet <Ticket>Tickets { get; set; }
        public DbSet <Roles>Roles { get; set; }
        public DbSet <Booking>Bookings { get; set; }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted))
            {

                entry.State = EntityState.Modified;
                entry.CurrentValues.SetValues(new { IsDeleted = true });
            }

            return base.SaveChanges();
        }

    }
}
