using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicsAdvertisements.Model;

namespace PhysicsAdvertisements.Repository.Repo
{
    public interface IPhysicsAreasDictionaryRepo : IDataRepository<PhysicsAreasDictionary>
    {

    }

    public class PhysicsAreasDictionaryRepo : DataRepository<PhysicsAreasDictionary>, IPhysicsAreasDictionaryRepo
    {
        public PhysicsAreasDictionaryRepo(IPhysicsAdvertisementsDbContext db)
                : base(db)
        {

        }
    }
}
