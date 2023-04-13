namespace backend.Models;

public class Product : BaseModel
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
    public string PictureUrl { get; set; } = null!;
    public string PublicId { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public Guid CategoryId { get; set; }

}
