namespace backend.Services;
using backend.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class JwtTokenService : ITokenService
{
 private readonly IConfiguration _config;
 private readonly UserManager<User> _userManager;
 public JwtTokenService(IConfiguration config, UserManager<User> userManager)
 {
  _config = config;
  _userManager = userManager;
 }
 public async Task<UserSignInResponseDTO> GenerateTokenAsync(User user)
 {
  //payload
  var claims = new List<Claim>
  {
   new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString()),
   new Claim (JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),
   new Claim(JwtRegisteredClaimNames.Email,user.Email),
   new Claim(JwtRegisteredClaimNames.Name,user.UserName)
};

  var roles = await _userManager.GetRolesAsync(user);

  foreach (var role in roles)
  {
   claims.Add(new Claim(ClaimTypes.Role, role));

  }

  //secret
  var secret = _config["Jwt:Secret"];
  byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(secret);


  var signInKey = new SigningCredentials(
                   new SymmetricSecurityKey(keyBytes),
                   SecurityAlgorithms.HmacSha256
                  );

  var expiration = DateTime.Now.AddHours(6);
  var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires: expiration, signingCredentials: signInKey);

  var tokenWriter = new JwtSecurityTokenHandler();
  var result = new UserSignInResponseDTO
  {
   Token = tokenWriter.WriteToken(token),
   Expiration = expiration,

  };
  return result;
 }
}