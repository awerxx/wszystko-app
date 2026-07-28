namespace Carrington.Blake.Admin.Models;

public class AccountDto
{
    public Guid Id { get; set; }
    public string AccountNumber { get; set; } = "";
    public string OwnerName { get; set; } = "";
    public string Type { get; set; } = "";
    public decimal Balance { get; set; }
    public string Currency { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}
