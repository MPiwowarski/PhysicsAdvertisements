using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PhysicsAdvertisements.WebForms.Web.Data.Advertisement
{
    public class MyAdvertisementsData
    {
        public DateTime AddedDate { get; set; }
        public string UserImageUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //For BulletList item FullNameAndAge in GridView
        public List<string> FullNameAndAge
        {
            get
            {
                return new List<string>()
                {
                    Name + " " + Surname.First().ToString() + ".",
                    "Age: " + Age.ToString() 
                };
            }
        }

        //For BulletList item ContactData in GridView
        public List<string> ContactData
        {
            get
            {
                return new List<string>()
                {
                    PhoneNumber,
                    Email
                };
            }
            
        }
        public int Age
        {
            get
            {
                return DateTime.Today.Year - Birthday.Year;
            }
            set
            {
                Age = value;
            }
            
        }

        //Hidden field in GridView
        public string AdvertisementId { get; set; }
        public string AdvertisementTitle { get; set; }
        public string AdvertisementCategory { get; set; }
        public string AdvertisementPhysicsArea { get; set; }
        public string AdvertisementContent { get; set; }
        

    }
}