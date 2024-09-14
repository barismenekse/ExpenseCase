using AutoMapper;
using ExpenseCase.Common.Dto;
using ExpenseCase.DataAccess.Entities;

namespace ExpenseCase.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        AllowNullCollections = true;
        AllowNullDestinationValues = true;
        CreateMap<RegisterRequestDto, User>().ReverseMap();
        CreateMap<CreateAccountDto, Account>().ReverseMap();
        CreateMap<Account, AccountDto>().PreserveReferences().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<AddTransactionDto, Transaction>().ReverseMap();
        CreateMap<Transaction, TransactionDto>()
            .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account))
            .ForPath(dest => dest.Account.Transactions, opt => opt.Ignore())
            .PreserveReferences()
            .ReverseMap();
    }
}