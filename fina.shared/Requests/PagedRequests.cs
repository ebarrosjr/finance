namespace fina.shared.Requests;

public abstract class PagedRequests : Request
{
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber;

}
