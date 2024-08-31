using CleanArchitecture.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;
public sealed class UserRole : Entity
{
    [ForeignKey("AppUser")]
    public string AppUserId { get; set; } = default!;
    public AppUser AppUser { get; set; } = default!;
    [ForeignKey("Role")]
    public string RoleId { get; set; } = default!;
    public Role Role { get; set; } = default!;
}
