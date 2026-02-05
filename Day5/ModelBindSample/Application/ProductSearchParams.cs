namespace ModelBindSample.Application;

public class ProductSearchParams
{

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string Category { get; set; }
    public string SearchTerm { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public bool? InStock { get; set; }
}