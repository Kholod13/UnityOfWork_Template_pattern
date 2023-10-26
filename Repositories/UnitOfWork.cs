using data_access.Data;
using data_access.Entities;
using data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Repositories
{
    public class UnitOfWork : IUnitOW
    {
        private DatabaseDBContext context = new();

        private Repository<FirstEntity>? firstEntities;
        private Repository<SecondEntity>? secondEntities;
        private Repository<ThirdEntity>? thirdEntities;
        //...other entities
        private bool disposed = false;

        public IRepository<FirstEntity> FirstEntities => firstEntities ??= new Repository<FirstEntity>(context);
        public IRepository<SecondEntity> SecondEntities => secondEntities ??= new Repository<SecondEntity>(context);
        public IRepository<ThirdEntity> ThirdEntities => thirdEntities ??= new Repository<ThirdEntity>(context);
        //... other entities

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}