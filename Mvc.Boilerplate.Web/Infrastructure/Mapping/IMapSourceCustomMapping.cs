using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Mvc.Boilerplate.Web.Infrastructure.Mapping
{
    public interface IMapSourceCustomMapping
    {
        void CreateMappings(IConfiguration configuration);
    }
}
