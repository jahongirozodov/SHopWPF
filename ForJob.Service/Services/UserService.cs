using AutoMapper;
using ForJob.Domain.Users;
using ForJob.Service.DTOs.Users;
using ForJob.Service.Exceptions;
using ForJob.Service.Helpers;
using ForJob.Service.Interfaces;
using FotJob.Data.Repository;

namespace ForJob.Service.Services;

public class UserService : IUserService
{
    private readonly Repository<User> repository;
    private readonly IMapper mapper;
    public UserService()
    {
        this.repository = new Repository<User>();
        this.mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async Task<UserResultDto> RegisterAsync(UserRegisterDto dto)
    {
        var existUser = await repository.GetAsync(x=> x.Username.Equals(dto.Username));
        if(existUser is not null)
            throw new AlreadyExistException("This user is already exist!");

        var mappedUser = mapper.Map<User>(dto);
        var hashSalt = PasswordHash.Hash(dto.Password);
        mappedUser.Salt = hashSalt.Salt;
        mappedUser.Password = hashSalt.PasswordHash;
        
        await repository.AddAsync(mappedUser);
        await repository.SaveAsync();

        return mapper.Map<UserResultDto>(mappedUser);
    }

    public async Task<UserResultDto> LoginAsync(UserLoginDto dto)
    {
        var user = await repository.GetAsync(x=> x.Username.Equals(dto.UserName));
        if(user is null)
            throw new NotFoundException("This user is not found!");

        var IsValid = PasswordHash.Verify(user.Password,user.Salt,dto.Password);
        if (IsValid is false)
            throw new PasswordDoesNotMatchException("Password is does not match!");

        return mapper.Map<UserResultDto>(user);
    }
}
