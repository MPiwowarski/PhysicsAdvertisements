﻿using PhysicsAdvertisements.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhysicsAdvertisements.Repository
{
    public class DataRepository<EntityClass> : PhysicsAdvertisements.Repository.IDataRepository<EntityClass>
        where EntityClass : class, IEntity
    {
        protected IPhysicsAdvertisementsDbContext _db;


        public IPhysicsAdvertisementsDbContext Context
        {
            get
            {
                return _db;
            }
        }

        public DataRepository(IPhysicsAdvertisementsDbContext db)
        {
            _db = db;
        }

        public void Delete(EntityClass entity)
        {
            _db.Set<EntityClass>().Remove(entity);
        }

        public EntityClass GetById(int key)
        {
            return _db.Set<EntityClass>().FirstOrDefault(x => x.Id == key);
        }

        public void Insert(EntityClass entity)
        {
            _db.Set<EntityClass>().Add(entity);
        }

        public void Save()
        {         
            _db.SaveChanges();                      
        }

        public void Update(EntityClass entity)
        {
            var original = _db.Set<EntityClass>().Find(entity.Id);
            _db.Entry(original).CurrentValues.SetValues(entity);
        }
    }
}
