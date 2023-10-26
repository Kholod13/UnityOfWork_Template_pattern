using data_access.Entities;
using data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Repositories
{
    public interface IUnitOW : IDisposable
    {
        IRepository<FirstEntity> FirstEntities{ get; }
        IRepository<SecondEntity> SecondEntities { get; }
        IRepository<ThirdEntity> ThirdEntities { get; }
        ///..other entities
        void Save();
    }
}