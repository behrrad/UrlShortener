using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using urlShortener.Models;
namespace urlShortener
{
    public class AppDbContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Url>().ToTable("url");
            builder.Entity<Url>().HasKey(p => p.shortUrl);
            builder.Entity<Url>().Property(p => p.longUrl).IsRequired();
            builder.Entity<Url>().Property(p => p.shortUrl).IsRequired();
        }
    }
}