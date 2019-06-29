﻿using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirportWildlife.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            public DbSet<ApplicationUser> Users { get; set; }

    }
}
}
