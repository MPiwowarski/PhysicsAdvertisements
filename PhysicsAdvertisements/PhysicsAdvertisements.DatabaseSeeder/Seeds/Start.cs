using PhysicsAdvertisements.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.DatabaseSeeder.Seeds
{
    public interface IStart
    {
        void Seed();
        void SeedCategory();
        void SeedPhysicsAreas();
    }

    class Start : IStart
    {
        private IPhysicsAdvertisementsDbContext _context;

        public Start(IPhysicsAdvertisementsDbContext context)
        {
            this._context = context;
        }

        public void Seed()
        {
            SeedCategory();
            SeedPhysicsAreas();
        }

        public void SeedCategory()
        {
            if (!_context.Category.Any())
            {
                // The table is empty
                List<Category> categories = new List<Category>()
                {
                    new Category()
                    {
                        Name="Category 1"
                    },
                    new Category()
                    {
                        Name="Category 2"
                    },
                };
                _context.Category.AddRange(categories);
                _context.SaveChanges();

            }
        }

        public void SeedPhysicsAreas()
        {
            if (!_context.PhysicsAreas.Any())
            {
                // The table is empty
                List<PhysicsAreas> physicsAreas = new List<PhysicsAreas>()
                {
                    new PhysicsAreas()
                    {
                        Name="Physics Area 1"
                    },
                    new PhysicsAreas()
                    {
                        Name="Physics Area 2"
                    },
                };
                _context.PhysicsAreas.AddRange(physicsAreas);
                _context.SaveChanges();

            }
        }

    }
}
