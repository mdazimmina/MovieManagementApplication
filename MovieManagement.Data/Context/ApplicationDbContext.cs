using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Actor> Actors { get; set; }


       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "ABC", LastName = "XYZ"},
                new Actor { Id = 2, FirstName = "ABC", LastName = "XYZ"},
                new Actor { Id = 3, FirstName = "ABC", LastName = "XYZ"}
                );

            modelBuilder.Entity<Movie>().HasData(

                new Movie { Id = 1, Name = "Movie xyz", Description = "Bengali Movie",ActorId = 1  },
                new Movie { Id = 2, Name = "Movie xyz", Description = "Bengali Movie",ActorId = 2  },
                new Movie { Id = 3, Name = "Movie xyz", Description = "Bengali Movie",ActorId = 3  }
                
                );

        }
    }
}
