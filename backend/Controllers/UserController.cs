namespace backend.Controllers;

using backend.Services;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UserController : ApiControllerBase
{
 private readonly IUserService _service;
 private readonly UserManager<User> _userManager;
 private readonly ILogger<UserController> _logger;

 public UserController(IUserService service, UserManager<User> userManager, ILogger<UserController> logger)
 {
  _service = service;
  _userManager = userManager;
  _logger = logger;
 }

 [HttpPost("signup")]
 [Consumes("multipart/form-data")]
 public async Task<IActionResult> SignUp([FromForm] UserSignUpDTO request)
 {

  var user = await _service.SignUpAsync(request);



  return Ok(user);
 }



 [HttpPost("signin")]
 public async Task<IActionResult> SignIn(UserSignInDTO request)
 {
  var response = await _service.SignInAsync(request);
  if (response is null)
  {
   return Unauthorized();
  }
  return Ok(response);
 }

 [Authorize]
 [HttpGet("profile")]
 public async Task<IActionResult> GetCurrentUser()
 {
  var user = await _userManager.GetUserAsync(User);
  var roles = await _userManager.GetRolesAsync(user);

  var response = new UserProfileResponseDTO
  {
   Roles = roles,
   FirstName = user.FirstName,
   LastName = user.LastName,
   UserName = user.Email,
   Email = user.Email,
   Id = user.Id,
   PictureUrl = user.PictureUrl,
   PublicId = user.PublicId
  };

  return Ok(response);
 }

 [Authorize]
 [HttpGet]
 public async Task<IActionResult> GetAllAsync()
 {
  var users = await _userManager.Users.AsNoTracking().ToListAsync();

  return Ok(users);
 }
}
