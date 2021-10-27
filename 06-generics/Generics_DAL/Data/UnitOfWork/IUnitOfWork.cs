using Generics_DAL.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL.Data.UnitOfWork
{

    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductRepo { get; }
        IRepository<Klant> KlantRepo { get; }
        IRepository<Order> OrderRepo { get; }
        IRepository<Orderlijn> OrderlijnRepo { get; }
        IRepository<Werknemer> WerknemerRepo { get; }
        int Save();
    }
}
