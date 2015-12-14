using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Mvc.Boilerplate.Entities;
using Mvc.Boilerplate.Web.Infrastructure.Mapping;

namespace Mvc.Boilerplate.Web.ViewModels
{
    public class HelloCustomInfoViewModel : IMapSourceCustomMapping
    {
        public int Id { get; set; }
        public string Description { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<HomeInfo, HelloCustomInfoViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(o => o.HomeInfoId));

        }
    }
}