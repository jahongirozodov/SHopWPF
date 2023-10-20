using BCrypt.Net;

namespace ForJob.Service.Helpers;

public static class PasswordHash
{
    public static (string PasswordHash, string Salt) Hash(string password)
    {
        string salt = Guid.NewGuid().ToString();
        string hash = BCrypt.Net.BCrypt.HashPassword(password + salt);
        return (hash, salt);
    }
    public static bool Verify(string hash, string salt, string password)
        => BCrypt.Net.BCrypt.Verify(password + salt, hash);
}
