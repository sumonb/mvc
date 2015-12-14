using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Boilerplate.Web.Infrastructure.Mapping;

namespace Mvc.Boilerplate.Web.ViewModels
{
    public class HomeInfoViewModel : IMapSource<Mvc.Boilerplate.Entities.HomeInfo>
    {
        public int HomeInfoId { get; set; }
        public string Description { get; set; }
    }

    ////IQueryable
    //var example1 = ee.ProjectTo<HelloCustomInfoViewModel>();
    ////List
    //var example2 = Mapper.Map<List<HomeInfoViewModel>>(dt);

}