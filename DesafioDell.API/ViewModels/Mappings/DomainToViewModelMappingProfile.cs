using AutoMapper;
using DesafioDell.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioDell.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Customer, CustomerViewModel>();
        }
    }
}
