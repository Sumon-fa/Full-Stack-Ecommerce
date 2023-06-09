using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;
public class UserSignUpDTO
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    [EmailAddress]
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public IFormFile File { get; set; } = null!;
}