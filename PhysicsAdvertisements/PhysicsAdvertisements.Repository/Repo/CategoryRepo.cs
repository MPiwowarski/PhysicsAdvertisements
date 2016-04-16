using PhysicsAdvertisements.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.Repository.Repo
{

    public interface ICategoryRepo : IDataRepository<Category>
    {

    }

    public class CategoryRepo : DataRepository<Category>, ICategoryRepo
    {
        public CategoryRepo(IPhysicsAdvertisementsDbContext db)
            : base(db)
        {

        }
    }
}
