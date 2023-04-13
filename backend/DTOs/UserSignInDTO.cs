using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;
public class UserSignInDTO
{
    public string Password { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;
}
