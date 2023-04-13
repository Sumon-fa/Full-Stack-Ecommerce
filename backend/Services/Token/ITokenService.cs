namespace backend.Services;
using backend.DTOs;
using backend.Models;

public interface ITokenService
{
    Task<UserSignInResponseDTO> GenerateTokenAsync(User user);
}