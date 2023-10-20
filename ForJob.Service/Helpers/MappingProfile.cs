using AutoMapper;
using ForJob.Domain.Shops;
using ForJob.Domain.Users;
using ForJob.Service.DTOs.Shops;
using ForJob.Service.DTOs.Users;

namespace ForJob.Service.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Users
        CreateMap<UserRegisterDto, User>().ReverseMap();
        CreateMap<UserLoginDto, User>().ReverseMap();
        CreateMap<UserResultDto, User>().ReverseMap();
        
        //Shops
        CreateMap<Shop,ShopCreationDto>().ReverseMap();
        CreateMap<Shop,ShopUpdateDto>().ReverseMap();
        CreateMap<Shop,ShopResultDto>().ReverseMap();
        
    }
}
