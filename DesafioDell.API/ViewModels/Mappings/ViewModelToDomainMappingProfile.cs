using AutoMapper;
using DesafioDell.Model;
using System.Collections.Generic;

namespace DesafioDell.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CustomerViewModel, Customer>();
        }
    }
}
