using backend.Models;
using backend.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using backend.Common;

namespace backend.Services;
public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly ImageService _imageService;

    public UserService(ImageService imageService, ITokenService tokenService, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _imageService = imageService;
    }

    public async Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            throw ServiceException.Unauthorized("Email is not valid,Authentication failed");
        }
        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw ServiceException.Unauthorized("Password is not valid");
        }

        return await _tokenService.GenerateTokenAsync(user);
    }

    public async Task<User?> SignUpAsync(UserSignUpDTO request)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Email,
            Email = request.Email
        };
        if (request.File != null)
        {
            var imageResult = await _imageService.AddImageAsync(request.File);
            user.PictureUrl = imageResult.SecureUrl.ToString();
            user.PublicId = imageResult.PublicId;
        }
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).FirstOrDefault();

            throw ServiceException.BadRequest(errors);
        }

        var roleExists = await _roleManager.RoleExistsAsync("User");
        if (!roleExists)
        {
            var createResult = await _roleManager.CreateAsync(new IdentityRole<int>("User"));
            if (!createResult.Succeeded)
            {
                var errors = createResult.Errors;
                return null;
            }
        }
        var addRoleResult = await _userManager.AddToRoleAsync(user, "User");
        if (!addRoleResult.Succeeded)
        {
            var errors = addRoleResult.Errors;
            return null;
        }
        return user;
    }
}