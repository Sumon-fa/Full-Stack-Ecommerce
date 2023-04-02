namespace backend.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class User : IdentityUser<int>
{
 [MaxLength(256)]
 public string FirstName { get; set; } = null!;
 [MaxLength(256)]
 public string LastName { get; set; } = null!;
 public string PictureUrl { get; set; } = null!;
 public string PublicId { get; set; } = null!;
}