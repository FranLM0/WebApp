using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarniceriaWebApp.Data.Entities;
using CarniceriaWebApp.ViewModels;

namespace CarniceriaWebApp.Data
{
    public class CarniceriaMappingProfile : Profile
    {
        public CarniceriaMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
              .ForMember(o => o.OrderId, ex => ex.MapFrom(i => i.Id))
              .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
              .ReverseMap()
              .ForMember(m => m.Product, opt => opt.Ignore());
        }
    }
}
