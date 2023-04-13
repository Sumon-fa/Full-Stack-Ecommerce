using backend.Models;
using backend.DTOs;

namespace backend.Services;
public interface IUserService
{
    Task<User?> SignUpAsync(UserSignUpDTO request);
    Task<UserSignInResponseDTO?> SignInAsync(UserSignInDTO request);
}
