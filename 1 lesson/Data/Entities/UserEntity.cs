using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _1_lesson.Data.Entites.Identity;

public class UserEntity : IdentityUser<int>
{
    [StringLength(100)]
    public string? FirstName { get; set; }
    [StringLength(100)]
    public string? LastName { get; set; }
    [StringLength(100)]
    public string? Image { get; set; }
    public ICollection<UserRoleEntity>? UserRoles { get; set; }
}
