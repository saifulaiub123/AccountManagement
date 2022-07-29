using AutoMapper;
using Account.Application.Features.Orders.Commands.CheckOutOrder;
using Account.Application.Features.Orders.Commands.UpdateOrder;
using Account.Application.Features.Orders.Queries.GetOrderList;
using Account.Domain.Entities;

namespace Account.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountActivity, OrderVm>().ReverseMap();
            CreateMap<CheckOutOrderCommand, AccountActivity>().ReverseMap();
            CreateMap<UpdateOrderCommand, AccountActivity>().ReverseMap();
        }
    }
}
