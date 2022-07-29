using AutoMapper;
using Account.Application.Model;
using Account.Application.Features.AccountActivity.Commands.Withdraw;
using Account.Domain.Entities;
using Account.Application.Features.AccountActivity.Queries.GetStatement;

namespace Account.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DepositCommand, Amount>().ReverseMap();
            CreateMap<WithdrawCommand, Amount>().ReverseMap();
            CreateMap<StatementVm, AccountActivity>().ReverseMap();
        }
    }
}
