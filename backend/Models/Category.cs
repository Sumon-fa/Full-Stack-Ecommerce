namespace backend.Models
{
 public class Category : BaseModel
 {
  public string Name { get; set; } = null!;
  public string PictureUrl { get; set; } = null!;
  public string PublicId { get; set; } = null!;

  public ICollection<Product> Products { get; set; } = null!;
 }
}