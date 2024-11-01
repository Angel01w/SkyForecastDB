﻿using Microsoft.EntityFrameworkCore;
using System;

namespace SkyForecastAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Clima> Clima { get; set; }
    }
}
