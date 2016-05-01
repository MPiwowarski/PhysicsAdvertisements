using AutoMapper;
using PhysicsAdvertisements.Model;
using PhysicsAdvertisements.WebForms.Web.ViewModels.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//na podstawie: http://stackoverflow.com/questions/6825244/where-to-place-automapper-createmaps
namespace PhysicsAdvertisements.WebForms.Web.App_Start
{
    public class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            ConfigureRegisterMapping();
        }


        private static void ConfigureRegisterMapping()
        {
            Mapper.CreateMap<RegisterVM, User>();
            

        }


    }
}