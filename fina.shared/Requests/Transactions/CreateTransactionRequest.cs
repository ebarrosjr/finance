using fina.shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace fina.shared.Requests.Transactions;

public class CreateTransactionRequest : Request
{
    [Required(ErrorMessage = "Título inválido")]
    public string Title { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "Valor inválido")]
    public decimal Amount { get; set; }
    
    [Required(ErrorMessage = "Tipo inválido")]
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;

    [Required(ErrorMessage = "Categoria inválida")]
    public long CategoryId { get; set; }

    [Required(ErrorMessage = "Data inválida")]
    public DateTime? PaidOrReceivedAt { get; set; }
}
