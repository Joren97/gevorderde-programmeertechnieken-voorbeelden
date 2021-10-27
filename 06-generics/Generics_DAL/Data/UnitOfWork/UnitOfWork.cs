using Generics_DAL;
using Generics_DAL.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region attributen
        private IRepository<Product> _productRepo;
        private IRepository<Klant> _klantRepo;
        private IRepository<Order> _orderRepo;
        private IRepository<Orderlijn> _orderlijnRepo;
        private IRepository<Werknemer> _werknemerRepo;
        #endregion

        public UnitOfWork(VerkoopBeheerEntities verkoopBeheerEntities)
        {
            this.VerkoopBeheerEntities = verkoopBeheerEntities;

        }
        private VerkoopBeheerEntities VerkoopBeheerEntities { get; }

        #region repositories
        public IRepository<Product> ProductRepo
        {
            get
            {
                if (_productRepo == null)
                {
                    _productRepo = new Repository<Product>(this.VerkoopBeheerEntities);
                }
                return _productRepo;
            }
        }
        public IRepository<Klant> KlantRepo
        {
            get
            {
                if (_klantRepo == null)
                {
                    _klantRepo = new Repository<Klant>(this.VerkoopBeheerEntities);
                }
                return _klantRepo;
            }
        }
        public IRepository<Order> OrderRepo
        {
            get
            {
                if (_orderRepo == null)
                {
                    _orderRepo = new Repository<Order>(this.VerkoopBeheerEntities);
                }
                return _orderRepo;
            }
        }
        public IRepository<Orderlijn> OrderlijnRepo
        {
            get
            {
                if (_orderlijnRepo == null)
                {
                    _orderlijnRepo = new Repository<Orderlijn>(this.VerkoopBeheerEntities);
                }
                return _orderlijnRepo;
            }
        }
        public IRepository<Werknemer> WerknemerRepo
        {
            get
            {
                if (_werknemerRepo == null)
                {
                    _werknemerRepo = new Repository<Werknemer>(this.VerkoopBeheerEntities);
                }
                return _werknemerRepo;
            }
        }

        #endregion

        public void Dispose()
        {
            VerkoopBeheerEntities.Dispose();
        }

        public int Save()
        {
            return VerkoopBeheerEntities.SaveChanges();
        }
    }
}
