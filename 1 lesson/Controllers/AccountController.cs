using _1_lesson.Data.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebGenQRCode.Models.Account;

namespace WebGenQRCode.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController(IImageService imageService,
    UserManager<UserEntity> userManager) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromForm] RegisterModel model)
    {
        try
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
                throw new Exception("Дана пошта уже зареєстрована");
            user = new UserEntity
            {
                Email = model.Email,
                UserName = model.Email,
                LastName = model.LastName,
                FirstName = model.FirstName
            };
            if (model.ImageFile != null)
                user.Image = await imageService.SaveOptimizedImageAsync(model.ImageFile);
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var erors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new Exception(erors);
            }
            await userManager.AddToRoleAsync(user, Roles.User);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}