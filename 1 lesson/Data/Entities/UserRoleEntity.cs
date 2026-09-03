using Microsoft.AspNetCore.Identity;

namespace _1_lesson.Data.Entites.Identity;

public class UserRoleEntity : IdentityUserRole<int>
{
    public UserEntity User { get; set; } = null!;
    public RoleEntity Role { get; set; } = null!;
}