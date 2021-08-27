using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HomeOfficeManagement.Entity;
using HomeOfficeManagement.Models;

namespace HomeOfficeManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Attendees> Attendees { get; set; }
        public DbSet<WorkList> WorkList { get; set; }
    }
}
