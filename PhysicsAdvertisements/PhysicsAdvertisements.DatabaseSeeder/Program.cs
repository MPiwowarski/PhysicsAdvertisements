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
            Console.WriteLine("2 - Insert 1 random users, each user created 4 advertisements (total number of ads: 1)");
            Console.WriteLine("---------------------------------  Performance Tests   ----------------------------------");
            Console.WriteLine("3 - Insert 1 random user, create 10000 advertisements");
            Console.WriteLine("4 - Insert 1 random user, create 5000 advertisements");
            Console.WriteLine("5 - Insert 1 random user, create 2500 advertisements");
            Console.WriteLine("6 - Insert 1 random user, create 1000 advertisements");
            Console.WriteLine("7 - Insert 1 random user, create 500 advertisements");
            Console.WriteLine("8 - Insert 1 random user, create 250 advertisements");
            Console.WriteLine("9 - Insert 1 random user, create 100 advertisements");
            Console.WriteLine("10 - Insert 1 random user, create 50 advertisements");
            Console.WriteLine("11 - Insert 1 random user, create 25 advertisements");
            Console.WriteLine("12 - Insert 1 random user, create 10 advertisements");
            Console.WriteLine("13 - Insert 1 random user, create 5 advertisements");
            Console.WriteLine("14 - Insert 1 random user, create 1 advertisements");


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
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(1);
                    break;
                //---------------------------   Performance Tests   ---------------------------
                case 3:
                    Console.WriteLine("Case 3");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(10000);
                    break;
                case 4:
                    Console.WriteLine("Case 4");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(5000);
                    break;
                case 5:
                    Console.WriteLine("Case 5");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(2500);
                    break;
                case 6:
                    Console.WriteLine("Case 6");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(1000);
                    break;
                case 7:
                    Console.WriteLine("Case 7");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(500);
                    break;
                case 8:
                    Console.WriteLine("Case 8");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(250);
                    break;
                case 9:
                    Console.WriteLine("Case 9");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(100);
                    break;
                case 10:
                    Console.WriteLine("Case 10");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(50);
                    break;
                case 11:
                    Console.WriteLine("Case 11");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(25);
                    break;
                case 12:
                    Console.WriteLine("Case 12");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(10);
                    break;
                case 13:
                    Console.WriteLine("Case 13");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(5);
                    break;
                case 14:
                    Console.WriteLine("Case 14");
                    randomDataCreator.CreateRandomUsers(1);
                    randomDataCreator.CreateRandomAdvertisements(1);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }


        
    }
}
