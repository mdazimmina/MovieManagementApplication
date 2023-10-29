using MovieManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Repository.Configuration
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepositoy Movie { get; }
        IActorRepository Actor{ get; }

        int Save();
    }
}
