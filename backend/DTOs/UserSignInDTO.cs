namespace backend.DTOs
{
 using System.ComponentModel.DataAnnotations;

 public class UserSignInDTO
 {
  public string Password { get; set; } = null!;

  [EmailAddress]
  public string Email { get; set; } = null!;
 }
}