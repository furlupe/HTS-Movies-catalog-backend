﻿using Microsoft.EntityFrameworkCore;

namespace MoviesCatalog.Models
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
