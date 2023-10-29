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
    public class ActorRepository : CommonGenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
