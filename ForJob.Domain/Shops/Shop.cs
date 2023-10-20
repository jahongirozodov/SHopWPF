using ForJob.Domain.Common;
using ForJob.Domain.Users;

namespace ForJob.Domain.Shops;

public class Shop : Auditable
{
    public string Name {get;set;}
    public string Description {get;set;}

    public long UserId {get;set; }
    public User User { get;set;}
}
