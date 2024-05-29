namespace fina.shared.Requests.Transactions;

public class GetTransactionsByPeriodRequest  : PagedRequests
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set;}

}
