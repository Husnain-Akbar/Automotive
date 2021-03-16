using System;
using System.Collections.Generic;
using System.Text;
using Automotive3S.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Automotive3S.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }

        public DbSet<AutoPart> AutoParts { get; set; }

        public DbSet<PartGallery> PartGalleries { get; set; }
    }
}
