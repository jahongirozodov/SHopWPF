using AutoMapper;
using ForJob.Domain.Shops;
using ForJob.Service.DTOs.Shops;
using ForJob.Service.Exceptions;
using ForJob.Service.Helpers;
using ForJob.Service.Interfaces;
using FotJob.Data.Repository;

namespace ForJob.Service.Services;

public class ShopService : IShopService
{
    private readonly Repository<Shop> repository;
    private readonly IMapper mapper;
    public ShopService()
    {
        this.repository = new Repository<Shop>();
        this.mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()));
    }

    public async Task<ShopResultDto> CreateAsync(ShopCreationDto dto)
    {
        var mappedShop = mapper.Map<Shop>(dto);

        await repository.AddAsync(mappedShop);
        await repository.SaveAsync();

        return mapper.Map<ShopResultDto>(mappedShop);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var shop = await repository.GetAsync(x => x.Id.Equals(id))
            ?? throw new NotFoundException("Shop is not found!");
        repository.Delete(shop);
        await repository.SaveAsync();

        return true;
    }

    public IEnumerable<ShopResultDto> GetAll()
    {
        var shops = repository.GetAll();

        return mapper.Map<IEnumerable<ShopResultDto>>(shops);
    }

    public async Task<ShopResultDto> GetByIdAsync(long id)
    {
        var shop = await repository.GetAsync(x => x.Id.Equals(id))
            ?? throw new NotFoundException("Shop is not found!");

        return mapper.Map<ShopResultDto>(shop);
    }

    public async Task<ShopResultDto> UpdateAsync(ShopUpdateDto dto)
    {
        var shop = await repository.GetAsync(x => x.Id.Equals(dto.Id))
            ?? throw new NotFoundException("Shop is not found!");

        var mappedShop = mapper.Map(dto, shop);

        repository.Modify(mappedShop);
        await repository.SaveAsync();

        return mapper.Map<ShopResultDto>(mappedShop);
    }
}
