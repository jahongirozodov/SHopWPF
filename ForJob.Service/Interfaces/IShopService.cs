using ForJob.Service.DTOs.Shops;

namespace ForJob.Service.Interfaces;

public interface IShopService
{
    Task<ShopResultDto> CreateAsync(ShopCreationDto dto);
    Task<ShopResultDto> UpdateAsync(ShopUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<ShopResultDto> GetByIdAsync(long id);
    IEnumerable<ShopResultDto> GetAll();
}
