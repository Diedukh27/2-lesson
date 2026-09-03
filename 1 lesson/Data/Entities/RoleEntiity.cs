using Microsoft.AspNetCore.Identity;

namespace _1_lesson.Data.Entites.Identity;

public class RoleEntity : IdentityRole<int>
{
    public ICollection<UserRoleEntity>? UserRoles { get; set; }
}
