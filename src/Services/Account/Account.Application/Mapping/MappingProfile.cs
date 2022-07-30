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
            CreateMap<AccountActivity, StatementVm>().ReverseMap();
            CreateMap<AccountActivity, Statement>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.TransactionAmount))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.CreatedDate));
                
        }
    }
}
