﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using _2_Persistency.Contracts;

namespace _3_Persistency.Implementations
{
    public class MTEContext : DbContext
    {
        private readonly IEnumerable<IEntityMapping> _entityMappingCollection;

        public MTEContext(IEnumerable<IEntityMapping> entityMappingCollection, DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            _entityMappingCollection = entityMappingCollection;
            Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}