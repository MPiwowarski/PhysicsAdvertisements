using AutoMapper;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.WebForms.Web.ViewModels.AccountViewModels;
using PhysicsAdvertisements.WebForms.Web.ViewModels.AdvertisementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//made on basics of this: http://stackoverflow.com/questions/6825244/where-to-place-automapper-createmaps
namespace PhysicsAdvertisements.WebForms.Web.App_Start
{
    public class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureRegisterMapping();
            ConfigureUserDataMapping();
        }


        private static void ConfigureRegisterMapping()
        {
            Mapper.CreateMap<RegisterVM, User>();            
        }

        private static void ConfigureUserDataMapping()
        {
            Mapper.CreateMap<UserDataVM, User>();
        }
    }
}