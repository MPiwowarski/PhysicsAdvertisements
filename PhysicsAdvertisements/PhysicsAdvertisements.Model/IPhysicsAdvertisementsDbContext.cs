using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.Model
{
    public interface IPhysicsAdvertisementsDbContext
    {
        System.Data.Entity.DbSet<User> User { get; set; }
        System.Data.Entity.DbSet<Advertisement> Advertisement { get; set; }
        System.Data.Entity.DbSet<Category> Category { get; set; }
        System.Data.Entity.DbSet<PhysicsAreas> PhysicsAreas { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();
        int SaveChanges();
    }
}
