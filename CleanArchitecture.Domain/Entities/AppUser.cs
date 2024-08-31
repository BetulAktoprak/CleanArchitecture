using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Domain.Entities;
public sealed class AppUser : IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string FullName { get; set; } = default!;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime? RefreshTokenExpires { get; set; }
}
