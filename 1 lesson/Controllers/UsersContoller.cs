using _1_lesson.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UsersController(AppQrDbContext appQrDbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await appQrDbContext.Users
            .Select(x => new UserItemModel
            {
                Id = x.Id,
                FullName = $"{x.LastName} {x.FirstName}",
                Email = x.Email,
                Image = x.Image
            }).ToListAsync();

        return Ok(users);
    }
}