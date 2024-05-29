namespace fina.shared.Requests.Categories;

public class GetTransactionsByPeriodRequest  : PagedRequests
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set;}

}
