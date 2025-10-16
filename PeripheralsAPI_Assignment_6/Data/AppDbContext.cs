using Microsoft.EntityFrameworkCore;
using PeripheralsAPI_Assignment_6.Models;
using System.Collections.Generic;

namespace PeripheralsAPI_Assignment_6.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Peripheral> Peripherals { get; set; }
    }
}