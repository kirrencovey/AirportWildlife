using System;
using System.Collections.Generic;
using System.Text;
using AirportWildlife.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirportWildlife.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<AnimalActivity> AnimalActivities { get; set; }
        public DbSet<ControlMethod> ControlMethods { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<Interaction> Interactoins { get; set; }
        public DbSet<Species> Species { get; set; }
    }
}
