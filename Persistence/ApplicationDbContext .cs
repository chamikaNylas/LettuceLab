using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence.Configaration;
using Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GreenHouse> GreenHouses { get; set;}
        public DbSet<Outbox> Outboxs { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.ApplyConfiguration(new GreenHouseConfiguration());
          //  modelBuilder.ApplyConfiguration(new GrowBedConfig());

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configure the database schema and relationships here
        //    base.OnModelCreating(modelBuilder);

        //    // Add shadow properties for created at and updated at
        //    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //    {
        //        modelBuilder.Entity(entityType.ClrType)
        //            .Property<DateTime>("CreatedAt")
        //            .HasDefaultValueSql("GETDATE()")
        //            .ValueGeneratedOnAdd();

        //        modelBuilder.Entity(entityType.ClrType)
        //            .Property<DateTime>("UpdatedAt")
        //            .HasDefaultValueSql("GETDATE()")
        //            .ValueGeneratedOnAddOrUpdate();
        //    }
        //}
        //https://medium.com/@shahabganji/explore-shadow-properties-in-ef-core-aaac8af42f5d
    }
}
