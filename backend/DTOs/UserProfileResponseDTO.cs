namespace backend.DTOs;


public class UserProfileResponseDTO
{
 public int Id { get; set; }
 public string FirstName { get; set; } = null!;
 public string LastName { get; set; } = null!;
 public string UserName { get; set; } = null!;

 public string Email { get; set; } = null!;

 public string PictureUrl { get; set; } = null!;
 public string PublicId { get; set; } = null!;
 public ICollection<string> Roles { get; set; } = null!;

}

