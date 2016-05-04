using PhysicsAdvertisements.DatabaseSeeder.Seeds;
using PhysicsAdvertisements.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.DatabaseSeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            PhysicsAdvertisementsDbContext context = new PhysicsAdvertisementsDbContext();

            Start start = new Start(context);
            start.Seed();

            Console.WriteLine("Write");
            Console.WriteLine("1 - Insert 100 random users, each user created 4 advertisements (total number of ads: 400)");

            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            
            IRandomDataCreator randomDataCreator = new RandomDataCreator(context);

            switch (caseSwitch)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    randomDataCreator.CreateRandomUsers(100);
                    randomDataCreator.CreateRandomAdvertisements(400);
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }


        
    }
}
