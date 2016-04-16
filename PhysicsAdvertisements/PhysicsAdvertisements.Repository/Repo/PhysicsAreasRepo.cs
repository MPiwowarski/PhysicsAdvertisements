using PhysicsAdvertisements.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.Repository.Repo
{

    public interface IPhysicsAreasRepo : IDataRepository<PhysicsAreas>
    {

    }

    public class PhysicsAreasRepo : DataRepository<PhysicsAreas>, IPhysicsAreasRepo
    {
        public PhysicsAreasRepo(IPhysicsAdvertisementsDbContext db)
            : base(db)
        {

        }
    }
}
