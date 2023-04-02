namespace backend.DTOs;
public class FilterDTO
{

 public int Page { get; set; } = 1;
 public int PageSize { get; set; } = 4;

 public double? MinPrice { get; set; }
 public double? MaxPrice { get; set; }

 public string? Category { get; set; }
 public string? SearchKeyWord { get; set; }
 public string Sort { get; set; } = string.Empty;
 public string Search { get; set; } = string.Empty;
 public SortBy SortBy { get; set; }
 public int Limit { get; set; } = 3;
 public int Skip { get; set; } = 0;

}









public enum SortBy
{
 ASC,
 DESC
}


/* public int Page { get; set; } = 1;
 private int recordsPerPage = 10;
 private readonly int maxRecordsPerPage=50;

 public int RecordsPerPage
 {
   get
   {
   return recordsPerPage;
  }
  set{
   recordsPerPage = (value > maxRecordsPerPage) ? maxRecordsPerPage : value;
  }
 }*/