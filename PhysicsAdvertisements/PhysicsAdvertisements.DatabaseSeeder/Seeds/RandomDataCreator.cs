using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsAdvertisements.DatabaseSeeder.Seeds
{
    public interface IRandomDataCreator
    {
        void Seed(int numberOfUsers, int numberOfAdvertisements);
        void CreateRandomUsers(int numberOfUsers);
        void CreateRandomAdvertisements(int numberOfAdvertisements);
    }

    public class RandomDataCreator:IRandomDataCreator
    {       
        private IPhysicsAdvertisementsDbContext _context;

        public RandomDataCreator(IPhysicsAdvertisementsDbContext context)
        {
            this._context = context;
        }

        public void Seed(int numberOfUsers, int numberOfAdvertisements)
        {
            CreateRandomUsers(numberOfUsers);
            CreateRandomAdvertisements( numberOfAdvertisements);
        }


        public void CreateRandomUsers(int numberOfUsers)
        {
            if (!_context.User.Any())
            {
                // The table is empty
                Random rnd = new Random();
               
                List<User> users = new List<User>();
                for (int i = 0; i < numberOfUsers; i++)
                {
                    User user = new User();
                    user.Login = "login" + i;
                    user.Password = (new HashingContext()).EncryptPhrase("password" + i);
                    user.Name = "userName" + i;
                    user.Surname = "userSurname" + i;
                    
                    DateTime startDate = new DateTime(1995, 1, 1);
                    int range = (DateTime.Today - startDate).Days;
                    user.Birthday = startDate.AddDays(rnd.Next(range));

                    user.Email = "login" + 1 + "@sample.com";
                    user.Gender = rnd.Next(0, 3);
                    user.PhoneNumber = rnd.Next(1, 10).ToString() + rnd.Next(12345678, 99999999);
                    user.Role = (int)User.RoleEnum.User;

                    users.Add(user);                                              
                }

                _context.User.AddRange(users);
                _context.SaveChanges();
            }
        }

        public void CreateRandomAdvertisements(int numberOfAdvertisements)
        {
            if (!_context.Advertisement.Any())
            {
                // The table is empty
                Random rnd = new Random();
               
                List<Advertisement> advertisements = new List<Advertisement>();
                for (int i = 0; i < numberOfAdvertisements; i++)
                {
                    Advertisement advertisement = new Advertisement();
                    advertisement.Title = "Title" + i;

                    int randUserId = rnd.Next(_context.User.ToList().Min(y => y.Id), _context.User.Max(y => y.Id)+1);
                    int randCategoryId = rnd.Next(_context.Category.Min(y => y.Id), _context.Category.Max(y => y.Id)+1);
                    int randPhysicsAreasId = rnd.Next(_context.PhysicsAreas.Min(y => y.Id), _context.PhysicsAreas.Max(y => y.Id)+1);

                    advertisement.User = _context.User.Where(x => x.Id == randUserId).First();
                    advertisement.Category = _context.Category.Where(x => x.Id == randCategoryId).First();
                    advertisement.PhysicsAreas = _context.PhysicsAreas.Where(x => x.Id == randPhysicsAreasId).First();

                    DateTime startDate = new DateTime(1995, 1, 1);
                    int range = (DateTime.Today - startDate).Days;
                    advertisement.AddedDate = startDate.AddDays(rnd.Next(range));

                    advertisement.Content = RandomString(rnd.Next(20,100));
                    //TODO Add random Category and Phycics areas to ad


                    advertisements.Add(advertisement);
                }

                _context.Advertisement.AddRange(advertisements);
                _context.SaveChanges();
            }
        }


        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWX      ";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
    
}
