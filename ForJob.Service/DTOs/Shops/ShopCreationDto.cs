using ForJob.Domain.Users;

namespace ForJob.Service.DTOs.Shops;

public class ShopCreationDto
{
    public string Name {get;set;}
    public string Description {get;set;}
    public long UserId {get;set; }
}
