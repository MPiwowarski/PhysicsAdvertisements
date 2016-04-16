using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysicsAdvertisements.Model;

namespace PhysicsAdvertisements.Repository.Repo
{
    public interface IUserRepo : IDataRepository<User>
    {

    }

    public class UserRepo : DataRepository<User>, IUserRepo
    {
        public UserRepo(IPhysicsAdvertisementsDbContext db)
            : base(db)
        {

        }
    }
}
