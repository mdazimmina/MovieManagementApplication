using Microsoft.EntityFrameworkCore;
using MovieManagement.Domain.Entities;
using MovieManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Repository.Repository
{
    public class MovieRepository : CommonGenericRepository<Movie>, IMovieRepositoy
    {
        public MovieRepository(DbContext dbContext) : base(dbContext)
        {
        }

    }
}
