using PhysicsAdvertisements.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.Repository.Repo
{
    
    public interface IAdvertisementRepo : IDataRepository<Advertisement>
    {

    }

    public class AdvertisementRepo : DataRepository<Advertisement>, IAdvertisementRepo
    {
        public AdvertisementRepo(IPhysicsAdvertisementsDbContext db)
            : base(db)
        {

        }
    }
}
