﻿using Microsoft.EntityFrameworkCore;
using MovieDB.Domain.Entities;
using MovieDB.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieDB.Infra.Context
{
    public class MyContextDatabase: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }


        public MyContextDatabase()
        {

        }
        public MyContextDatabase(DbContextOptions<MyContextDatabase> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "server=localhost;port=3306;database=moviedb;user=root;password=1234";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).HasMaxLength(100).IsRequired();
                entity.Property(e => e.ReleaseYear).IsRequired();
                entity.HasOne(e => e.Director).WithMany(d => d.Movies).HasForeignKey(e => e.Id);
                entity.HasMany(e => e.Actors).WithMany(a => a.Movies);

                entity.Property(m => m.Genres)
                  .HasConversion(
                       v => string.Join(',', v),
                       v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(g => (GenreEnum)Enum.Parse(typeof(GenreEnum), g)).ToList()
                   );

            });

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.HasMany(e => e.Movies).WithMany(m => m.Actors);
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.HasMany(e => e.Movies).WithOne(m => m.Director);
            });

           
        }

    }
}
