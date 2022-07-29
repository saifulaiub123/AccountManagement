using AutoMapper;
using Account.Application.Model;
using Account.Application.Features.AccountActivity.Commands.Withdraw;

namespace Account.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<A, OrderVm>().ReverseMap();
            CreateMap<DepositCommand, Amount>().ReverseMap();
            CreateMap<WithdrawCommand, Amount>().ReverseMap();
            //CreateMap<UpdateOrderCommand, AccountActivity>().ReverseMap();
        }
    }
}
