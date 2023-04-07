namespace backend.DTOs;
public class GetAllResultDTO<TModel>
{
 public ICollection<TModel> Result { get; set; } = null!;
 public int ItemLength { get; set; }
}