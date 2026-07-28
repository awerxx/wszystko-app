namespace Carrington.Blake.Models;

public enum AccountType
{
    Checking,
    Savings,
    Credit
}

public class Account
{
    public Guid Id { get; set; }
    public required string AccountNumber { get; set; }
    public required string OwnerName { get; set; }
    public AccountType Type { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; } = "USD";
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; } = true;
}
