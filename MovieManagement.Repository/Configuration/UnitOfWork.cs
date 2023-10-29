using Microsoft.EntityFrameworkCore;
using MovieManagement.Data.Context;
using MovieManagement.Repository.Interface;
using MovieManagement.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Repository.Configuration
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Movie = new MovieRepository(_context);
            Actor = new ActorRepository(_context);
        }
        public IMovieRepositoy Movie { get; private set; }

        public IActorRepository Actor { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
           return _context.SaveChanges();
        }
    }
}
