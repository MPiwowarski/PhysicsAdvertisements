using PhysicsAdvertisements.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.Repository
{
    public interface IDataRepository<T>
       where T : class, IEntity
    {
        void Delete(T entity);
        T GetById(int id);
        void Insert(T entity);
        void Save();
        void Update(T entity);

        IPhysicsAdvertisementsDbContext Context { get; }
        DbSet<T> Table { get; }
    }
}
