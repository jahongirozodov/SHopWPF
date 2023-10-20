using ForJob.Domain.Common;

namespace ForJob.Domain.Users;

public class User : Auditable
{
    public string Username { get;set; }
    public string Firstname {get;set; }
    public string Lastname { get;set; }
    public string Password { get;set; }
    public string Salt {get;set; }
}
