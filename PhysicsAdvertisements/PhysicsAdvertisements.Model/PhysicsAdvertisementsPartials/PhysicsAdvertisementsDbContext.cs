﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.Model
{
    public partial class PhysicsAdvertisementsDbContext : IPhysicsAdvertisementsDbContext
    {
        public static PhysicsAdvertisementsDbContext Create()
        {
            return new PhysicsAdvertisementsDbContext();
        }
    }
}
