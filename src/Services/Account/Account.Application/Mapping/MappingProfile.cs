using AutoMapper;
using Account.Application.Features.Orders.Commands.CheckOutOrder;
using Account.Application.Model;

namespace Account.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<A, OrderVm>().ReverseMap();
            CreateMap<DepositCommand, Amount>().ReverseMap();
            //CreateMap<UpdateOrderCommand, AccountActivity>().ReverseMap();
        }
    }
}
