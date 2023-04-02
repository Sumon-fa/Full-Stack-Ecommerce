namespace backend.Services;

using backend.Models;
using backend.DTOs;

public interface IUserService
{
 Task<User?> SignUpAsync(UserSignUpDTO request);
 Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request);
}
